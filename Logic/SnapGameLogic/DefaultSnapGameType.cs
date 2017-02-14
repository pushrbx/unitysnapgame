using System.Collections.Generic;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Internal;

namespace SnapGameLogic
{
    public class DefaultSnapGameType : ISlapjackGame
    {
        public DefaultSnapGameType(ICardDealerLogic cardDealer, ICardCollectionFactory cardCollectionFactory)
        {
            Check.NotNull(cardDealer, "cardDealer");
            Check.NotNull(cardCollectionFactory, "cardCollectionFactory");

            var decksOfPlayers = cardDealer.DealCards(PlayerCount);
            
            Players = new List<ICardGamePlayer>()
            {
                new Player("Ray", decksOfPlayers[0], cardCollectionFactory.CreateCardCollection()),
                new Player("Lucy", decksOfPlayers[1], cardCollectionFactory.CreateCardCollection()),
                new Player("Steve", decksOfPlayers[2], cardCollectionFactory.CreateCardCollection()),
                new Player("Player 1", decksOfPlayers[3], cardCollectionFactory.CreateCardCollection()),
            };

            DealingLogic = cardDealer;
        }

        public IList<ICardGamePlayer> Players { get; }

        public int PlayerCount { get { return 4; } }

        public ICardDealerLogic DealingLogic { get; }
    }
}
