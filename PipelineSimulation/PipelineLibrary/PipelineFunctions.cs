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

        /// <summary>
        /// Check if instruction should be loaded into the Memory Access stage
        /// </summary>
        /// <param name="pipeLineRegister">EX/MEM Pipeline Register</param>
        /// <returns>
        ///             true, if instruction should be loaded
        ///             false, if instruction should not be loaded
        ///</returns>
        public static bool CheckMemAccess(ControlSignal controlUnit) {
            if (controlUnit.MemWrite == true || controlUnit.MemRead == true || controlUnit.RegWrite) {
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// Check if instruction should be loaded into the Register Write stage
        /// </summary>
        /// <param name="pipeLineRegister">MEM/REG Pipeline Register</param>
        /// <returns>
        ///             true, if instruction should be loaded
        ///             false, if instruction should not be loaded
        ///</returns>
        public static bool CheckRegWrite(ControlSignal controlUnit) {
            if (controlUnit.RegWrite == true) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
