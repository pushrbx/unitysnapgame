using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGameLogic.Abstractions
{
    public interface ICardType : IEquatable<ICardType>
    {
        string Name { get; }

        int Value { get; }
    }
}
