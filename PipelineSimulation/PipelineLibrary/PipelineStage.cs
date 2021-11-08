using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class PipelineStage {
        public IInstruction Instruction { get; set; }
        public int CyclesLeft { get; set; }

        public PipelineStage(IInstruction instruction) {
            Instruction = instruction;
        }

        public override string ToString() {
            return Instruction.ToString();
        }
    }
}
