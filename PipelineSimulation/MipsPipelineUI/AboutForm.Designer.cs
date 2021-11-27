
namespace MipsPipelineUI
{
    partial class AboutForm
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
            this.aboutMenuStrip = new System.Windows.Forms.MenuStrip();
            this.aboutInstructionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutRegistersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutControlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutStagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHazardsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox = new System.Windows.Forms.ListBox();
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.aboutMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutMenuStrip
            // 
            this.aboutMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutInstructionsMenuItem,
            this.aboutRegistersMenuItem,
            this.aboutControlMenuItem,
            this.aboutStagesMenuItem,
            this.aboutHazardsMenuItem});
            this.aboutMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.aboutMenuStrip.Name = "aboutMenuStrip";
            this.aboutMenuStrip.Size = new System.Drawing.Size(675, 24);
            this.aboutMenuStrip.TabIndex = 0;
            this.aboutMenuStrip.Text = "menuStrip1";
            // 
            // aboutInstructionsMenuItem
            // 
            this.aboutInstructionsMenuItem.Name = "aboutInstructionsMenuItem";
            this.aboutInstructionsMenuItem.Size = new System.Drawing.Size(81, 20);
            this.aboutInstructionsMenuItem.Text = "Instructions";
            this.aboutInstructionsMenuItem.Click += new System.EventHandler(this.aboutInstructionsMenuItem_Click);
            // 
            // aboutRegistersMenuItem
            // 
            this.aboutRegistersMenuItem.Name = "aboutRegistersMenuItem";
            this.aboutRegistersMenuItem.Size = new System.Drawing.Size(66, 20);
            this.aboutRegistersMenuItem.Text = "Registers";
            this.aboutRegistersMenuItem.Click += new System.EventHandler(this.aboutRegistersMenuItem_Click);
            // 
            // aboutControlMenuItem
            // 
            this.aboutControlMenuItem.Name = "aboutControlMenuItem";
            this.aboutControlMenuItem.Size = new System.Drawing.Size(91, 20);
            this.aboutControlMenuItem.Text = "Control Logic";
            this.aboutControlMenuItem.Click += new System.EventHandler(this.aboutControlMenuItem_Click);
            // 
            // aboutStagesMenuItem
            // 
            this.aboutStagesMenuItem.Name = "aboutStagesMenuItem";
            this.aboutStagesMenuItem.Size = new System.Drawing.Size(53, 20);
            this.aboutStagesMenuItem.Text = "Stages";
            this.aboutStagesMenuItem.Click += new System.EventHandler(this.aboutStagesMenuItem_Click);
            // 
            // aboutHazardsMenuItem
            // 
            this.aboutHazardsMenuItem.Name = "aboutHazardsMenuItem";
            this.aboutHazardsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutHazardsMenuItem.Text = "Hazards";
            this.aboutHazardsMenuItem.Click += new System.EventHandler(this.aboutHazardsMenuItem_Click);
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 18;
            this.listBox.Location = new System.Drawing.Point(12, 27);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(239, 328);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.SystemColors.Window;
            this.infoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoBox.Location = new System.Drawing.Point(257, 27);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(406, 334);
            this.infoBox.TabIndex = 2;
            this.infoBox.Text = "";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 371);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.aboutMenuStrip);
            this.MainMenuStrip = this.aboutMenuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(691, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(691, 410);
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.aboutInstructionsMenuItem_Click);
            this.aboutMenuStrip.ResumeLayout(false);
            this.aboutMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip aboutMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutHazardsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutInstructionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutRegistersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutStagesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutControlMenuItem;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.RichTextBox infoBox;
    }
}