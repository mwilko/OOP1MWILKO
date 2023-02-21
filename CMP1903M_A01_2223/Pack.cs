using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        //list and objects initialised
        //limiting capacity of list to 52
        public List<Card> CardPack;
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
            int FisherYates = 1;
            int RiffleShuffle = 2;
            int NoShuffle = 3;

            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == FisherYates)
            {
                int n = CardPack.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Card card = CardPack[k];
                    CardPack[k] = CardPack[n];
                    CardPack[n] = card;
                }
                return true;
            }
            else if (typeOfShuffle == RiffleShuffle)
            {
                return true;
            }
            else if (typeOfShuffle == NoShuffle)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Value: '{typeOfShuffle}' is not valid: ");
                return false;
            }

        }
        public static Card deal(List<Card> pack)
        {
            //Deals one card
            if (pack.Count == 0)
            {
                Console.WriteLine("Error: Pack is empty");
            }
            Card card = pack[0];
            pack.RemoveAt(0);
            return card;

        }
        public static List<Card> dealCard(int amount, List<Card> pack)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> hand = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                hand.Add(deal(pack));
            }
            return hand;
        }

    }
}
