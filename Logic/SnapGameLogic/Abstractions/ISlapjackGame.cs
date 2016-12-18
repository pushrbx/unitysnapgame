using System.Collections.Generic;

namespace SnapGameLogic.Abstractions
{
    /// <summary>
    /// An interface which represents a type of slapjack game
    /// </summary>
    public interface ISlapjackGame
    {
        IList<ICardGamePlayer> Players { get; }
    }
}
