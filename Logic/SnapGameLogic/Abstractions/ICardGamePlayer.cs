namespace SnapGameLogic.Abstractions
{
    public interface ICardGamePlayer
    {
        int Score { get; }

        string Name { get; }

        int CardCount { get; }
    }
}
