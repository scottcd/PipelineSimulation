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

namespace MipsPipelineUI
{
    public partial class AboutForm : Form
    {
        public RegisterEnum CurrentKey { get; private set; }
        public Processor Processor { get; set; }

        private List<OpcodeEnum> instructions;
        private List<RegisterEnum> registers;
        private List<string> controls, stages, hazards;

        public AboutForm()
        {
            InitializeComponent();

            Processor = new Processor(1500);

            instructions = Processor.ExecutionCycleDictionary.Keys.ToList();

            registers = Processor.Registers.Keys.ToList();

            controls = new List<string>
            {
                "RegDst", "Branch", "MemRead",
                "MemtoReg", "ALU Op", "MemWrite",
                "ALU Src", "RegWrite"
            };

            stages = new List<string>{
                "Fetch", "Decode", "Execute",
                "Memory Access", "Register Write"
            };

            hazards = new List<string>
            {
                "Data Hazard", "Memory Hazard", "Structural Hazard"
            };
        }

        #region Menu Bar Selection
        private void aboutInstructionsMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (instructions);
        }

        private void aboutRegistersMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (registers);
        }

        private void aboutControlMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (controls);
        }       

        private void aboutStagesMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (stages);
        }

        private void aboutHazardsMenuItem_Click(object sender, EventArgs e)
        {
            listBox.DataSource = (hazards);
        }
        #endregion

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(listBox.Items[0])
            {
                case OpcodeEnum.add:
                    instructionSelect((OpcodeEnum)listBox.SelectedItem);
                    break;
                case RegisterEnum.r0:
                    registerSelect((RegisterEnum)listBox.SelectedItem);
                    break;
                case "RegDst":
                    controlSelect((string)listBox.SelectedItem);
                    break;
                case "Fetch":
                    stageSelect((string)listBox.SelectedItem);
                    break;
                case "Data Hazard":
                    hazardSelect((string)listBox.SelectedItem);
                    break;
            }
        }

        #region List Selection Logic

        #region Instruction Selection
        private void instructionSelect(OpcodeEnum current) 
        {
            string result = "";

            switch (current)
            {
                case OpcodeEnum.add:
                    result += $"Name:\n";
                    result += $"add\n\n";
                    result += $"Syntax:\n";
                    result += $"add $1,$2,$0\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Adds two integers together.";
                    break;
                case OpcodeEnum.add_s:
                    result += $"Name:\n";
                    result += $"floating add\n\n";
                    result += $"Syntax:\n";
                    result += $"add.s $1,$2,$0\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Adds two floating points together.";
                    break;
                case OpcodeEnum.sub:
                    result += $"Name:\n";
                    result += $"subtract\n\n";
                    result += $"Syntax:\n";
                    result += $"sub $1,$2,$0\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Subtracts one integer from another.";
                    break;
                case OpcodeEnum.sub_s:
                    result += $"Name:\n";
                    result += $"floating subtract\n\n";
                    result += $"Syntax:\n";
                    result += $"sub.s $1,$2,$0\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Subtracts one floating point from another.";
                    break;
                case OpcodeEnum.mul_s:
                    result += $"Name:\n";
                    result += $"floating multiply\n\n";
                    result += $"Syntax:\n";
                    result += $"mul.s $1,$2,$0\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Multiplies two floating points together.";
                    break;
                case OpcodeEnum.div_s:
                    result += $"Name:\n";
                    result += $"floating divide\n\n";
                    result += $"Syntax:\n";
                    result += $"div.s $1,$2,$0\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Divides one floating point from another.";
                    break;
                case OpcodeEnum.beq:
                    result += $"Name:\n";
                    result += $"branch if equal\n\n";
                    result += $"Syntax:\n";
                    result += $"beq $1,$2,100\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: immediate\n\n";
                    result += $"Description:\n";
                    result += $"If arg1 and arg2 are equal then branch to an immediate address in memory.";
                    break;
                case OpcodeEnum.bne:
                    result += $"Name:\n";
                    result += $"branch if not equal\n\n";
                    result += $"Syntax:\n";
                    result += $"bne $1,$2,100\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: register\n";
                    result += $"arg3: immediate\n\n";
                    result += $"Description:\n";
                    result += $"If arg1 and arg2 are not equal then branch to an immediate address in memory.";
                    break;
                case OpcodeEnum.lw:
                    result += $"Name:\n";
                    result += $"load word\n\n";
                    result += $"Syntax:\n";
                    result += $"lw $1,100($0)\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: immediate\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Loads an integer from an address in memory into a register.";
                    break;
                case OpcodeEnum.sw:
                    result += $"Name:\n";
                    result += $"store word\n\n";
                    result += $"Syntax:\n";
                    result += $"sw $1,100($0)\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: immediate\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Stores an integer from a register to a specified address in memory.";
                    break;
                case OpcodeEnum.l_s:
                    result += $"Name:\n";
                    result += $"floating load word\n\n";
                    result += $"Syntax:\n";
                    result += $"lw.s $1,100($0)\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: immediate\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Loads a floating point from an address in memory into a register.";
                    break;
                case OpcodeEnum.s_s:
                    result += $"Name:\n";
                    result += $"floating store word\n\n";
                    result += $"Syntax:\n";
                    result += $"sw.s $1,100($0)\n";
                    result += $"Opcode: {current}\n";
                    result += $"arg1: register\n";
                    result += $"arg2: immediate\n";
                    result += $"arg3: register\n\n";
                    result += $"Description:\n";
                    result += $"Stores a floating point from a register to a specified address in memory.";
                    break;
            }

            infoBox.Text = result;
        }
        #endregion

        #region Register Selection
        private void registerSelect(RegisterEnum current)
        {
            string result = "";
            string secondCase = "";

            switch (current)
            {
                case RegisterEnum.r0:
                    result += $"Name:\n";
                    result += $"$zero\n\n";
                    result += $"Number:\n";
                    result += $"{current}\n\n";
                    result += $"Purpose:\n";
                    result += $"zero-register\n";
                    break;
                case RegisterEnum.r1:
                    result += $"Name:\n";
                    result += $"at\n\n";
                    result += $"Number:\n";
                    result += $"{current}\n\n";
                    result += $"Purpose:\n";
                    result += $"reserved for assembler\n";
                    break;
                case RegisterEnum.r2:
                    result += $"Name:\n";
                    result += $"$v0\n";
                    secondCase = "result";
                    break;
                case RegisterEnum.r3:
                    result += $"Name:\n";
                    result += $"$v1\n";                    
                    secondCase = "result";
                    break;
                case RegisterEnum.r4:
                    result += $"Name:\n";
                    result += $"$a0\n";
                    secondCase = "argument";
                    break;
                case RegisterEnum.r5:
                    result += $"Name:\n";
                    result += $"$a1\n";
                    secondCase = "argument";
                    break;
                case RegisterEnum.r6:
                    result += $"Name:\n";
                    result += $"$a2\n";
                    secondCase = "argument";
                    break;
                case RegisterEnum.r7:
                    result += $"Name:\n";
                    result += $"$a3\n";
                    secondCase = "argument";
                    break;
                case RegisterEnum.r8:
                    result += $"Name:\n";
                    result += $"$t0\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r9:
                    result += $"Name:\n";
                    result += $"$t1\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r10:
                    result += $"Name:\n";
                    result += $"$t2\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r11:
                    result += $"Name:\n";
                    result += $"$t3\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r12:
                    result += $"Name:\n";
                    result += $"$t4\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r13:
                    result += $"Name:\n";
                    result += $"$t5\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r14:
                    result += $"Name:\n";
                    result += $"$t6\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r15:
                    result += $"Name:\n";
                    result += $"$t7\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r16:
                    result += $"Name:\n";
                    result += $"$s0\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r17:
                    result += $"Name:\n";
                    result += $"$s1\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r18:
                    result += $"Name:\n";
                    result += $"$s2\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r19:
                    result += $"Name:\n";
                    result += $"$s3\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r20:
                    result += $"Name:\n";
                    result += $"$s4\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r21:
                    result += $"Name:\n";
                    result += $"$s5\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r22:
                    result += $"Name:\n";
                    result += $"$s6\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r23:
                    result += $"Name:\n";
                    result += $"$s7\n";
                    secondCase = "save";
                    break;
                case RegisterEnum.r24:
                    result += $"Name:\n";
                    result += $"$t8\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r25:
                    result += $"Name:\n";
                    result += $"$t9\n";
                    secondCase = "temp";
                    break;
                case RegisterEnum.r26:
                    result += $"Name:\n";
                    result += $"$k0\n";
                    secondCase = "kernel";
                    break;
                case RegisterEnum.r27:
                    result += "Name:\n";
                    result += $"$k1\n";
                    secondCase = "kernel";
                    break;
                case RegisterEnum.r28:
                    result += $"Name:\n";
                    result += $"$gp\n\n";
                    result += $"Number:\n";
                    result += $"{current}\n\n";
                    result += $"Purpose:\n";
                    result += $"global pointer\n";
                    break;
                case RegisterEnum.r29:
                    result += $"Name:\n";
                    result += $"$sp\n\n";
                    result += $"Number:\n";
                    result += $"{current}\n\n";
                    result += $"Purpose:\n";
                    result += $"stack pointer\n";
                    break;
                case RegisterEnum.r30:
                    result += $"Name:\n";
                    result += $"$fp\n\n";
                    result += $"Number:\n";
                    result += $"{current}\n\n";
                    result += $"Purpose:\n";
                    result += $"frame pointer\n";
                    break;
                case RegisterEnum.r31:
                    result += $"Name:\n";
                    result += $"$ra\n\n";
                    result += $"Number:\n";
                    result += $"{current}\n\n";
                    result += $"Purpose:\n";
                    result += $"return address\n";            
                    break;
            }

            if (!String.IsNullOrEmpty(secondCase)) 
            {
                switch (secondCase) 
                {
                    case "result":
                        result += $"\nNumber:\n";
                        result += $"{current}\n\n";
                        result += $"Purpose:\n";
                        result += $"result register\n";
                        break;
                    case "argument":
                        result += $"\nNumber:\n";
                        result += $"{current}\n\n";
                        result += $"Purpose:\n";
                        result += $"argument register\n";
                        break;
                    case "temp":
                        result += $"\nNumber:\n";
                        result += $"{current}\n\n";
                        result += $"Purpose:\n";
                        result += $"temporary register\n";
                        break;
                    case "save":
                        result += $"\nNumber:\n";
                        result += $"{current}\n\n";
                        result += $"Purpose:\n";
                        result += $"saved register\n";
                        break;
                    case "kernel":
                        result += $"\nNumber:\n";
                        result += $"{current}\n\n";
                        result += $"Purpose:\n";
                        result += $"kernel register\n";
                        break;
                }
            }

            infoBox.Text = result;
        }
        #endregion

        #region Control Selection
        private void controlSelect(string current)
        {
            string result = "";

            switch (current)
            {
                case "RegDst":
                    result += $"Example:\n";
                    result += $"add $1,$2,$3\n\n";
                    result += $"Description:\n";
                    result += $"Determines how the destination register is specified ";
                    break;
                case "Branch":
                    result += $"Example:\n";
                    result += $"beq $1,$2,16\n\n";
                    result += $"Description:\n";
                    result += $"Combined with a condition test boolean to enable loading the \nbranch target address into the PC.";
                    break;
                case "MemRead":
                    result += $"Example:\n";
                    result += $"lw $1,200($3)\n\n";
                    result += $"Description:\n";
                    result += $"Enables a memory read for load instructions.";
                    break;
                case "MemtoReg":
                    result += $"Example:\n";
                    result += $"lw $1,200($3)\n\n";
                    result += $"Description:\n";
                    result += $"Determines where the value to be written comes from ";
                    break;
                case "ALU Op":
                    result += $"Example:\n";
                    result += $"add $1,$2,$3\n\n";
                    result += $"Description:\n";
                    result += $"Either specifies the ALU operation to be performed or specifies \nthat the operation should be determined from the function bits.";
                    break;
                case "MemWrite":
                    result += $"Example:\n";
                    result += $"sw $1,200($3)\n\n";
                    result += $"Description:\n";
                    result += $"Enables a memory write for store instructions.";
                    break;
                case "ALU Src":
                    result += $"Example:\n";
                    result += $"sw $1,200($3)\n\n";
                    result += $"Description:\n";
                    result += $"Selects the second source operand for the ALU";
                    break;
                case "RegWrite":
                    result += $"Example:\n";
                    result += $"add $1,$2,$3\n\n";
                    result += $"Description:\n";
                    result += $"Enables a write to one of the registers.";
                    break;
            }

            infoBox.Text = result;
        }
        #endregion

        #region Stage Selection
        private void stageSelect(string current)
        {
            string result = "";
            switch (current)
            {
                case "Fetch":
                    result += $"Description:\n";
                    result += $"Statically fetches one instruction from \n" +
                        $"instruction memory and adds it to the IF/ID pipeline register.";
                    break;
                case "Decode":
                    result += $"Description:\n";
                    result += $"Reads the instruction and parses the \n" +
                        $"various components. Also, hazards and control \n" +
                        $"logic are determined.";
                    break;
                case "Execute":
                    result += $"Description:\n";
                    result += $"The instruction operands are fed into \n" +
                        $"the ALU which reads the control logic to get the ALU op. \n " +
                        $"Once calculated, the value is written to a pipeline register or \n" +
                        $" the program counter is updated if branching.";
                    break;
                case "Memory Access":
                    result += $"Description:\n";
                    result += $"If the instruction is a load or store, \n" +
                        $"memory is written to/read from.";
                    break;
                case "Register Write":
                    result += $"Description:\n";
                    result += $"If the instruction writes back to a register, it is this \n" +
                        $"stage that handles it. " + $"A destination register is written to\n" +
                        $"either by the value read in memory or the value calculated \n" +
                        $"in the ALU.";
                    break;
            }
            infoBox.Text = result;
        }
        #endregion

        #region Hazard Selection
        private void hazardSelect(string current)
        {
            string result = "";

            switch (current)
            {
                case "Data Hazard":
                    result += $"Example:\n";
                    result += $"mul $1,$2,$3\n";
                    result += $"add $8,$1,$7\n\n";
                    result += $"Description:\n";
                    result += $"Occurs when two instructions need the same register.\n" +
                        $"Can take three forms:\n" +
                        $"    Read after Write\n" +
                        $"    Write after Read\n" +
                        $"    Write after Write";
                    break;
                case "Memory Hazard":
                    result += $"Example:\n";
                    result += $"sw $1,100($2)\n";
                    result += $"lw $3,100($2)\n\n";
                    result += $"Description:\n";
                    result += $"Occurs when two instructions need the same address in memory.";
                    break;
                case "Structural Hazard":
                    result += $"Example:\n";
                    result += $"div.s $1,$2,$3\n";
                    result += $"add $1,$2,$3\n\n";
                    result += $"Description:\n";
                    result += $"Occurs when two instructions need the same resource.";
                    break;
            }

            infoBox.Text = result;
        }
        #endregion

        #endregion
    }
}
