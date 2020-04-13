using System;
using System.Collections.Generic;
using Uno.Service.Models;

namespace Uno.Service
{
    public class UnoGameService
    {
        public UnoDeck Deck { get; set; }
        public UnoDeck Discard { get; set; }
        public List<UnoPlayer> Players { get; set;}

        public void StartGame() {
            Deck = new UnoDeck();
            Deck.CreateDeck();
            Deck.Shuffle();
        }
    }
}
