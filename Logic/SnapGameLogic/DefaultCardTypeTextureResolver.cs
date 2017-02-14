using System;
using System.Collections.Generic;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Cards;
using UnityEngine;

namespace SnapGameLogic
{
    public class DefaultCardTypeTextureResolver : ICardTypeTextureResolver
    {
        //private const string BasePath = "Assets/Standard Assets/2D/Sprites/";

        private static readonly Dictionary<int, string> TypeToPathMap = new Dictionary<int, string>()
        {
            {FrenchCardType.Clubs_Ace.Value, "Clubs Ace"},
            {FrenchCardType.Clubs_2.Value, "Clubs 2"},
            {FrenchCardType.Clubs_3.Value, "Clubs 3"},
            {FrenchCardType.Clubs_4.Value, "Clubs 4"},
            {FrenchCardType.Clubs_5.Value, "Clubs 5"},
            {FrenchCardType.Clubs_6.Value, "Clubs 6"},
            {FrenchCardType.Clubs_7.Value, "Clubs 7"},
            {FrenchCardType.Clubs_8.Value, "Clubs 8"},
            {FrenchCardType.Clubs_9.Value, "Clubs 9"},
            {FrenchCardType.Clubs_10.Value, "Clubs 10"},
            {FrenchCardType.Clubs_Joker.Value, "Clubs Jack"},
            {FrenchCardType.Clubs_Queen.Value, "Clubs Queen"},
            {FrenchCardType.Clubs_King.Value, "Clubs King"},
            {FrenchCardType.Diamonds_Ace.Value, "Diamonds Ace"},
            {FrenchCardType.Diamonds_2.Value, "Diamonds 2"},
            {FrenchCardType.Diamonds_3.Value, "Diamonds 3"},
            {FrenchCardType.Diamonds_4.Value, "Diamonds 4"},
            {FrenchCardType.Diamonds_5.Value, "Diamonds 5"},
            {FrenchCardType.Diamonds_6.Value, "Diamonds 6"},
            {FrenchCardType.Diamonds_7.Value, "Diamonds 7"},
            {FrenchCardType.Diamonds_8.Value, "Diamonds 8"},
            {FrenchCardType.Diamonds_9.Value, "Diamonds 9"},
            {FrenchCardType.Diamonds_10.Value, "Diamonds 10"},
            {FrenchCardType.Diamonds_Joker.Value, "Diamonds Jack"},
            {FrenchCardType.Diamonds_Queen.Value, "Diamonds Queen"},
            {FrenchCardType.Diamonds_King.Value, "Diamonds King"},
            {FrenchCardType.Hearts_Ace.Value, "Hearts Ace"},
            {FrenchCardType.Hearts_2.Value, "Hearts 2"},
            {FrenchCardType.Hearts_3.Value, "Hearts 3"},
            {FrenchCardType.Hearts_4.Value, "Hearts 4"},
            {FrenchCardType.Hearts_5.Value, "Hearts 5"},
            {FrenchCardType.Hearts_6.Value, "Hearts 6"},
            {FrenchCardType.Hearts_7.Value, "Hearts 7"},
            {FrenchCardType.Hearts_8.Value, "Hearts 8"},
            {FrenchCardType.Hearts_9.Value, "Hearts 9"},
            {FrenchCardType.Hearts_10.Value, "Hearts 10"},
            {FrenchCardType.Hearts_Joker.Value, "Hearts Jack"},
            {FrenchCardType.Hearts_Queen.Value, "Hearts Queen"},
            {FrenchCardType.Hearts_King.Value, "Hearts King"},
            {FrenchCardType.Spades_Ace.Value, "Spades Ace"},
            {FrenchCardType.Spades_2.Value, "Spades 2"},
            {FrenchCardType.Spades_3.Value, "Spades 3"},
            {FrenchCardType.Spades_4.Value, "Spades 4"},
            {FrenchCardType.Spades_5.Value, "Spades 5"},
            {FrenchCardType.Spades_6.Value, "Spades 6"},
            {FrenchCardType.Spades_7.Value, "Spades 7"},
            {FrenchCardType.Spades_8.Value, "Spades 8"},
            {FrenchCardType.Spades_9.Value, "Spades 9"},
            {FrenchCardType.Spades_10.Value, "Spades 10"},
            {FrenchCardType.Spades_Joker.Value, "Spades Jack"},
            {FrenchCardType.Spades_Queen.Value, "Spades Queen"},
            {FrenchCardType.Spades_King.Value, "Spades King"}
        };

        public Sprite Resolve(ICardType cardType)
        {
            if (!TypeToPathMap.ContainsKey(cardType.Value))
                throw new ArgumentOutOfRangeException("cardType");

            return Resources.Load<Sprite>(TypeToPathMap[cardType.Value]);
        }
    }
}
