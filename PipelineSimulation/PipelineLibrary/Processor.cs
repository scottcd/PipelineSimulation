using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class Processor {
        public List<IInstruction> InstructionMemory;
        public IInstruction [] Pipeline { get; set; }
        public ControlSignal [] ControlUnit { get; set; }
        
        /*
                still need 4 pipeline registers to pass data in between stages of the pipeline
                0:  fetched instruction
                1:  decoded instruction values + logic
                2:
                3:
         */

        // ALUs
        public Dictionary<RegisterEnum, int> Registers { get; set; }
        // MUXs
        // ALUs

        public Processor() {
            Pipeline = new IInstruction[5];
            InstructionMemory = new List<IInstruction>();
            ControlUnit = new ControlSignal[3];             // need control signal for execute, memory access, and register write stages.
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
        }

        public int RunCycle() {
            RegWrite();
            MemAccess();
            Execute();
            Decode();
            int doneYet = Fetch();
            if (doneYet == -1) { // if there are no more instructions
                return -1;
            }
            else {              // else, return normally
                foreach (var item in Pipeline) {
                    System.Diagnostics.Debug.WriteLine(item);
                }
                return 0;
            }
        }

        public string Compile(string[] instructions) {
            try {
                InstructionMemory = CompilerFunctions.Compile(instructions);
            }
            catch (NotSupportedException) {

                throw;
            }

            return "Instruction Memory\n";
        }

        /// <summary>
        /// Gets the next instruction from memory, places that instruction in the fetch stage and first pipeline register
        /// </summary>
        /// <returns></returns>
        public int Fetch() {
            int programCounter;
            Registers.TryGetValue(RegisterEnum.r28, out programCounter);

            IInstruction instruction = PipelineFunctions.Fetch(programCounter, InstructionMemory);

            if (instruction is null) {
                return -1;
            }
            else {
                Pipeline[0] = instruction;
                Registers[RegisterEnum.r28] += 4; // this will get sent to the ALU
                return 0;
            }
        }

        // decode
        public void Decode() {

        }

        // execute
        public void Execute() {

        }

        // memaccess
        public void MemAccess() {

        }

        // regwrite
        public void RegWrite() {

        }
    }
}
