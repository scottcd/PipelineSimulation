using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public static class CompilerFunctions {
        public static List<IInstruction> Compile(string[] instructions) {
            // clear out previous program
            List<IInstruction> instructionMemory = new List<IInstruction>();

            foreach (var instruction in instructions) {
                string[] formattedInstruction = FormatInstruction(instruction);

                bool gotOpcode = OpcodeEnum.TryParse(formattedInstruction[0], out OpcodeEnum opcode);
                int opcodeType = OpcodeEnums.GetType(opcode);

                // check syntax of instruction
                if (gotOpcode == false) {
                    throw new NotSupportedException();
                }
                if (opcodeType == 1) {

                    bool correctFormat = CheckRType(formattedInstruction);
                    if (correctFormat == false) {
                        throw new NotSupportedException();
                    }
                    else {
                        instructionMemory.Add(new RTypeInstruction(formattedInstruction));  
                    }
                    
                }
                else {
                    bool correctFormat = CheckIType(formattedInstruction);
                    if (correctFormat == false) {
                        throw new NotSupportedException();
                    }
                    else {
                        instructionMemory.Add(new ITypeInstruction(formattedInstruction));  
                    }
                    
                }
                //else 
                
                // if we have a valid instruction, add it to instruction memory.
            }

            return instructionMemory;
        }

        private static bool CheckIType(string[] formattedInstruction) {
            return false;
        }

        private static bool CheckRType(string[] formattedInstruction) {
            string  d1 = formattedInstruction[1],
                    s1 = formattedInstruction[2],
                    s2 = formattedInstruction[3];
            int registerNumber;
            // check d1
            Int32.TryParse(d1.Substring(1), out registerNumber);
            if (d1[0] == '$' && (0 <= registerNumber) && (registerNumber <= 31) ) {
                return true;
            }
            // check s1
            Int32.TryParse(s1.Substring(1), out registerNumber);
            if (s1[0] == '$' && (0 <= registerNumber) && (registerNumber <= 31)) {
                return true;
            }
            // check s2
            Int32.TryParse(s2.Substring(1), out registerNumber);
            if (s2[0] == '$' && (0 <= registerNumber) && (registerNumber <= 31)) {
                return true;
            }

            return false;
        }

        private static string[] FormatInstruction(string item) {
            #region Format instruction into an array[4]
            string[] halfsplit = item.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string[] formattedInstruction = new string[4];

            string trimmed = String.Concat(halfsplit[1].Where(c => !Char.IsWhiteSpace(c)));
            trimmed = trimmed.Trim(')');
            string[] argumentSplit = trimmed.Split(',', '(');
            
            formattedInstruction[0] = halfsplit[0].Replace('.', '_').ToLower();
            formattedInstruction[1] = argumentSplit[0].ToLower().Replace('$', 'r').ToLower();
            formattedInstruction[2] = argumentSplit[1].ToLower().Replace('$', 'r').ToLower();
            formattedInstruction[3] = argumentSplit[2].ToLower().Replace('$', 'r').ToLower();
            #endregion
            return formattedInstruction;
        }
    }
}
