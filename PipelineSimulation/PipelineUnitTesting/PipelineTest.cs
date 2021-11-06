using NUnit.Framework;
using PipelineLibrary;

namespace PipelineUnitTesting {
    public class Tests {

        public ControlSignal controller;
        [SetUp]
        public void Setup() {
            controller = new ControlSignal();
        }

        [Test]
        public void TestInit() {
            Assert.NotNull(controller);
        }

        [TestCase("false")]
        public void TestBranchInit(bool v) {
            Assert.AreEqual(controller.Branch, v) ;
        }
    }
}