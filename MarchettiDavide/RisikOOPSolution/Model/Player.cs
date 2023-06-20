using System.Collections.Immutable;

namespace RisikOOPSolution.Model;

public class Player
{
    private ISet<Territory> _territories = new HashSet<Territory>();
    private int _id;
    
    public int Id { get => _id;
        set => _id = value;
    }
    
    public ISet<Territory> Territories
    {
        get => _territories;
        set => _territories = new HashSet<Territory>(value);
    }

    public Player(int id, ISet<Territory> territories)
    {
        Id = id;
        Territories = territories;
    }

    public Player() : this(0, ImmutableHashSet<Territory>.Empty) { }

    public void AddTerritories(IEnumerable<Territory> territories)
    {
        Territories = Territories.Concat(territories).ToHashSet();
    }
    
    public void RemoveTerritory(Territory territory)
    {
        Territories.Remove(territory);
    }
    
}