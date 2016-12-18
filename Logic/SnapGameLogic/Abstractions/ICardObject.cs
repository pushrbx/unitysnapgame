using System;
using UnityEngine;

namespace SnapGameLogic.Abstractions
{
    public interface ICardObject : IEquatable<ICardObject>
    {
        Sprite CardGraphic { get; }

        ICardType Type { get; }
    }
}
