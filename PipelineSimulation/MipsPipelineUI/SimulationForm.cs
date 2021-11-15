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

namespace MipsPipelineUI {
    public partial class SimulationForm : Form {
        public string[] LoadedInstructions { get; set; }
        Processor MIPS_Processor { get; set; }
        public bool IsRunning { get; set; }

        public SimulationForm() {
            InitializeComponent();
            MIPS_Processor = new Processor();
            ProcessorStateBox.Text = MIPS_Processor.ToString();
            InstructionTextBox.Text = "Instructions here";
            PotentialHazardsTextBox.Text = $"No Potential Hazards Detected";
            DetectedHazardsTextBox.Text = $"No Hazards Detected";
            StatisticsTextBox.Text = $"No Stats Yet";
            IsRunning = false;
            cycleTimer.Interval = MIPS_Processor.ClockSpeed;
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
                cycleTimer.Interval = MIPS_Processor.ClockSpeed;
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
            ProcessorStateBox.Text = MIPS_Processor.ToString();
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
            //StatisticsTextBox 
        }

        private void loadInstructions(string instructionstr) {
            LoadedInstructions = instructionstr.Split("\n");

            string instructionOutput = $"Program Instructions\n";

            foreach (var item in LoadedInstructions) {
                instructionOutput += $"{item}\n";
            }

            InstructionTextBox.Text = instructionOutput;
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
            ConfigInstructionsForm inputForm = new ConfigInstructionsForm();
            inputForm.ShowDialog();
        }

        private void clockSpeedToolStripMenuItem_Click(object sender, EventArgs e) {
            ConfigClockForm inputForm = new ConfigClockForm();
            inputForm.ShowDialog();
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
