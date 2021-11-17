using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class ITypeInstruction : IInstruction {
        public OpcodeEnum Opcode { get; set; }
        public RegisterEnum DestinationRegister { get; set; }
        public RegisterEnum SourceRegister1 { get; set; }
        public int Immediate { get; set; }
        private string DisplayString { get; set; }
        public int CyclesToComplete { get; set; }

        public ITypeInstruction(string[] formattedInstruction) {
            OpcodeEnum.TryParse(formattedInstruction[0], out OpcodeEnum opcode);
            Opcode = opcode;

            DecideParse(formattedInstruction);
            CyclesToComplete = 1;
        }

        private void DecideParse(string[] formattedInstruction) {
            if (Opcode == OpcodeEnum.lw || Opcode == OpcodeEnum.l_s) {
                ParseLoad(formattedInstruction);
            }
            else if (Opcode == OpcodeEnum.sw || Opcode == OpcodeEnum.s_s) {
                ParseStore(formattedInstruction);
            }
            else {
                ParseBranch(formattedInstruction);
            }
        }

        public void ParseLoad(string [] formattedInstruction) {
            RegisterEnum register;
            RegisterEnum.TryParse(formattedInstruction[1], out register);
            DestinationRegister = register;

            Int32.TryParse(formattedInstruction[2], out int immediate);
            Immediate = immediate;

            RegisterEnum.TryParse(formattedInstruction[3], out register);
            SourceRegister1 = register;

            DisplayString = $"{Opcode}\t{DestinationRegister}, {Immediate}({SourceRegister1})";
        }
        public void ParseStore(string[] formattedInstruction) {
            RegisterEnum register;
            RegisterEnum.TryParse(formattedInstruction[1], out register);
            SourceRegister1 = register;
            
            RegisterEnum.TryParse(formattedInstruction[3], out register);
            DestinationRegister = register;

            Int32.TryParse(formattedInstruction[2], out int immediate);
            Immediate = immediate;

            DisplayString = $"{Opcode}\t{SourceRegister1}, {Immediate}({DestinationRegister})";
        }


        public void ParseBranch(string[] formattedInstruction) {
            RegisterEnum register;
            RegisterEnum.TryParse(formattedInstruction[1], out register);
            DestinationRegister = register;

            RegisterEnum.TryParse(formattedInstruction[2], out register);
            SourceRegister1 = register;

            Int32.TryParse(formattedInstruction[3], out int immediate);
            Immediate = immediate;

            DisplayString = $"{Opcode}    {DestinationRegister}, {SourceRegister1}, {Immediate}";
        }

        public override string ToString() {
            return $"{DisplayString}";
        }
    }
}
