using PipelineLibrary.ProcessorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class HazardDetection {
        public List<DataHazard> DataHazards { get; set; }
        public List<MemoryHazard> MemoryHazards { get; set; }
        public (bool, IHazard) HazardStall { get; private set; }
        public int PipelineStage {
            get { return HazardStall.Item2.Stage; }
            private set { }
        }

        public HazardDetection() {
            DataHazards = new List<DataHazard>();
            MemoryHazards = new List<MemoryHazard>();
            HazardStall = (false, null);
        }

        public void CheckToAddHazards(IInstruction instruction, ControlSignal controlSignal, Processor mips) {
            if (controlSignal.RegWrite is true) {
                DataHazards.Add(new DataHazard(instruction.DestinationRegister, 1, instruction, controlSignal));
            }
            else if (controlSignal.MemWrite is true) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                int address = i.Immediate + mips.Registers[i.DestinationRegister];
                MemoryHazards.Add(new MemoryHazard(address, 1, instruction, controlSignal));
            }
        }
        public void CheckToRemoveHazard(IInstruction instruction, ControlSignal controlSignal, Processor mips) {
            if (controlSignal.RegWrite is true) {
                DataHazards.RemoveAll((x) => x.Register == instruction.DestinationRegister);
                HazardStall = (false, null);
            }
            if (controlSignal.MemWrite is true) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                int address = i.Immediate + mips.Registers[i.DestinationRegister];
                MemoryHazards.RemoveAll((x) => x.MemoryAddress == address);
                HazardStall = (false, null);
            }
        }

        /// <summary>
        /// Checks the List of potential data hazards for a match and stalls if found
        /// </summary>
        /// <param name="instruction">instruction being checked</param>
        /// <param name="controlSignal">instruction's control signal</param>
        public void CheckForDataHazardMatch(IInstruction instruction, ControlSignal controlSignal) {
            if (instruction is null || controlSignal.RegWrite is false) {
                return;
            }
            else if (instruction is ITypeInstruction) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                
                if (DataHazards.Any((x) => x.Register == i.DestinationRegister) is true) {
                    RegisterEnum StallRegister = i.DestinationRegister;
                    
                    DataHazard hazard = DataHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                else if (DataHazards.Any((x) => x.Register == i.SourceRegister1) is true) {
                    RegisterEnum StallRegister = i.SourceRegister1;
                    DataHazard hazard = DataHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
            }
            else {
                RTypeInstruction i = (RTypeInstruction)instruction;
                if (DataHazards.Any((x) => x.Register == instruction.DestinationRegister) is true) {
                    RegisterEnum StallRegister = i.DestinationRegister;
                    DataHazard hazard = DataHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                else if (DataHazards.Any((x) => x.Register == i.SourceRegister1) is true) {
                    RegisterEnum StallRegister = i.SourceRegister1;
                    DataHazard hazard = DataHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                else if (DataHazards.Any((x) => x.Register == i.SourceRegister2) is true) {
                    RegisterEnum StallRegister = i.SourceRegister2;
                    DataHazard hazard = DataHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
            }
            return;
        }

        /// <summary>
        /// Checks the list of potential memory hazards for a match and stalls if found
        /// </summary>
        /// <param name="instruction">instruction being checked</param>
        /// <param name="controlSignal">instruction's control signal</param>
        /// <param name="mips">processor</param>
        public void CheckForMemoryHazardMatch(IInstruction instruction, ControlSignal controlSignal, Processor mips) {
            if (instruction is null || (controlSignal.MemWrite is false && controlSignal.MemRead is false)) {
                return;
            }
            ITypeInstruction i = (ITypeInstruction)instruction;
            int address = i.Immediate + mips.Registers[i.DestinationRegister];
            int index = MemoryHazards.FindIndex((x) => x.MemoryAddress == address);
            if (index == -1) {
                return;
            }
            MemoryHazard hazard = MemoryHazards[index];
            HazardStall = (true, hazard);
        }

        /// <summary>
        /// Increment the pipeline stage of the hazard
        /// </summary>
        public void IncrementStage() {
            foreach (var item in DataHazards) {
                item.Stage++;
            }
            foreach (var item in MemoryHazards) {
                item.Stage++;
            }
        }
    }
}
