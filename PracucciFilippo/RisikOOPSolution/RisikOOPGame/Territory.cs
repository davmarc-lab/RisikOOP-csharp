using System.Text;

namespace RisikOOPSolution.RisikOOPGame
{
    public class Territory
    {
        public string Name { get; }

        private ISet<Territory> _adjTerritories;
        private int _numTroops;

        public ISet<Territory> AdjTerritories
        {
            get => _adjTerritories;
            set => _adjTerritories = value;
        }

        public int NumTroops 
        {
            get => _numTroops;
            set => _numTroops += value;  
        }

        public Territory(string name)
        {
            this.Name = name;
            this.AdjTerritories = new HashSet<Territory>();
            this.NumTroops = 0;
        }

        public override string ToString()
        {
            return new StringBuilder("NAME = ")
                .Append(Name)
                .Append(", ADJ = (")
                .Append(string.Join("; ", AdjTerritories.Select(t => t.Name)))
                .Append(')')
                .ToString();
        }
    }
}
