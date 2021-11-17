using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public class RegisterPipelineStage : IPipelineStage {
        public IInstruction Instruction { get; set; }

        public RegisterEnum WriteReg { get; set; }
        public int WriteValue { get; set; }

        public RegisterPipelineStage(IInstruction instruction, RegisterEnum writeReg, int writeValue) {
            Instruction = instruction;
            WriteReg = writeReg;
            WriteValue = writeValue;
        }

        public override string ToString() {
            return Instruction.ToString();
        }
    }
}
