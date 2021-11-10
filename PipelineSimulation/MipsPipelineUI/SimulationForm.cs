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
        public string[]  LoadedInstructions { get; set; }
        Processor MIPS_Processor { get; set; }

        public SimulationForm() {
            InitializeComponent();
            MIPS_Processor = new Processor();
            stateBox.Text = MIPS_Processor.ToString();
            infoBox.Text = "Instructions here";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openDialog.InitialDirectory = Application.StartupPath;
            if (openDialog.ShowDialog() == DialogResult.OK && !openDialog.FileName.Equals("")) 
            {
                StreamReader sr = new StreamReader(openDialog.FileName);
                loadInstructions(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void loadDirectInputMenuItem_Click(object sender, EventArgs e)
        {
            DirectInputForm inputForm = new DirectInputForm();
            inputForm.ShowDialog();
            if (inputForm.DirectInput != null)
            {
                loadInstructions(inputForm.DirectInput);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {

        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {
            // timer
            int doneYet = MIPS_Processor.RunCycle();
            if (doneYet == -1) {
                cycleTimer.Stop();
                System.Diagnostics.Debug.WriteLine("Done!");
            }
            stateBox.Text = MIPS_Processor.ToString();
        }

        private void loadInstructions(string instructionstr) 
        {
            LoadedInstructions = instructionstr.Split("\n");

            string instructionOutput = $"Program Instructions\n";

            foreach (var item in LoadedInstructions) {
                instructionOutput += $"{item}\n";
            }

            infoBox.Text = instructionOutput;
        }

        private void stepButton_Click(object sender, EventArgs e) {

        }

        private void compileProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            // compile LoadedInstructions
            string output = MIPS_Processor.Compile(LoadedInstructions);

            foreach (var instruction in MIPS_Processor.InstructionMemory) {
                output += instruction + "\n";
            }

            infoBox.Text = output;
            cycleTimer.Start();
        }
    }
}
