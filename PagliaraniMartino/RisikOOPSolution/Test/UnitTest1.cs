using RisikOOPSolution.Model;

namespace RisikOOPSolution.Test;

[TestClass]
public class UnitTest1
{
    private readonly Objective _twoContinentObjective =
        ObjectiveBuilder.NewBuilder().ObjectiveType(Objective.ObjectiveType.Conquer).FirstContinent("Asia")
            .SecondContinent("Africa").ThirdContinent(false).Build();

    private readonly Objective _threeContinentObjective = ObjectiveBuilder.NewBuilder()
        .ObjectiveType(Objective.ObjectiveType.Conquer).FirstContinent("Europe")
        .SecondContinent("Oceania").ThirdContinent(true).Build();

    private readonly Objective _territoriesToConquerObjective =
        ObjectiveBuilder.NewBuilder().ObjectiveType(Objective.ObjectiveType.Conquer).NumTerritoriesToConquer(18)
            .MinNumArmies(2).Build();

    private readonly Objective _destroyArmyObjective = ObjectiveBuilder.NewBuilder()
        .ObjectiveType(Objective.ObjectiveType.Destroy).ArmyColor(new Color("Red")).Build();

    private readonly Objective _defaultObjective = ObjectiveBuilder.NewBuilder()
        .ObjectiveType(Objective.ObjectiveType.Conquer).NumTerritoriesToConquer(24).MinNumArmies(2).Build();

    private readonly IList<Player> _players = new List<Player>();

    private readonly Deck<Territory> _deckTerritories = new Deck<Territory>();

    private readonly IList<Territory> _territories = new List<Territory>();

    private Tuple<Deck<Objective>, Objective> _deckObjectives;

    private readonly GamePrep _gamePrep = new GamePrep();

    [TestInitialize]
    public void PreparePlayers()
    {
        _players.Add(new Player(1, new Color("Red")));
        _players.Add(new Player(2, new Color("Blue")));
        _players.Add(new Player(3, new Color("Purple")));
        _territories.Add(new Territory("NorthAmerica"));
        _territories.Add(new Territory("Ontario"));
        _territories.Add(new Territory("Madagascar"));
        _territories.ToList().ForEach(t => _deckTerritories.AddCard(t));
        var objDeck = new Deck<Objective>();
        objDeck.AddCard(_twoContinentObjective);
        objDeck.AddCard(_threeContinentObjective);
        objDeck.AddCard(_territoriesToConquerObjective);
        objDeck.AddCard(_destroyArmyObjective);
        _deckObjectives = new Tuple<Deck<Objective>, Objective>(objDeck, _defaultObjective);
    }

    [TestMethod]
    public void TestObjectiveType()
    {
        Assert.AreEqual(Objective.ObjectiveType.Conquer, _twoContinentObjective.ObjType);
        Assert.AreEqual(Objective.ObjectiveType.Conquer, _threeContinentObjective.ObjType);
        Assert.AreEqual(Objective.ObjectiveType.Conquer, _territoriesToConquerObjective.ObjType);
        Assert.AreEqual(Objective.ObjectiveType.Destroy, _destroyArmyObjective.ObjType);
    }

    [TestMethod]
    public void TestDescription()
    {
        Assert.AreEqual(_twoContinentObjective.Description, "Conquer Asia and Africa.");
        Assert.AreEqual(_threeContinentObjective.Description,
            "Conquer Europe and Oceania and another continent of your choice.");
        Assert.AreEqual(_territoriesToConquerObjective.Description, "Conquer 18 territories with at least 2 troop.");
        Assert.AreEqual(_destroyArmyObjective.Description, "Destroy the Red army.");
    }

    [TestMethod]
    public void TestObjective()
    {
        Assert.AreEqual(_twoContinentObjective.FirstContinent, "Asia");
        Assert.AreEqual(_twoContinentObjective.ThirdContinent, false);
        Assert.AreEqual(_threeContinentObjective.ThirdContinent, true);
        Assert.AreEqual(_territoriesToConquerObjective.NumTerritoriesToConquer, 18);
        Assert.AreEqual(_destroyArmyObjective.ArmyColor.Name, "Red");
    }

    [TestMethod]
    public void TestGamePrep()
    {
        Assert.IsTrue(_deckTerritories.Cards.Any());
        _gamePrep.PreparePlayers(_players, _deckTerritories, _deckObjectives);
        Assert.AreEqual(_players.Select(p => p.Objective).ToList().Count, 3);
        Assert.AreEqual(_players.Select(p => p.BonusTroops).First(), 21);
        Assert.AreEqual(_players.Select(p => p.Territories).ToList().Count, 3);
    }
}