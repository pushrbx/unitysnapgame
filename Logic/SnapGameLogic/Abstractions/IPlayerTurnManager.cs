using System.Collections.Generic;

namespace SnapGameLogic.Abstractions
{
    public interface IPlayerTurnManager
    {
        IEnumerable<IPlayerTurn> PlayerTurns { get; }

        bool ResetPlayerTurns();

        bool ActivateNextPlayerTurn();
    }
}
