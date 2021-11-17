
namespace MipsPipelineUI {
    partial class AboutRegistersForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.InstructionComboBox = new System.Windows.Forms.ComboBox();
            this.RegisterNumberLabel = new System.Windows.Forms.Label();
            this.AssemblyNameLabel = new System.Windows.Forms.Label();
            this.RegisterPurposeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "MIPS Registers";
            // 
            // InstructionComboBox
            // 
            this.InstructionComboBox.FormattingEnabled = true;
            this.InstructionComboBox.Location = new System.Drawing.Point(200, 30);
            this.InstructionComboBox.Name = "InstructionComboBox";
            this.InstructionComboBox.Size = new System.Drawing.Size(121, 23);
            this.InstructionComboBox.TabIndex = 2;
            this.InstructionComboBox.SelectedValueChanged += new System.EventHandler(this.InstructionComboBox_SelectedValueChanged);
            // 
            // RegisterNumberLabel
            // 
            this.RegisterNumberLabel.AutoSize = true;
            this.RegisterNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegisterNumberLabel.Location = new System.Drawing.Point(29, 102);
            this.RegisterNumberLabel.Name = "RegisterNumberLabel";
            this.RegisterNumberLabel.Size = new System.Drawing.Size(38, 15);
            this.RegisterNumberLabel.TabIndex = 3;
            this.RegisterNumberLabel.Text = "label2";
            // 
            // AssemblyNameLabel
            // 
            this.AssemblyNameLabel.AutoSize = true;
            this.AssemblyNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AssemblyNameLabel.Location = new System.Drawing.Point(245, 102);
            this.AssemblyNameLabel.Name = "AssemblyNameLabel";
            this.AssemblyNameLabel.Size = new System.Drawing.Size(38, 15);
            this.AssemblyNameLabel.TabIndex = 4;
            this.AssemblyNameLabel.Text = "label3";
            // 
            // RegisterPurposeLabel
            // 
            this.RegisterPurposeLabel.AutoSize = true;
            this.RegisterPurposeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegisterPurposeLabel.Location = new System.Drawing.Point(105, 102);
            this.RegisterPurposeLabel.Name = "RegisterPurposeLabel";
            this.RegisterPurposeLabel.Size = new System.Drawing.Size(38, 15);
            this.RegisterPurposeLabel.TabIndex = 5;
            this.RegisterPurposeLabel.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(97, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Purpose:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(209, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "Assembly Syntax:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(11, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Number:";
            // 
            // AboutRegistersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RegisterPurposeLabel);
            this.Controls.Add(this.AssemblyNameLabel);
            this.Controls.Add(this.RegisterNumberLabel);
            this.Controls.Add(this.InstructionComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AboutRegistersForm";
            this.Text = "AboutRegisters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox InstructionComboBox;
        private System.Windows.Forms.Label RegisterNumberLabel;
        private System.Windows.Forms.Label AssemblyNameLabel;
        private System.Windows.Forms.Label RegisterPurposeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}