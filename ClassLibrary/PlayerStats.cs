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
            Difficulty = board.Difficulty;
            BoardSize = board.Size;

            CalculateScore();
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
        public void CalculateScore()
        {
            //Base score
            Score = (1000 / TimeInSeconds);

            // Score is calculated based on the size of board and Difficulty
            // Easy
            if (Difficulty == 10 ) {
                Score = (int)(Score * BoardSize * 0.5);
            }
            // Medium
            else if (Difficulty == 30)
            {
                Score = (int)(Score * BoardSize * 0.70);
            }
            // Hard
            else if (Difficulty == 50)
            {
                Score = (int)(Score * BoardSize * 0.85);
            }   
            // ERROR --! 
            else
            {   
                // Flag value
                Score = -1;

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
            // Set string difficulty to display
            string difficulty = string.Empty;

            if (Difficulty == 10)
                difficulty = "Easy";
            else if (Difficulty == 30)
                difficulty = "Medium";
            else if (Difficulty == 50)
                difficulty = "Hard"; 

            return (Initials + " --- " + Score + " --- " + difficulty);
        }

        public string SaveStats()
        {
            return (string.Format("{0}- {1}- {2}- {3}- {4}", 
                BoardSize, Initials, Score, TimeInSeconds, Difficulty));
        }
    }
}