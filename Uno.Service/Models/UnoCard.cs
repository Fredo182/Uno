using System;
namespace Uno.Service.Models
{
    public class UnoCard
    {
        public enum CardColor {
            Red = 0,
            Yellow = 1,
            Green = 2,
            Blue = 3,
            Wild = 4,
            Max = 5
        }

        public enum CardFace {
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Draw2 = 10,
            Skip = 11,
            Reverse = 12,
            Draw4 = 13,
            None = 14,
            Max = 15
        }

        public UnoCard(CardColor color, CardFace face)
        {
            this.Color = color;
            this.Face = face;
        }

        public CardColor Color { get; private set; }
        public CardFace Face { get; private set; }

        public string Image { get { return ImageForCard(this.Color, this.Face); } }
        public int SortValue { get { return CardToSortValue(this.Color, this.Face); } }
        public int ScoringValue { get { return CardToScoreValue(this.Face); } }
        
        public override string ToString()
        {
            return CardToString(this.Color, this.Face);
        }

        // Static Methods
        public static int CardFaceToInt(CardFace cardFace)
        {
            int value = (int)cardFace;
            return value > 9 ? -1 : value;
        }

        public static CardFace? IntToCardFace(int cardInt)
        {
            if(cardInt < (int)CardFace.Max)
                return (CardFace)cardInt;

            return null;
        }

        public static int CardColorToInt(CardColor cardColor)
        {
            return (int)cardColor;
        }

        public static CardColor? IntToCardColor(int colorInt)
        {
            if (colorInt < (int)CardColor.Max)
                return (CardColor)colorInt;

            return null;
        }

        public static string CardColorToString(CardColor cardColor)
        {
            return cardColor.ToString().Substring(0, 1).ToLowerInvariant();
        }

        public static string CardFaceToString(CardFace cardFace)
        {
            string val = "";

            switch (cardFace)
            {
                case CardFace.Zero:
                case CardFace.One:
                case CardFace.Two:
                case CardFace.Three:
                case CardFace.Four:
                case CardFace.Five:
                case CardFace.Six:
                case CardFace.Seven:
                case CardFace.Eight:
                case CardFace.Nine:
                    val = CardFaceToInt(cardFace).ToString();
                    break;
                case CardFace.Draw2:
                    val = "D2";
                    break;
                case CardFace.Draw4:
                    val = "D4";
                    break;
                case CardFace.Reverse:
                    val = "R";
                    break;
                case CardFace.Skip:
                    val = "S";
                    break;
            }
            return val;
        }

        public static string CardToString(CardColor cardColor, CardFace cardFace)
        {
            return CardColorToString(cardColor) + CardFaceToString(cardFace);
        }

        public static int CardToScoreValue(CardFace cardFace)
        {
            int value = 0;
            switch (cardFace)
            {
                case CardFace.Zero:
                case CardFace.One:
                case CardFace.Two:
                case CardFace.Three:
                case CardFace.Four:
                case CardFace.Five:
                case CardFace.Six:
                case CardFace.Seven:
                case CardFace.Eight:
                case CardFace.Nine:
                    value = CardFaceToInt(cardFace);
                    break;
                case CardFace.Draw2:
                case CardFace.Reverse:
                case CardFace.Skip:
                    value = 20;
                    break;
                case CardFace.None:
                case CardFace.Draw4:
                    value = 50;
                    break;
            }

            return value;
        }

        public static int CardToSortValue(CardColor cardColor, CardFace cardFace)
        {
            if (cardColor == CardColor.Wild && cardFace == CardFace.None)
                return 13 * 4;
            else
                return (int)cardColor * 13 + (int)cardFace;

        }

        public static string ImageForCard(CardColor cardColor, CardFace cardFace)
        {
            string card = CardToString(cardColor, cardFace);
            string img = card; //TODO: Get base64 string image of card
            return img;
        }
    }
}
