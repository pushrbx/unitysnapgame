using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCardCollectionFactory : ICardCollectionFactory
    {
        public ICardCollection CreateCardCollection()
        {
            return new FrenchCardCollection();
        }
    }
}
