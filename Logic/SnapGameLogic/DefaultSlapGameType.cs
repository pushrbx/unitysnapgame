using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SnapGameLogic.Abstractions;

namespace SnapGameLogic
{
    public class DefaultSlapGameType : ISlapjackGame
    {
        public DefaultSlapGameType(ICardCollectionFactory cardCollectionFactory)
        {
            Players = new List<ICardGamePlayer>()
            {
                new Player("Ray", cardCollectionFactory) { IsComputerPlayer = true },
                new Player("Lucy", cardCollectionFactory) { IsComputerPlayer = true },
                new Player("Steve", cardCollectionFactory) { IsComputerPlayer = true },
                new Player("Player 1", cardCollectionFactory) { IsComputerPlayer = false }
            };
        }

        public IList<ICardGamePlayer> Players { get; }
    }
}
