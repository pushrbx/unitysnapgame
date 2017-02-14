using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Internal;
using UnityEngine;

namespace SnapGameLogic.Cards
{
    public class FrenchCardObject : ICardObject
    {
        private readonly FrenchCardComparer m_comparer;

        public FrenchCardObject(FrenchCardType type, Sprite cardGraphic)
        {
            Check.NotNull(type, "type");
            Check.NotNull(cardGraphic, "cardGraphic");

            m_comparer = new FrenchCardComparer();
            Type = type;
            CardGraphic = cardGraphic;
        }

        public bool Equals(ICardObject other)
        {
            return m_comparer.Equals(this, other);
        }

        public Sprite CardGraphic { get; }

        public ICardType Type { get; }
    }
}
