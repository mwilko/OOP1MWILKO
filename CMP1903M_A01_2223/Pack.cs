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
        public static bool fisherBool = false;
        public static bool riffleBool = false;
        public static bool noShuffleBool = false;
        private Random random = new Random();
        private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private string[] values = { "Ace", "2", "3", "4", "5", "6", "7",
        "8", "9", "10", "Jack", "King", "Queen" };


        public Pack()
        {
            //initialise the card pack here
            CardPack = new List<Card>();
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    CardPack.Add(new Card(suit, value));
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
                fisherBool = true;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Card card = CardPack[k];
                    CardPack[k] = CardPack[n];
                    CardPack[n] = card;
                }
                //OutputPack("fisher-yates");
                return true;
            }
            else if (typeOfShuffle == riffleShuffle)
            {
                //riffle-shuffle algorithm
                int halfPack = 52 / 2;
                riffleBool = true;
                List<Card> FirstHalf = CardPack.GetRange(0, halfPack);
                List<Card> LastHalf = CardPack.GetRange(halfPack, halfPack);

                for (int i = 0; i < halfPack; i++)
                {
                    RifflePack.Add(LastHalf[i]);
                    RifflePack.Add(FirstHalf[i]);
                }
                //OutputPack("riffle-shuffle");

                return true;
            }
            else if (typeOfShuffle == noShuffle)
            {
                noShuffleBool = true;
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
            if (fisherBool == true)
            {
                if (CardPack.Count == 0)
                { 
                    Console.WriteLine("Error: Pack is empty");
                }
                card = CardPack[0];
                CardPack.RemoveAt(0);
            }
            //loop to deal card out of riffle-shuffled card pack
            else if (riffleBool == true)
            {
                if (RifflePack.Count == 0)
                {
                    Console.WriteLine("Error: Pack is empty");
                }
                card = RifflePack[0];
                RifflePack.RemoveAt(0);
            }
            //loop to deal card out of non-shuffled card pack
            else if (noShuffleBool == true)
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
        public void OutputPack(string shuffleType)
        {
            //displays card pack for fisher-yates shuffle
            if (shuffleType == "fisher-yates")
            {
                Console.WriteLine("--------- <Pack> ---------");
                foreach (var card in CardPack)
                {
                    Console.WriteLine(card);
                }
            }
            //displays card pack for the riffle shuffle
            else if (shuffleType == "riffle-shuffle")
            {
                Console.WriteLine("--------- <Pack> ---------");
                foreach (var card in RifflePack)
                {
                    Console.WriteLine(card);
                }
            }
            else
            {
                Console.WriteLine($"Value '{shuffleType}' is invalid: ");
            }
        }

    }
}
