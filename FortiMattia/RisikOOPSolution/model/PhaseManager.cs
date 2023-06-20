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

        private Phase _phase;

        public PhaseManager()
        {
            _phase = Phase.REINFORCEMENTS;
        }

        public string GetCurrentPhase()
        {
            return _phase.ToString();
        }

        public void SwitchToNextPhase()
        {
            Phase[] arr = (Phase[])Enum.GetValues(typeof(Phase));
            int index = Array.IndexOf(arr, _phase);
            _phase = arr[(index + 1) % arr.Length];
        }

        public void SwitchToPhase(string phase)
        {
            _phase = (Phase)Enum.Parse(typeof(Phase), phase);
        }
    }
}
