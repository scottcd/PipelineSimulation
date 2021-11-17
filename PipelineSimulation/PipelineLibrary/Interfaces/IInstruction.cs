namespace PipelineLibrary {
    public interface IInstruction {
        public OpcodeEnum Opcode { get; set; }
        public RegisterEnum DestinationRegister { get; set; }
        public int CyclesToComplete { get; set; }
    }
}