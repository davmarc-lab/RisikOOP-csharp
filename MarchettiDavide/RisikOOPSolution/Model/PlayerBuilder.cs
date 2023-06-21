namespace RisikOOPSolution.Model;

public class PlayerBuilder
{
    private int _id;
    private ISet<Territory> _territories = new HashSet<Territory>();

    public static PlayerBuilder NewBuilder() => new PlayerBuilder();

    public PlayerBuilder Id(int id)
    {
        _id = id;
        return this;
    }

    public PlayerBuilder Territories(ISet<Territory> territories)
    {
        _territories = territories;
        return this;
    }

    public Player Build() => new(_id, _territories);
}