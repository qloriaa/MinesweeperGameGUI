using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string Initials { get; set;}
        public int TimeInSeconds { get; set;}
        public int Difficulty;
        public int BoardSize;
        public int Score;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="board"></param>
        public PlayerStats(int seconds, Board board)
        {
            TimeInSeconds = seconds;
            Difficulty = (int)board.PercentLive;
            BoardSize = board.Size;

            // If error getting Difficulty in BOard.cs, flag value of percentLive is -1
            CalculateScore(board.PercentLive);
        }

        /// <summary>
        /// Parameterized constructor used when player stats were read from file
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initials"></param>
        /// <param name="score"></param>
        /// <param name="seconds"></param>
        /// <param name="difficulty"></param>
        public PlayerStats(int size, string initials, int score, int seconds, int difficulty)
        {
            BoardSize = size;
            Initials = initials;
            Score = score;
            TimeInSeconds = seconds;
            Difficulty = difficulty;
        }

        /// <summary>
        /// Calculate Player's score based on board size and difficulty
        /// </summary>
        public void CalculateScore(int percent)
        {
            //Base score
            Score = (10000 / TimeInSeconds);

            //   percent flag value is -1 if there was an error getting the Difficulty
            if (percent > 0)
            {
                // Score is calculated based on the size of board and Difficulty
                Score = (int)(Score * BoardSize * (Difficulty / 2));
            }
            else
            {
                Score = -1;  // Flag value
            }
        }

        /// <summary>
        /// Compare based on score in Descending Order
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(PlayerStats other)
        {
            return other.Score.CompareTo(this.Score);
        }

        /// <summary>
        /// Override ToString() method to display the player and score
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Set string difficulty to display, Get the string value of the enum Difficulty
            string difficulty = (string)((Board.Difficulty)Difficulty).ToString();

            return (Initials + " --- " + Score + " --- " + difficulty);
        }

        /// <summary>
        /// Create a string for the PlayerStats to save to text file
        /// </summary>
        /// <returns></returns>
        public string SaveStats()
        {
            return (string.Format("{0}- {1}- {2}- {3}- {4}", 
                BoardSize, Initials, Score, TimeInSeconds, Difficulty));
        }
    }
}