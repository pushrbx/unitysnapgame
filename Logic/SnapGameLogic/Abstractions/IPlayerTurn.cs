namespace SnapGameLogic.Abstractions
{
    public interface IPlayerTurn : ITurnObject
    {
        ICardGamePlayer AssociatedPlayer { get; }
    }
}
