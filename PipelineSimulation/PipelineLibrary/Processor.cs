using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class Processor {
        public List<IInstruction> InstructionMemory;
        public IInstruction [] Pipeline { get; set; }
        public LogicController ControlLogic { get; set; }
        // ALUs
        // Registers
        // MUXs

        public Processor() {
            Pipeline = new IInstruction[5];
            InstructionMemory = new List<IInstruction>();
            ControlLogic = new LogicController();
        }

        // fetch

        // decode

        // execute

        // memaccess

        // regwrite
    }
}
