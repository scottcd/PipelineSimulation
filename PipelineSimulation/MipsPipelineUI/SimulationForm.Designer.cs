
namespace MipsPipelineUI {
    partial class SimulationForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationForm));
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.cycleTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pipelinePictureBox = new System.Windows.Forms.PictureBox();
            this.loadMenuStrip = new System.Windows.Forms.MenuStrip();
            this.loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDirectInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pipelinePictureBox)).BeginInit();
            this.loadMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.infoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoBox.Location = new System.Drawing.Point(927, 27);
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(219, 469);
            this.infoBox.TabIndex = 3;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Some Text";
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadButton.Location = new System.Drawing.Point(927, 502);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(219, 37);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(927, 545);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(105, 37);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stepButton.Location = new System.Drawing.Point(1038, 545);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(108, 37);
            this.stepButton.TabIndex = 2;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // cycleTimer
            // 
            this.cycleTimer.Interval = 1500;
            this.cycleTimer.Tick += new System.EventHandler(this.cycleTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pipelinePictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 555);
            this.panel1.TabIndex = 4;
            // 
            // pipelinePictureBox
            // 
            this.pipelinePictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pipelinePictureBox.BackgroundImage")));
            this.pipelinePictureBox.Location = new System.Drawing.Point(1, 0);
            this.pipelinePictureBox.Name = "pipelinePictureBox";
            this.pipelinePictureBox.Size = new System.Drawing.Size(908, 555);
            this.pipelinePictureBox.TabIndex = 0;
            this.pipelinePictureBox.TabStop = false;
            // 
            // loadMenuStrip
            // 
            this.loadMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenu});
            this.loadMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.loadMenuStrip.Name = "loadMenuStrip";
            this.loadMenuStrip.Size = new System.Drawing.Size(1158, 24);
            this.loadMenuStrip.TabIndex = 5;
            this.loadMenuStrip.Text = "menuStrip1";
            // 
            // loadMenu
            // 
            this.loadMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileMenuItem,
            this.loadDirectInputMenuItem});
            this.loadMenu.Name = "loadMenu";
            this.loadMenu.Size = new System.Drawing.Size(45, 20);
            this.loadMenu.Text = "Load";
            // 
            // loadFileMenuItem
            // 
            this.loadFileMenuItem.Name = "loadFileMenuItem";
            this.loadFileMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadFileMenuItem.Text = "From File";
            this.loadFileMenuItem.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // loadDirectInputMenuItem
            // 
            this.loadDirectInputMenuItem.Name = "loadDirectInputMenuItem";
            this.loadDirectInputMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadDirectInputMenuItem.Text = "Direct Input";
            this.loadDirectInputMenuItem.Click += new System.EventHandler(this.loadDirectInputMenuItem_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "Open File";
            this.openDialog.Filter = "txt files (*.txt)|*.txt";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.loadMenuStrip);
            this.MaximumSize = new System.Drawing.Size(1174, 637);
            this.MinimumSize = new System.Drawing.Size(1174, 637);
            this.Name = "SimulationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mips Simulation";
            this.Load += new System.EventHandler(this.SimulationForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pipelinePictureBox)).EndInit();
            this.loadMenuStrip.ResumeLayout(false);
            this.loadMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox infoBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pipelinePictureBox;
        private System.Windows.Forms.MenuStrip loadMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadMenu;
        private System.Windows.Forms.ToolStripMenuItem loadFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDirectInputMenuItem;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}

