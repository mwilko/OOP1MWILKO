using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public string Value { get; set; }
        public string Suit { get; set; }

        public Card(string value, string suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
