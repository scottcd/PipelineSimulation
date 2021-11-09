using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class Processor {
        public List<IInstruction> InstructionMemory;
        public PipelineStage [] Pipeline { get; set; }
        public InstructionPipelineRegister IFID_PipelineRegister { get; set; }
        public FullPipelineRegister IDEX_PipelineRegister { get; set; }
        public InstructionControlPipelineRegister EXMEM_PipelineRegister { get; set; }
        public ValuePipelineRegister MEMREG_PipelineRegister { get; set; }
        public AdderALU ProgramCounterALU { get; set; }
        public AdderALU BranchALU { get; set; }
        public FullALU ExecutionALU { get; set; }
        public Dictionary<RegisterEnum, int> Registers { get; set; }
        public int CycleNumber { get; set; }
        public int[] MainMemory { get; set; }

        public Processor() {
            Pipeline = new PipelineStage[5];
            
            IFID_PipelineRegister = new InstructionPipelineRegister();
            IDEX_PipelineRegister = new FullPipelineRegister();
            EXMEM_PipelineRegister = new InstructionControlPipelineRegister();
            MEMREG_PipelineRegister = new ValuePipelineRegister();

            ProgramCounterALU = new AdderALU();
            BranchALU = new AdderALU();
            ExecutionALU = new FullALU();

            Registers = new Dictionary<RegisterEnum, int>() {
                {RegisterEnum.r0, 0},
                {RegisterEnum.r1, 1},
                {RegisterEnum.r2, 1},
                {RegisterEnum.r3, 1},
                {RegisterEnum.r4, 1},
                {RegisterEnum.r5, 1},
                {RegisterEnum.r6, 1},
                {RegisterEnum.r7, 1},
                {RegisterEnum.r8, 1},
                {RegisterEnum.r9, 1},
                {RegisterEnum.r10, 1},
                {RegisterEnum.r11, 1},
                {RegisterEnum.r12, 1},
                {RegisterEnum.r13, 1},
                {RegisterEnum.r14, 1},
                {RegisterEnum.r15, 1},
                {RegisterEnum.r16, 1},
                {RegisterEnum.r17, 1},
                {RegisterEnum.r18, 1},
                {RegisterEnum.r19, 1},
                {RegisterEnum.r20, 1},
                {RegisterEnum.r21, 1},
                {RegisterEnum.r22, 1},
                {RegisterEnum.r23, 1},
                {RegisterEnum.r24, 1},
                {RegisterEnum.r25, 1},
                {RegisterEnum.r26, 1},
                {RegisterEnum.r27, 1},
                {RegisterEnum.r28, 0},
                {RegisterEnum.r29, 1},
                {RegisterEnum.r30, 1},
                {RegisterEnum.r31, 1},
            };
            CycleNumber = 0;

            MainMemory = new int[2^32];
        }

        public int RunCycle() {
            CycleNumber++;
            
            RegWrite();
            MemAccess();
            Execute();
            Decode();
            Fetch();

            System.Diagnostics.Debug.WriteLine($"{CycleNumber}");
            System.Diagnostics.Debug.WriteLine($"Fetch:    \t{Pipeline[0]}");
            System.Diagnostics.Debug.WriteLine($"Decode:   \t{Pipeline[1]}");
            System.Diagnostics.Debug.WriteLine($"Execute:  \t{Pipeline[2]}");
            System.Diagnostics.Debug.WriteLine($"MemAccess:\t{Pipeline[3]}");
            System.Diagnostics.Debug.WriteLine($"RegWrite: \t{Pipeline[4]}");
            System.Diagnostics.Debug.WriteLine("");


            return 0;
        }

        public string Compile(string[] instructions) {
            InstructionMemory = new List<IInstruction>();
            try {
                InstructionMemory = CompilerFunctions.Compile(instructions);
            }
            catch (Exception e ) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return "Invalid Syntax. Try again.\n";
            }

            return "Instruction Memory\n";
        }

        /// <summary>
        /// Gets the next instruction from memory, places that instruction in the fetch stage and first pipeline register
        /// </summary>
        /// <returns></returns>
        public void Fetch() {
            int programCounter;
            Registers.TryGetValue(RegisterEnum.r28, out programCounter);

            IInstruction instruction = PipelineFunctions.Fetch(programCounter, InstructionMemory);

            if (instruction is null) {
                // flush stage && pipeline register
                Pipeline[0] = null;
                IFID_PipelineRegister.FlushPipeline();
                return;
            }
            else {
                // put instruction in fetch stage
                Pipeline[0] = new PipelineStage(instruction);

                // write pipeline register
                IFID_PipelineRegister.FillPipeline(instruction);
                Registers[RegisterEnum.r28] = ProgramCounterALU.AddOperands(Registers[RegisterEnum.r28], 4); // this will get sent to the ALU
                return;
            }
        }

        // decode
        public void Decode() {
            if (IFID_PipelineRegister.Instruction is null) {
                // flush stage && pipeline register
                Pipeline[1] = null;
                IDEX_PipelineRegister.FlushPipeline();
                return;
            }
            // read pipeline register
            IInstruction instruction = IFID_PipelineRegister.Instruction;

            // put instruction in decode stage
            Pipeline[1] = new PipelineStage(instruction);

            // fill control unit - need to implement
            ControlSignal controlUnit = new ControlSignal(instruction.Opcode);

            // get hazards -> need to implement

            // write pipeline register
            if (instruction is ITypeInstruction) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                int operand1, operand2;

                if (i.Opcode == OpcodeEnum.beq || i.Opcode == OpcodeEnum.bne) {
                    operand1 = Registers[i.SourceRegister1];
                    operand2 = Registers[i.DestinationRegister];
                }
                else if (i.Opcode == OpcodeEnum.lw || i.Opcode == OpcodeEnum.l_s) {
                    operand1 = Registers[i.DestinationRegister];
                    operand2 = i.Immediate;
                }
                else{
                    operand1 = Registers[i.SourceRegister1];
                    operand2 = i.Immediate;
                }

                IDEX_PipelineRegister.FillPipeline(instruction, controlUnit, operand1, operand2);
            }
            else {
                RTypeInstruction i = (RTypeInstruction)instruction;
                int operand1 = Registers[i.SourceRegister1];
                int operand2 = Registers[i.SourceRegister2];

                IDEX_PipelineRegister.FillPipeline(instruction, controlUnit, operand1, operand2);
            }
        }

        // execute
        public void Execute() {
            if (IDEX_PipelineRegister.Instruction is null) {
                // flush stage && pipeline register
                Pipeline[2] = null;
                EXMEM_PipelineRegister.FlushPipeline();
                return;
            }
            // read pipeline register
            IInstruction instruction = IDEX_PipelineRegister.Instruction;
            ControlSignal controlUnit = IDEX_PipelineRegister.ControlLogic;

            // put instruction in execute stage
            Pipeline[2] = new PipelineStage(instruction);

            // need seperate logic for branch
            int valueToWrite = ExecutionALU.ExecuteOperation(controlUnit.ALUOp, IDEX_PipelineRegister.Operand1, IDEX_PipelineRegister.Operand2);

            if (controlUnit.Branch == false) {
                // write pipeline register
                EXMEM_PipelineRegister.FillPipeline(instruction, controlUnit, valueToWrite);
                return;
            }
            else{ 
                ITypeInstruction i = (ITypeInstruction)instruction;
                if (instruction.Opcode == OpcodeEnum.beq) {
                    if (valueToWrite == 0) {
                        Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate);
                    }
                }
                else if(instruction.Opcode == OpcodeEnum.bne) {
                    if (valueToWrite != 0) {
                        Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate);
                    }
                }
            }
        }

        // memaccess
        public void MemAccess() {
            if (EXMEM_PipelineRegister.Instruction is null || PipelineFunctions.CheckMemAccess(EXMEM_PipelineRegister.ControlLogic) == false) {
                // flush stage && pipeline register
                Pipeline[3] = null;
                MEMREG_PipelineRegister.FlushPipeline();
                return;
            }
            // read pipeline register
            IInstruction instruction = EXMEM_PipelineRegister.Instruction;
            ControlSignal controlUnit = EXMEM_PipelineRegister.ControlLogic;

            if (controlUnit.RegWrite == true && controlUnit.MemRead == false) {
                MEMREG_PipelineRegister.FillPipeline(instruction, controlUnit, EXMEM_PipelineRegister.ValueToWrite);
                return;
            }
            
            // put instruction in memAccess stage
            Pipeline[3] = new PipelineStage(instruction);

            // load
            if (controlUnit.MemRead == true) {
                int readAddress = MEMREG_PipelineRegister.ValueToWrite;

                // read memory to valueToWrite
                int valueToWrite = MainMemory[readAddress];

                // write pipeline register
                MEMREG_PipelineRegister.FillPipeline(instruction, controlUnit, valueToWrite);
            }
            // store
            else if (controlUnit.MemWrite == true) {
                int writeAddress = MEMREG_PipelineRegister.ValueToWrite;
                // write to memory
                int valueToWrite = Registers[EXMEM_PipelineRegister.IType.SourceRegister1];
                
                MainMemory[writeAddress] = valueToWrite;
            }
        }

        // regwrite
        public void RegWrite() {
            if (MEMREG_PipelineRegister.Instruction is null || PipelineFunctions.CheckRegWrite(MEMREG_PipelineRegister.ControlLogic) == false) {
                // flush stage
                Pipeline[4] = null;
                return;
            }
            // read pipeline register
            IInstruction instruction = MEMREG_PipelineRegister.Instruction;
            ControlSignal controlUnit = MEMREG_PipelineRegister.ControlLogic;

            // put instruction in regWrite stage
            Pipeline[4] = new PipelineStage(instruction);
            
            RegisterEnum destinationRegister = instruction.DestinationRegister;
            Registers[destinationRegister] = MEMREG_PipelineRegister.ValueToWrite;
        }
    }
}
