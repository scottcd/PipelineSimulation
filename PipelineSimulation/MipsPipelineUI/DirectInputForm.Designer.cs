
namespace MipsPipelineUI
{
    partial class DirectInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.loadInputButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(13, 13);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(394, 237);
            this.inputBox.TabIndex = 0;
            this.inputBox.Text = "";
            // 
            // loadInputButton
            // 
            this.loadInputButton.Location = new System.Drawing.Point(13, 256);
            this.loadInputButton.Name = "loadInputButton";
            this.loadInputButton.Size = new System.Drawing.Size(394, 35);
            this.loadInputButton.TabIndex = 1;
            this.loadInputButton.Text = "Load Input";
            this.loadInputButton.UseVisualStyleBackColor = true;
            this.loadInputButton.Click += new System.EventHandler(this.loadInputButton_Click);
            // 
            // DirectInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 303);
            this.Controls.Add(this.loadInputButton);
            this.Controls.Add(this.inputBox);
            this.Name = "DirectInputForm";
            this.ShowIcon = false;
            this.Text = "Direct Input";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputBox;
        private System.Windows.Forms.Button loadInputButton;
    }
}