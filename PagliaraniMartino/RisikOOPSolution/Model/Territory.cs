namespace RisikOOPSolution.Model;

public class Territory
{
    public Territory(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public int Troops { get; set; }

    public int AddTroops(int i) => Troops += i;
}