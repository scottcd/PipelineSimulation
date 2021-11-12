using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class Hazard {
        public RegisterEnum Register { get; set; }
        public IInstruction Instruction { get; set; }
        public ControlSignal ControlUnit { get; set; }
        public int Stage { get; set; }
        public delegate string RegisterDelegate(RegisterEnum myreg);

        public Hazard(RegisterEnum register, int stage, IInstruction instruction, ControlSignal controlSignal) {
            Register = register;
            Stage = stage;
            Instruction = instruction;
            ControlUnit = controlSignal;
        }
    }
}
