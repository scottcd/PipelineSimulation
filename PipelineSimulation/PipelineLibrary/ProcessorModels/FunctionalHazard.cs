using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public class FunctionalHazard : IHazard {
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlUnit { get; set; }
        public int Stage { get; set; }
        public FunctionalHazard(int stage, IInstruction instruction, ControlSignal controlSignal) {
            Stage = stage;
            Instruction = instruction;
            ControlUnit = controlSignal;
        }
    }
}
