using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack : Input
    {
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
