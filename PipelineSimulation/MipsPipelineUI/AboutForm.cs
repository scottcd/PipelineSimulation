using PipelineLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MipsPipelineUI
{
    public partial class AboutForm : Form
    {
        public RegisterEnum CurrentKey { get; private set; }
        public Processor Processor { get; set; }

        private List<OpcodeEnum> instructions;
        private List<RegisterEnum> registers;
        private List<string> controls, stages, hazards;

        public AboutForm()
        {
            InitializeComponent();

            Processor = new Processor(1500);

            instructions = Processor.ExecutionCycleDictionary.Keys.ToList();

            registers = Processor.Registers.Keys.ToList();

            controls = new List<string>
            {
                "RegDst", "Branch", "MemRead",
                "MemtoReg", "ALU Op", "MemWrite",
                "ALU Src", "RegWrite"
            };

            stages = new List<string>{
                "Fetch", "Decode", "Execute",
                "Memory Access", "Register Write"
            };

            hazards = new List<string>
            {
                "Data Hazard", "Memory Hazard", "Structural Hazard"
            };
        }

        private void aboutInstructionsMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (instructions);
        }

        private void aboutRegistersMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (registers);
        }

        private void aboutControlMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (controls);
        }

        private void aboutStagesMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (stages);
        }

        private void aboutHazardsMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (hazards);
        }
    }
}
