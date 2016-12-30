using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCardComparer : ICardComparer
    {
        public bool Equals(ICardObject x, ICardObject y)
        {
            if (x == null || y == null)
                return false;

            if (x.Type == null || y.Type == null)
                return false;

            return x.Type.Value == y.Type.Value;
        }

        public int GetHashCode(ICardObject obj)
        {
            return obj.Type.GetHashCode();
        }
    }
}
