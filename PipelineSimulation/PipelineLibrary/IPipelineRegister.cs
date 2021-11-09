namespace PipelineLibrary {
    public interface IPipelineRegister {
        public IInstruction Instruction { get; set; }
        public void FlushPipeline();
    }
}