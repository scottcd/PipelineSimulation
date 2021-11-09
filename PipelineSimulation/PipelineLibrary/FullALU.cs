using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class FullALU {
        public int ExecuteOperation(int opcode, int operand1, int operand2) {
            if (opcode == 32) {
                return AddOperands(operand1, operand2);
            }
            else if (opcode == 34) {
                return SubOperands(operand1, operand2);
            }
            else if (opcode == 24) {
                return MulOperands(operand1, operand2);
            }
            else if (opcode == 26) {
                return DivOperands(operand1, operand2);
            }
            else {
                return -1;
            }
        }
        public int AddOperands(int operand1, int operand2) {
            int sum = operand1 + operand2;
            return sum;
        }
        public int SubOperands(int operand1, int operand2) {
            int sum = operand1 - operand2;
            return sum;
        }
        public int MulOperands(int operand1, int operand2) {
            int sum = operand1 * operand2;
            return sum;
        }
        public int DivOperands(int operand1, int operand2) {
            int sum = operand1 / operand2;
            return sum;
        }
    }
}
