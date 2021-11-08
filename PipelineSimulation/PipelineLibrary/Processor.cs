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
        public PipelineRegister[] PipelineRegisters { get; set; }
        
        public Dictionary<RegisterEnum, int> Registers { get; set; }
        public int CycleNumber { get; set; }
        // MUXs
        // ALUs
        // Main Memory

        public Processor() {
            Pipeline = new PipelineStage[5];
            PipelineRegisters = new PipelineRegister[4];
            Registers = new Dictionary<RegisterEnum, int>() {
                {RegisterEnum.r0, 0},
                {RegisterEnum.r1, 0},
                {RegisterEnum.r2, 0},
                {RegisterEnum.r3, 0},
                {RegisterEnum.r4, 0},
                {RegisterEnum.r5, 0},
                {RegisterEnum.r6, 0},
                {RegisterEnum.r7, 0},
                {RegisterEnum.r8, 0},
                {RegisterEnum.r9, 0},
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
            CycleNumber = 0;
        }

        public int RunCycle() {
            RegWrite();
            MemAccess();
            Execute();
            Decode();
            Fetch();

            CycleNumber++;

            System.Diagnostics.Debug.WriteLine($"{CycleNumber}");
            System.Diagnostics.Debug.WriteLine($"Fetch:\t{Pipeline[0]}");
            System.Diagnostics.Debug.WriteLine($"Decode:\t{Pipeline[1]}");
            System.Diagnostics.Debug.WriteLine($"Execute:\t{Pipeline[2]}");
            System.Diagnostics.Debug.WriteLine($"MemAccess:\t{Pipeline[3]}");
            System.Diagnostics.Debug.WriteLine($"RegWrite:\t{Pipeline[4]}");
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
                PipelineRegisters[0] = null;
                return;
            }
            else {
                // put instruction in fetch stage
                Pipeline[0] = new PipelineStage(instruction);

                // write pipeline register
                PipelineRegisters[0] = new PipelineRegister(instruction);
                Registers[RegisterEnum.r28] += 4; // this will get sent to the ALU
                return;
            }
        }

        // decode
        public void Decode() {
            if (PipelineRegisters[0] is null) {
                // flush stage && pipeline register
                Pipeline[1] = null;
                PipelineRegisters[1] = null;
                return;
            }
            // read pipeline register
            IInstruction instruction = PipelineRegisters[0].Instruction;

            // put instruction in decode stage
            Pipeline[1] = new PipelineStage(instruction);

            // fill control unit - need to implement
            ControlSignal controlUnit = new ControlSignal(instruction.Opcode);

            // get hazards -> need to implement

            // write pipeline register
            if (instruction is ITypeInstruction) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                int operand1 = Registers[i.SourceRegister1];
                int operand2 = i.Immediate;

                PipelineRegisters[1] = new PipelineRegister(instruction, controlUnit, operand1, operand2);
            }
            else {
                RTypeInstruction i = (RTypeInstruction)instruction;
                int operand1 = Registers[i.SourceRegister1];
                int operand2 = Registers[i.SourceRegister2];

                PipelineRegisters[1] = new PipelineRegister(instruction, controlUnit, operand1, operand2);
            }
        }

        // execute
        public void Execute() {
            if (PipelineRegisters[1] is null) {
                // flush stage && pipeline register
                Pipeline[2] = null;
                PipelineRegisters[2] = null;
                return;
            }
            // read pipeline register
            IInstruction instruction = PipelineRegisters[1].Instruction;
            ControlSignal controlUnit = PipelineRegisters[1].ControlLogic;

            // put instruction in execute stage
            Pipeline[2] = new PipelineStage(instruction);

            /*
             *  EXECUTE LOGIC HERE
             */

            // write pipeline register
            PipelineRegisters[2] = new PipelineRegister(instruction, controlUnit);
        }

        // memaccess
        public void MemAccess() {
            if (PipelineRegisters[2] is null || PipelineFunctions.CheckMemAccess(PipelineRegisters[2]) == false) {
                // flush stage && pipeline register
                Pipeline[3] = null;
                PipelineRegisters[3] = null;
                return;
            }
            // read pipeline register
            IInstruction instruction = PipelineRegisters[2].Instruction;
            ControlSignal controlUnit = PipelineRegisters[2].ControlLogic;

            if (controlUnit.RegWrite == true && controlUnit.MemRead == false) {
                PipelineRegisters[3] = new PipelineRegister(instruction, controlUnit, PipelineRegisters[2].ValueToWrite);
                return;
            }

            // put instruction in memAccess stage
            Pipeline[3] = new PipelineStage(instruction);

            // load
            if (controlUnit.MemRead == true) {
                // read memory to valueToWrite
                int valueToWrite = 0;

                // write pipeline register
                PipelineRegisters[3] = new PipelineRegister(instruction, controlUnit, valueToWrite);
            }
            // store
            else if (controlUnit.MemWrite == true) {
                // write to memory
            
                PipelineRegisters[3] = new PipelineRegister(instruction, controlUnit);
            }
            
        }

        // regwrite
        public void RegWrite() {
            if (PipelineRegisters[3] is null || PipelineFunctions.CheckRegWrite(PipelineRegisters[3]) == false) {
                // flush stage
                Pipeline[4] = null;
                return;
            }
            // read pipeline register
            IInstruction instruction = PipelineRegisters[3].Instruction;
            ControlSignal controlUnit = PipelineRegisters[3].ControlLogic;

            // put instruction in regWrite stage
            Pipeline[4] = new PipelineStage(instruction);
            
            RegisterEnum destinationRegister = instruction.DestinationRegister;
            Registers[destinationRegister] = PipelineRegisters[3].ValueToWrite;
        }
    }
}
