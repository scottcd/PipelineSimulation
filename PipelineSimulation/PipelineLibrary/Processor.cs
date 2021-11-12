using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class Processor {
        public List<IInstruction> InstructionMemory;
        public PipelineStage[] Pipeline { get; set; }
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
        public int ExecutionCyclesLeft { get; set; }
        public Dictionary<OpcodeEnum, int> ExecutionCycleDictionary { get; set; }
        public HazardDetection Hazards {get;set;}
        


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
                {RegisterEnum.r1, 0},
                {RegisterEnum.r2, 0},
                {RegisterEnum.r3, 0},
                {RegisterEnum.r4, 0},
                {RegisterEnum.r5, 0},
                {RegisterEnum.r6, 0},
                {RegisterEnum.r7, 1},
                {RegisterEnum.r8, 2},
                {RegisterEnum.r9, 3},
                {RegisterEnum.r10, 0},
                {RegisterEnum.r11, 0},
                {RegisterEnum.r12, 0},
                {RegisterEnum.r13, 0},
                {RegisterEnum.r14, 0},
                {RegisterEnum.r15, 0},
                {RegisterEnum.r16, 0},
                {RegisterEnum.r17, 0},
                {RegisterEnum.r18, 0},
                {RegisterEnum.r19, 0},
                {RegisterEnum.r20, 0},
                {RegisterEnum.r21, 0},
                {RegisterEnum.r22, 0},
                {RegisterEnum.r23, 0},
                {RegisterEnum.r24, 0},
                {RegisterEnum.r25, 0},
                {RegisterEnum.r26, 0},
                {RegisterEnum.r27, 0},
                {RegisterEnum.r28, 0},
                {RegisterEnum.r29, 0},
                {RegisterEnum.r30, 0},
                {RegisterEnum.r31, 0},
            };

            ExecutionCycleDictionary = new Dictionary<OpcodeEnum, int>() {
                {OpcodeEnum.add,1 },
                {OpcodeEnum.add_s,2 },
                {OpcodeEnum.beq,0},
                {OpcodeEnum.bne,0},
                {OpcodeEnum.div_s,10},
                {OpcodeEnum.lw,2},
                {OpcodeEnum.l_s,2},
                {OpcodeEnum.mul_s,5},
                {OpcodeEnum.sub,1},
                {OpcodeEnum.sub_s,2},
                {OpcodeEnum.sw,2},
                {OpcodeEnum.s_s,2 }
            };

            Hazards = new HazardDetection();
            
            CycleNumber = 0;
            ExecutionCyclesLeft = -1;
            MainMemory = new int[100000];
        }

        public int RunCycle() {
            Pipeline[4] = null;
            CycleNumber++;
            if (ExecutionCyclesLeft > 1) {
                Execute();
            }
            else if (Hazards.HazardStall.Item1 is true) {
                Hazard hazard = Hazards.HazardStall.Item2;
                
                // stall and either execute, mem, or regwrite
                switch (Hazards.HazardStall.Item2.Stage) {
                    case 2:
                        Execute();
                        break;
                    case 3:

                        if (hazard.ControlUnit.MemRead is true ||
                            hazard.ControlUnit.MemWrite is true) {
                            MemAccess();
                        }
                        else {
                            RegWrite();
                        }
                        break;
                    default:
                        RegWrite();
                        break;

                }
            }
            else {
                if (MEMREG_PipelineRegister.Instruction is null || PipelineFunctions.CheckRegWrite(MEMREG_PipelineRegister.ControlLogic) == false) {
                    Pipeline[4] = null;
                }
                else {
                    RegWrite();
                    MEMREG_PipelineRegister.FlushPipeline();
                }
                if (EXMEM_PipelineRegister.Instruction is null || PipelineFunctions.CheckMemAccess(EXMEM_PipelineRegister.ControlLogic) == false) {
                    Pipeline[3] = null;
                    MEMREG_PipelineRegister.FlushPipeline();
                }
                else {
                    MemAccess();
                }
                if (IDEX_PipelineRegister.Instruction is null) {
                    Pipeline[2] = null;
                    EXMEM_PipelineRegister.FlushPipeline();
                }
                else {
                    ExecutionCyclesLeft = -1;
                    Execute();
                }
                if (IFID_PipelineRegister.Instruction is null) {
                    Pipeline[1] = null;
                    IDEX_PipelineRegister.FlushPipeline();
                }
                else {
                    Decode();
                }
                Fetch();
                
            }
            
            System.Diagnostics.Debug.WriteLine($"{CycleNumber}");
            System.Diagnostics.Debug.WriteLine($"Fetch:    \t{Pipeline[0]}");
            System.Diagnostics.Debug.WriteLine($"Decode:   \t{Pipeline[1]}");
            System.Diagnostics.Debug.WriteLine($"Execute:  \t{Pipeline[2]}");
            System.Diagnostics.Debug.WriteLine($"MemAccess:\t{Pipeline[3]}");
            System.Diagnostics.Debug.WriteLine($"RegWrite: \t{Pipeline[4]}");
            System.Diagnostics.Debug.WriteLine("");

            if (ExecutionCyclesLeft == 0) {
                Hazards.IncrementStage();
            }
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
            // read pipeline register
            IInstruction instruction = IFID_PipelineRegister.Instruction;

            // put instruction in decode stage
            Pipeline[1] = new PipelineStage(instruction);

            // fill control unit - need to implement
            ControlSignal controlUnit = new ControlSignal(instruction.Opcode);

            IDEX_PipelineRegister.FillPipeline(instruction, controlUnit);

            Hazards.CheckForHazardMatch(instruction, controlUnit);
            Hazards.CheckToAddHazard(instruction, controlUnit);
        }

        // execute
        public void Execute() {
            if (ExecutionCyclesLeft == -1) {
                // read pipeline register
                IInstruction instruction = IDEX_PipelineRegister.Instruction;
                ControlSignal controlUnit = IDEX_PipelineRegister.ControlLogic;
                ExecutionCyclesLeft = ExecutionCycleDictionary[instruction.Opcode];

                int operand1, operand2;


                if (instruction is ITypeInstruction) {
                    ITypeInstruction i = (ITypeInstruction)instruction;
                    if (i.Opcode == OpcodeEnum.beq || i.Opcode == OpcodeEnum.bne) {
                        operand1 = Registers[i.SourceRegister1];
                        operand2 = Registers[i.DestinationRegister];
                    }
                    else if (i.Opcode == OpcodeEnum.lw || i.Opcode == OpcodeEnum.l_s) {
                        operand1 = Registers[i.DestinationRegister];
                        operand2 = i.Immediate;
                    }
                    else {
                        operand1 = Registers[i.DestinationRegister];
                        operand2 = i.Immediate;
                    }
                }
                else {
                    RTypeInstruction i = (RTypeInstruction)instruction;
                    operand1 = Registers[i.SourceRegister1];
                    operand2 = Registers[i.SourceRegister2];
                }
                
                // put instruction in execute stage
                Pipeline[2] = new PipelineStage(instruction);

                int valueToWrite = ExecutionALU.ExecuteOperation(controlUnit.ALUOp, operand1, operand2);

                if (controlUnit.Branch == false) {
                    MEMREG_PipelineRegister.FillPipeline(instruction, controlUnit, valueToWrite);
                    return;
                }
                else {
                    ITypeInstruction i = (ITypeInstruction)instruction;
                    if (instruction.Opcode == OpcodeEnum.beq) {
                        if (valueToWrite == 0) {
                            Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate);
                            return;
                        }
                    }
                    else if (instruction.Opcode == OpcodeEnum.bne) {
                        if (valueToWrite != 0) {
                            Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate);
                            return;
                        }
                    }
                }   
            }
            else if (ExecutionCyclesLeft > 0) {
                ExecutionCyclesLeft--;
                // STALL
            }
        }

        // memaccess
        public void MemAccess() {
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
                int readAddress = EXMEM_PipelineRegister.ValueToWrite;

                // read memory to valueToWrite
                int valueRead = MainMemory[readAddress];

                // write pipeline register
                MEMREG_PipelineRegister.FillPipeline(instruction, controlUnit, valueRead);
            }
            // store
            else if (controlUnit.MemWrite == true) {
                int writeAddress = EXMEM_PipelineRegister.ValueToWrite;
                // write to memory
                int valueToWrite = Registers[EXMEM_PipelineRegister.IType.SourceRegister1];
                
                MainMemory[writeAddress] = valueToWrite;
            }
        }

        // regwrite
        public void RegWrite() {
            // read pipeline register
            IInstruction instruction = MEMREG_PipelineRegister.Instruction;
            ControlSignal controlUnit = MEMREG_PipelineRegister.ControlLogic;

            // put instruction in regWrite stage
            Pipeline[4] = new PipelineStage(instruction);
            
            RegisterEnum destinationRegister = instruction.DestinationRegister;
            Registers[destinationRegister] = MEMREG_PipelineRegister.ValueToWrite;
            Hazards.CheckToRemoveHazard(instruction, controlUnit);
            MEMREG_PipelineRegister.FlushPipeline();
        }

        public override string ToString() {
            string output = $"MIPS Processor State\n";
            foreach (var register in Registers) {
                output += $"{register.Key}\t{register.Value}\n";
            }
            return output;
        }
    }
}
