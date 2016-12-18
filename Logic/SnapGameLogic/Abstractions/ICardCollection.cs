using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGameLogic.Abstractions
{
    /// <summary>
    /// An interface which represents a Deck of cards.
    /// </summary>
    public interface ICardCollection
    {
        bool GenerateCards();

        bool ShuffleCards();

        ICardObject GetNextCard();
    }
}
