using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public class HazardDetection {
        public List<Hazard> CurrentHazards { get; set; }
        public (bool, Hazard) HazardStall { get; private set; }
        public int PipelineStage {
            get { return HazardStall.Item2.Stage; }
            private set { }
        }

        public HazardDetection() {
            CurrentHazards = new List<Hazard>();
            HazardStall = (false, null);
        }

        public void CheckToAddHazard(IInstruction instruction, ControlSignal controlSignal) {
            if (controlSignal.RegWrite is true) {
                CurrentHazards.Add(new Hazard(instruction.DestinationRegister, 1, instruction, controlSignal));
            }
            else if (controlSignal.MemWrite is true) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                CurrentHazards.Add(new Hazard(i.SourceRegister1, 1, instruction, controlSignal));
                // or if memory matches
            }
        }
        public void CheckToRemoveHazard(IInstruction instruction, ControlSignal controlSignal) {
            if (controlSignal.RegWrite is true) {
                CurrentHazards.RemoveAll((x) => x.Register == instruction.DestinationRegister);
                HazardStall = (false, null);
            }
            if (controlSignal.MemWrite is true) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                CurrentHazards.RemoveAll((x) => x.Register == i.SourceRegister1);
                HazardStall = (false, null);
            }
        }

        public int CheckForHazardMatch(IInstruction instruction, ControlSignal controlSignal) {
            if (instruction is null || controlSignal.RegWrite is false) {
                return -1;
            }
            else if (instruction is ITypeInstruction) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                if (CurrentHazards.Any((x) => x.Register == i.DestinationRegister) is true) {
                    RegisterEnum StallRegister = i.DestinationRegister;
                    
                    Hazard hazard = CurrentHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                else if (CurrentHazards.Any((x) => x.Register == i.SourceRegister1) is true) {
                    RegisterEnum StallRegister = i.SourceRegister1;
                    Hazard hazard = CurrentHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                // or if memory matches
            }
            else {
                RTypeInstruction i = (RTypeInstruction)instruction;
                if (CurrentHazards.Any((x) => x.Register == instruction.DestinationRegister) is true) {
                    RegisterEnum StallRegister = i.DestinationRegister;
                    Hazard hazard = CurrentHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                else if (CurrentHazards.Any((x) => x.Register == i.SourceRegister1) is true) {
                    RegisterEnum StallRegister = i.SourceRegister1;
                    Hazard hazard = CurrentHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
                else if (CurrentHazards.Any((x) => x.Register == i.SourceRegister2) is true) {
                    RegisterEnum StallRegister = i.SourceRegister2;
                    Hazard hazard = CurrentHazards.Where((x) => x.Register == StallRegister).First();
                    HazardStall = (true, hazard);
                }
            }
            return -1;
        }

        public void IncrementStage() {
            foreach (var item in CurrentHazards) {
                item.Stage++;
            }
        }
        public void IncrementStage(Hazard hazard) {
            int index = CurrentHazards.FindIndex((x) => x == hazard);
            if (index!=-1) {
                CurrentHazards[index].Stage++;
            }
        }
    }
}
