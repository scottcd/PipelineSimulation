using PipelineLibrary.ProcessorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLibrary {
    public static class PipelineFunctions {
       public static IInstruction Fetch(int programCounter, List<IInstruction> instructionMemory) {
            int instructionIndex = programCounter / 4;
            if (instructionIndex > instructionMemory.Count - 1) {
                return null;
            }
            else { 
                IInstruction instruction = instructionMemory[instructionIndex];
                return instruction;
            }
        }
        
        public static void Execute() {

        }

        public static void WritePipeline(Processor mips) {
            if (mips.ExecutionCyclesLeft == 0) {
                if (mips.Instruction is RTypeInstruction) {
                    FullPipelineRegister reg = (FullPipelineRegister)mips.PipelineRegisters[3];
                    reg.FillPipeline(mips.Instruction, mips.ControlUnit, mips.ValueToWrite);
                }
                else if (mips.ExecutionCyclesLeft == 0) {
                    FullPipelineRegister reg = (FullPipelineRegister)mips.PipelineRegisters[2];
                    reg.FillPipeline(mips.Instruction, mips.ControlUnit, mips.ValueToWrite);
                }
            }
        }

        public static bool NullCheckPipelineRegisters(Processor mips) {
            if (mips.PipelineRegisters[0].Instruction is null &&
                mips.PipelineRegisters[1].Instruction is null &&
                mips.PipelineRegisters[2].Instruction is null &&
                mips.PipelineRegisters[3].Instruction is null) {
                return true;
            }
            return false;
        }


        public static (int,int) GetOperands(IInstruction instruction, Dictionary<RegisterEnum, int> registers) {
            int operand1, operand2;
            if (instruction is ITypeInstruction) {
                ITypeInstruction i = (ITypeInstruction)instruction;
                if (i.Opcode == OpcodeEnum.beq || i.Opcode == OpcodeEnum.bne) {
                    operand1 = registers[i.SourceRegister1];
                    operand2 = registers[i.DestinationRegister];
                }
                else if (i.Opcode == OpcodeEnum.lw || i.Opcode == OpcodeEnum.l_s) {
                    operand1 = registers[i.SourceRegister1];
                    operand2 = i.Immediate;
                }
                else {
                    operand1 = registers[i.DestinationRegister];
                    operand2 = i.Immediate;
                }
            }
            else {
                RTypeInstruction i = (RTypeInstruction)instruction;
                operand1 = registers[i.SourceRegister1];
                operand2 = registers[i.SourceRegister2];
            }

            return (operand1, operand2);
        }

        /// <summary>
        /// Check if instruction should be loaded into the Memory Access stage
        /// </summary>
        /// <param name="pipeLineRegister">EX/MEM Pipeline Register</param>
        /// <returns>
        ///             true, if instruction should be loaded
        ///             false, if instruction should not be loaded
        ///</returns>
        public static bool CheckMemAccess(ControlSignal controlUnit) {
            if (controlUnit.MemWrite == true || controlUnit.MemRead == true || controlUnit.RegWrite) {
                return true;
            }
            else {
                return false;
            }
        }

        public  static void MemoryTouch(IInstruction instruction, ControlSignal controlUnit, Processor mips) {
            FullPipelineRegister reg = (FullPipelineRegister)mips.PipelineRegisters[2];
            // load
            if (controlUnit.MemRead == true) {
                int readAddress = reg.ValueToWrite;

                // read memory to valueToWrite
                int valueRead = mips.MainMemory[readAddress];

                // write pipeline register
                FullPipelineRegister reg1 = (FullPipelineRegister)mips.PipelineRegisters[3];
                reg1.FillPipeline(instruction, controlUnit, valueRead);
                mips.Pipeline[3] = new MemoryPipelineStage(instruction, readAddress, valueRead);
            }
            // store
            else if (controlUnit.MemWrite == true) {

                int writeAddress = reg.ValueToWrite;
                // write to memory
                int valueToWrite = mips.Registers[reg.IType.SourceRegister1];
                mips.Pipeline[3] = new MemoryPipelineStage(instruction, writeAddress, valueToWrite);
                mips.MainMemory[writeAddress] = valueToWrite;
                mips.Hazards.CheckToRemoveHazard(instruction, controlUnit, mips);
            }
        }

        /// <summary>
        /// Check if instruction should be loaded into the Register Write stage
        /// </summary>
        /// <param name="pipeLineRegister">MEM/REG Pipeline Register</param>
        /// <returns>
        ///             true, if instruction should be loaded
        ///             false, if instruction should not be loaded
        ///</returns>
        public static bool CheckRegWrite(ControlSignal controlUnit) {
            if (controlUnit.RegWrite == true) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
