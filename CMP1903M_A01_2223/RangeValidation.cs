using System;
using System.Collections.Generic;
using System.Text;

namespace CMP1903M_A01_2223
{
    public class RangeValidation 
    {
        //class used for range validation, seperate class was made to make it easier for
        //porblem solving/syntax errors.(Class and methods not included in base code)

        //method to validate range of integer between a lower and upper boundary of integers
        //returns boolean value
        public bool ValidateRange(int value, int lowerBoundary, int upperBoundary)
        {
            bool isValid = false;
            if (value >= lowerBoundary && value <= upperBoundary)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine($"The value {value} entered is outside the acceptable range.\n" +
                    $"The value must be between {lowerBoundary} and {upperBoundary}\n");
                Console.WriteLine($"Try again, enter your value: ");
                isValid = false;
            }
            return isValid;
        }
    }
}




