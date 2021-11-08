using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class PipelineRegister {
        public ControlSignal ControlLogic {get; set;}
        public IInstruction Instruction { get; set; }
        public int ValueToWrite { get; set; }
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }

        public PipelineRegister(IInstruction instruction) {
            Instruction = instruction;
        }
        public PipelineRegister(IInstruction instruction, ControlSignal controlLogic) {
            Instruction = instruction;
            ControlLogic = controlLogic;
        }
        public PipelineRegister(IInstruction instruction, ControlSignal controlLogic, int operand1, int operand2) {
            Instruction = instruction;
            ControlLogic = controlLogic;
            Operand1 = operand1;
            Operand2 = operand2;
        }
        public PipelineRegister(IInstruction instruction, ControlSignal controlLogic, int valueToWrite) {
            Instruction = instruction;
            ControlLogic = controlLogic;
            ValueToWrite = valueToWrite;
        }
    }
}
