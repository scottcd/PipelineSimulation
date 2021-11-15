
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
            this.InstructionTextBox = new System.Windows.Forms.RichTextBox();
            this.stepButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.cycleTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadMenuStrip = new System.Windows.Forms.MenuStrip();
            this.loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.compileProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionLatenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pipelineStagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProcessorStateBox = new System.Windows.Forms.RichTextBox();
            this.StatisticsTextBox = new System.Windows.Forms.RichTextBox();
            this.PotentialHazardsTextBox = new System.Windows.Forms.RichTextBox();
            this.DetectedHazardsTextBox = new System.Windows.Forms.RichTextBox();
            this.loadMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstructionTextBox
            // 
            this.InstructionTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.InstructionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InstructionTextBox.Location = new System.Drawing.Point(927, 27);
            this.InstructionTextBox.Name = "InstructionTextBox";
            this.InstructionTextBox.ReadOnly = true;
            this.InstructionTextBox.Size = new System.Drawing.Size(219, 221);
            this.InstructionTextBox.TabIndex = 3;
            this.InstructionTextBox.TabStop = false;
            this.InstructionTextBox.Text = "Some Text";
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stepButton.Location = new System.Drawing.Point(927, 502);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(216, 37);
            this.stepButton.TabIndex = 0;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(927, 545);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(216, 37);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // cycleTimer
            // 
            this.cycleTimer.Interval = 500;
            this.cycleTimer.Tick += new System.EventHandler(this.cycleTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(225, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 458);
            this.panel1.TabIndex = 4;
            // 
            // loadMenuStrip
            // 
            this.loadMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenu,
            this.configToolStripMenuItem,
            this.aboutToolStripMenuItem});
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
            this.compileProgramToolStripMenuItem});
            this.loadMenu.Name = "loadMenu";
            this.loadMenu.Size = new System.Drawing.Size(37, 20);
            this.loadMenu.Text = "File";
            // 
            // loadFileMenuItem
            // 
            this.loadFileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.loadFileMenuItem.Name = "loadFileMenuItem";
            this.loadFileMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loadFileMenuItem.Text = "Load Program";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "From File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "Direct Input";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.loadDirectInputMenuItem_Click);
            // 
            // compileProgramToolStripMenuItem
            // 
            this.compileProgramToolStripMenuItem.Name = "compileProgramToolStripMenuItem";
            this.compileProgramToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.compileProgramToolStripMenuItem.Text = "Compile Program";
            this.compileProgramToolStripMenuItem.Click += new System.EventHandler(this.compileProgramToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionLatenciesToolStripMenuItem,
            this.clockSpeedToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // instructionLatenciesToolStripMenuItem
            // 
            this.instructionLatenciesToolStripMenuItem.Name = "instructionLatenciesToolStripMenuItem";
            this.instructionLatenciesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.instructionLatenciesToolStripMenuItem.Text = "Instruction Latencies";
            this.instructionLatenciesToolStripMenuItem.Click += new System.EventHandler(this.instructionLatenciesToolStripMenuItem_Click);
            // 
            // clockSpeedToolStripMenuItem
            // 
            this.clockSpeedToolStripMenuItem.Name = "clockSpeedToolStripMenuItem";
            this.clockSpeedToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.clockSpeedToolStripMenuItem.Text = "Clock Speed";
            this.clockSpeedToolStripMenuItem.Click += new System.EventHandler(this.clockSpeedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.registersToolStripMenuItem,
            this.pipelineStagesToolStripMenuItem,
            this.controlUnitToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // registersToolStripMenuItem
            // 
            this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            this.registersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registersToolStripMenuItem.Text = "Registers";
            this.registersToolStripMenuItem.Click += new System.EventHandler(this.registersToolStripMenuItem_Click);
            // 
            // pipelineStagesToolStripMenuItem
            // 
            this.pipelineStagesToolStripMenuItem.Name = "pipelineStagesToolStripMenuItem";
            this.pipelineStagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pipelineStagesToolStripMenuItem.Text = "Pipeline Stages";
            this.pipelineStagesToolStripMenuItem.Click += new System.EventHandler(this.pipelineStagesToolStripMenuItem_Click);
            // 
            // controlUnitToolStripMenuItem
            // 
            this.controlUnitToolStripMenuItem.Name = "controlUnitToolStripMenuItem";
            this.controlUnitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlUnitToolStripMenuItem.Text = "Control Unit";
            this.controlUnitToolStripMenuItem.Click += new System.EventHandler(this.controlUnitToolStripMenuItem_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "Open File";
            this.openDialog.Filter = "txt files (*.txt)|*.txt";
            // 
            // ProcessorStateBox
            // 
            this.ProcessorStateBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProcessorStateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessorStateBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProcessorStateBox.Location = new System.Drawing.Point(927, 265);
            this.ProcessorStateBox.Name = "ProcessorStateBox";
            this.ProcessorStateBox.ReadOnly = true;
            this.ProcessorStateBox.Size = new System.Drawing.Size(219, 221);
            this.ProcessorStateBox.TabIndex = 6;
            this.ProcessorStateBox.TabStop = false;
            this.ProcessorStateBox.Text = "Some Text";
            // 
            // StatisticsTextBox
            // 
            this.StatisticsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatisticsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatisticsTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatisticsTextBox.Location = new System.Drawing.Point(12, 27);
            this.StatisticsTextBox.Name = "StatisticsTextBox";
            this.StatisticsTextBox.ReadOnly = true;
            this.StatisticsTextBox.Size = new System.Drawing.Size(207, 555);
            this.StatisticsTextBox.TabIndex = 7;
            this.StatisticsTextBox.TabStop = false;
            this.StatisticsTextBox.Text = "Some Text";
            // 
            // PotentialHazardsTextBox
            // 
            this.PotentialHazardsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PotentialHazardsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PotentialHazardsTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PotentialHazardsTextBox.Location = new System.Drawing.Point(225, 27);
            this.PotentialHazardsTextBox.Name = "PotentialHazardsTextBox";
            this.PotentialHazardsTextBox.ReadOnly = true;
            this.PotentialHazardsTextBox.Size = new System.Drawing.Size(345, 91);
            this.PotentialHazardsTextBox.TabIndex = 8;
            this.PotentialHazardsTextBox.TabStop = false;
            this.PotentialHazardsTextBox.Text = "Some Text";
            // 
            // DetectedHazardsTextBox
            // 
            this.DetectedHazardsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DetectedHazardsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetectedHazardsTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetectedHazardsTextBox.Location = new System.Drawing.Point(585, 27);
            this.DetectedHazardsTextBox.Name = "DetectedHazardsTextBox";
            this.DetectedHazardsTextBox.ReadOnly = true;
            this.DetectedHazardsTextBox.Size = new System.Drawing.Size(336, 91);
            this.DetectedHazardsTextBox.TabIndex = 9;
            this.DetectedHazardsTextBox.TabStop = false;
            this.DetectedHazardsTextBox.Text = "Some Text";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 598);
            this.Controls.Add(this.DetectedHazardsTextBox);
            this.Controls.Add(this.PotentialHazardsTextBox);
            this.Controls.Add(this.StatisticsTextBox);
            this.Controls.Add(this.ProcessorStateBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.InstructionTextBox);
            this.Controls.Add(this.loadMenuStrip);
            this.MaximumSize = new System.Drawing.Size(1174, 637);
            this.MinimumSize = new System.Drawing.Size(1174, 637);
            this.Name = "SimulationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mips Simulation";
            this.loadMenuStrip.ResumeLayout(false);
            this.loadMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox InstructionTextBox;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip loadMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadMenu;
        private System.Windows.Forms.ToolStripMenuItem loadFileMenuItem;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem compileProgramToolStripMenuItem;
        private System.Windows.Forms.RichTextBox ProcessorStateBox;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionLatenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clockSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pipelineStagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlUnitToolStripMenuItem;
        private System.Windows.Forms.RichTextBox StatisticsTextBox;
        private System.Windows.Forms.RichTextBox PotentialHazardsTextBox;
        private System.Windows.Forms.RichTextBox DetectedHazardsTextBox;
    }
}

