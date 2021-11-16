using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class PipelineStatistics {
        List<(IInstruction, int[])> Stats { get; set; }
        public PipelineStatistics() {
            Stats = new List<(IInstruction, int[])>();
        }

        public void AddStatistic(IInstruction instruction, int cycleNumber) {
            int[] stages = new int[5];
            stages[0] = cycleNumber;
            (IInstruction, int[]) statLog = (instruction, stages);

            Stats.Add(statLog);
        }

        public void WriteStatistic(IInstruction instruction, int stage, int cycleNumber) {
            int index;
            if (stage == 4) {
                index = Stats.FindIndex(x => x.Item1.Equals(instruction) &&
                    x.Item2[2] > 0 &&
                    x.Item2[4] == 0);
                if (index == -1) {
                    return;
                }
                Stats[index].Item2[stage] = cycleNumber;
            }
            else {
                index = Stats.FindIndex(x => 
                    x.Item1.Equals(instruction) && 
                    x.Item2[stage - 1] > 0 && 
                    x.Item2[4] == 0 &&
                    x.Item2[stage] == 0);
                if (index == -1) {
                    return;
                }

                Stats[index].Item2[stage] = cycleNumber;
            }
        }

        public override string ToString() {
            string output = string.Empty;
            output += $"Instruction\t\t\tIF\tDD\tEX\tMEM\tREG\n";
            output += $"---------\t\t\t--\t--\t--\t---\t---\n";
            int n = 1;
            foreach (var item in Stats) {
                output += $"{n} {item.Item1}\t\t{item.Item2[0]}\t{item.Item2[1]}\t{item.Item2[2]}\t{item.Item2[3]}\t{item.Item2[4]}\n";
                n++;
            }

            return output;
        }
    }
}
