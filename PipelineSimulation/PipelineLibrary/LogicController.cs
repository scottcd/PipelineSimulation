using System;

namespace PipelineLibrary {
    public class LogicController {
        public bool RegDst { get; set; }
        public bool Branch { get; set; }
        public bool MemRead { get; set; }
        public bool MemtoReg { get; set; }
        public int ALUOp { get; set; }
        public bool MemWrite { get; set; }
        public bool ALUSrc { get; set; }
        public bool RegWrite { get; set; }

        public LogicController() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
    }
}
