namespace RisikOOPSolution.Model;

internal enum Result
{
    Win,
    Lose
}

public class Combat
{
    private const int MaxDiceNumber = 6;
    private const int MaxAttackDefendTroops = 3;
    private const int MinAttackDefendTroops = 1;

    private IList<int> _attackers = new List<int>();
    private IList<int> _defenders = new List<int>();
    private Tuple<Territory, int> _attacker;
    private Tuple<Territory, int> _defender;

    public Combat(Territory tAttacker, int numberAttacker, Territory tDefender, int numberDefender)
    {
        _attacker = new Tuple<Territory, int>(tAttacker, numberAttacker);
        _defender = new Tuple<Territory, int>(tDefender, numberDefender);
    }

    public Combat(Territory tAttacker, int numberAttacker, Territory tDefender, int numberDefender,
        IList<int> attackers, IList<int> defenders) : this(tAttacker, numberAttacker, tDefender, numberDefender)
    {
        _attackers = attackers;
        _defenders = defenders;
    }

    public Tuple<int, int> Attack(int numAttacker, int numDefender)
    {
        _attacker = new Tuple<Territory, int>(_attacker.Item1, numAttacker);
        _defender = new Tuple<Territory, int>(_defender.Item1, numDefender);

        if (!IsNumberTroopsValid())
        {
            throw new ArgumentException("The number of troops cannot be less or equal 0 or more than 3");
        }

        if (!CheckAttackValidity())
        {
            return Tuple.Create(0, 0);
        }

        if (_attackers.Any() && _defenders.Any())
        {
            return ComputeAttack(_attackers, _defenders);
        }

        _attackers = DeclarePower(_attacker.Item2);
        _defenders = DeclarePower(_defender.Item2);
        return ComputeAttack(_attackers, _defenders);
    }

    private bool IsNumberTroopsValid()
    {
        return _defender.Item2.CompareTo(MaxAttackDefendTroops) <= 0 &&
               _defender.Item2.CompareTo(MinAttackDefendTroops) >= 0 &&
               _attacker.Item2.CompareTo(MaxAttackDefendTroops) <= 0 &&
               _attacker.Item2.CompareTo(MinAttackDefendTroops) >= 0;
    }

    private bool CheckAttackValidity()
    {
        return _attacker.Item1.Adjust.Contains(_defender.Item1.Name);
    }

    private IList<int> DeclarePower(int number)
    {
        return Enumerable.Range(0, number)
            .Select(_ => RollDice())
            .OrderByDescending(i => i)
            .ToList();
    }

    private int RollDice()
    {
        return new Random().Next(MaxDiceNumber) + 1;
    }

    private Tuple<int, int> ComputeAttack(IList<int> attackers, IList<int> defenders)
    {
        IList<Result> results = new List<Result>();
        while (attackers.Any() && defenders.Any())
        {
            results.Add(attackers[0] > defenders[0] ? Result.Win : Result.Lose);
            attackers.RemoveAt(0);
            defenders.RemoveAt(0);
        }
        return new Tuple<int, int>(results.Count(r => r.Equals(Result.Lose)), results.Count(r => r.Equals(Result.Win)));
    }
}