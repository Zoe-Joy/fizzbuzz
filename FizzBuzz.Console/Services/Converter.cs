﻿using FizzBuzz.Console.Constants;

namespace FizzBuzz.Console.Services
{
    /// <summary>
    /// A conversion class for converting numbers into the appropriate Fizz/Buzz/Converter words
    /// depending on whether they are divisible by three, divisible by five or divisible by both three and five.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts an input number to a string representation based on the below criteria:
        /// If the number is divisible by three returns "Fizz"
        /// If the number is divisible by five returns "Buzz"
        /// If the number is divisible by both three and five returns "Converter"
        /// If the number is not divisible by either three or five, returns a string representation of the input number.
        /// </summary>
        /// <param name="inputNumber">The input number to be converted</param>
        /// <returns>A string value representing the word version of the number</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the input number is out of range, accepted range is (1-100)</exception>
        public static string ConvertNumberToWord(int inputNumber)
        {
           string output;

            if (inputNumber % 5 == 0 && inputNumber % 3 == 0)
                output = StringConstants.FizzBuzz;

            else if (inputNumber % 5 == 0)
                output = StringConstants.Buzz;

            else if (inputNumber % 3 == 0)
                output = StringConstants.Fizz;

            else output = inputNumber.ToString();

            return output;
        }
    }
}
