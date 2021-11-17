using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public class MemoryHazard : IHazard {
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlUnit { get; set; }
        public int Stage { get; set; }
        public int MemoryAddress { get; set; }

        public MemoryHazard(int memoryAddress, int stage, IInstruction instruction, ControlSignal controlSignal) {
            MemoryAddress = memoryAddress;
            Stage = stage;
            Instruction = instruction;
            ControlUnit = controlSignal;
        }
    }
}
