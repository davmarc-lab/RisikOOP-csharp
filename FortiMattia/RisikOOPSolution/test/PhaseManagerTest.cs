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
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "REINFORCEMENTS");
            _phaseManager.SwitchToNextPhase();
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "COMBAT");
            _phaseManager.SwitchToNextPhase();
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "MOVEMENT");
            _phaseManager.SwitchToNextPhase();
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "REINFORCEMENTS");
            _phaseManager.SwitchToNextPhase();
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "COMBAT");
        }

        [TestMethod]
        public void TestPhaseSkip()
        {
            _phaseManager.SwitchToPhase("REINFORCEMENTS");
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "REINFORCEMENTS");
            _phaseManager.SwitchToPhase("MOVEMENT");
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "MOVEMENT");
            _phaseManager.SwitchToPhase("COMBAT");
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "COMBAT");
            _phaseManager.SwitchToPhase("REINFORCEMENTS");
            Assert.AreEqual(_phaseManager.GetCurrentPhase(), "REINFORCEMENTS");
        }
    }
}
