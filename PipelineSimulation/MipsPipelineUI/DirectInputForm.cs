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
    public partial class DirectInputForm : Form
    {

        public string DirectInput;

        public DirectInputForm()
        {
            InitializeComponent();
        }

        private void loadInputButton_Click(object sender, EventArgs e)
        {
            DirectInput = inputBox.Text;
            DialogResult = DialogResult.OK;
            
            Close();
        }
    }
}
