namespace FizzBuzz.Console.Models
{
    /// <summary>
    /// A representation of a player for the FizzBuzz game.
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A flag indicating whether they are still in the game or have lost.
        /// </summary>
        public bool IsStillInTheGame { get; set; }
    }
}
