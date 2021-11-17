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
                        System.Diagnostics.Debug.WriteLine(formattedInstruction);
                    }                   
                }
                else {
                    bool correctFormat = CheckIType(formattedInstruction, opcode);
                    if (correctFormat == false) {
                        throw new NotSupportedException();
                    }
                    else {
                        instructionMemory.Add(new ITypeInstruction(formattedInstruction));  
                    }   
                }   
            }
            return instructionMemory;
        }

        private static bool CheckIType(string[] formattedInstruction, OpcodeEnum opcode) {
            if (opcode == OpcodeEnum.lw || opcode == OpcodeEnum.l_s) {
                return CheckLoad(formattedInstruction);
            }
            else if (opcode == OpcodeEnum.sw || opcode == OpcodeEnum.s_s) {
                return CheckStore(formattedInstruction);
            }
            else {
                return CheckBranch(formattedInstruction);
            }
        }

        private static bool CheckBranch(string [] formattedInstruction) {
            string destination = formattedInstruction[1],
                    source = formattedInstruction[2],
                    immediate = formattedInstruction[3];

            // check source
            if (CheckRegisterFormat(source) == false) {
                return false;
            }
            // check destination
            if (CheckRegisterFormat(destination) == false) {
                return false;
            }
            // check immediate
            if (CheckImmediateFormat(immediate) == false) {
                return false;
            }

            return true;
        }

        private static bool CheckStore(string[] formattedInstruction) {
            string  source = formattedInstruction[1],
                    immediate = formattedInstruction[2],
                    destination = formattedInstruction[3];


            // check source
            if (CheckRegisterFormat(source) == false) {
                return false;
            }
            // check destination
            if (CheckRegisterFormat(destination) == false) {
                return false;
            }
            // check immediate
            if (CheckImmediateFormat(immediate) == false) {
                return false;
            }

            return true;
        }

        private static bool CheckLoad(string[] formattedInstruction) {
            string destination = formattedInstruction[1],
                    immediate = formattedInstruction[2],
                    source = formattedInstruction[3];

            // check source
            if (CheckRegisterFormat(source) == false) {
                return false;
            }
            // check destination
            if (CheckRegisterFormat(destination) == false) {
                return false;
            }
            // check immediate
            if (CheckImmediateFormat(immediate) == false) {
                return false;
            }

            return true;
        }

        private static bool CheckRType(string[] formattedInstruction) {
            string  destination = formattedInstruction[1],
                    source1 = formattedInstruction[2],
                    source2 = formattedInstruction[3];
            // check d1
            if (CheckRegisterFormat(destination) == false) {
                return false;
            }
            // check s1
            if (CheckRegisterFormat(source1) == false) {
                return false;
            }
            // check s2
            if (CheckRegisterFormat(source2) == false) {
                return false;
            }

            return true;
        }

        public static bool CheckRegisterFormat(string registerString) {
            Int32.TryParse(registerString.Substring(1), out int immediateValue);
            if (registerString[0] == 'r' && (0 <= immediateValue) && (immediateValue <= 31)) {
                return true;
            }
            else {
                return false;
            } 
        }

        public static bool CheckImmediateFormat(string immediateString) {
            bool tried = Int32.TryParse(immediateString, out int immediateValue);
            if ((-10000 <= immediateValue) && (immediateValue <= 10000) && tried == true) {
                return true;
            }
            else {
                return false;
            }
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
