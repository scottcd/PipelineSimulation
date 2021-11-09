using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class FullPipelineRegister : IPipelineRegister {
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlLogic { get; private set; }
        public int Operand1 { get; private set; }
        public int Operand2 { get; private set; }

        
        public void FillPipeline(IInstruction instruction, ControlSignal controlLogic, int operand1, int operand2) {
            Instruction = instruction;
            ControlLogic = controlLogic;
            Operand1 = operand1;
            Operand2 = operand2;
        }
        public void FlushPipeline() {
            Instruction = null;
            ControlLogic = null;
            Operand1 = -1;
            Operand2 = -1;
        }
    }
}
