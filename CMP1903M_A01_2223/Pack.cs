using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack : Input
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
        //Changes made to Pack.cs after code reviews:
        // * Added a string message to each card displaying the suit which helped
        //   the user understand what the card they were dealt is.
        //   This improved the programs readability for the user.
        // * Altered the Riffle-Shuffle algorithm since it was difficult to understand
        //   as well as removing the second list, making the program more portable.
        // * When the riffle shuffle was used. The first 52 values were removed form the
        //   card pack since it would leave the unshuffled values. This improved the
        //   project as the user didnt get dealt cards which werent shuffled.
        //---------------------------------------------------------------------------------//

        //list and objects initialised
        public static List<Card> CardPack;
        public static List<Card> RifflePack = new List<Card>();
        public static bool shufflingBool = false;
        private Random random = new Random();

        public int[] suits = { 1, 2, 3, 4 };
        public int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        public string[] suitMessages = { "Hearts", "Diamonds", "Clubs", "Spades" };


        public Pack()
        {
            //initialise the card pack here
            CardPack = new List<Card>();
            foreach (int suit in suits)
            {
                    foreach (int value in values)
                    {
                        //when adding set method validation, realised the value and suit
                        //should be swapped since they were outputted opposite
                        CardPack.Add(new Card(value, suit));
                    }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            int fisherYates = 1;
            int riffleShuffle = 2;
            int noShuffle = 3;

            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == fisherYates)
            {
                //fisher-yates shuffling algorithm 
                int n = CardPack.Count;
                shufflingBool = true;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Card card = CardPack[k];
                    CardPack[k] = CardPack[n];
                    CardPack[n] = card;
                }
                //OutputPack();
                return true;
            }
            else if (typeOfShuffle == riffleShuffle)
            {
                //new riffle-shuffle algorithm, added after code review
                //modified as GetRange function wouldnt take the number 52 as in input to get range from
                //it caused Stack Over-flow. To make the program easier to understand and cut down code
                //i tweaked it
                int halfPack = 52/2;
                shufflingBool = true;
                for (int i = 0; i < halfPack; i++)
                {
                    CardPack.Add(CardPack[i]);
                    CardPack.Add(CardPack[i + halfPack]);
                }
                    
                //added after code review, removes first unshuffled pack from list
                //so no need for a seperate list for the riffle-shuffle
                CardPack.RemoveRange(0, 52);
                //OutputPack();

                return true;
            }
            else if (typeOfShuffle == noShuffle)
            {
                shufflingBool = true;
                return true;
            }
            else
            {
                Console.WriteLine($"Value: '{typeOfShuffle}' is not valid: ");
                return false;
            }

        }
        public static Card dealCard()
        {
            //Deals one card
            //card object is set to null as if all bool variables are false
            //the card object would have no value for the method to return
            Card card = null;
            //loop to deal card out of fisher-yates shuffled card pack
            if (shufflingBool == true)
            {
                if (CardPack.Count == 0)
                { 
                    Console.WriteLine("Error: Pack is empty");
                }
                card = CardPack[0];
                CardPack.RemoveAt(0);
            }
            else
            {
                //error message to catch any errors which may occur
                Console.WriteLine("Error: Unexpected error, contact IT support: ");
            }
            //card object marked as warning as it could be outputted as null/nothing
            return card;

        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> hand = new List<Card>();
            
            for (int i = 0; i < amount; i++)
            {
                hand.Add(dealCard());
            }
            return hand;
        }

        //created for testing purposes
        public void OutputPack()
        {
            //displays card pack for fisher-yates shuffle
            Console.WriteLine("--------- <Pack> ---------");
            foreach (var card in CardPack)
            {
                Console.WriteLine(card);
            }
        }

    }
}
