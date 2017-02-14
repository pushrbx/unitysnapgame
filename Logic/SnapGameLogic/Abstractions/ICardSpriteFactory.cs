﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SnapGameLogic.Abstractions
{
    public interface ICardSpriteFactory
    {
        Sprite CreateSpriteFor(ICardType cardType);
    }
}