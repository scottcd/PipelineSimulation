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
    public partial class RunReport : Form
    {
        string newStats;
        public RunReport(string stats)
        {
            InitializeComponent();
            newStats = stats;
            DisplayStats();
        }

        private void DisplayStats()
        {
            richTextBox.Text = newStats;
        }
    }
}
