using System;

namespace PipelineLibrary {
    public class ControlSignal {
        public bool RegDst { get; set; }
        public bool Branch { get; set; }
        public bool MemRead { get; set; }
        public bool MemtoReg { get; set; }
        public int ALUOp { get; set; }
        public bool MemWrite { get; set; }
        public bool ALUSrc { get; set; }
        public bool RegWrite { get; set; }

        public ControlSignal() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }

        public ControlSignal(OpcodeEnum instructionOpcode) {
            int type = OpcodeEnums.GetType(instructionOpcode);

            if (type == 0) {
                switch (instructionOpcode) {
                    case (OpcodeEnum.lw):
                        LoadConfiguration();
                        break;
                    case (OpcodeEnum.sw):
                        StoreConfiguration();
                        break;
                    case (OpcodeEnum.l_s):
                        LoadConfiguration();
                        break;
                    case (OpcodeEnum.s_s):
                        StoreConfiguration();
                        break;
                    case (OpcodeEnum.beq):
                        BranchConfiguration();
                        break;
                    case (OpcodeEnum.bne):
                        BranchConfiguration();
                        break;
                }
             }
            else {
                RTypeConfiguration(instructionOpcode);
            }
            

        }

        private void BranchConfiguration() {
            RegDst = false;
            Branch = true;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 34;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }

        public void LoadConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = true;
            MemtoReg = true;
            ALUOp = 32;
            MemWrite = false;
            ALUSrc = true;
            RegWrite = true;
        }
        public void StoreConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 32;
            MemWrite = true;
            ALUSrc = true;
            RegWrite = false;
        }
        public void RTypeConfiguration(OpcodeEnum opcode) {
            RegDst = true;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = true;

            switch (opcode) {
                case OpcodeEnum.add:
                    ALUOp = 32;
                    break;
                case OpcodeEnum.add_s:
                    ALUOp = 32;
                    break;
                case OpcodeEnum.sub:
                    ALUOp = 34;
                    break;
                case OpcodeEnum.sub_s:
                    ALUOp = 34;
                    break;
                case OpcodeEnum.mul_s:
                    ALUOp = 24;
                    break;
                case OpcodeEnum.div_s:
                    ALUOp = 26;
                    break;
            }
        }
    }
}
