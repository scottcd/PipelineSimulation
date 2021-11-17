
namespace MipsPipelineUI {
    partial class AboutInstructionsForm {
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
            this.OpcodeLabel = new System.Windows.Forms.Label();
            this.Argument3Label = new System.Windows.Forms.Label();
            this.Argument2Label = new System.Windows.Forms.Label();
            this.Argument1Label = new System.Windows.Forms.Label();
            this.SyntaxLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.InstructionNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MIPS Instructions";
            // 
            // InstructionComboBox
            // 
            this.InstructionComboBox.FormattingEnabled = true;
            this.InstructionComboBox.Location = new System.Drawing.Point(200, 29);
            this.InstructionComboBox.Name = "InstructionComboBox";
            this.InstructionComboBox.Size = new System.Drawing.Size(121, 23);
            this.InstructionComboBox.TabIndex = 1;
            this.InstructionComboBox.SelectionChangeCommitted += new System.EventHandler(this.InstructionComboBox_SelectionChangeCommitted);
            // 
            // OpcodeLabel
            // 
            this.OpcodeLabel.AutoSize = true;
            this.OpcodeLabel.Location = new System.Drawing.Point(30, 135);
            this.OpcodeLabel.Name = "OpcodeLabel";
            this.OpcodeLabel.Size = new System.Drawing.Size(24, 15);
            this.OpcodeLabel.TabIndex = 2;
            this.OpcodeLabel.Text = " op";
            // 
            // Argument3Label
            // 
            this.Argument3Label.AutoSize = true;
            this.Argument3Label.Location = new System.Drawing.Point(30, 222);
            this.Argument3Label.Name = "Argument3Label";
            this.Argument3Label.Size = new System.Drawing.Size(30, 15);
            this.Argument3Label.TabIndex = 3;
            this.Argument3Label.Text = "arg3";
            // 
            // Argument2Label
            // 
            this.Argument2Label.AutoSize = true;
            this.Argument2Label.Location = new System.Drawing.Point(30, 193);
            this.Argument2Label.Name = "Argument2Label";
            this.Argument2Label.Size = new System.Drawing.Size(30, 15);
            this.Argument2Label.TabIndex = 4;
            this.Argument2Label.Text = "arg2";
            // 
            // Argument1Label
            // 
            this.Argument1Label.AutoSize = true;
            this.Argument1Label.Location = new System.Drawing.Point(30, 164);
            this.Argument1Label.Name = "Argument1Label";
            this.Argument1Label.Size = new System.Drawing.Size(30, 15);
            this.Argument1Label.TabIndex = 5;
            this.Argument1Label.Text = "arg1";
            // 
            // SyntaxLabel
            // 
            this.SyntaxLabel.AutoSize = true;
            this.SyntaxLabel.Location = new System.Drawing.Point(30, 103);
            this.SyntaxLabel.Name = "SyntaxLabel";
            this.SyntaxLabel.Size = new System.Drawing.Size(41, 15);
            this.SyntaxLabel.TabIndex = 6;
            this.SyntaxLabel.Text = "syntax";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(202, 209);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(0, 15);
            this.DescriptionLabel.TabIndex = 7;
            // 
            // InstructionNameLabel
            // 
            this.InstructionNameLabel.AutoSize = true;
            this.InstructionNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InstructionNameLabel.Location = new System.Drawing.Point(30, 71);
            this.InstructionNameLabel.Name = "InstructionNameLabel";
            this.InstructionNameLabel.Size = new System.Drawing.Size(49, 21);
            this.InstructionNameLabel.TabIndex = 8;
            this.InstructionNameLabel.Text = "name";
            // 
            // AboutInstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.InstructionNameLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.SyntaxLabel);
            this.Controls.Add(this.Argument1Label);
            this.Controls.Add(this.Argument2Label);
            this.Controls.Add(this.Argument3Label);
            this.Controls.Add(this.OpcodeLabel);
            this.Controls.Add(this.InstructionComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AboutInstructionsForm";
            this.Text = "AboutInstructions";
            this.Load += new System.EventHandler(this.AboutInstructionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox InstructionComboBox;
        private System.Windows.Forms.Label OpcodeLabel;
        private System.Windows.Forms.Label Argument3Label;
        private System.Windows.Forms.Label Argument2Label;
        private System.Windows.Forms.Label Argument1Label;
        private System.Windows.Forms.Label SyntaxLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label InstructionNameLabel;
    }
}