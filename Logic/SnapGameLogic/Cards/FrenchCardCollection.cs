using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCardCollection : ICardCollection
    {
        private Stack<ICardObject> m_cards;

        public FrenchCardCollection()
        {
            m_cards = new Stack<ICardObject>();
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

        public bool GenerateCards()
        {
            throw new NotImplementedException();
        }

        public bool ShuffleCards()
        {
            throw new NotImplementedException();
        }

        public ICardObject PopNextCard()
        {
            return m_cards.Pop();
        }
    }
}
