namespace RisikOOPSolution.Model;

public class Territory
{

    private string Name { get; set; }
    private int BonusTroops { get; set; }

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