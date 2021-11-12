using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class FullPipelineRegister : IPipelineRegister {
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlLogic { get; private set; }


        
        public void FillPipeline(IInstruction instruction, ControlSignal controlLogic) {
            Instruction = instruction;
            ControlLogic = controlLogic;

        }
        public void FlushPipeline() {
            Instruction = null;
            ControlLogic = null;
       }
    }
}
