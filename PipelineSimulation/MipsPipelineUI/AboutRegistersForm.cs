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
    public partial class AboutRegistersForm : Form {
        public RegisterEnum CurrentKey { get; private set; }
        public Processor Processor { get; set; }
        public AboutRegistersForm(Processor processor) {
            if (processor is null) {
                processor = new Processor(1500);
            }

            InitializeComponent();
            Processor = processor;
            InstructionComboBox.DataSource = Processor.Registers.Keys.ToList();
            CurrentKey = (RegisterEnum)InstructionComboBox.SelectedItem;
        }

        private void InstructionComboBox_SelectedValueChanged(object sender, EventArgs e) {
            CurrentKey = (RegisterEnum)InstructionComboBox.SelectedItem;
            GetDisplay(CurrentKey);
        }

        private void GetDisplay(RegisterEnum currentKey) {
            switch (currentKey) {
                case RegisterEnum.r0:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"zero-register";
                    AssemblyNameLabel.Text = $"$zero";
                    break;
                case RegisterEnum.r1:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"reserved for assembler";
                    AssemblyNameLabel.Text = $"at";
                    break;
                case RegisterEnum.r2:
                    AssemblyNameLabel.Text = $"$v0";
                    goto case RegisterEnum.r3;
                case RegisterEnum.r3:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"result register";
                    AssemblyNameLabel.Text = $"$v1";
                    break;
                case RegisterEnum.r4:
                    AssemblyNameLabel.Text = $"$a0";
                    goto case RegisterEnum.r7;
                case RegisterEnum.r5:
                    AssemblyNameLabel.Text = $"$a1";
                    goto case RegisterEnum.r7;
                case RegisterEnum.r6:
                    AssemblyNameLabel.Text = $"$a2";
                    goto case RegisterEnum.r7;
                case RegisterEnum.r7:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"argument register";
                    AssemblyNameLabel.Text = $"$a3";
                    break;
                case RegisterEnum.r8:
                    AssemblyNameLabel.Text = $"$t0";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r9:
                    AssemblyNameLabel.Text = $"$t1";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r10:
                    AssemblyNameLabel.Text = $"$t2";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r11:
                    AssemblyNameLabel.Text = $"$t3";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r12:
                    AssemblyNameLabel.Text = $"$t4";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r13:
                    AssemblyNameLabel.Text = $"$t5";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r14:
                    AssemblyNameLabel.Text = $"$t6";
                    goto case RegisterEnum.r15;
                case RegisterEnum.r15:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"temporary register";
                    AssemblyNameLabel.Text = $"$t7";
                    break;
                case RegisterEnum.r16:
                    AssemblyNameLabel.Text = $"$s0";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r17:
                    AssemblyNameLabel.Text = $"$s1";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r18:
                    AssemblyNameLabel.Text = $"$s2";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r19:
                    AssemblyNameLabel.Text = $"$s3";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r20:
                    AssemblyNameLabel.Text = $"$s4";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r21:
                    AssemblyNameLabel.Text = $"$s5";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r22:
                    AssemblyNameLabel.Text = $"$s6";
                    goto case RegisterEnum.r23;
                case RegisterEnum.r23:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"saved register";
                    AssemblyNameLabel.Text = $"$s7";
                    break;
                case RegisterEnum.r24:
                    AssemblyNameLabel.Text = $"$t8";
                    goto case RegisterEnum.r25;
                case RegisterEnum.r25:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"temporary register";
                    AssemblyNameLabel.Text = $"$t9";
                    break;
                case RegisterEnum.r26:
                    AssemblyNameLabel.Text = $"$k0";
                    goto case RegisterEnum.r27;
                case RegisterEnum.r27:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"kernel register";
                    AssemblyNameLabel.Text = $"$k1";
                    break;
                case RegisterEnum.r28:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"global pointer";
                    AssemblyNameLabel.Text = $"$gp";
                    break;
                case RegisterEnum.r29:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"stack pointer";
                    AssemblyNameLabel.Text = $"$sp";
                    break;
                case RegisterEnum.r30:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"frame pointer";
                    AssemblyNameLabel.Text = $"$fp";
                    break;
                case RegisterEnum.r31:
                    RegisterNumberLabel.Text = $"{currentKey}";
                    RegisterPurposeLabel.Text = $"return address";
                    AssemblyNameLabel.Text = $"$ra";
                    break;
            }
        }
    }
}
