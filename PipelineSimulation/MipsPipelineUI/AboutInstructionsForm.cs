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
    public partial class AboutInstructionsForm : Form {
        public OpcodeEnum CurrentKey { get; private set; }
        public Processor Processor { get; set; }
        public AboutInstructionsForm(Processor processor) {
            if (processor is null) {
                processor = new Processor(1500);
            }
            
            InitializeComponent();
            Processor = processor;
            InstructionComboBox.DataSource = Processor.ExecutionCycleDictionary.Keys.ToList();
            CurrentKey = (OpcodeEnum)InstructionComboBox.SelectedItem;

            InstructionNameLabel.Text = $"";
            SyntaxLabel.Text = $"";
            OpcodeLabel.Text = $"";
            Argument1Label.Text = $"";
            Argument2Label.Text = $"";
            Argument3Label.Text = $"";
            DescriptionLabel.Text = $"";
        }

        private void InstructionComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            CurrentKey = (OpcodeEnum)InstructionComboBox.SelectedItem;
            GetDisplay(CurrentKey);
        }

        private void GetDisplay(OpcodeEnum op) {
            switch (op) {
                case OpcodeEnum.add:
                    InstructionNameLabel.Text = $"add";
                    SyntaxLabel.Text = $"add $1,$2,$0";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.add_s:
                    InstructionNameLabel.Text = $"floating add";
                    SyntaxLabel.Text = $"add.s $1,$2,$0";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.sub:
                    InstructionNameLabel.Text = $"subtract";
                    SyntaxLabel.Text = $"sub $1,$2,$0";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.sub_s:
                    InstructionNameLabel.Text = $"floating subtract";
                    SyntaxLabel.Text = $"sub.s $1,$2,$0";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.mul_s:
                    InstructionNameLabel.Text = $"floating multiply";
                    SyntaxLabel.Text = $"mul.s $1,$2,$0";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.div_s:
                    InstructionNameLabel.Text = $"floating divide";
                    SyntaxLabel.Text = $"div.s $1,$2,$0";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.beq:
                    InstructionNameLabel.Text = $"branch if equal";
                    SyntaxLabel.Text = $"beq $1,$2,100";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: immediate";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.bne:
                    InstructionNameLabel.Text = $"branch if not equal";
                    SyntaxLabel.Text = $"bne $1,$2,100";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: register";
                    Argument3Label.Text = $"arg3: immediate";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.lw:
                    InstructionNameLabel.Text = $"load word";
                    SyntaxLabel.Text = $"lw $1,100($0)";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: immediate";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.sw:
                    InstructionNameLabel.Text = $"store word";
                    SyntaxLabel.Text = $"sw $1,100($0)";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: immediate";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.l_s:
                    InstructionNameLabel.Text = $"floating load word";
                    SyntaxLabel.Text = $"lw.s $1,100($0)";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: immediate";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
                case OpcodeEnum.s_s:
                    InstructionNameLabel.Text = $"floating store word";
                    SyntaxLabel.Text = $"sw.s $1,100($0)";
                    OpcodeLabel.Text = $"Opcode: {op}";
                    Argument1Label.Text = $"arg1: register";
                    Argument2Label.Text = $"arg2: immediate";
                    Argument3Label.Text = $"arg3: register";
                    DescriptionLabel.Text = $"";
                    break;
            }
        }

        private void AboutInstructionsForm_Load(object sender, EventArgs e) {

        }
    }
}
