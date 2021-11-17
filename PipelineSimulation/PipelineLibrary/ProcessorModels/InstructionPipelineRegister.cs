using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class InstructionPipelineRegister  : IPipelineRegister {
        public IInstruction Instruction { get; set; }
        public InstructionPipelineRegister() {
            
        }
        public void FillPipeline(IInstruction instruction) {
            Instruction = instruction;
        }
        public void FlushPipeline() {
            Instruction = null;
        }
        public override string ToString() {
            return "Instruction";
        }
    }
}
