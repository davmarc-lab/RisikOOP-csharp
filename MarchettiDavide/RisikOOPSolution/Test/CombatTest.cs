
using RisikOOPSolution.Model;

namespace RisikOOPSolution;
[TestClass]
public class UnitTest1
{
    private readonly Player _p1 = PlayerBuilder.NewBuilder().Id(1).Territories(new HashSet<Territory>()).Build();
    private readonly Player _p2 = PlayerBuilder.NewBuilder().Id(2).Territories(new HashSet<Territory>()).Build();

    private readonly Territory[] _attackerTerritories = new[]
    {
        new Territory("Southern Europe", 5, new HashSet<string>() { "Ukraine", "Egypt" }),
        new Territory("Venezuela", 5, new HashSet<string>() { "Brazil" }),
        new Territory("Scandinavia", 5, new HashSet<string>() { "Ukraine" }),
        new Territory("Egypt", 5, new HashSet<string>() { "Southern Europe" })
    };

    private readonly Territory[] _defenderTerritories = new[]
    {
        new Territory("Ukraine", 5, new HashSet<string>() { "Southern Europe", "Scandinavia" }),
        new Territory("Brazil", 5, new HashSet<string>() { "Venezuela" })
    };

    private void PreparePlayers()
    {
        _p1.Territories.Clear();
        _p2.Territories.Clear();
        _p1.AddTerritories(_attackerTerritories);
        _p2.AddTerritories(_defenderTerritories);
    }

    [TestMethod]
    public void PlayerCreationTest()
    {
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

    [TestMethod]
    public void RemoveTerritoriesToPlayersTest()
    {
        PreparePlayers();
        _p1.RemoveTerritory(_attackerTerritories[0]);
        _p1.RemoveTerritory(_attackerTerritories[2]);
        _p1.RemoveTerritory(_attackerTerritories[3]);
        Assert.IsTrue(_p1.Territories.IsSubsetOf(new HashSet<Territory>() { _attackerTerritories[1] }));
        _p2.RemoveTerritory(_defenderTerritories[0]);
        _p2.RemoveTerritory(_defenderTerritories[1]);
        Assert.IsTrue(_p2.Territories.Count == 0);
    }

    [TestMethod]
    public void CombatWithForcedResultTest()
    {
        var s = _attackerTerritories[0];
        var d = _defenderTerritories[0];
        Combat c1 = new Combat(s, 2, d, 3, new List<int>() { 6, 5 },
            new List<int>() { 5, 2, 1 });
        Assert.AreEqual(new Tuple<int, int>(0, 2), c1.Attack(2, 3));
        d.AddTroops(-2);
        Assert.AreEqual(3, d.Troops);
    }

    [TestMethod]
    public void CombatWithInvalidTroops()
    {
        var s = _attackerTerritories[0];
        var d = _defenderTerritories[0];
        Assert.ThrowsException<ArgumentException>(() => new Combat(s, 0, d, 3).Attack(0, 3));
    }
}