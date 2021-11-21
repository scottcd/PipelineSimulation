
using System;

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
            System.Windows.Forms.ToolStripMenuItem loadFileMenuItem;
            this.InstructionTextBox = new System.Windows.Forms.RichTextBox();
            this.stepButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.cycleTimer = new System.Windows.Forms.Timer(this.components);
            this.PipelinePanel = new System.Windows.Forms.Panel();
            this.ExecutionCyclesLabel = new System.Windows.Forms.Label();
            this.Mem_Value = new System.Windows.Forms.Label();
            this.RegWrite_WriteReg = new System.Windows.Forms.Label();
            this.RegWrite_Value = new System.Windows.Forms.Label();
            this.Mem_Address = new System.Windows.Forms.Label();
            this.Execute_Value2 = new System.Windows.Forms.Label();
            this.Execute_Value1 = new System.Windows.Forms.Label();
            this.Execute_Operation = new System.Windows.Forms.Label();
            this.Decode_Arg3 = new System.Windows.Forms.Label();
            this.Decode_Arg2 = new System.Windows.Forms.Label();
            this.Decode_Arg1 = new System.Windows.Forms.Label();
            this.Decode_Op = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Decode_Instruction = new System.Windows.Forms.Label();
            this.Execute_Instruction = new System.Windows.Forms.Label();
            this.Mem_Instruction = new System.Windows.Forms.Label();
            this.RegWrite_Instruction = new System.Windows.Forms.Label();
            this.Fetch_Instruction = new System.Windows.Forms.Label();
            this.IDEX_Control = new System.Windows.Forms.Label();
            this.EXMEM_Control = new System.Windows.Forms.Label();
            this.EXMEM_Value = new System.Windows.Forms.Label();
            this.MEMREG_Control = new System.Windows.Forms.Label();
            this.MEMREG_Value = new System.Windows.Forms.Label();
            this.ClockCycleLabel = new System.Windows.Forms.Label();
            this.MEMREG_Instruction = new System.Windows.Forms.Label();
            this.EXMEM_Instruction = new System.Windows.Forms.Label();
            this.IDEX_Instruction = new System.Windows.Forms.Label();
            this.IFID_Instruction = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loadMenuStrip = new System.Windows.Forms.MenuStrip();
            this.loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DirectInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionLatenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProcessorStateBox = new System.Windows.Forms.RichTextBox();
            this.StatisticsTextBox = new System.Windows.Forms.RichTextBox();
            this.PotentialHazardsTextBox = new System.Windows.Forms.RichTextBox();
            this.DetectedHazardsTextBox = new System.Windows.Forms.RichTextBox();
            loadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PipelinePanel.SuspendLayout();
            this.loadMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFileMenuItem
            // 
            loadFileMenuItem.Name = "loadFileMenuItem";
            loadFileMenuItem.Size = new System.Drawing.Size(152, 22);
            loadFileMenuItem.Text = "Load From File";
            loadFileMenuItem.Click += new System.EventHandler(this.loadFileMenuItem_Click);
            // 
            // InstructionTextBox
            // 
            this.InstructionTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.InstructionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InstructionTextBox.Location = new System.Drawing.Point(927, 27);
            this.InstructionTextBox.Name = "InstructionTextBox";
            this.InstructionTextBox.ReadOnly = true;
            this.InstructionTextBox.Size = new System.Drawing.Size(219, 257);
            this.InstructionTextBox.TabIndex = 3;
            this.InstructionTextBox.TabStop = false;
            this.InstructionTextBox.Text = "Some Text";
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stepButton.Location = new System.Drawing.Point(927, 538);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(216, 53);
            this.stepButton.TabIndex = 0;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(927, 595);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(216, 53);
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
            // PipelinePanel
            // 
            this.PipelinePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PipelinePanel.Controls.Add(this.ExecutionCyclesLabel);
            this.PipelinePanel.Controls.Add(this.Mem_Value);
            this.PipelinePanel.Controls.Add(this.RegWrite_WriteReg);
            this.PipelinePanel.Controls.Add(this.RegWrite_Value);
            this.PipelinePanel.Controls.Add(this.Mem_Address);
            this.PipelinePanel.Controls.Add(this.Execute_Value2);
            this.PipelinePanel.Controls.Add(this.Execute_Value1);
            this.PipelinePanel.Controls.Add(this.Execute_Operation);
            this.PipelinePanel.Controls.Add(this.Decode_Arg3);
            this.PipelinePanel.Controls.Add(this.Decode_Arg2);
            this.PipelinePanel.Controls.Add(this.Decode_Arg1);
            this.PipelinePanel.Controls.Add(this.Decode_Op);
            this.PipelinePanel.Controls.Add(this.label11);
            this.PipelinePanel.Controls.Add(this.label12);
            this.PipelinePanel.Controls.Add(this.label13);
            this.PipelinePanel.Controls.Add(this.label10);
            this.PipelinePanel.Controls.Add(this.Decode_Instruction);
            this.PipelinePanel.Controls.Add(this.Execute_Instruction);
            this.PipelinePanel.Controls.Add(this.Mem_Instruction);
            this.PipelinePanel.Controls.Add(this.RegWrite_Instruction);
            this.PipelinePanel.Controls.Add(this.Fetch_Instruction);
            this.PipelinePanel.Controls.Add(this.IDEX_Control);
            this.PipelinePanel.Controls.Add(this.EXMEM_Control);
            this.PipelinePanel.Controls.Add(this.EXMEM_Value);
            this.PipelinePanel.Controls.Add(this.MEMREG_Control);
            this.PipelinePanel.Controls.Add(this.MEMREG_Value);
            this.PipelinePanel.Controls.Add(this.ClockCycleLabel);
            this.PipelinePanel.Controls.Add(this.MEMREG_Instruction);
            this.PipelinePanel.Controls.Add(this.EXMEM_Instruction);
            this.PipelinePanel.Controls.Add(this.IDEX_Instruction);
            this.PipelinePanel.Controls.Add(this.IFID_Instruction);
            this.PipelinePanel.Controls.Add(this.label9);
            this.PipelinePanel.Controls.Add(this.label8);
            this.PipelinePanel.Controls.Add(this.label7);
            this.PipelinePanel.Controls.Add(this.label6);
            this.PipelinePanel.Controls.Add(this.label5);
            this.PipelinePanel.Controls.Add(this.label4);
            this.PipelinePanel.Controls.Add(this.label3);
            this.PipelinePanel.Controls.Add(this.label2);
            this.PipelinePanel.Controls.Add(this.label1);
            this.PipelinePanel.Location = new System.Drawing.Point(12, 177);
            this.PipelinePanel.Name = "PipelinePanel";
            this.PipelinePanel.Size = new System.Drawing.Size(909, 472);
            this.PipelinePanel.TabIndex = 4;
            // 
            // ExecutionCyclesLabel
            // 
            this.ExecutionCyclesLabel.AutoSize = true;
            this.ExecutionCyclesLabel.Location = new System.Drawing.Point(382, 253);
            this.ExecutionCyclesLabel.Name = "ExecutionCyclesLabel";
            this.ExecutionCyclesLabel.Size = new System.Drawing.Size(39, 15);
            this.ExecutionCyclesLabel.TabIndex = 38;
            this.ExecutionCyclesLabel.Text = "cycles";
            // 
            // Mem_Value
            // 
            this.Mem_Value.AutoSize = true;
            this.Mem_Value.Location = new System.Drawing.Point(582, 181);
            this.Mem_Value.Name = "Mem_Value";
            this.Mem_Value.Size = new System.Drawing.Size(35, 15);
            this.Mem_Value.TabIndex = 37;
            this.Mem_Value.Text = "value";
            // 
            // RegWrite_WriteReg
            // 
            this.RegWrite_WriteReg.AutoSize = true;
            this.RegWrite_WriteReg.Location = new System.Drawing.Point(791, 145);
            this.RegWrite_WriteReg.Name = "RegWrite_WriteReg";
            this.RegWrite_WriteReg.Size = new System.Drawing.Size(53, 15);
            this.RegWrite_WriteReg.TabIndex = 36;
            this.RegWrite_WriteReg.Text = "writeReg";
            // 
            // RegWrite_Value
            // 
            this.RegWrite_Value.AutoSize = true;
            this.RegWrite_Value.Location = new System.Drawing.Point(791, 181);
            this.RegWrite_Value.Name = "RegWrite_Value";
            this.RegWrite_Value.Size = new System.Drawing.Size(35, 15);
            this.RegWrite_Value.TabIndex = 35;
            this.RegWrite_Value.Text = "value";
            // 
            // Mem_Address
            // 
            this.Mem_Address.AutoSize = true;
            this.Mem_Address.Location = new System.Drawing.Point(582, 145);
            this.Mem_Address.Name = "Mem_Address";
            this.Mem_Address.Size = new System.Drawing.Size(47, 15);
            this.Mem_Address.TabIndex = 34;
            this.Mem_Address.Text = "address";
            // 
            // Execute_Value2
            // 
            this.Execute_Value2.AutoSize = true;
            this.Execute_Value2.Location = new System.Drawing.Point(382, 217);
            this.Execute_Value2.Name = "Execute_Value2";
            this.Execute_Value2.Size = new System.Drawing.Size(41, 15);
            this.Execute_Value2.TabIndex = 33;
            this.Execute_Value2.Text = "Value2";
            // 
            // Execute_Value1
            // 
            this.Execute_Value1.AutoSize = true;
            this.Execute_Value1.Location = new System.Drawing.Point(382, 181);
            this.Execute_Value1.Name = "Execute_Value1";
            this.Execute_Value1.Size = new System.Drawing.Size(41, 15);
            this.Execute_Value1.TabIndex = 32;
            this.Execute_Value1.Text = "Value1";
            // 
            // Execute_Operation
            // 
            this.Execute_Operation.AutoSize = true;
            this.Execute_Operation.Location = new System.Drawing.Point(382, 145);
            this.Execute_Operation.Name = "Execute_Operation";
            this.Execute_Operation.Size = new System.Drawing.Size(60, 15);
            this.Execute_Operation.TabIndex = 31;
            this.Execute_Operation.Text = "Operation";
            // 
            // Decode_Arg3
            // 
            this.Decode_Arg3.AutoSize = true;
            this.Decode_Arg3.Location = new System.Drawing.Point(183, 253);
            this.Decode_Arg3.Name = "Decode_Arg3";
            this.Decode_Arg3.Size = new System.Drawing.Size(30, 15);
            this.Decode_Arg3.TabIndex = 30;
            this.Decode_Arg3.Text = "arg3";
            // 
            // Decode_Arg2
            // 
            this.Decode_Arg2.AutoSize = true;
            this.Decode_Arg2.Location = new System.Drawing.Point(183, 217);
            this.Decode_Arg2.Name = "Decode_Arg2";
            this.Decode_Arg2.Size = new System.Drawing.Size(30, 15);
            this.Decode_Arg2.TabIndex = 29;
            this.Decode_Arg2.Text = "arg2";
            // 
            // Decode_Arg1
            // 
            this.Decode_Arg1.AutoSize = true;
            this.Decode_Arg1.Location = new System.Drawing.Point(183, 181);
            this.Decode_Arg1.Name = "Decode_Arg1";
            this.Decode_Arg1.Size = new System.Drawing.Size(30, 15);
            this.Decode_Arg1.TabIndex = 28;
            this.Decode_Arg1.Text = "arg1";
            // 
            // Decode_Op
            // 
            this.Decode_Op.AutoSize = true;
            this.Decode_Op.Location = new System.Drawing.Point(183, 145);
            this.Decode_Op.Name = "Decode_Op";
            this.Decode_Op.Size = new System.Drawing.Size(47, 15);
            this.Decode_Op.TabIndex = 27;
            this.Decode_Op.Text = "opcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(517, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 267);
            this.label11.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(323, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2, 267);
            this.label12.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(749, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(2, 267);
            this.label13.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(119, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 267);
            this.label10.TabIndex = 23;
            // 
            // Decode_Instruction
            // 
            this.Decode_Instruction.AutoSize = true;
            this.Decode_Instruction.Location = new System.Drawing.Point(183, 109);
            this.Decode_Instruction.Name = "Decode_Instruction";
            this.Decode_Instruction.Size = new System.Drawing.Size(64, 15);
            this.Decode_Instruction.TabIndex = 22;
            this.Decode_Instruction.Text = "instruction";
            // 
            // Execute_Instruction
            // 
            this.Execute_Instruction.AutoSize = true;
            this.Execute_Instruction.Location = new System.Drawing.Point(382, 109);
            this.Execute_Instruction.Name = "Execute_Instruction";
            this.Execute_Instruction.Size = new System.Drawing.Size(64, 15);
            this.Execute_Instruction.TabIndex = 21;
            this.Execute_Instruction.Text = "instruction";
            // 
            // Mem_Instruction
            // 
            this.Mem_Instruction.AutoSize = true;
            this.Mem_Instruction.Location = new System.Drawing.Point(582, 109);
            this.Mem_Instruction.Name = "Mem_Instruction";
            this.Mem_Instruction.Size = new System.Drawing.Size(64, 15);
            this.Mem_Instruction.TabIndex = 20;
            this.Mem_Instruction.Text = "instruction";
            // 
            // RegWrite_Instruction
            // 
            this.RegWrite_Instruction.AutoSize = true;
            this.RegWrite_Instruction.Location = new System.Drawing.Point(791, 109);
            this.RegWrite_Instruction.Name = "RegWrite_Instruction";
            this.RegWrite_Instruction.Size = new System.Drawing.Size(64, 15);
            this.RegWrite_Instruction.TabIndex = 19;
            this.RegWrite_Instruction.Text = "instruction";
            // 
            // Fetch_Instruction
            // 
            this.Fetch_Instruction.AutoSize = true;
            this.Fetch_Instruction.Location = new System.Drawing.Point(17, 109);
            this.Fetch_Instruction.Name = "Fetch_Instruction";
            this.Fetch_Instruction.Size = new System.Drawing.Size(64, 15);
            this.Fetch_Instruction.TabIndex = 18;
            this.Fetch_Instruction.Text = "instruction";
            // 
            // IDEX_Control
            // 
            this.IDEX_Control.AutoSize = true;
            this.IDEX_Control.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IDEX_Control.Location = new System.Drawing.Point(279, 395);
            this.IDEX_Control.Name = "IDEX_Control";
            this.IDEX_Control.Size = new System.Drawing.Size(58, 12);
            this.IDEX_Control.TabIndex = 17;
            this.IDEX_Control.Text = "control here";
            // 
            // EXMEM_Control
            // 
            this.EXMEM_Control.AutoSize = true;
            this.EXMEM_Control.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EXMEM_Control.Location = new System.Drawing.Point(473, 395);
            this.EXMEM_Control.Name = "EXMEM_Control";
            this.EXMEM_Control.Size = new System.Drawing.Size(58, 12);
            this.EXMEM_Control.TabIndex = 16;
            this.EXMEM_Control.Text = "control here";
            // 
            // EXMEM_Value
            // 
            this.EXMEM_Value.AutoSize = true;
            this.EXMEM_Value.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EXMEM_Value.Location = new System.Drawing.Point(473, 424);
            this.EXMEM_Value.Name = "EXMEM_Value";
            this.EXMEM_Value.Size = new System.Drawing.Size(50, 12);
            this.EXMEM_Value.TabIndex = 15;
            this.EXMEM_Value.Text = "value here";
            // 
            // MEMREG_Control
            // 
            this.MEMREG_Control.AutoSize = true;
            this.MEMREG_Control.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MEMREG_Control.Location = new System.Drawing.Point(705, 398);
            this.MEMREG_Control.Name = "MEMREG_Control";
            this.MEMREG_Control.Size = new System.Drawing.Size(58, 12);
            this.MEMREG_Control.TabIndex = 14;
            this.MEMREG_Control.Text = "control here";
            // 
            // MEMREG_Value
            // 
            this.MEMREG_Value.AutoSize = true;
            this.MEMREG_Value.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MEMREG_Value.Location = new System.Drawing.Point(705, 424);
            this.MEMREG_Value.Name = "MEMREG_Value";
            this.MEMREG_Value.Size = new System.Drawing.Size(50, 12);
            this.MEMREG_Value.TabIndex = 13;
            this.MEMREG_Value.Text = "value here";
            // 
            // ClockCycleLabel
            // 
            this.ClockCycleLabel.AutoSize = true;
            this.ClockCycleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClockCycleLabel.Location = new System.Drawing.Point(3, 12);
            this.ClockCycleLabel.Name = "ClockCycleLabel";
            this.ClockCycleLabel.Size = new System.Drawing.Size(120, 21);
            this.ClockCycleLabel.TabIndex = 10;
            this.ClockCycleLabel.Text = "Current Cycle: 0";
            // 
            // MEMREG_Instruction
            // 
            this.MEMREG_Instruction.AutoSize = true;
            this.MEMREG_Instruction.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MEMREG_Instruction.Location = new System.Drawing.Point(705, 366);
            this.MEMREG_Instruction.Name = "MEMREG_Instruction";
            this.MEMREG_Instruction.Size = new System.Drawing.Size(73, 12);
            this.MEMREG_Instruction.TabIndex = 12;
            this.MEMREG_Instruction.Text = "instruction here";
            // 
            // EXMEM_Instruction
            // 
            this.EXMEM_Instruction.AutoSize = true;
            this.EXMEM_Instruction.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EXMEM_Instruction.Location = new System.Drawing.Point(473, 366);
            this.EXMEM_Instruction.Name = "EXMEM_Instruction";
            this.EXMEM_Instruction.Size = new System.Drawing.Size(73, 12);
            this.EXMEM_Instruction.TabIndex = 11;
            this.EXMEM_Instruction.Text = "instruction here";
            // 
            // IDEX_Instruction
            // 
            this.IDEX_Instruction.AutoSize = true;
            this.IDEX_Instruction.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IDEX_Instruction.Location = new System.Drawing.Point(279, 366);
            this.IDEX_Instruction.Name = "IDEX_Instruction";
            this.IDEX_Instruction.Size = new System.Drawing.Size(73, 12);
            this.IDEX_Instruction.TabIndex = 10;
            this.IDEX_Instruction.Text = "instruction here";
            // 
            // IFID_Instruction
            // 
            this.IFID_Instruction.AutoSize = true;
            this.IFID_Instruction.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IFID_Instruction.Location = new System.Drawing.Point(75, 366);
            this.IFID_Instruction.Name = "IFID_Instruction";
            this.IFID_Instruction.Size = new System.Drawing.Size(73, 12);
            this.IFID_Instruction.TabIndex = 9;
            this.IFID_Instruction.Text = "instruction here";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(183, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Decode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(382, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Execute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(582, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "MemAccess";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(791, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "RegWrite";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(710, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "MEM/REG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(484, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "EX/MEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(300, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID/EX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(99, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "IF/ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fetch";
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
            loadFileMenuItem,
            this.DirectInputMenuItem});
            this.loadMenu.Name = "loadMenu";
            this.loadMenu.Size = new System.Drawing.Size(45, 20);
            this.loadMenu.Text = "Load";
            // 
            // DirectInputMenuItem
            // 
            this.DirectInputMenuItem.Name = "DirectInputMenuItem";
            this.DirectInputMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DirectInputMenuItem.Text = "Direct Input";
            this.DirectInputMenuItem.Click += new System.EventHandler(this.loadDirectInputMenuItem_Click);
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
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.ProcessorStateBox.Location = new System.Drawing.Point(927, 292);
            this.ProcessorStateBox.Name = "ProcessorStateBox";
            this.ProcessorStateBox.ReadOnly = true;
            this.ProcessorStateBox.Size = new System.Drawing.Size(219, 242);
            this.ProcessorStateBox.TabIndex = 6;
            this.ProcessorStateBox.TabStop = false;
            this.ProcessorStateBox.Text = "Some Text";
            // 
            // StatisticsTextBox
            // 
            this.StatisticsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatisticsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatisticsTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatisticsTextBox.Location = new System.Drawing.Point(366, 27);
            this.StatisticsTextBox.Name = "StatisticsTextBox";
            this.StatisticsTextBox.ReadOnly = true;
            this.StatisticsTextBox.Size = new System.Drawing.Size(554, 144);
            this.StatisticsTextBox.TabIndex = 7;
            this.StatisticsTextBox.TabStop = false;
            this.StatisticsTextBox.Text = "Some Text";
            // 
            // PotentialHazardsTextBox
            // 
            this.PotentialHazardsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PotentialHazardsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PotentialHazardsTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PotentialHazardsTextBox.Location = new System.Drawing.Point(12, 27);
            this.PotentialHazardsTextBox.Name = "PotentialHazardsTextBox";
            this.PotentialHazardsTextBox.ReadOnly = true;
            this.PotentialHazardsTextBox.Size = new System.Drawing.Size(170, 144);
            this.PotentialHazardsTextBox.TabIndex = 8;
            this.PotentialHazardsTextBox.TabStop = false;
            this.PotentialHazardsTextBox.Text = "Some Text";
            // 
            // DetectedHazardsTextBox
            // 
            this.DetectedHazardsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DetectedHazardsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetectedHazardsTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetectedHazardsTextBox.Location = new System.Drawing.Point(189, 27);
            this.DetectedHazardsTextBox.Name = "DetectedHazardsTextBox";
            this.DetectedHazardsTextBox.ReadOnly = true;
            this.DetectedHazardsTextBox.Size = new System.Drawing.Size(170, 144);
            this.DetectedHazardsTextBox.TabIndex = 9;
            this.DetectedHazardsTextBox.TabStop = false;
            this.DetectedHazardsTextBox.Text = "Some Text";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 661);
            this.Controls.Add(this.StatisticsTextBox);
            this.Controls.Add(this.DetectedHazardsTextBox);
            this.Controls.Add(this.PotentialHazardsTextBox);
            this.Controls.Add(this.ProcessorStateBox);
            this.Controls.Add(this.PipelinePanel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.InstructionTextBox);
            this.Controls.Add(this.loadMenuStrip);
            this.MaximumSize = new System.Drawing.Size(1174, 700);
            this.MinimumSize = new System.Drawing.Size(1174, 637);
            this.Name = "SimulationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mips Simulation";
            this.PipelinePanel.ResumeLayout(false);
            this.PipelinePanel.PerformLayout();
            this.loadMenuStrip.ResumeLayout(false);
            this.loadMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.RichTextBox InstructionTextBox;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Windows.Forms.Panel PipelinePanel;
        private System.Windows.Forms.MenuStrip loadMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadMenu;
        private System.Windows.Forms.ToolStripMenuItem loadFileMenuItem;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem DirectInputMenuItem;
        private System.Windows.Forms.RichTextBox ProcessorStateBox;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionLatenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clockSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RichTextBox StatisticsTextBox;
        private System.Windows.Forms.RichTextBox PotentialHazardsTextBox;
        private System.Windows.Forms.RichTextBox DetectedHazardsTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MEMREG_Instruction;
        private System.Windows.Forms.Label EXMEM_Instruction;
        private System.Windows.Forms.Label IDEX_Instruction;
        private System.Windows.Forms.Label IFID_Instruction;
        private System.Windows.Forms.Label ClockCycleLabel;
        private System.Windows.Forms.Label IDEX_Control;
        private System.Windows.Forms.Label EXMEM_Control;
        private System.Windows.Forms.Label EXMEM_Value;
        private System.Windows.Forms.Label MEMREG_Control;
        private System.Windows.Forms.Label MEMREG_Value;
        private System.Windows.Forms.Label Decode_Instruction;
        private System.Windows.Forms.Label Execute_Instruction;
        private System.Windows.Forms.Label Mem_Instruction;
        private System.Windows.Forms.Label RegWrite_Instruction;
        private System.Windows.Forms.Label Fetch_Instruction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Mem_Value;
        private System.Windows.Forms.Label RegWrite_WriteReg;
        private System.Windows.Forms.Label RegWrite_Value;
        private System.Windows.Forms.Label Mem_Address;
        private System.Windows.Forms.Label Execute_Value2;
        private System.Windows.Forms.Label Execute_Value1;
        private System.Windows.Forms.Label Execute_Operation;
        private System.Windows.Forms.Label Decode_Arg3;
        private System.Windows.Forms.Label Decode_Arg2;
        private System.Windows.Forms.Label Decode_Arg1;
        private System.Windows.Forms.Label Decode_Op;
        private System.Windows.Forms.Label ExecutionCyclesLabel;
    }
}

