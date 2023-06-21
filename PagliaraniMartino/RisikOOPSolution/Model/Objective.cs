namespace RisikOOPSolution.Model;

public class Objective
{
    public enum ObjectiveType
    {
        Conquer,
        Destroy,
        None
    }

    public Objective(string firstContinent, string secondContinent, bool thirdContinent, int numTerritoriesToConquer,
        int minNumArmies, ObjectiveType objType, Color armyColor)
    {
        FirstContinent = firstContinent;
        SecondContinent = secondContinent;
        ThirdContinent = thirdContinent;
        NumTerritoriesToConquer = numTerritoriesToConquer;
        MinNumArmies = minNumArmies;
        ObjType = objType;
        ArmyColor = armyColor;
        Description = CreateDescription();
    }

    public string Description { get; }
    public ObjectiveType ObjType { get; set; }
    public Color ArmyColor { get; }
    public string FirstContinent { get; set; }
    public string SecondContinent { get; set; }
    public bool ThirdContinent { get; set; }
    public int NumTerritoriesToConquer { get; set; }
    public int MinNumArmies { get; set; }
    public Tuple<ObjectiveType, IList<string>> CheckObjectives { get; set; }
    private bool _complete = false;

    public bool IsComplete() => _complete;

    public void SetComplete()
    {
        _complete = true;
    }

    private string CreateDescription()
    {
        if (ObjType == ObjectiveType.Destroy)
        {
            CheckObjectives = new Tuple<ObjectiveType, IList<string>>(ObjType, new List<string>() { ArmyColor.Name });
            return $"Destroy the {ArmyColor.Name} army.";
        }

        if (string.IsNullOrEmpty(FirstContinent))
        {
            CheckObjectives = new Tuple<ObjectiveType, IList<string>>(ObjType,
                new List<string>() { NumTerritoriesToConquer.ToString(), MinNumArmies.ToString() });
            return $"Conquer {NumTerritoriesToConquer} territories with at least {MinNumArmies} troop.";
        }

        if (ThirdContinent)
        {
            CheckObjectives = new Tuple<ObjectiveType, IList<string>>(ObjType,
                new List<string>() { FirstContinent, SecondContinent, ThirdContinent.ToString() });
            return $"Conquer {FirstContinent} and {SecondContinent} and another continent of your choice.";
        }
        else
        {
            CheckObjectives = new Tuple<ObjectiveType, IList<string>>(ObjType,
                new List<string>() { FirstContinent, SecondContinent, ThirdContinent.ToString() });
            return $"Conquer {FirstContinent} and {SecondContinent}.";
        }
    }
}