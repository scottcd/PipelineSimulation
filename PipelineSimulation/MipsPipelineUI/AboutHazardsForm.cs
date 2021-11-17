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

        private void InstructionComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            string key = (string)HazardsBox.SelectedItem;
            GetDisplay(key);
        }
        private void GetDisplay(string currentKey) {
            switch (currentKey) {
                case "Data Hazard":
                    InstructionOneLabel.Text = $"";
                    InstructionTwoLabel.Text = $"";
                    DescriptionLabel.Text = $"";
                    break;
                case "Memory Hazard":
                    InstructionOneLabel.Text = $"";
                    InstructionTwoLabel.Text = $"";
                    DescriptionLabel.Text = $"";
                    break;
                case "Structural Hazard":
                    InstructionOneLabel.Text = $"";
                    InstructionTwoLabel.Text = $"";
                    DescriptionLabel.Text = $"";
                    break;
            }
        }
    }
}
