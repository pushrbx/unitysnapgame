using System;
using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCard : ICardType
    {
        private readonly string m_name;
        private readonly ushort m_val;

        private FrenchCard(FrenchCardColour colour, byte cardNumber)
        {
            m_val = CompressColourAndValue(colour, cardNumber);
            m_name = GetCardName(m_val);
        }

        private ushort CompressColourAndValue(FrenchCardColour colour, byte cardNumber)
        {
            // bitformat:  cccc cccc vvvv vvvv
            return (ushort) (((ushort) colour << 8) | (cardNumber << 1));
        }

        private void DecompressValue(ushort val, out FrenchCardColour colour, out byte number)
        {
            colour = (FrenchCardColour) ((val >> 8) & 0xf);
            number = (byte) ((val >> 1) & 0xf);
        }

        private string GetCardName(ushort val)
        {
            byte cardNumber;
            FrenchCardColour colour;
            DecompressValue(val, out colour, out cardNumber);

            return string.Format("{0}_{1}", colour, GetNameIfSpecialNumber(cardNumber));
        }

        private string GetNameIfSpecialNumber(byte cardNumber)
        {
            switch (cardNumber)
            {
                case 1:
                    return "Ace";
                case 11:
                    return "Joker";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return cardNumber.ToString();
            }
        }

        public bool Equals(ICardType other)
        {
            if (other == null)
                return false;

            return other.Value == Value;
        }

        public string Name { get { return m_name; } }

        public int Value { get { return m_val; } }

        public static readonly ICardType Hearts_Ace = new FrenchCard(FrenchCardColour.Hearts, 1);
        public static readonly ICardType Hearts_2 = new FrenchCard(FrenchCardColour.Hearts, 2);
        public static readonly ICardType Hearts_3 = new FrenchCard(FrenchCardColour.Hearts, 3);
        public static readonly ICardType Hearts_4 = new FrenchCard(FrenchCardColour.Hearts, 4);
        public static readonly ICardType Hearts_5 = new FrenchCard(FrenchCardColour.Hearts, 5);
        public static readonly ICardType Hearts_6 = new FrenchCard(FrenchCardColour.Hearts, 6);
        public static readonly ICardType Hearts_7 = new FrenchCard(FrenchCardColour.Hearts, 7);
        public static readonly ICardType Hearts_8 = new FrenchCard(FrenchCardColour.Hearts, 8);
        public static readonly ICardType Hearts_9 = new FrenchCard(FrenchCardColour.Hearts, 9);
        public static readonly ICardType Hearts_10 = new FrenchCard(FrenchCardColour.Hearts, 10);
        public static readonly ICardType Hearts_Joker = new FrenchCard(FrenchCardColour.Hearts, 11);
        public static readonly ICardType Hearts_Queen = new FrenchCard(FrenchCardColour.Hearts, 12);
        public static readonly ICardType Hearts_King = new FrenchCard(FrenchCardColour.Hearts, 13);
        public static readonly ICardType Spades_Ace = new FrenchCard(FrenchCardColour.Spades, 1);
        public static readonly ICardType Spades_2 = new FrenchCard(FrenchCardColour.Spades, 2);
        public static readonly ICardType Spades_3 = new FrenchCard(FrenchCardColour.Spades, 3);
        public static readonly ICardType Spades_4 = new FrenchCard(FrenchCardColour.Spades, 4);
        public static readonly ICardType Spades_5 = new FrenchCard(FrenchCardColour.Spades, 5);
        public static readonly ICardType Spades_6 = new FrenchCard(FrenchCardColour.Spades, 6);
        public static readonly ICardType Spades_7 = new FrenchCard(FrenchCardColour.Spades, 7);
        public static readonly ICardType Spades_8 = new FrenchCard(FrenchCardColour.Spades, 8);
        public static readonly ICardType Spades_9 = new FrenchCard(FrenchCardColour.Spades, 9);
        public static readonly ICardType Spades_10 = new FrenchCard(FrenchCardColour.Spades, 10);
        public static readonly ICardType Spades_Joker = new FrenchCard(FrenchCardColour.Spades, 11);
        public static readonly ICardType Spades_Queen = new FrenchCard(FrenchCardColour.Spades, 12);
        public static readonly ICardType Spades_King = new FrenchCard(FrenchCardColour.Spades, 13);
        public static readonly ICardType Diamonds_Ace = new FrenchCard(FrenchCardColour.Diamonds, 1);
        public static readonly ICardType Diamonds_2 = new FrenchCard(FrenchCardColour.Diamonds, 2);
        public static readonly ICardType Diamonds_3 = new FrenchCard(FrenchCardColour.Diamonds, 3);
        public static readonly ICardType Diamonds_4 = new FrenchCard(FrenchCardColour.Diamonds, 4);
        public static readonly ICardType Diamonds_5 = new FrenchCard(FrenchCardColour.Diamonds, 5);
        public static readonly ICardType Diamonds_6 = new FrenchCard(FrenchCardColour.Diamonds, 6);
        public static readonly ICardType Diamonds_7 = new FrenchCard(FrenchCardColour.Diamonds, 7);
        public static readonly ICardType Diamonds_8 = new FrenchCard(FrenchCardColour.Diamonds, 8);
        public static readonly ICardType Diamonds_9 = new FrenchCard(FrenchCardColour.Diamonds, 9);
        public static readonly ICardType Diamonds_10 = new FrenchCard(FrenchCardColour.Diamonds, 10);
        public static readonly ICardType Diamonds_Joker = new FrenchCard(FrenchCardColour.Diamonds, 11);
        public static readonly ICardType Diamonds_Queen = new FrenchCard(FrenchCardColour.Diamonds, 12);
        public static readonly ICardType Diamonds_King = new FrenchCard(FrenchCardColour.Diamonds, 13);
        public static readonly ICardType Clubs_Ace = new FrenchCard(FrenchCardColour.Clubs, 1);
        public static readonly ICardType Clubs_2 = new FrenchCard(FrenchCardColour.Clubs, 2);
        public static readonly ICardType Clubs_3 = new FrenchCard(FrenchCardColour.Clubs, 3);
        public static readonly ICardType Clubs_4 = new FrenchCard(FrenchCardColour.Clubs, 4);
        public static readonly ICardType Clubs_5 = new FrenchCard(FrenchCardColour.Clubs, 5);
        public static readonly ICardType Clubs_6 = new FrenchCard(FrenchCardColour.Clubs, 6);
        public static readonly ICardType Clubs_7 = new FrenchCard(FrenchCardColour.Clubs, 7);
        public static readonly ICardType Clubs_8 = new FrenchCard(FrenchCardColour.Clubs, 8);
        public static readonly ICardType Clubs_9 = new FrenchCard(FrenchCardColour.Clubs, 9);
        public static readonly ICardType Clubs_10 = new FrenchCard(FrenchCardColour.Clubs, 10);
        public static readonly ICardType Clubs_Joker = new FrenchCard(FrenchCardColour.Clubs, 11);
        public static readonly ICardType Clubs_Queen = new FrenchCard(FrenchCardColour.Clubs, 12);
        public static readonly ICardType Clubs_King = new FrenchCard(FrenchCardColour.Clubs, 13);

        private enum FrenchCardColour : ushort
        {
            Hearts = 2,
            Spades = 4,
            Diamonds = 8,
            Clubs = 16
        }
    }
}
