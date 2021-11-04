using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class ITypeInstruction : IInstruction {
        public OpcodeEnum Opcode { get; set; }
        public int[] Instruction { get; set; }
        public RegisterEnum DestinationRegister { get; set; }
        public RegisterEnum SourceRegister1 { get; set; }
        public int Immediate { get; set; }
    }
}
