using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnapGameLogic.Abstractions;

namespace SnapGameLogic
{
    public class DefaultCardTypeDescriptor : ICardTypeDescriptor
    {
        public IList<ICardType> GetAvailableCardTypesOf<T>(T typeObject) where T : ICardType
        {
            // todo: cache reflection operation
            var result = new List<ICardType>();
            var fieldInfos = typeObject.GetType().GetFields();

            foreach (var field in fieldInfos)
            {
                // filter out those fields which are cannot be assigned to a ICardType type.
                if (!typeof(ICardType).IsAssignableFrom(field.FieldType))
                    continue;

                result.Add((ICardType)field.GetValue(null));
            }

            return result;
        }
    }
}
