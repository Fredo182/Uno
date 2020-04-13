using System;
using System.Collections.Generic;

namespace Uno.Service.Models
{
    public class UnoPlayer
    {
        public string Name { get; set; }
        public List<UnoCard> Cards { get; private set;}
        public bool Turn { get; set; }

        public UnoPlayer(string name)
        {
            Name = name;
            Cards = new List<UnoCard>();
        }

    }
}
