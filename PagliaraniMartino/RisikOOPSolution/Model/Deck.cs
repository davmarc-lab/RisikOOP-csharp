namespace RisikOOPSolution.Model;

public class Deck<T>
{
    public IList<T> Cards { get; }
    private readonly Random _rng = new Random();

    public Deck()
    {
        Cards = new List<T>();
    }

    public void AddCard(T card)
    {
        Cards.Add(card);
    }

    public void RemoveCard(T card)
    {
        Cards.Remove(card);
    }

    public T DrawCard()
    {
        if (!Cards.Any())
        {
            throw new Exception("The deck is empty");
        }

        var drawnCard = Cards[0];
        Cards.Remove(drawnCard);
        return drawnCard;
    }

    public void Shuffle(IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = _rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}