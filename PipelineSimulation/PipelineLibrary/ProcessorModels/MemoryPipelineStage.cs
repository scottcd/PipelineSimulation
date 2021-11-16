using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public class MemoryPipelineStage : IPipelineStage {
        public IInstruction Instruction { get; set; }
        public int MemoryAddress { get; set; }
        public int? ValueToWrite { get; set; }
        public MemoryPipelineStage(IInstruction instruction, int memoryAddress, int valueToWrite) {
            Instruction = instruction;
            MemoryAddress = memoryAddress;
            ValueToWrite = valueToWrite;
        }

        public override string ToString() {
            return Instruction.ToString();
        }
    }
}
