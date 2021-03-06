﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SnapGameLogic.Abstractions;
using SnapGameLogic.Internal;

namespace SnapGameLogic
{
    public class Player : ICardGamePlayer
    {
        public Player(string name, ICardCollection faceDownPile, ICardCollection faceUpPile)
        {
            Check.NotNull(faceDownPile, "faceDownPile");
            Check.NotNull(faceUpPile, "faceUpPile");

            Name = name;

            FaceDownPile = faceDownPile;
            FaceUpPile = faceUpPile;
        }

        public int Score { get; set; }

        public string Name { get; private set; }

        public int CardCount { get; set; }

        public bool IsComputerPlayer { get; set; }

        public ICardCollection FaceDownPile { get; }

        public ICardCollection FaceUpPile { get; }
    }
}
