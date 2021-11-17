using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public interface IHazard {
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlUnit { get; set; }
        public int Stage { get; set; }
    }
}
