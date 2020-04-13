using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno.Service.Models
{
    public class UnoDeck
    {
        public List<UnoCard> Cards { get; set; }

        public void CreateDeck()
        {
            Cards = new List<UnoCard>();
            for (var color = 0; color < 4; color++)
            {
                for (var x = 1; x < 13; x++)
                {
                    Cards.Add(new UnoCard(color, x));
                    Cards.Add(new UnoCard(color, x));
                }

                Cards.Add(new UnoCard(color, 0));
            }

            for (var x = 0; x < 4; x++)
            {
                Cards.Add(new UnoCard(UnoCard.CardColor.Wild, UnoCard.CardFace.Draw4));
                Cards.Add(new UnoCard(UnoCard.CardColor.Wild, UnoCard.CardFace.None));
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int otherIndex = rand.Next(0, Cards.Count);
                UnoCard temp = Cards[otherIndex];
                Cards[otherIndex] = Cards[i];
                Cards[i] = temp;
            }
        }

        public bool IsEmpty()
        {
            return Cards.Any();
        }

        public UnoCard StartDraw()
        {
            var card = Cards[0];
            while (card.Color != UnoCard.CardColor.Wild)
            {
                Shuffle();
                card = Cards[0];
            }
            return Draw();
        }

        public UnoCard Draw()
        {
            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public override string ToString()
        {
            var allCards = "";
            foreach (UnoCard card in Cards)
                allCards += card + Environment.NewLine;
            var totalCards = $"{Cards.Count} cards in the deck";
            return allCards + totalCards;
        }


    }
    
}
