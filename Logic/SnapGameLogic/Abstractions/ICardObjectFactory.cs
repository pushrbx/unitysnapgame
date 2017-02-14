using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnapGameLogic.Abstractions
{
    public interface ICardObjectFactory
    {
        ICardObject CreateCardObject(ICardType type);
    }
}
