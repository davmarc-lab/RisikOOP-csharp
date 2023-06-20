using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RisikOOPSolution.RisikOOPGame
{
    public class JsonReaderTerritory
    {
        private string TERRITORIES_PATH = "Territories.json";

        private ISet<Tuple<string, ISet<Territory>>> _territories;

        public JsonReaderTerritory()
        {
            _territories = new HashSet<Tuple<string, ISet<Territory>>>();
        }

        public ISet<Tuple<string, ISet<Territory>>> ReadFromFile()
        {
            dynamic _jsonFile = JsonConvert.DeserializeObject<List<JToken>>(File.ReadAllText(TERRITORIES_PATH));

            foreach (JToken elem in _jsonFile)
            {
                JToken continentName = elem.SelectToken("continent");
                JToken territory = elem.SelectToken("territories");
                _territories.Add(new Tuple<string, ISet<Territory>>(continentName.ToString(), new HashSet<Territory>()));
                foreach (JToken t in territory)
                {
                    JToken tName = t.SelectToken("name");
                    _territories.Where(x => continentName.ToString().Equals(x.Item1))
                        .First()
                        .Item2
                        .Add(new Territory(tName.ToString()));
                }
            }
            foreach (JToken elem in _jsonFile)
            {
                JToken territory = elem.SelectToken("territories");
                foreach (JToken t in territory)
                {
                    JToken tName = t.SelectToken("name");
                    JToken tAdj = t.SelectToken("adj");
                    foreach (JToken adj in tAdj)
                    {
                        ISet<Territory> adjTemp = new HashSet<Territory>();
                        adjTemp.Add(GetTerritory(adj.ToString()));
                        adjTemp.UnionWith(GetTerritory(tName.ToString()).AdjTerritories);
                        GetTerritory(tName.ToString()).AdjTerritories = adjTemp;
                    }
                }
            }
            return _territories;
        }

        private Territory GetTerritory(string name)
        {
            return GetTerritories().Where(t => t.Name.Equals(name))
                .First();
        }

        public ISet<Territory> GetTerritories()
        {
            ISet<Territory> set = new HashSet<Territory>();
            _territories.ToList()
                .ForEach(x => set.UnionWith(x.Item2));
            return set;
        }
    }
}
