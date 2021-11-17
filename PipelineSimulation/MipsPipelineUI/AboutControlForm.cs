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
                    InstructionOneLabel.Text = $"add $1,$2,$3";
                    DescriptionLabel.Text = $"Determines how the destination register is specified ";
                    break;
                case "Branch":
                    InstructionOneLabel.Text = $"beq $1,$2,16";
                    DescriptionLabel.Text = $"Combined with a condition test boolean to enable loading the \nbranch target address into the PC.";
                    break;
                case "MemRead":
                    InstructionOneLabel.Text = $"lw $1,200($3)";
                    DescriptionLabel.Text = $"Enables a memory read for load instructions.";
                    break;
                case "MemtoReg":
                    InstructionOneLabel.Text = $"lw $1,200($3)";
                    DescriptionLabel.Text = $"Determines where the value to be written comes from ";
                    break;
                case "ALU Op":
                    InstructionOneLabel.Text = $"add $1,$2,$3";
                    DescriptionLabel.Text = $"Either specifies the ALU operation to be performed or specifies \nthat the operation should be determined from the function bits.";
                    break;
                case "MemWrite":
                    InstructionOneLabel.Text = $"sw $1,200($3)";
                    DescriptionLabel.Text = $"Enables a memory write for store instructions.";
                    break;
                case "ALU Src":
                    InstructionOneLabel.Text = $"sw $1,200($3)";
                    DescriptionLabel.Text = $"Selects the second source operand for the ALU";
                    break;
                case "RegWrite":
                    InstructionOneLabel.Text = $"add $1,$2,$3";
                    DescriptionLabel.Text = $"Enables a write to one of the registers.";
                    break;
            }
        }
    }
}
