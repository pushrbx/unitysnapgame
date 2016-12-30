using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SnapGameLogic.Abstractions
{
    public interface ICardCollectionFactory
    {
        ICardCollection CreateFaceDownPile();

        ICardCollection CreateEmptyFaceUpPile();
    }
}
