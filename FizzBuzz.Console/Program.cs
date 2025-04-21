using System.ComponentModel.DataAnnotations;
using FizzBuzz.Console.Models;
using FizzBuzz.Console.Services;
using Validator = FizzBuzz.Console.Services.Validator;

namespace FizzBuzz.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayBanner();

            List<string> validAnswers = Enumerable.Range(0, 101).Select(index => Converter.ConvertNumberToWord(index)).ToList();
            var validator = new Validator();

            var playerCount = CaptureAndValidatePlayerCount(validator);
            var players = Enumerable.Range(1, playerCount)
                .Select(index => new Player { Name = index.ToString(), IsStillInTheGame = true }).ToList();
            
            var round = 1;
            while (round <= 100 && players.Count(p => p.IsStillInTheGame) > 1)
            {
                foreach (Player player in players.Where(p => p.IsStillInTheGame).ToList())
                {
                    var playerAnswer = CaptureAndValidateUserInput(round, validator, player.Name);

                    var correctAnswer = validAnswers[round];
                    if (playerAnswer == correctAnswer)
                    {
                        System.Console.WriteLine(
                            $"You have entered the correct answer for round: {round} which is : {correctAnswer}");
                        System.Console.WriteLine();
                    }
                    else
                    {
                        System.Console.WriteLine(
                            $"The Output for round: {round} is : {correctAnswer} but you entered: {playerAnswer}");
                        System.Console.WriteLine(
                            $"Player {player.Name}, you are out of the game.");
                        System.Console.WriteLine();
                        player.IsStillInTheGame = false;
                    }

                    if (players.Count(p => p.IsStillInTheGame) == 1)
                    {
                        break;
                    }

                    round++;
                }
            }


            var winningPlayer = players.SingleOrDefault(p => p.IsStillInTheGame);
            System.Console.WriteLine();
            System.Console.WriteLine($"Player {winningPlayer?.Name} is the WINNER!");

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

        private static string? CaptureAndValidateUserInput(int round, Validator validator, string playerName)
        {
            bool validationResult;
            string playersAnswer;

            do
            {
                System.Console.WriteLine($"Player {playerName}, Please enter your answer for round {round}:");
                playersAnswer = System.Console.ReadLine();
                validationResult = validator.ValidateInput(playersAnswer!);
                if (!validationResult)
                {
                    System.Console.WriteLine($"Invalid input. Please try again");
                }
            } while (!validationResult);

            return playersAnswer;
        }

        private static int CaptureAndValidatePlayerCount(Validator validator)
        {
            bool validPlayerCount;
            int playerCount = 0;

            do
            {
                System.Console.WriteLine("Please enter number of players (1-5)");
                var noOfPlayers = System.Console.ReadLine();
                validPlayerCount = validator.ValidatePlayerCount(noOfPlayers!);
                if (!validPlayerCount)
                {
                    System.Console.WriteLine("Invalid input for no of players, please try again.");
                }

                playerCount = int.Parse(noOfPlayers!);
            } while (!validPlayerCount);

            return playerCount;
        }

        private static void ConvertAndDisplayOutputForInputNumbers(IEnumerable<int> inputNumbers)
        {
            inputNumbers.ToList().ForEach(inputNumber =>
            {
                try
                {
                    var resultWord = Services.Converter.ConvertNumberToWord(inputNumber);
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
