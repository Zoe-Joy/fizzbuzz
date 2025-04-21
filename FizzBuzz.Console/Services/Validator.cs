using FizzBuzz.Console.Constants;

namespace FizzBuzz.Console.Services
{
    /// <summary>
    /// This class validates input data to ensure in meets requirements.
    /// </summary>
    internal class Validator
    {
        private readonly List<string> _validNonNumericAnswers = new List<string>
            { StringConstants.Fizz, StringConstants.Buzz, StringConstants.FizzBuzz };

        /// <summary>
        /// Validates an input  by a player for the Fizz Buzz game.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ValidateInput(string input)
        {
            if (input.All(char.IsDigit))
            {
                var integerValue = int.Parse(input);
                return integerValue >= 1 && integerValue <= 100;
            }

            return _validNonNumericAnswers.Contains(input);
        }

        /// <summary>
        /// Validates an input by a player for the no od players.
        /// </summary>
        /// <param name="playerCount"></param>
        /// <returns></returns>
        public bool ValidatePlayerCount(string playerCount)
        {
            if (playerCount.All(char.IsDigit))
            {
                var integerValue = int.Parse(playerCount);
                return integerValue >= 1 && integerValue <= 5;
            }

            return false;
        }
    }
}
