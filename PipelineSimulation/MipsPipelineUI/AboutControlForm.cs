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
    public partial class AboutControlForm : Form {
        public AboutControlForm() {
            InitializeComponent();

            List<string> controls = new List<string>{
                "RegDst",
                "Branch",
                "MemRead",
                "MemtoReg",
                "ALU Op",
                "MemWrite",
                "ALU Src",
                "RegWrite"
            };

            ControlBox.DataSource = controls.ToList();
            
        }

        private void InstructionComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            string key= (string)ControlBox.SelectedItem;
            GetDisplay(key);
        }
        private void GetDisplay(string currentKey) {
            switch (currentKey) {
                case "RegDst":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"";
                    break;
                case "Branch":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"True if the instruction is a branch";
                    break;
                case "MemRead":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"True if the instruction reads memory";
                    break;
                case "MemtoReg":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"";
                    break;
                case "ALU Op":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"Operand to be fed to the ALU to determine operation.";
                    break;
                case "MemWrite":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"True if the instruction writes to memory.";
                    break;
                case "ALU Src":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"";
                    break;
                case "RegWrite":
                    InstructionOneLabel.Text = $"";
                    DescriptionLabel.Text = $"True if the instruction writes back to a register.";
                    break;
            }
        }
    }
}
