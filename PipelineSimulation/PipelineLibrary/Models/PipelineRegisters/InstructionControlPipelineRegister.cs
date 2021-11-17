using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class InstructionControlPipelineRegister : IPipelineRegister {
        public ControlSignal ControlLogic { get; private set; }
        public IInstruction Instruction { get; set; }


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
