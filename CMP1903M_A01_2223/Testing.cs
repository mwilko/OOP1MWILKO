using System;
using System.Collections.Generic;
namespace CMP1903M_A01_2223
{
    public class Testing : Pack
    {
        public Testing()
        {

        }
        public void ProgramTesting()
        {

            bool isValid = false;
            int choice = 0;

            //loop which validates the input for the shuffle type
            do
            {
                Console.WriteLine("Shuffle Types: For Fisher-Yates [1], Riffle Shuffle [2]" +
                ", No Shuffle [3] ");
                choice = GetInputAndTypeValidate(choice);
                isValid = ValidateRange(choice, 1, 3);
            } while (!isValid);
            shuffleCardPack(choice);


            //loop and if statement which decides which dealing method
            //is used while also validating type and range of given input
            isValid = false;
            do
            {
                Console.WriteLine("Card Dealing: Deal one card [1], Deal specific amount of cards [2] ");
                choice = GetInputAndTypeValidate(choice);
                isValid = ValidateRange(choice, 1, 2);
            } while (!isValid);
            //if choice == 1, run method to deal one card
            if (choice == 1)
            {
                Console.WriteLine(dealCard()); 
            }
            //if choice == 2, run method to deal inputted amount of cards
            else if (choice == 2)
            {
                isValid = false;
                int cardAmount = 0;
                do
                {
                    Console.WriteLine("Please enter the amount of cards you want to be dealt: ");
                    cardAmount = GetInputAndTypeValidate(cardAmount);
                    isValid = ValidateRange(cardAmount, 1, 52);
                } while (!isValid);

                List<Card> Hand = dealCard(cardAmount);
                //for each loop which outputs all values in the hand list
                foreach (var card in Hand)
                {
                    Console.WriteLine(card);
                }
            }


        }
    }
}


