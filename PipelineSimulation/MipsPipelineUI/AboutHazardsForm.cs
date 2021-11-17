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
    public partial class AboutHazardsForm : Form {
        public AboutHazardsForm() {
            InitializeComponent();

            List<string> controls = new List<string>{
                "Data Hazard",
                "Memory Hazard",
                "Structural Hazard"
            };

            HazardsBox.DataSource = controls.ToList();

        }

        private void GetDisplay(string currentKey) {
            switch (currentKey) {
                case "Data Hazard":
                    InstructionOneLabel.Text = $"mul $1,$2,$3";
                    InstructionTwoLabel.Text = $"add $8,$1,$7";
                    DescriptionLabel.Text = $"Occurs when two instructions need the same register." +
                        $"\nCan take three forms:\n    Read after Write\n    Write after Read\n    Write after Write";
                    break;
                case "Memory Hazard":
                    InstructionOneLabel.Text = $"sw $1,100($2)";
                    InstructionTwoLabel.Text = $"lw $3,100($2)";
                    DescriptionLabel.Text = $"Occurs when two instructions need the same address in memory.";
                    break;
                case "Structural Hazard":
                    InstructionOneLabel.Text = $"div.s $1,$2,$3";
                    InstructionTwoLabel.Text = $"add $1,$2,$3";
                    DescriptionLabel.Text = $"Occurs when two instructions need the same resource.";
                    break;
            }
        }

        private void HazardsBox_SelectedValueChanged(object sender, EventArgs e) {
            string key = (string)HazardsBox.SelectedItem;
            GetDisplay(key);
        }
    }
}
