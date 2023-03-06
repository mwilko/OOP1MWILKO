using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        //---------------------------------------------------------------------------------//
        //Code Reviews were recieved from peers, this allowed me to edit my project
        //and ensure that it matched the criteria, has comments which help the user
        //understand what is occuring in the project and how i could improve.
        //
        //Advantages of my code were given to me such as the informal commentation,
        //use of static variables, use of shuffling algorithms and good error handling.
        //Improvements were also given and i solved these by implimenting the code below.
        //
        //Changes made to Card.cs after code reviews:
        // * Changed the properties Value and Suit to integer data types instead of string
        //   to better match the criteria and plan given in the assessement brief.
        //   This also made the program to be more portable to other card game applications.
        // * Added direct validation to the set and get methods of both Value and Suit
        //   properties for better error handling, this ensured any other value which isnt
        //   accepted such as 14 for Value or -1 for Suit isnt accepted. 
        // * SuitMessage property made to display the string of which suit the card is
        //   improving the usability of the project and making it easier for the user to
        //   understand, set and get method validation is given.
        //---------------------------------------------------------------------------------//

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

        private string _suitMessage;
        public string SuitMessage
        {
            //added SuitMessage property to display the suit in string form after code review
            get { return _suitMessage; }
            set
            {
                if (value == "Hearts")
                {
                    _suitMessage = value;
                }
                else if (value == "Diamonds")
                {
                    _suitMessage = value;

                }
                else if (value == "Clubs")
                {
                    _suitMessage = value;

                }
                else if (value == "Spades")
                {
                    _suitMessage = value;
                }
                else
                {
                    throw new Exception("Error, SuitMessage should be either:" +
                        " Hearts, Diamonds, Clubs or Spades");
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
            //after code review from Vibin Dewan, added if statement to display what suit
            //the cards are in the form of an integer value and string value‹. 
            string suitValue = "";
            if (Suit == 1)
            {
                suitValue = "Hearts";
            }
            else if (Suit == 2)
            {
                suitValue = "Diamonds";
            }
            else if (Suit == 3)
            {
                suitValue = "Clubs";
            }
            else if (Suit == 4)
            {
                suitValue = "Spades";
            }
            return $"{Value} of {Suit} ({suitValue}) ";
        }
    }
}
