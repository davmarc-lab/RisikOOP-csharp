namespace RisikOOPSolution.Model;

public class Territory
{
    public string Name { get; set;  }
    public int Troops { get; set; }
    public readonly ISet<string> Adjust;

    public Territory(string name, int troops, ISet<string> adjust)
    {
        Name = name;
        Troops = troops;
        Adjust = adjust;
    }

    public void AddTroops(int troops)
    {
        Troops += troops;
    }
}