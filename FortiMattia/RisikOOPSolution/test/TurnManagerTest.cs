using RisikOOPSolution.model;

namespace RisikOOPSolution.test
{
    [TestClass]
    public class TurnManagerTest
    {
        readonly TurnManager _turnManager = new(new()
        {
            1,
            2,
            3,
            4
        });

        [TestMethod]
        public void TestTurnManagerCreation()
        {
            Assert.IsNotNull(_turnManager);
        }

        [TestMethod]
        public void TestPlayerOrder()
        {
            List<int> playerList = _turnManager.PlayersIDs;
            Assert.IsTrue(playerList[0] == _turnManager.GetCurrentPlayerID());
            _turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[1] == _turnManager.GetCurrentPlayerID());
            _turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[2] == _turnManager.GetCurrentPlayerID());
            _turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[3] == _turnManager.GetCurrentPlayerID());
            _turnManager.ResetTurns();
        }

        [TestMethod]
        public void TestResetTurns()
        {
            List<int> playerList = _turnManager.PlayersIDs;
            Assert.IsTrue(playerList[0] == _turnManager.GetCurrentPlayerID());
            _turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[1] == _turnManager.GetCurrentPlayerID());
            _turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[2] == _turnManager.GetCurrentPlayerID());
            _turnManager.ResetTurns();
            Assert.IsTrue(playerList[0] == _turnManager.GetCurrentPlayerID());
            _turnManager.SwitchToNextPlayer();
            Assert.IsTrue(playerList[1] == _turnManager.GetCurrentPlayerID());
            _turnManager.ResetTurns();
        }
    }
}
