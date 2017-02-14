using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Cards;
using SnapGameLogic.Internal;

namespace SnapGameLogic
{
    public class DefaultCardDealerLogic : ICardDealerLogic
    {
        private readonly ICardCollectionFactory m_cardCollectionFactory;
        private readonly ICardTypeDescriptor m_cardTypeDescriptor;
        private readonly ICardObjectFactory m_cardObjectFactory;
        private static readonly int _totalCardCount = 52;

        public DefaultCardDealerLogic(ICardCollectionFactory cardCollectionFactory,
            ICardTypeDescriptor cardTypeDescriptor, ICardObjectFactory cardObjectFactory)
        {
            Check.NotNull(cardCollectionFactory, "cardCollectionFactory");
            Check.NotNull(cardTypeDescriptor, "cardTypeDescriptor");
            Check.NotNull(cardObjectFactory, "cardObjectFactory");

            m_cardCollectionFactory = cardCollectionFactory;
            m_cardTypeDescriptor = cardTypeDescriptor;
            m_cardObjectFactory = cardObjectFactory;
        }

        public IList<ICardCollection> DealCards(int playerCount)
        {
            var result = new List<ICardCollection>();

            for (int i = 0; i < playerCount; i++)
            {
                var collection = m_cardCollectionFactory.CreateCardCollection();
                // deal the card equally between the players.
                collection = GenerateCardsFor(collection, (_totalCardCount / playerCount));
                result.Add(collection);
            }

            return result;
        }

        protected internal ICardCollection GenerateCardsFor(ICardCollection cardCollection, int count)
        {
            var availableCardTypes = m_cardTypeDescriptor.GetAvailableCardTypesOf(cardCollection.ContentType);
            var rnd = new Random();

            // shuffle add cards
            for (int i = 0; i < count; i++)
            {
                var index = rnd.Next(0, availableCardTypes.Count - 1);
                cardCollection.Add(m_cardObjectFactory.CreateCardObject(availableCardTypes.ElementAt(index)));
            }

            return cardCollection;
        }
    }
}
