using System.Collections.Generic;

namespace SnapGameLogic.Abstractions
{
    public interface ICardDealerLogic
    {
        IList<ICardCollection> DealCards(int playerCount);
    }
}
