namespace RisikOOPSolution.Model;

public class ObjectiveBuilder
{
    private Color _armyColor;
    private string _firstContinent;
    private string _secondContinent;
    private bool _thirdContinent;
    private int _numTerritoriesToConquer;
    private int _minNumArmies;
    private Objective.ObjectiveType _objectiveType = Objective.ObjectiveType.None;

    public static ObjectiveBuilder NewBuilder()
    {
        return new ObjectiveBuilder();
    }

    public ObjectiveBuilder ArmyColor(Color armyColor)
    {
        _armyColor = armyColor;
        return this;
    }

    public ObjectiveBuilder FirstContinent(string firstContinent)
    {
        _firstContinent = firstContinent;
        return this;
    }

    public ObjectiveBuilder SecondContinent(string secondContinent)
    {
        _secondContinent = secondContinent;
        return this;
    }

    public ObjectiveBuilder ThirdContinent(bool thirdContinent)
    {
        _thirdContinent = thirdContinent;
        return this;
    }

    public ObjectiveBuilder NumTerritoriesToConquer(int numTerritoriesToConquer)
    {
        _numTerritoriesToConquer = numTerritoriesToConquer;
        return this;
    }

    public ObjectiveBuilder MinNumArmies(int minNumArmies)
    {
        _minNumArmies = minNumArmies;
        return this;
    }

    public ObjectiveBuilder ObjectiveType(Objective.ObjectiveType objectiveType)
    {
        _objectiveType = objectiveType;
        return this;
    }

    public Objective Build()
    {
        return new Objective(_firstContinent, _secondContinent, _thirdContinent, _numTerritoriesToConquer,
            _minNumArmies, _objectiveType, _armyColor);
    }
}