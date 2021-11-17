using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public class ExecutePipelineStage : IPipelineStage {
        public IInstruction Instruction { get; set; }
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int OperationCode { get; set; }

        public ExecutePipelineStage(IInstruction instruction, int operand1, int operand2, int operationCode) {
            Instruction = instruction;
            Operand1 = operand1;
            Operand2 = Operand2;
            OperationCode = operationCode;
        }

        public override string ToString() {
            return Instruction.ToString();
        }
    }
}
