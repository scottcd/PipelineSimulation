using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary
{
    public class FinalStatistics
    {
        public int registersHit { get; set; }
        public int memAccess { get; set; }
        public int cycles { get; set; }
        public int instructionCount { get; set; }
        public int hazardsHit { get; set; }

        private double cpi = 0.00;

        public FinalStatistics()
        {
            registersHit = 0;
            memAccess = 0;
            cycles = 0;
            instructionCount = 0;
            hazardsHit = 0;

        }

        public void calcCPI()
        {

            cpi = (double)cycles / (double)instructionCount;
        }

        public override string ToString()
        {
            string strCPI = String.Format("{0:0.##}", cpi);
            string output = "" +
                $"   Cycles Per Instruction: {strCPI}\n" +
                $"Number of Instructions: {instructionCount}\n" +
                $"                    Cycles used: {cycles}\n" +
                $"           Registers Written: {registersHit}\n" +
                $"            Memory Written: {memAccess}\n" +
                $"                     Hazards Hit: {hazardsHit}";
            return output;
        }
    }
}
