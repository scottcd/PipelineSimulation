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
            switch (instructionOpcode) {
                case (OpcodeEnum.lw):
                    LoadConfiguration();
                    break;
                case (OpcodeEnum.sw):
                    StoreConfiguration();
                    break;
                case (OpcodeEnum.l_s):
                    FloatingLoadConfiguration();
                    break;
                case (OpcodeEnum.s_s):
                    FloatingStoreConfiguration();
                    break;
                case (OpcodeEnum.add):
                    AddConfiguration();
                    break;
                case (OpcodeEnum.sub):
                    SubConfiguration();
                    break;
                case (OpcodeEnum.beq):
                    BranchEqualConfiguration();
                    break;
                case (OpcodeEnum.bne):
                    BranchNotEqualConfiguration();
                    break;
                case (OpcodeEnum.add_s):
                    FloatingAddConfiguration();
                    break;
                case (OpcodeEnum.sub_s):
                    FloatingSubConfiguration();
                    break;
                case (OpcodeEnum.mul_s):
                    FloatingMulConfiguration();
                    break;
                case (OpcodeEnum.div_s):
                    FloatingDivConfiguration();
                    break;
                default:
                    break;
            }
        }

        public void LoadConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void StoreConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void FloatingLoadConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void FloatingStoreConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void AddConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void SubConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void BranchEqualConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void BranchNotEqualConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void FloatingAddConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void FloatingSubConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void FloatingMulConfiguration() {
            RegDst = false;
            Branch = false;
            MemRead = false;
            MemtoReg = false;
            ALUOp = 0;
            MemWrite = false;
            ALUSrc = false;
            RegWrite = false;
        }
        public void FloatingDivConfiguration() {
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
