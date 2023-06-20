using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RisikOOPSolution.RisikOOPGame
{
    public class TerritoryFactory
    {
        public GameTerritory CreateTerritories()
        {
            IDictionary<string, ISet<Territory>> territories = new Dictionary<string, ISet<Territory>>();
            ISet<Tuple<string, ISet<Territory>>> set = new JsonReaderTerritory().ReadFromFile();
            set.ToList().ForEach(t => territories.Add(t.Item1, t.Item2));
            return new GameTerritory(territories);
        }
    }
}
