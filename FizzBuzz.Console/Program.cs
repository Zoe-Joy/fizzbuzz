

namespace FizzBuzz.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayBanner();

            for (int round = 1; round <= 100; round++)
            {
                System.Console.WriteLine($"Please enter your answer for round {round}:");
                var playersAnswer = System.Console.ReadLine();
                if (int.TryParse(playersAnswer, out int inputNumber))
                {
                    ConvertAndDisplayOutputForInputNumbers(new List<int> { inputNumber });
                }
                else
                {
                    var resultWord = Services.FizzBuzz.ConvertNumberToWord(inputNumber);
                    if (resultWord != playersAnswer)
                    {
                        System.Console.WriteLine($"The Output for input number: {inputNumber} is : {resultWord} but you entered: {playersAnswer}");
                    }
                    else
                    {
                        System.Console.WriteLine($"You have entered the correct answer for input number: {inputNumber} which is : {resultWord}");
                    }
                }
            }
            
            System.Console.ReadKey();
        }

        #region Private Helpers

        private static void DisplayBanner()
        {
            System.Console.WriteLine("*****************************************************************************************************");
            System.Console.WriteLine("*                                                                                                   *");
            System.Console.WriteLine("*             Welcome to the Fizz Buzz Game for Counting Numbers  Version 1.0                       *");
            System.Console.WriteLine("*                                                                                                   *");
            System.Console.WriteLine("*  The game is played by 2 or more players. You have to enter the correct input                     *");
            System.Console.WriteLine("*  guided by the below rules:                                                                       *");
            System.Console.WriteLine("   1: If the number is divisble by three then enter Fizz                                            *");
            System.Console.WriteLine("   ");
            System.Console.WriteLine("   ");
            System.Console.WriteLine("   ");
            System.Console.WriteLine("*****************************************************************************************************");
            System.Console.WriteLine();
        }

        private static void ConvertAndDisplayOutputForInputNumbers(IEnumerable<int> inputNumbers)
        {
            inputNumbers.ToList().ForEach(inputNumber =>
            {
                try
                {
                    var resultWord = Services.FizzBuzz.ConvertNumberToWord(inputNumber);
                    System.Console.WriteLine($"The Output for input number: {inputNumber} is : {resultWord}");
                }
                catch (ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    System.Console.WriteLine($"The Output for input number: {inputNumber} is " +
                        $": {argumentOutOfRangeException.Message}. Valid range is (1-100)");
                }
            });
        }

        #endregion
    }

}
