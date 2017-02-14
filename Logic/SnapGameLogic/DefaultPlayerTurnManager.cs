using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnapGameLogic.Abstractions;

namespace SnapGameLogic
{
    public class DefaultPlayerTurnManager : IPlayerTurnManager
    {
        private readonly List<IPlayerTurn> m_playerTurns;

        public DefaultPlayerTurnManager()
        {
            m_playerTurns = new List<IPlayerTurn>();
        }

        public IEnumerable<IPlayerTurn> PlayerTurns { get { return m_playerTurns; } }

        public bool ResetPlayerTurns()
        {
            return true;
        }

        public bool ActivateNextPlayerTurn()
        {
            return true;
        }
    }
}
