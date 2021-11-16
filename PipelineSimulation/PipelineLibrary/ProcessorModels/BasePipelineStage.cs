using PipelineLibrary.ProcessorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class BasePipelineStage :IPipelineStage {
        public IInstruction Instruction { get; set; }
        public int CyclesLeft { get; set; }

        public BasePipelineStage(IInstruction instruction) {
            Instruction = instruction;
        }

        public override string ToString() {
            return Instruction.ToString();
        }
    }
}
