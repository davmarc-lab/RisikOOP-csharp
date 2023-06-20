using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisikOOPSolution.model
{
    internal class PhaseManager
    {
        enum Phase
        {
            REINFORCEMENTS,
            COMBAT,
            MOVEMENT
        }

        private Phase phase;

        public PhaseManager()
        {
            this.phase = Phase.REINFORCEMENTS;
        }

        public string GetCurrentPhase()
        {
            return this.phase.ToString();
        }

        public void SwitchToNextPhase()
        {
            Phase[] arr = (Phase[])Enum.GetValues(typeof(Phase));
            int index = Array.IndexOf(arr, this.phase);
            this.phase = arr[(index + 1) % arr.Length];
        }

        public void SwitchToPhase(string phase)
        {
            this.phase = (Phase)Enum.Parse(typeof(Phase), phase);
        }
    }
}
