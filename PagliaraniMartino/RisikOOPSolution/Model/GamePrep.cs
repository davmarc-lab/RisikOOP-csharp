namespace RisikOOPSolution.Model;

public class GamePrep
{
    private const int MaxPlayers = 3;
    private const int InitialTroops = 21;

    public void PreparePlayers(IList<Player> players, Deck<Territory> territoryDeck,
        Tuple<Deck<Objective>, Objective> objectives)
    {
        AssignTerritories(players, territoryDeck);
        AssignObjectives(players, objectives);
        AssignTroops(players);
    }

    private void AssignTerritories(IEnumerable<Player> players, Deck<Territory> territoryDeck)
    {
        players.ToList().ForEach(player =>
            Enumerable.Range(0, territoryDeck.Cards.Count / MaxPlayers).ToList()
                .ForEach(i => player.AddTerritory(territoryDeck.DrawCard())));
    }

    private void AssignObjectives(IEnumerable<Player> players, Tuple<Deck<Objective>, Objective> objectives)
    {
        var pList = players.ToList();
        var colors = pList.Select(player => player.Color.Name);
        var availableColors = new List<Objective>();

        colors.ToList().ForEach(color =>
            objectives.Item1.Cards
                .Where(c => c.ObjType.Equals(Objective.ObjectiveType.Destroy) && c.Description.Contains(color))
                .ToList().ForEach(obj => availableColors.Add(obj)));

        objectives.Item1.Cards.Where(objective => objective.ObjType.Equals(Objective.ObjectiveType.Destroy))
            .Where(obj => !availableColors.Contains(obj)).ToList().ForEach(o => objectives.Item1.RemoveCard(o));

        pList.ToList().ForEach(player =>
        {
            var drawnObj = objectives.Item1.DrawCard();
            var finalObj = drawnObj.Description.Contains(player.Color.Name) ? objectives.Item2 : drawnObj;
            player.Objective = finalObj;
        });
    }

    private void AssignTroops(IList<Player> players)
    {
        players.ToList().ForEach(player => player.AddTroops(InitialTroops));
        players.ToList().ForEach(player =>
            player.Territories.Cards.ToList().ForEach(territory => territory.AddTroops(1)));
    }
}