using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCardCollection : ICardCollection
    {
        private readonly Stack<ICardObject> m_cards;
        private static FieldInfo[] _cardTypeFieldInfos;

        public FrenchCardCollection()
        {
            m_cards = new Stack<ICardObject>();
            ContentType = FrenchCardType.Clubs_2; // just meta data info
        }

        private static FieldInfo[] CardTypeFieldInfos
        {
            get { return _cardTypeFieldInfos ?? (_cardTypeFieldInfos = typeof(FrenchCardType).GetFields()); }
        }

        public IEnumerator<ICardObject> GetEnumerator()
        {
            return m_cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICardObject item)
        {
            m_cards.Push(item);
        }

        public void Clear()
        {
            m_cards.Clear();
        }

        public bool Contains(ICardObject item)
        {
            return m_cards.Contains(item);
        }

        public void CopyTo(ICardObject[] array, int arrayIndex)
        {
            m_cards.CopyTo(array, arrayIndex);
        }

        public bool Remove(ICardObject item)
        {
            throw new NotSupportedException();
        }

        public int Count { get { return m_cards.Count; } }

        public bool IsReadOnly { get { return true; } }

        public ICardObject PopNextCard()
        {
            return m_cards.Pop();
        }

        public ICardType ContentType { get; }

        /// <summary>
        /// Returns the list of available card types
        /// </summary>
        /// <returns>
        /// The list of available card types.
        /// </returns>
        protected internal virtual IList<ICardType> GetCardTypes()
        {
            var result = new List<ICardType>();

            foreach (var field in CardTypeFieldInfos)
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
