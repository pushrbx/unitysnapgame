using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnapGameLogic.Abstractions;

namespace SnapGameLogic
{
    public class DefaultGameTurnManager : IGameTurnManager
    {
        public DefaultGameTurnManager(IPlayerTurnManager playerTurnManager)
        {
            PlayerTurnManager = playerTurnManager;
        }

        public IPlayerTurnManager PlayerTurnManager { get; }

        public bool ActivateNextTurn()
        {
            return true;
        }
    }
}
