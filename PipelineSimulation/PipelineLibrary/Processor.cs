using PipelineLibrary.ProcessorModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class Processor {
        public List<IInstruction> InstructionMemory;
        public IPipelineStage[] Pipeline { get; set; }
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
        public int ClockSpeed { get; set; } = 1500;
        public (int, int) Operands { get; private set; }
        public int ValueToWrite { get; private set; }
        public IInstruction Instruction { get; private set; }
        public ControlSignal ControlUnit { get; private set; }
        public PipelineStatistics Statistics { get; set; }

        public Processor(int clockSpeed) {
            Pipeline = new IPipelineStage[5];
            ClockSpeed = clockSpeed;


            IFID_PipelineRegister = new InstructionPipelineRegister();
            IDEX_PipelineRegister = new FullPipelineRegister();
            EXMEM_PipelineRegister = new InstructionControlPipelineRegister();
            MEMREG_PipelineRegister = new ValuePipelineRegister();

            ProgramCounterALU = new AdderALU();
            BranchALU = new AdderALU();
            ExecutionALU = new FullALU();


            Statistics = new PipelineStatistics();
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
                {OpcodeEnum.beq,1},
                {OpcodeEnum.bne,1},
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
            

            CycleNumber++;
            Pipeline[3] = null;
            Pipeline[4] = null;
            if (ExecutionCyclesLeft > 0) {
                Execute();
                // finish stages with instructions -- memaccess & regwrite
                
            }
            else if (Hazards.HazardStall.Item1 is true) {
                Hazard hazard = Hazards.HazardStall.Item2;
                // stall and either execute, mem, or regwrite
                switch (Hazards.HazardStall.Item2.Stage) {
                    case 1:
                        
                        Execute();
                        break;
                    case 2:
                    case 3:
                        Pipeline[2] = null;
                        if (hazard.ControlUnit.MemRead is true ||
                            hazard.ControlUnit.MemWrite is true) {
                            MemAccess();
                        }
                        else {
                            RegWrite();
                        }
                        break;
                    default:
                        if (hazard.ControlUnit.RegWrite is true) {
                            RegWrite();
                        }
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
            if (ExecutionCyclesLeft == 0) {
                Hazards.IncrementStage();
                Pipeline[2] = null;
                Statistics.WriteStatistic(Instruction, 2, CycleNumber);
            }
            if (Pipeline.All((x) => x is null) && NullCheckPipelineRegisters() is true) {
                return -1;
            }

            return 0;
        }

        public bool NullCheckPipelineRegisters() {
            if (IFID_PipelineRegister.Instruction is null &&
                IDEX_PipelineRegister.Instruction is null &&
                EXMEM_PipelineRegister.Instruction is null &&
                MEMREG_PipelineRegister.Instruction is null ) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compile the given instructions usint CompilerFunctions.cs
        /// </summary>
        /// <param name="instructions">instructions to compile</param>
        /// <returns>Display to the user</returns>
        public string Compile(string[] instructions) {
            InstructionMemory = new List<IInstruction>();
            try {
                InstructionMemory = CompilerFunctions.Compile(instructions);
            }
            catch (Exception e ) {
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
                Pipeline[0] = new BasePipelineStage(instruction);

                // write pipeline register
                IFID_PipelineRegister.FillPipeline(instruction);
                Registers[RegisterEnum.r28] = ProgramCounterALU.AddOperands(Registers[RegisterEnum.r28], 4); // this will get sent to the ALU
                Statistics.AddStatistic(instruction, CycleNumber);
                return;
            }
        }

        public void Decode() {
            // read pipeline register
            IInstruction instruction = IFID_PipelineRegister.Instruction;

            // put instruction in decode stage
            Pipeline[1] = new BasePipelineStage(instruction);

            // fill control unit - need to implement
            ControlSignal controlUnit = new ControlSignal(instruction.Opcode);

            IDEX_PipelineRegister.FillPipeline(instruction, controlUnit);
            
            Statistics.WriteStatistic(instruction, 1, CycleNumber);
            
            Hazards.CheckForHazardMatch(instruction, controlUnit);
            Hazards.CheckToAddHazard(instruction, controlUnit);
        }

        // execute
        public void Execute() {
            if (ExecutionCyclesLeft > 0) {
                ExecutionCyclesLeft--;

                WritePipeline();
                
                return;
            }


            // read pipeline register
            Instruction = IDEX_PipelineRegister.Instruction; 
            ControlUnit = IDEX_PipelineRegister.ControlLogic;
            ExecutionCyclesLeft = ExecutionCycleDictionary[Instruction.Opcode] - 1;

            // put instruction in execute stage
            Operands = PipelineFunctions.GetOperands(Instruction, Registers);
            Pipeline[2] = new ExecutePipelineStage(Instruction, Operands.Item1, Operands.Item2, ControlUnit.ALUOp);
            ValueToWrite = ExecutionALU.ExecuteOperation(ControlUnit.ALUOp, Operands.Item1, Operands.Item2);

            WritePipeline();

            if (ControlUnit.Branch == true) {
                ITypeInstruction i = (ITypeInstruction)Instruction;
                if (Instruction.Opcode == OpcodeEnum.beq) {
                    if (ValueToWrite == 0) {
                        Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate) - 8;
                        Pipeline[1] = null;
                        IFID_PipelineRegister.FlushPipeline();
                    }
                }
                else if (Instruction.Opcode == OpcodeEnum.bne) {
                    if (ValueToWrite != 0) {
                        Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate) - 8;
                        Pipeline[1] = null;
                        IFID_PipelineRegister.FlushPipeline();
                    }
                }
            }   
        }

        private void WritePipeline() {
            if (ExecutionCyclesLeft == 0) {
                if (Instruction is RTypeInstruction) {
                    MEMREG_PipelineRegister.FillPipeline(Instruction, ControlUnit, ValueToWrite);
                }
                else if (ExecutionCyclesLeft == 0) {
                    EXMEM_PipelineRegister.FillPipeline(Instruction, ControlUnit, ValueToWrite);
                }
            }
        }

        // memaccess
        public void MemAccess() {
            // read pipeline register
            IInstruction instruction = EXMEM_PipelineRegister.Instruction;
            ControlSignal controlUnit = EXMEM_PipelineRegister.ControlLogic;
            

            if (controlUnit.RegWrite == true && controlUnit.MemRead == false) {
                MEMREG_PipelineRegister.FillPipeline(instruction, controlUnit, EXMEM_PipelineRegister.ValueToWrite);
                Statistics.WriteStatistic(instruction, 3, CycleNumber);
                return;
            }
            
            // put instruction in memAccess stage
            

            // load
            if (controlUnit.MemRead == true) {
                int readAddress = EXMEM_PipelineRegister.ValueToWrite;

                // read memory to valueToWrite
                int valueRead = MainMemory[readAddress];

                // write pipeline register
                MEMREG_PipelineRegister.FillPipeline(instruction, controlUnit, valueRead);
                Pipeline[3] = new MemoryPipelineStage(instruction, readAddress, valueRead);
            }
            // store
            else if (controlUnit.MemWrite == true) {
                
                int writeAddress = EXMEM_PipelineRegister.ValueToWrite;
                // write to memory
                int valueToWrite = Registers[EXMEM_PipelineRegister.IType.SourceRegister1];
                Pipeline[3] = new MemoryPipelineStage(instruction, writeAddress, valueToWrite);
                MainMemory[writeAddress] = valueToWrite;
                Hazards.CheckToRemoveHazard(instruction, controlUnit);
            }
            Statistics.WriteStatistic(instruction, 3, CycleNumber);
            EXMEM_PipelineRegister.FlushPipeline();
        }

        // regwrite
        public void RegWrite() {
            // read pipeline register
            IInstruction instruction = MEMREG_PipelineRegister.Instruction;
            ControlSignal controlUnit = MEMREG_PipelineRegister.ControlLogic;

            // put instruction in regWrite stage
            
            
            RegisterEnum destinationRegister = instruction.DestinationRegister;
            Registers[destinationRegister] = MEMREG_PipelineRegister.ValueToWrite;

            Pipeline[4] = new RegisterPipelineStage(instruction, destinationRegister, MEMREG_PipelineRegister.ValueToWrite);
            Statistics.WriteStatistic(instruction, 4, CycleNumber);
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
