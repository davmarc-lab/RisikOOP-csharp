using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisikOOPSolution.model
{
    internal class Movement
    {
        private readonly Territory sourceTerritory;
        private readonly Territory destinationTerritory;

        public Movement(Territory sourceTerritory, Territory destinationTerritory)
        {
            this.sourceTerritory = new(sourceTerritory);
            this.destinationTerritory = new(destinationTerritory);
        }

        public Movement(Movement movement)
        {
            this.sourceTerritory = movement.GetSourceTerritory();
            this.destinationTerritory= movement.GetDestinationTerritory();
        }

        public bool IsMovementValid(int troops)
        {
            return sourceTerritory.GetTroops() - troops >= 1;
        }

        public void Move(int troops)
        {
            sourceTerritory.AddTroops(-troops);
            destinationTerritory.AddTroops(troops);
        }

        public Territory GetSourceTerritory()
        {
            return new(this.sourceTerritory);
        }

        public Territory GetDestinationTerritory()
        {
            return new(this.destinationTerritory);
        }

    }

    internal class Territory
    {
        private readonly string name;
        private int troops;

        public Territory(String name, int troops)
        {
            this.name = name;
            this.troops = troops;
        }

        public Territory(Territory territory)
        {
            this.name = territory.GetName();
            this.troops = territory.GetTroops();
        }

        public int GetTroops()
        {
            return this.troops;
        }

        public string GetName()
        {
            return this.name;
        }

        public void AddTroops(int troops)
        {
            this.troops += troops;
        }
    }
}
