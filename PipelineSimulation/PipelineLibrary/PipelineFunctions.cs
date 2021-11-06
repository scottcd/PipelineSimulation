using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public static class PipelineFunctions {
       public static IInstruction Fetch(int programCounter, List<IInstruction> instructionMemory) {
            int instructionIndex = programCounter / 4;
            if (instructionIndex > instructionMemory.Count - 1) {
                return null;
            }
            else { 
                IInstruction instruction = instructionMemory[instructionIndex];
                return instruction;
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
