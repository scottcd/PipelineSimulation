using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class InstructionControlPipelineRegister : IPipelineRegister {
        public ControlSignal ControlLogic { get; private set; }
        public IInstruction Instruction { get; set; }
        public ITypeInstruction IType { get; set; }
        public int ValueToWrite { get; set; }

        public void FillPipeline(IInstruction instruction, ControlSignal controlLogic, int valueToWrite) {
            Instruction = instruction;
            ControlLogic = controlLogic;
            ValueToWrite = valueToWrite;

            if (instruction is ITypeInstruction) {
                IType = (ITypeInstruction)instruction;
            }
        }
        public void FlushPipeline() {
            Instruction = null;
            ControlLogic = null;
            ValueToWrite = -1;
        }
    }
}
