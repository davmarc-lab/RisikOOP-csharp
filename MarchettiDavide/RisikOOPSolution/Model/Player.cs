using System.Collections.Immutable;

namespace RisikOOPSolution.Model;

public class Player
{
    private ISet<Territory> _territories = new HashSet<Territory>();
    
    public int Id { get; set; }
    
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
    
}