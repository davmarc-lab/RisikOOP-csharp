using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisikOOPSolution.model
{
    internal class TurnManager
    {
        private readonly List<int> playersIDs;
        private List<int>.Enumerator playerIterator;

        public TurnManager(List<int> _playersIDs)
        {
            this.playersIDs = new List<int>(_playersIDs);
            this.SetRandomOrder();
            this.playerIterator = this.playersIDs.GetEnumerator();
            this.ResetTurns();
        }

        public List<int> GetPlayersID()
        {
            return new List<int>(this.playersIDs);
        }

        public int GetCurrentPlayerID()
        {
            return this.playerIterator.Current;
        }

        public void SwitchToNextPlayer()
        {
            if (!this.playerIterator.MoveNext())
            {
                this.ResetTurns();
            }
        }

        private void SetRandomOrder()
        {
            Random rng = new();
            int n = playersIDs.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (playersIDs[n], playersIDs[k]) = (playersIDs[k], playersIDs[n]);
            }
        }

        public void ResetTurns()
        {
            this.playerIterator = this.playersIDs.GetEnumerator();
            this.playerIterator.MoveNext();
        }

    }

}
