using RisikOOPSolution.model;

namespace RisikOOPSolution.test
{
    [TestClass]
    public class TurnManagerTest
    {
        readonly TurnManager turnManager = new(new()
        {
            1,
            2,
            3,
            4
        });

        [TestMethod]
        public void TestTurnManagerCreation()
        {
            Assert.IsNotNull(turnManager);
        }

        [TestMethod]
        public void TestPlayerOrder()
        {
            List<int> playerList = turnManager.GetPlayersID();
            Assert.IsTrue(playerList[0] == turnManager.GetCurrentPlayerID());
            turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[1] == turnManager.GetCurrentPlayerID());
            turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[2] == turnManager.GetCurrentPlayerID());
            turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[3] == turnManager.GetCurrentPlayerID());
            turnManager.ResetTurns();
        }

        [TestMethod]
        public void TestResetTurns()
        {
            List<int> playerList = turnManager.GetPlayersID();
            Assert.IsTrue(playerList[0] == turnManager.GetCurrentPlayerID());
            turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[1] == turnManager.GetCurrentPlayerID());
            turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[2] == turnManager.GetCurrentPlayerID());
            turnManager.ResetTurns();
            Assert.IsTrue(playerList[0] == turnManager.GetCurrentPlayerID());
            turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[1] == turnManager.GetCurrentPlayerID());
            turnManager.ResetTurns();
        }

    }

}
