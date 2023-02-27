using System;
using System.Collections.Generic;
using System.Text;

namespace CMP1903M_A01_2223
{
    public class Input : RangeValidation
    {
        //class used for range validation, seperate class was made to make it easier for
        //problem solving/syntax errors. (Class and methods not included in base code)

        //property used for error message
        public string TypeError { get; } = "TypeError. Plase enter a valid value";

        //validation of choice input by user
        public int GetInputAndTypeValidate(int intChoice)
        {
            bool isValid = false;
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out intChoice);
                if (!isValid)
                {
                    Console.WriteLine(TypeError);
                }
            } while (!isValid);
            return intChoice;
        }
    }
}



