namespace RisikOOPSolution.Model;

static class Constants
{
    public const int MAX_DICE_NUMBER = 6;
    public const int MAX_ATTACK_DEFEND_ARMY = 3;
    public const int MIN_ATTACK_DEFEND_ARMY = 1;
}

public class Combat
{
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

    public Tuple<int, int> attack(int numAttacker, int numDefender)
    {
        _attacker = new Tuple<Territory, int>(_attacker.Item1, numAttacker);
        _defender = new Tuple<Territory, int>(_defender.Item1, numDefender);

        if (!isNumberTroopsValid())
        {
            throw new ArgumentException("The number of troops cannot be less or equal 0 or more than 3");
        }

        if (!checkAttackValidity())
        {
            return Tuple.Create(0, 0);
        }

        if (!_attackers.Any() && !_defenders.Any())
        {
            _attackers = declarePower(_attacker.Item2);
            _defenders = declarePower(_defender.Item2);
        }
        return computeAttack(_attackers, _defenders);
    }

    private bool isNumberTroopsValid()
    {
        return _defender.Item2 <= Constants.MAX_ATTACK_DEFEND_ARMY && _defender.Item2 >= Constants.MIN_ATTACK_DEFEND_ARMY
                && _attacker.Item2 <= Constants.MAX_ATTACK_DEFEND_ARMY && _attacker.Item2 >= Constants.MIN_ATTACK_DEFEND_ARMY;
    }

    private bool checkAttackValidity()
    {
        return true;
    }

    private IList<int> declarePower(int number)
    {
        return Enumerable.Range(0, number)
            .Select(i => rollDice())
            .OrderByDescending(i => i)
            .ToList();
    }

    private int rollDice()
    {
        return new Random().Next(Constants.MAX_DICE_NUMBER) + 1;
    }

    private Tuple<int, int> computeAttack(IList<int> attackers, IList<int> defenders)
    {
        IList<bool> results = new List<bool>();
        while (attackers.Any() && defenders.Any())
        {
            results.Add(attackers[0] > defenders[0] ? true : false);
            attackers.RemoveAt(0);
            defenders.RemoveAt(0);
        }

        return new Tuple<int, int>(results.Count(v => results.Contains(true)), results.Count(v => results.Contains(false)));
    }
}