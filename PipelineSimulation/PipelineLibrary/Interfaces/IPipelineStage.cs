using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public interface IPipelineStage{
        public IInstruction Instruction { get; set; }
    }

}
