using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public static class PipelineFunctions {
        public static List<IInstruction> Compile(string [] instructions) {
            // clear out previous program
            List<IInstruction> instructionMemory = new List<IInstruction>();

            foreach (var item in instructions) {
                // if compile error
                if (false) {
                    throw new ArgumentException();
                }
                else {
                    //if h-type add that
                    // if r-Type add that
                    //add instruction
                    instructionMemory.Add(new RTypeInstruction());
                }
            }

            return instructionMemory;
        }

        public static IInstruction Fetch(int programCounter, List<IInstruction> instructionMemory) {
            try {
                int instructionIndex = programCounter / 4;
                IInstruction instruction = instructionMemory[instructionIndex];
                return instruction;
            }
            // if there are no more instructions to be read; return null.
            catch (Exception) {
                return null;
            }
        }
        public static void Decode() {

        }
        public static void Execute() {

        }
        public static void MemAccess() {

        }
        public static void RegWrite() {

        }
    }
}
