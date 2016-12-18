namespace SnapGameLogic.Abstractions
{
    public interface IGameTurnManager
    {
        IPlayerTurnManager PlayerTurnManager { get; }

        bool ActivateNextTurn();
    }
}
