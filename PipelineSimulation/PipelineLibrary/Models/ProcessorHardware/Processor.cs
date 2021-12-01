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
        public IPipelineRegister[] PipelineRegisters { get; set; }

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
        public FinalStatistics FinalStatistics { get; set; }

        public Processor(int clockSpeed) {
            Pipeline = new IPipelineStage[5];
            PipelineRegisters = new IPipelineRegister[4] { 
                new InstructionPipelineRegister(), 
                new ValuePipelineRegister(), 
                new FullPipelineRegister(),
                new FullPipelineRegister() 
            };
            ClockSpeed = clockSpeed;
            
            ProgramCounterALU = new AdderALU();
            BranchALU = new AdderALU();
            ExecutionALU = new FullALU();

            Statistics = new PipelineStatistics();
            FinalStatistics = new FinalStatistics();
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
                IHazard hazard = Hazards.HazardStall.Item2;
                FinalStatistics.hazardsHit++;
                // stall and either execute, mem, or regwrite
                switch (Hazards.HazardStall.Item2.Stage) {
                    case 1:
                        Execute();
                        break;
                    case 2:
                    case 3:
                    case 4:
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
                FullPipelineRegister memReg = (FullPipelineRegister)PipelineRegisters[3];
                if (memReg.Instruction is null || PipelineFunctions.CheckRegWrite(memReg.ControlLogic) == false) {
                    Pipeline[4] = null;
                }
                else {
                    RegWrite();
                    memReg.FlushPipeline();
                }
                FullPipelineRegister exMem = (FullPipelineRegister)PipelineRegisters[2];
                if (exMem.Instruction is null || PipelineFunctions.CheckMemAccess(exMem.ControlLogic) == false) {
                    Pipeline[3] = null;
                    memReg.FlushPipeline();
                }
                else {
                    MemAccess();
                }
                ValuePipelineRegister idEx = (ValuePipelineRegister)PipelineRegisters[1];
                if (idEx.Instruction is null) {
                    Pipeline[2] = null;
                    exMem.FlushPipeline();
                }
                else {
                   Execute();
                }
                InstructionPipelineRegister ifId = (InstructionPipelineRegister)PipelineRegisters[0];
                if (ifId.Instruction is null) {
                    Pipeline[1] = null;
                    idEx.FlushPipeline();
                }
                else {
                    Decode();
                }
                Fetch();
                
            }
            if (ExecutionCyclesLeft == 0) {
                Hazards.IncrementStage();
                Statistics.WriteStatistic(Instruction, 2, CycleNumber);
                
            }
            if (Pipeline.All((x) => x is null) && PipelineFunctions.NullCheckPipelineRegisters(this) is true) {
                FinalStatistics.cycles = CycleNumber;
                return -1;
            }

            return 0;
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
                FinalStatistics.instructionCount = InstructionMemory.Count;
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
            Registers.TryGetValue(RegisterEnum.r28, out int programCounter);

            IInstruction instruction = PipelineFunctions.Fetch(programCounter, InstructionMemory);
            InstructionPipelineRegister reg = (InstructionPipelineRegister)PipelineRegisters[0];

            if (instruction is null) {
                // flush stage && pipeline register
                Pipeline[0] = null;
                reg.FlushPipeline();
            }
            else {
                // put instruction in fetch stage
                Pipeline[0] = new BasePipelineStage(instruction);


                
                // write pipeline register
                reg.FillPipeline(instruction);
                Registers[RegisterEnum.r28] = ProgramCounterALU.AddOperands(Registers[RegisterEnum.r28], 4); 
                Statistics.AddStatistic(instruction, CycleNumber);
            }
        }

        public void Decode() {
            // read pipeline register
            
            IInstruction instruction = PipelineRegisters[0].Instruction;

            // put instruction in decode stage
            Pipeline[1] = new BasePipelineStage(instruction);

            // fill control unit - need to implement
            ControlSignal controlUnit = new ControlSignal(instruction.Opcode);
            ValuePipelineRegister reg = (ValuePipelineRegister)PipelineRegisters[1];
            reg.FillPipeline(instruction, controlUnit, 0);
            
            Statistics.WriteStatistic(instruction, 1, CycleNumber);
            Hazards.CheckForDataHazardMatch(instruction, controlUnit);
            Hazards.CheckForMemoryHazardMatch(instruction, controlUnit, this);
            Hazards.CheckToAddHazards(instruction, controlUnit, this);
        }

        // execute
        public void Execute() {
            if (ExecutionCyclesLeft > 0) {
                ExecutionCyclesLeft--;
                PipelineFunctions.WritePipeline(this);
                return;
            }
            ValuePipelineRegister reg = (ValuePipelineRegister)PipelineRegisters[1];
            // read pipeline register
            Instruction = reg.Instruction; 
            ControlUnit = reg.ControlLogic;
            ExecutionCyclesLeft = ExecutionCycleDictionary[Instruction.Opcode] - 1;

            // put instruction in execute stage
            Operands = PipelineFunctions.GetOperands(Instruction, Registers);
            Pipeline[2] = new ExecutePipelineStage(Instruction, Operands.Item1, Operands.Item2, ControlUnit.ALUOp);
            ValueToWrite = ExecutionALU.ExecuteOperation(ControlUnit.ALUOp, Operands.Item1, Operands.Item2);

            PipelineFunctions.WritePipeline(this);

            if (ControlUnit.Branch == true) {
                ITypeInstruction i = (ITypeInstruction)Instruction;
                if (Instruction.Opcode == OpcodeEnum.beq) {
                    if (ValueToWrite == 0) {
                        Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate) - 8;
                        Pipeline[1] = null;
                        PipelineRegisters[0].FlushPipeline();
                        PipelineRegisters[1].FlushPipeline();
                    }
                }
                else if (Instruction.Opcode == OpcodeEnum.bne) {
                    if (ValueToWrite != 0) {
                        Registers[RegisterEnum.r28] = BranchALU.AddOperands(Registers[RegisterEnum.r28], i.Immediate) - 8;
                        Pipeline[1] = null;
                        PipelineRegisters[0].FlushPipeline();
                        PipelineRegisters[1].FlushPipeline();
                    }
                }
            }   
        }

        
        // memaccess
        public void MemAccess() {
            // read pipeline register
            FullPipelineRegister reg = (FullPipelineRegister)PipelineRegisters[2];
            IInstruction instruction = reg.Instruction;
            ControlSignal controlUnit = reg.ControlLogic;

            FinalStatistics.memAccess++;

            if (controlUnit.RegWrite == true && controlUnit.MemRead == false) {
                FullPipelineRegister mem = (FullPipelineRegister)PipelineRegisters[3];
                mem.FillPipeline(instruction, controlUnit, reg.ValueToWrite);
                Statistics.WriteStatistic(instruction, 3, CycleNumber);
                return;
            }

            PipelineFunctions.MemoryTouch(instruction, controlUnit, this);
            Statistics.WriteStatistic(instruction, 3, CycleNumber);
            reg.FlushPipeline();
        }

        
        // regwrite
        public void RegWrite() {
            // read pipeline register
            FullPipelineRegister reg = (FullPipelineRegister)PipelineRegisters[3];
            IInstruction instruction = reg.Instruction;
            ControlSignal controlUnit = reg.ControlLogic;

            RegisterEnum destinationRegister = instruction.DestinationRegister;
            Registers[destinationRegister] = reg.ValueToWrite;

            Pipeline[4] = new RegisterPipelineStage(instruction, destinationRegister, reg.ValueToWrite);
            Statistics.WriteStatistic(instruction, 4, CycleNumber);
            Hazards.CheckToRemoveHazard(instruction, controlUnit, this);
            reg.FlushPipeline();

            FinalStatistics.registersHit++;
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