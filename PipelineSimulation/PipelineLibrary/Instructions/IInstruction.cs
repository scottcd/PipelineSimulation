namespace PipelineLibrary {
    public interface IInstruction {
        public OpcodeEnum Opcode { get; set; }
        public int[] Instruction { get; set; }
    }
}