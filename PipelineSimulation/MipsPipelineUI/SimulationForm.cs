using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PipelineLibrary;
using PipelineLibrary.ProcessorModels;

namespace MipsPipelineUI {
    public partial class SimulationForm : Form {
        public string[] LoadedInstructions { get; set; }
        Processor MIPS_Processor { get; set; }
        public bool IsRunning { get; set; }
        public int ClockSpeed { get; set; }

        public SimulationForm() {
            InitializeComponent();
            ClockSpeed = 1500;
            InstructionTextBox.Text = "Empty Instruction Memory";
            PotentialHazardsTextBox.Text = $"No Potential Hazards Detected";
            DetectedHazardsTextBox.Text = $"No Hazards Detected";
            StatisticsTextBox.Text = $"No Stats Yet";
            ProcessorStateBox.Text = $"No Processor Loaded";
            DisplayPipelineStages();
            DisplayPipelineRegisters();
        }

        private void loadDirectInputMenuItem_Click(object sender, EventArgs e) {
            DirectInputForm inputForm = new DirectInputForm();
            inputForm.ShowDialog();
            if (inputForm.DirectInput != null) {
                loadInstructions(inputForm.DirectInput);
            }
        }

        private void runButton_Click(object sender, EventArgs e) {
            if (IsRunning is true) {
                runButton.Text = "Run";
                cycleTimer.Stop();
                IsRunning = false;
            }
            else {
                runButton.Text = "Stop";
                cycleTimer.Interval = ClockSpeed;
                cycleTimer.Start();
                IsRunning = true;
            }

        }

        private void cycleTimer_Tick(object sender, EventArgs e) {
            // timer
            int doneYet = MIPS_Processor.RunCycle();
            if (doneYet == -1) {
                cycleTimer.Stop();
                stepButton.Enabled = false;
                runButton.Enabled = false;
                System.Diagnostics.Debug.WriteLine("Done!");
            }
            UpdateUI();
        }

        private void UpdateUI() {
            // display state
            ProcessorStateBox.Text = MIPS_Processor.ToString();
            ClockCycleLabel.Text = $"Current Cycle: {MIPS_Processor.CycleNumber}";
            StatisticsTextBox.Text = $"{MIPS_Processor.Statistics}";

            // hazards conditional display
            if (MIPS_Processor.Hazards.HazardStall.Item2 is null) {
                DetectedHazardsTextBox.Text = $"No Hazards Detected";
            }
            else {
                DetectedHazardsTextBox.Text = $"HAZARD DETECTED -- {MIPS_Processor.Hazards.HazardStall.Item2.Instruction} -- {MIPS_Processor.Hazards.HazardStall.Item2.Register}";
            }
            if (MIPS_Processor.Hazards.CurrentHazards is null || MIPS_Processor.Hazards.CurrentHazards.Count == 0) {
                PotentialHazardsTextBox.Text = $"No Potential Hazards Detected";
            }
            else {
                string output = $"Potential Hazards - ";
                if (MIPS_Processor.Hazards.CurrentHazards.Count == 1) {
                    output += $"{MIPS_Processor.Hazards.CurrentHazards[0].Register}";
                }
                else {
                    foreach (var item in MIPS_Processor.Hazards.CurrentHazards) {
                        output += $"{item.Register}, ";
                    }
                }
                PotentialHazardsTextBox.Text = output;
            }
            // display stats
            

            DisplayPipelineRegisters();
            DisplayPipelineStages();
        }

        private void DisplayPipelineRegisters() {
            // display pipeline registers
            if (MIPS_Processor is null) {
                IFID_Instruction.Text = string.Empty;

                IDEX_Instruction.Text = string.Empty;
                IDEX_Control.Text = string.Empty;

                EXMEM_Instruction.Text = string.Empty;
                EXMEM_Control.Text = string.Empty;
                EXMEM_Value.Text = string.Empty;

                MEMREG_Instruction.Text = string.Empty;
                MEMREG_Control.Text = string.Empty;
                MEMREG_Value.Text = string.Empty;
            }
            else {
                IFID_Instruction.Text = $"{MIPS_Processor.PipelineRegisters[0].Instruction}";

                ValuePipelineRegister reg1 = (ValuePipelineRegister)MIPS_Processor.PipelineRegisters[1];
                IDEX_Instruction.Text = $"{reg1.Instruction}";
                IDEX_Control.Text = $"{reg1.ControlLogic}";

                FullPipelineRegister reg2 = (FullPipelineRegister)MIPS_Processor.PipelineRegisters[2];
                EXMEM_Instruction.Text = $"{reg2.Instruction}";
                EXMEM_Control.Text = $"{reg2.ControlLogic}";
                if (reg2.Instruction is null) {
                    EXMEM_Value.Text = string.Empty;
                }
                else {
                    EXMEM_Value.Text = $"{reg2.ValueToWrite}";
                }

                FullPipelineRegister reg3 = (FullPipelineRegister)MIPS_Processor.PipelineRegisters[3];
                MEMREG_Instruction.Text = $"{reg3.Instruction}";
                MEMREG_Control.Text = $"{reg3.ControlLogic}";
                
                if (reg3.Instruction is null) {
                    MEMREG_Value.Text = string.Empty;
                }
                else {
                    MEMREG_Value.Text = $"{reg3.ValueToWrite}";
                }
            }
        }

        private void DisplayPipelineStages() {
            // display pipeline stages
            if (MIPS_Processor is null) {
                Fetch_Instruction.Text = string.Empty;
                
                Decode_Instruction.Text = string.Empty;
                Decode_Op.Text = string.Empty;
                Decode_Arg1.Text = string.Empty;
                Decode_Arg2.Text = string.Empty;
                Decode_Arg3.Text = string.Empty;

                Execute_Instruction.Text = string.Empty;
                Execute_Operation.Text = string.Empty;
                Execute_Value1.Text = string.Empty;
                Execute_Value2.Text = string.Empty;

                Mem_Instruction.Text = string.Empty;
                Mem_Address.Text = string.Empty;
                Mem_Value.Text = string.Empty;

                RegWrite_Instruction.Text = string.Empty;
                RegWrite_WriteReg.Text = string.Empty;
                RegWrite_Value.Text = string.Empty;
            }
            else {
                if (MIPS_Processor.Pipeline[0] is null) {
                    Fetch_Instruction.Text = string.Empty;
                }
                else {
                    Fetch_Instruction.Text = $"{MIPS_Processor.Pipeline[0].Instruction}";
                }
                if (MIPS_Processor.Pipeline[1] is null) {
                    Decode_Instruction.Text = string.Empty;
                    Decode_Op.Text = string.Empty;
                    Decode_Arg1.Text = string.Empty;
                    Decode_Arg2.Text = string.Empty;
                    Decode_Arg3.Text = string.Empty;
                }
                else {
                    IInstruction instruction =  MIPS_Processor.Pipeline[1].Instruction;
                    Decode_Instruction.Text = $"{instruction}";
                    Decode_Op.Text = $"{instruction.Opcode}";
                    if (instruction is ITypeInstruction) {
                        ITypeInstruction i = (ITypeInstruction)instruction;
                        Decode_Arg1.Text = $"Dest Reg: {i.DestinationRegister}";
                        Decode_Arg2.Text = $"Source Reg: {i.SourceRegister1}";
                        Decode_Arg3.Text = $"Immediate: {i.Immediate}";
                    }
                    else {
                        RTypeInstruction i = (RTypeInstruction)instruction;
                        Decode_Arg1.Text = $"Dest Reg: {i.DestinationRegister}";
                        Decode_Arg2.Text = $"Source Reg: {i.SourceRegister1}";
                        Decode_Arg3.Text = $"Source Reg: {i.SourceRegister2}";
                    }
                }
                if (MIPS_Processor.Pipeline[2] is null) {
                    Execute_Instruction.Text = string.Empty;
                    Execute_Operation.Text = string.Empty;
                    Execute_Value1.Text = string.Empty;
                    Execute_Value2.Text = string.Empty;
                }
                else {
                    ExecutePipelineStage stage = (ExecutePipelineStage)MIPS_Processor.Pipeline[2];
                    
                    Execute_Instruction.Text = $"{stage.Instruction}";
                    Execute_Operation.Text = $"Operation: {stage.OperationCode}";
                    Execute_Value1.Text = $"Operand 1: {stage.Operand1}";
                    Execute_Value2.Text = $"Operand 2: {stage.Operand2}";
                }
                if (MIPS_Processor.Pipeline[3] is null) {
                    Mem_Instruction.Text = string.Empty;
                    Mem_Address.Text = string.Empty;
                    Mem_Value.Text = string.Empty;
                }
                else {
                    MemoryPipelineStage stage = (MemoryPipelineStage)MIPS_Processor.Pipeline[3];
                    IInstruction i = stage.Instruction;

                    if (i.Opcode == OpcodeEnum.sw || i.Opcode == OpcodeEnum.s_s) {
                        ITypeInstruction instruction = (ITypeInstruction)i;
                        Mem_Value.Text = $"Value: {MIPS_Processor.Registers[instruction.SourceRegister1]}";
                    }
                    else {
                        Mem_Value.Text = $"Value: {MIPS_Processor.MainMemory[stage.MemoryAddress]}";
                    }

                    Mem_Instruction.Text = $"{stage.Instruction}";
                    Mem_Address.Text = $"Memory Address: {stage.MemoryAddress}";
                    
                }
                if (MIPS_Processor.Pipeline[4] is null) {
                    RegWrite_Instruction.Text = string.Empty;
                    RegWrite_WriteReg.Text = string.Empty;
                    RegWrite_Value.Text = string.Empty;
                }
                else {
                    RegisterPipelineStage stage = (RegisterPipelineStage)MIPS_Processor.Pipeline[4];

                    RegWrite_Instruction.Text = $"{stage.Instruction}";
                    RegWrite_WriteReg.Text = $"Write Reg: {stage.WriteReg}";
                    RegWrite_Value.Text = $"Write Value: {stage.WriteValue}";
                }
            }
        }


        private void loadInstructions(string instructionstr) {
            stepButton.Enabled = false;
            runButton.Enabled = false;
            LoadedInstructions = instructionstr.Split("\n");

            string instructionOutput = $"Program Instructions\n";

            foreach (var item in LoadedInstructions) {
                instructionOutput += $"{item}\n";
            }

            InstructionTextBox.Text = instructionOutput;

            MIPS_Processor = new Processor(ClockSpeed);
            ProcessorStateBox.Text = MIPS_Processor.ToString();

            IsRunning = false;
            cycleTimer.Interval = MIPS_Processor.ClockSpeed;
            UpdateUI();
        }

        private void stepButton_Click(object sender, EventArgs e) {
            int doneYet = MIPS_Processor.RunCycle();

            if (doneYet == -1) {
                stepButton.Enabled = false;
                runButton.Enabled = false;
            }
            UpdateUI();
        }

        private void compileProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            // compile LoadedInstructions
            string output = MIPS_Processor.Compile(LoadedInstructions);

            foreach (var instruction in MIPS_Processor.InstructionMemory) {
                output += instruction + "\n";
            }
            stepButton.Enabled = true;
            runButton.Enabled = true;
            InstructionTextBox.Text = output;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            openDialog.InitialDirectory = Application.StartupPath;
            if (openDialog.ShowDialog() == DialogResult.OK && !openDialog.FileName.Equals("")) {
                StreamReader sr = new StreamReader(openDialog.FileName);
                loadInstructions(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void instructionLatenciesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MIPS_Processor is not null) {
                ConfigInstructionsForm inputForm = new ConfigInstructionsForm(MIPS_Processor);
                inputForm.ShowDialog();
                OpcodeEnum key = inputForm.CurrentKey;
                int executionCycles = inputForm.ExecutionCycles;
                MIPS_Processor.ExecutionCycleDictionary[key] = executionCycles;
            }   
        }

        private void clockSpeedToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MIPS_Processor is not null) {
                ConfigClockForm inputForm = new ConfigClockForm(ClockSpeed);
                inputForm.ShowDialog();
                if (inputForm.CPU_Speed > 0) {
                    ClockSpeed = inputForm.CPU_Speed;
                }
            }    
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutInstructionsForm inputForm = new AboutInstructionsForm();
            inputForm.ShowDialog();
        }

        private void registersToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutRegistersForm inputForm = new AboutRegistersForm();
            inputForm.ShowDialog();
        }

        private void pipelineStagesToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutStagesForm inputForm = new AboutStagesForm();
            inputForm.ShowDialog();
        }

        private void controlUnitToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutControlForm inputForm = new AboutControlForm();
            inputForm.ShowDialog();
        }
    }
}
