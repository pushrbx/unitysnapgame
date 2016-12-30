namespace SnapGameLogic.Abstractions
{
    public interface ICardGamePlayer
    {
        int Score { get; set; }

        string Name { get; }

        int CardCount { get; set; }

        bool IsComputerPlayer { get; set; }

        ICardCollection FaceDownPile { get; }

        ICardCollection FaceUpPile { get; }
    }
}
