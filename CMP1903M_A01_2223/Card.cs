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

        private int _value;
        public int Value
        {
            get { return _value; }
            //added validation to set methods due to code review, forgot to include it
            //this ensures card value only uses values 1-13
            set
            {
                if (value >= 1 && value <= 13)
                {
                    _value = value;
                }
                else
                {
                    throw new Exception("Error, Value should be " +
                        "between 1 and 13. ");
                }
            }
        }
        private int _suit;
        public int Suit
        {
            get { return _suit; }
            //this ensures card suit only uses values 1-4
            set
            {
                if (value >= 1 && value <= 4)
                {
                    _suit = value;
                }
                else
                {
                    throw new Exception("Error, Suit value should be " +
                        "between 1 and 4.");
                }
            }
        }

        public Card(int value, int suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"{Value}-{Suit}";
        }
    }
}
