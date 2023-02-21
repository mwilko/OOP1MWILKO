using System;
namespace CMP1903M_A01_2223
{
    public class Testing
    {
        public Testing()
        {

        }
        public void ProgramTesting()
        {
            //Console.WriteLine("Hello World!");
            Pack pack = new Pack();
            Input inputValidation = new Input();
            RangeValidation rangeValid = new RangeValidation();

            Console.ReadLine();

            bool isValid = false;
            int choice = 0;

            do
            {
                Console.WriteLine("Shuffle Types: For Fisher-Yates [1], Riffle Shuffle [2]" +
                ", No Shuffle [3] ");
                choice = inputValidation.GetInputAndTypeValidate(choice);
                isValid = rangeValid.ValidateRange(choice, 1, 3);
            } while (!isValid);
            //pack.shuffleCardPack(choice);

        }
    }
}


