using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisikOOPSolution.model
{
    internal class Movement
    {
        public Territory SourceTerritory { get; }
        public Territory DestinationTerritory { get; }

        public Movement(Territory sourceTerritory, Territory destinationTerritory)
        {
            SourceTerritory = new(sourceTerritory);
            DestinationTerritory = new(destinationTerritory);
        }

        public bool IsMovementValid(int troops)
        {
            return SourceTerritory.Troops - troops >= 1;
        }

        public void Move(int troops)
        {
            SourceTerritory.AddTroops(-troops);
            DestinationTerritory.AddTroops(troops);
        }
    }

    internal class Territory
    {
        public string Name { get; }
        public int Troops { get; set; }

        public Territory(String name, int troops)
        {
            Name = name;
            Troops = troops;
        }

        public Territory(Territory territory)
        {
            Name = territory.Name;
            Troops = territory.Troops;
        }

        public void AddTroops(int troops)
        {
            Troops += troops;
        }
    }
}
