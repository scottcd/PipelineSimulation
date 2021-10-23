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

namespace MipsPipelineUI {
    public partial class SimulationForm : Form {
        public SimulationForm() {
            InitializeComponent();
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {

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

        private void stepButton_Click(object sender, EventArgs e)
        {

        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {

        }

        private void loadInstructions(string instructions) 
        {
            
        }
    }
}
