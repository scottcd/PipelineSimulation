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
}