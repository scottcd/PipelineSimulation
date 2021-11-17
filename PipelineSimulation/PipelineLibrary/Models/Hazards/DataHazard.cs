using PipelineLibrary.ProcessorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary.ProcessorModels {
    public class DataHazard : IHazard{
        public RegisterEnum Register { get; set; }
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlUnit { get; set; }
        public int Stage { get; set; }
        
        public DataHazard(RegisterEnum register, int stage, IInstruction instruction, ControlSignal controlSignal) {
            Register = register;
            Stage = stage;
            Instruction = instruction;
            ControlUnit = controlSignal;
        }
    }
}
