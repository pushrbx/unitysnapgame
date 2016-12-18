namespace SnapGameLogic.Abstractions
{
    public interface IGameTurn : ITurnObject
    {
        int Number { get; }

        IPlayerTurnManager PlayerTurnManager { get; }
    }
}
