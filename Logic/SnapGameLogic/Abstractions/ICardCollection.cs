using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SnapGameLogic.Abstractions
{
    /// <summary>
    /// An interface which represents a Deck of cards.
    /// </summary>
    public interface ICardCollection : ICollection<ICardObject>
    {
        ICardObject PopNextCard();

        ICardType ContentType { get; }
    }
}
