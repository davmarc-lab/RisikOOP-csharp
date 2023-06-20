namespace RisikOOPSolution.Test;

using RisikOOPSolution.Model;

[TestClass]
public class UnitTest1
{
    private readonly Player _p1 = new Player();
    private readonly Player _p2 = new Player();

    private readonly Territory[] _attackerTerritories = new[] { new Territory("Southern Europe", 5, new HashSet<string>()),
        new Territory("Venezuela", 5, new HashSet<string>()), 
        new Territory("Scandinavia", 5, new HashSet<string>()), 
        new Territory("Egypt", 5, new HashSet<string>()) };
    
    private readonly Territory[] _defenderTerritories = new[] { new Territory("Ukraine", 5, new HashSet<string>()),
        new Territory("Brazil", 5, new HashSet<string>()) };

    [TestMethod]
    public void PlayerCreationTest()
    {
        PreparePlayers();
        Assert.AreEqual(1, _p1.Id);
        Assert.AreEqual(2, _p2.Id);
    }
    
    [TestMethod]
    public void AddTerritoriesToPlayersTest()
    {
        PreparePlayers();
        Assert.IsTrue(_p1.Territories.IsSupersetOf(_attackerTerritories));
        Assert.IsTrue(_p2.Territories.IsSupersetOf(_defenderTerritories));
    }

    private void PreparePlayers()
    {
        _p1.Id = 1;
        _p2.Id = 2;
        _p1.Territories.Clear();
        _p2.Territories.Clear();
        _p1.AddTerritories(_attackerTerritories);
        _p2.AddTerritories(_defenderTerritories);
    }
}