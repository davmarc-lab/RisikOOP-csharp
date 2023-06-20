using RisikOOPSolution.model;

namespace RisikOOPSolution.test
{
    [TestClass]
    public class PhaseManagerTest
    {
        readonly PhaseManager phaseManager = new();

        [TestMethod]
        public void TestPhaseManagerCreation() {
            Assert.IsNotNull(phaseManager);
        }

        [TestMethod]
        public void TestPhaseIteration()
        {
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
            phaseManager.SwitchToNextPhase();
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("COMBAT"));
            phaseManager.SwitchToNextPhase();
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("MOVEMENT"));
            phaseManager.SwitchToNextPhase();
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
            phaseManager.SwitchToNextPhase();
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("COMBAT"));
        }

        [TestMethod]
        public void TestPhaseSkip()
        {
            phaseManager.SwitchToPhase("REINFORCEMENTS");
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
            phaseManager.SwitchToPhase("MOVEMENT");
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("MOVEMENT"));
            phaseManager.SwitchToPhase("COMBAT");
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("COMBAT"));
            phaseManager.SwitchToPhase("REINFORCEMENTS");
            Assert.IsTrue(phaseManager.GetCurrentPhase().Equals("REINFORCEMENTS"));
        }
    }
}
