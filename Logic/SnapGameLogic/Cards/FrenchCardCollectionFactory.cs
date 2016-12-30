using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCardCollectionFactory : ICardCollectionFactory
    {
        public ICardCollection CreateFaceDownPile()
        {
            var cardCollection = new FrenchCardCollection();
            cardCollection.GenerateCards();
            cardCollection.ShuffleCards();

            return cardCollection;
        }

        public ICardCollection CreateEmptyFaceUpPile()
        {
            return new FrenchCardCollection();
        }
    }
}
