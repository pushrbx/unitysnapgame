using System.Collections.Generic;

namespace SnapGameLogic.Abstractions
{
    public interface ICardTypeDescriptor
    {
        IList<ICardType> GetAvailableCardTypesOf<T>(T typeObject) where T : ICardType;
    }
}
