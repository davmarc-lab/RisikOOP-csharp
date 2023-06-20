using System.Collections.ObjectModel;

namespace RisikOOPSolution.RisikOOPGame
{
    public class GameTerritory
    {
        public IDictionary<string, ISet<Territory>> Territories { get; set; }

        public GameTerritory(IDictionary<string, ISet<Territory>> t)
        {
            Territories = new ReadOnlyDictionary<string, ISet<Territory>>(t);
        }

        public string GetContinentNameFromTerritory(Territory t)
        {
            return Territories.Where(x => x.Value.Contains(t))
                .First()
                .Key;
        }

        public ISet<string> GetTerritoryNameSet()
        {
            return GetTerritories()
                .Select(t => t.Name)
                .ToHashSet();
        }

        public ISet<Territory> GetTerritories()
        {
            ISet<Territory> set = new HashSet<Territory>();
            Territories.Values
                .ToList()
                .ForEach(s => set.UnionWith(s));
            return set;
        }

        public Territory GetTerritory(string name)
        {
            return GetTerritories().Where(t => t.Name.Equals(name))
                .First();
        }

        public ISet<Territory> GetTerritoryByContinent(string name)
        {
            return Territories.Where(x => x.Key.Equals(name))
                .First()
                .Value;
        }
    }
}
