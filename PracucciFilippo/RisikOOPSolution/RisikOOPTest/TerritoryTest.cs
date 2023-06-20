using RisikOOPSolution.RisikOOPGame;

namespace RisikOOPSolution
{
    [TestClass]
    public class TerritoryTest
    {
        private GameTerritory _territories;

        [TestInitialize]
        public void InitTerritoryFactory()
        {
            _territories = new TerritoryFactory().CreateTerritories();
        }

        [TestMethod]
        public void TestCreationTerritories()
        {
            Territory t = _territories.GetTerritory("Argentina");
            ISet<string> argAdj = new HashSet<string>() { "Brazil", "Peru'" };
            Assert.AreEqual(t.Name, "Argentina");
            Assert.IsTrue(t.AdjTerritories
                .Select(x => x.Name)
                .ToHashSet()
                .All(x => argAdj.Contains(x)));
            Assert.ThrowsException<InvalidOperationException>(() => _territories.GetTerritory("Italy"));
        }

        [TestMethod]
        public void TestContinentFromTerritory()
        {
            Territory tM = _territories.GetTerritory("Madagascar");
            Territory tJ = _territories.GetTerritory("Japan");
            Assert.AreEqual(_territories.GetContinentNameFromTerritory(tM), "Africa");
            Assert.AreNotEqual(_territories.GetContinentNameFromTerritory(tJ), "Europe");
            Assert.ThrowsException<InvalidOperationException>(() => _territories.GetContinentNameFromTerritory(new Territory("France")));
        }

        [TestMethod]
        public void TestTerritoryNameSet()
        {
            ISet<string> nameSet = _territories.GetTerritoryNameSet();
            Assert.AreEqual(nameSet.Where(s => "Alaska".Equals(s))
                .First(),
                "Alaska");
            Assert.IsTrue(nameSet.Contains("China"));
            Assert.IsFalse(nameSet.Contains("japan"));
        }

        [TestMethod]
        public void TestAdjTerritories()
        {
            ISet<string> continentSet = new HashSet<string>();
            _territories.GetTerritory("Southern Europe")
                .AdjTerritories
                .ToList()
                .ForEach(t => continentSet.Add(t.Name));
            ISet<string> set = new HashSet<string>()
            {
                "Western Europe",
                "Northern Europe",
                "Ukraine",
                "North Africa",
                "Egypt",
                "Middle East"
            };
            Assert.IsTrue(continentSet.All(x => set.Contains(x)));
            continentSet.Clear();
            _territories.GetTerritory("Eastern Australia")
                .AdjTerritories
                .ToList()
                .ForEach(t => continentSet.Add(t.Name));
            set.Clear();
            set = new HashSet<string>() { "Western Australia", "New Guinea" };
            Assert.IsTrue(set.All(x => set.Contains(x)));
            Assert.IsFalse(_territories.GetTerritory("Japan")
                .AdjTerritories
                .Contains(_territories.GetTerritory("Siam")));
        }

        [TestMethod]
        public void TestTerritorySet()
        {
            ISet<Territory> tSet = _territories.GetTerritories();
            Assert.IsInstanceOfType(tSet.Where(t => "Quebec".Equals(t.Name)).First(),
                typeof(Territory));
            Assert.IsTrue(tSet.Contains(_territories.GetTerritory("Ontario")));
            Assert.IsFalse(tSet.Contains(new Territory("Alberia")));
        }

        [TestMethod]
        public void TestTerritoryByContinent()
        {
            Assert.IsTrue(_territories.GetTerritoryByContinent("Europe")
                .Contains(_territories.GetTerritory("Great Britain")));
            Assert.IsTrue(_territories.GetTerritoryByContinent("Oceania")
                .Contains(_territories.GetTerritory("Indonesia")));
            Assert.AreEqual(_territories.GetTerritoryByContinent("North America")
                .Where(t => "Alaska".Equals(t.Name))
                .First(),
                _territories.GetTerritory("Alaska"));
        }
    }
}