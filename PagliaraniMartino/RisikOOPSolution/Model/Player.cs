using System.Collections.Specialized;

namespace RisikOOPSolution.Model;

public class Player
{
    public int Id { get; }
    public Deck<Territory> Territories { get; }
    public Objective Objective { get; set; }
    public Color Color { get; }
    public int BonusTroops { get; private set; }

    public Player(int id, Color color)
    {
        Id = id;
        Territories = new Deck<Territory>();
        Objective = ObjectiveBuilder.NewBuilder().Build();
        Color = color;
        BonusTroops = 0;
    }

    public void AddTerritory(Territory territory)
    {
        Territories.AddCard(territory);
    }

    public void RemoveTerritory(Territory territory)
    {
        Territories.RemoveCard(territory);
    }

    public void SetObjectiveComplete()
    {
        Objective.SetComplete();
    }

    public int AddTroops(int i) => BonusTroops += i;
}