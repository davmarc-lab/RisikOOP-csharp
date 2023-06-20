using RisikOOPSolution.model;

namespace RisikOOPSolution.test
{
    [TestClass]
    public class PhaseManagerTest
    {
        readonly PhaseManager _phaseManager = new();

        [TestMethod]
        public void TestPhaseManagerCreation() {
            Assert.IsNotNull(_phaseManager);
        }

        [TestMethod]
        public void TestPhaseIteration()
        {
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
            _phaseManager.SwitchToNextPhase();
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("COMBAT"));
            _phaseManager.SwitchToNextPhase();
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("MOVEMENT"));
            _phaseManager.SwitchToNextPhase();
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
            _phaseManager.SwitchToNextPhase();
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("COMBAT"));
        }

        [TestMethod]
        public void TestPhaseSkip()
        {
            _phaseManager.SwitchToPhase("REINFORCEMENTS");
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
            _phaseManager.SwitchToPhase("MOVEMENT");
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("MOVEMENT"));
            _phaseManager.SwitchToPhase("COMBAT");
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("COMBAT"));
            _phaseManager.SwitchToPhase("REINFORCEMENTS");
            Assert.IsTrue(_phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
        }
    }
}
