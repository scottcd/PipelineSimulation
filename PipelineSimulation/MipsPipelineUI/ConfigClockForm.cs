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
    public partial class ConfigClockForm : Form {
        public int CPU_Speed { get; set; }

        public ConfigClockForm(int ClockSpeed) {
            InitializeComponent();
            ClockSpeedInput.Text = $"{ClockSpeed}";
        }

        private void ApplyButton_Click(object sender, EventArgs e) {
            if (int.TryParse(ClockSpeedInput.Text, out int speed)) {
                CPU_Speed = speed;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
