using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class RTypeInstruction : IInstruction {
        public OpcodeEnum Opcode { get; set; }
        public RegisterEnum DestinationRegister { get; set; }
        public RegisterEnum SourceRegister1 { get; set; }
        public RegisterEnum SourceRegister2 { get; set; }
        private string DisplayString { get; set; }
        public int[] CyclesToComplete { get; set; }

        public RTypeInstruction(string[] formattedInstruction) {
            OpcodeEnum.TryParse(formattedInstruction[0], out OpcodeEnum opcode);
            Opcode = opcode;
            RegisterEnum register;

            RegisterEnum.TryParse(formattedInstruction[1], out register);
            SourceRegister1 = register;

            RegisterEnum.TryParse(formattedInstruction[2], out register);
            SourceRegister2 = register;

            RegisterEnum.TryParse(formattedInstruction[3], out register);
            DestinationRegister = register;

            CyclesToComplete = new int[5] {1,2,3,4,5 };

            DisplayString = $"{Opcode}\t{SourceRegister1}, {SourceRegister2}, {DestinationRegister}";
        }

        public override string ToString() {
            return $"{DisplayString}";
        }
    }
}
