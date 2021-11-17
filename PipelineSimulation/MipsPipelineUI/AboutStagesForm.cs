using PipelineLibrary;
using PipelineLibrary.ProcessorModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MipsPipelineUI {
    public partial class AboutStagesForm : Form {
        public RegisterEnum CurrentKey { get; private set; }
        public Processor Processor { get; set; }

        public AboutStagesForm(Processor processor) {
            if (processor is null) {
                processor = new Processor(1500);
            }
            InitializeComponent();
            
            List<string> stages = new List<string>{
                "Fetch",
                "Decode",
                "Execute",
                "Memory Access",
                "Register Write"
            };
            StagesBox.DataSource = stages.ToList();
        }
        private void InstructionComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            string key = (string)StagesBox.SelectedItem;
            GetDisplay(key);
        }
        private void GetDisplay(string currentKey) {
            switch (currentKey) {
                case "Fetch":
                    DescriptionLabel.Text = $"Statically fetches one instruction from \ninstruction " +
                        $"memory and adds it to the IF/ID pipeline register.";
                    break;
                case "Decode":
                    DescriptionLabel.Text = $"Reads the instruction and parses the \nvarious components. Also, " +
                        $"hazards and control \nlogic are determined.";
                    break;
                case "Execute":
                    DescriptionLabel.Text = $"The instruction operands are fed into \n" +
                        $"the ALU which reads the control logic " + $" to get the ALU op. \n " +
                        $"Once calculated, the value is written to a pipeline register or \n the program counter is" +
                        $" updated if branching.";
                    break;
                case "Memory Access":
                    DescriptionLabel.Text = $"If the instruction is a load or store, \n" +
                        $"memory is written to/read from.";
                    break;
                case "Register Write":
                    DescriptionLabel.Text = $"If the instruction writes back to a register," +
                        $" it is this \nstage that handles it. " +  $"A destination register is " +
                        $"written to\neither by the value read in memory or the value calculated \n" +
                        $"in the ALU.";
                    break;
            }
            
        }
    }
}
