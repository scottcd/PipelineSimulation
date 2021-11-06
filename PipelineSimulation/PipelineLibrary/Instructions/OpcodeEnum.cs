using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public enum OpcodeEnum {
        lw,
        sw,
        l_s,
        s_s,
        add,
        sub,
        beq,
        bne,
        add_s,
        sub_s,
        mul_s,
        div_s
    }
    public static class OpcodeEnums {
        public static int GetType(OpcodeEnum opcode) {
            switch (opcode) {
                case OpcodeEnum.lw:
                    return 0;
                case OpcodeEnum.sw:
                    return 0;
                case OpcodeEnum.l_s:
                    return 0;
                case OpcodeEnum.s_s:
                    return 0;
                case OpcodeEnum.beq:
                    return 0;
                case OpcodeEnum.bne:
                    return 0;
                case OpcodeEnum.add:
                    return 1;
                case OpcodeEnum.sub:
                    return 1;
                case OpcodeEnum.add_s:
                    return 1;
                case OpcodeEnum.sub_s:
                    return 1;
                case OpcodeEnum.mul_s:
                    return 1;
                case OpcodeEnum.div_s:
                    return 1;
                default: 
                    return -1;
            }
        }
    }
}