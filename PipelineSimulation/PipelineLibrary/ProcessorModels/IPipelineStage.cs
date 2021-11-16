using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public interface IPipelineStage{
        public IInstruction Instruction { get; set; }
    }

}
