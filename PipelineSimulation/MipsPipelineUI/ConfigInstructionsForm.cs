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

namespace MipsPipelineUI {
    public partial class ConfigInstructionsForm : Form {
        public Processor Processor { get; set; }
        public OpcodeEnum CurrentKey { get; set; }
        public int ExecutionCycles {get;set;}
        public ConfigInstructionsForm(Processor processor) {
            InitializeComponent();
            Processor = processor;
            InstructionBox.DataSource = Processor.ExecutionCycleDictionary.Keys.ToList();
            CurrentKey = (OpcodeEnum)InstructionBox.SelectedItem;
            int value = Processor.ExecutionCycleDictionary[CurrentKey];
            CyclesInput.Text = $"{value}";
        }

        private void InstructionBox_SelectedValueChanged(object sender, EventArgs e) {
            CurrentKey = (OpcodeEnum)InstructionBox.SelectedItem;
            int value = Processor.ExecutionCycleDictionary[CurrentKey];
            CyclesInput.Text = $"{value}";
        }

        private void ApplyButton_Click(object sender, EventArgs e) {
            if (int.TryParse(CyclesInput.Text, out int cycles)) {
                ExecutionCycles = cycles;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
