namespace RisikOOPSolution.Model;

public class Territory
{

    public string Name { get; set; }
    public int BonusTroops { get; set; }

    public Territory(string name, int bonusTroops)
    {
        Name = name;
        BonusTroops = bonusTroops;
    }

    public Territory()
    {
        Name = string.Empty;
        BonusTroops = 0;
    }
}