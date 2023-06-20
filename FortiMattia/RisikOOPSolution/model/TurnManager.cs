using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisikOOPSolution.model
{
    internal class TurnManager
    {
        public List<int> PlayersIDs { get; }
        private List<int>.Enumerator _playerIterator;

        public TurnManager(List<int> playersIDs)
        {
            PlayersIDs = new List<int>(playersIDs);
            SetRandomOrder();
            _playerIterator = PlayersIDs.GetEnumerator();
            ResetTurns();
        }

        public int GetCurrentPlayerID()
        {
            return _playerIterator.Current;
        }

        public void SwitchToNextPlayer()
        {
            if (!_playerIterator.MoveNext())
            {
                ResetTurns();
            }
        }

        private void SetRandomOrder()
        {
            Random rng = new();
            int n = PlayersIDs.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (PlayersIDs[n], PlayersIDs[k]) = (PlayersIDs[k], PlayersIDs[n]);
            }
        }

        public void ResetTurns()
        {
            _playerIterator = PlayersIDs.GetEnumerator();
            _playerIterator.MoveNext();
        }
    }
}
