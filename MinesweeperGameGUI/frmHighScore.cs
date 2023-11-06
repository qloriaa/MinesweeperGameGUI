using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGameGUI
{
    public partial class frmHighScore : Form
    {
        // Database were high scores are stored/retrieved from
        string topScoresFileLocation = Path.GetFullPath(@"..\\..\\..\\..\\HighScores.txt");
        // Used to connect the List<PlayerStats> lists in Store to the ListBox form controls on the form
        BindingSource listBinding = new BindingSource();
        // To Get size and Difficulty
        private Board board;
        private List<string> AllTopScores = new List<string>();
        // Current Top Scores for the board Size
        private List<PlayerStats> topScores = new List<PlayerStats>();
        // Create new Player if player Won Game and has a high score.
        private PlayerStats player;

        public frmHighScore(Board board, int time)
        {
            InitializeComponent();

            // Set List box control bindings
            SetListBindings();

            // initialize board
            this.board = board;
            // initialize player
            player = new PlayerStats(time, board);

        }

        /// <summary>
        /// Set the form title, read high scores text file, and check if player won the current game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHighScore_Load(object sender, EventArgs e)
        {
            // Set Title Label
            BoardSizeLabel();

            // Read All High Scores recorded and get necessary scores
            ReadHighScores();

            // Check if player won the Game
            if (board.AllCellsVisited())
            {
                // Check if player has a new High score
                CompareStats();
            }
            else
            {
                // If no new score, stats do not need to be updated just displayed
                DisplayTopScores();
            }
        }

        /// <summary>
        /// Get Text File High Scores and select the corresponding high scores for the board size played
        /// </summary>
        private void ReadHighScores()
        {
            // Create a List of lines read from original file
            AllTopScores = File.ReadAllLines(topScoresFileLocation).ToList();

            // Use LINQ statement to filter required lines based on the board size played
            var scoresToCompare =
                from score in AllTopScores
                where score.StartsWith(board.Size.ToString())
                select score;

            // Convert string to PlayerStats objects
            foreach (string line in scoresToCompare)
            {
                // split string line using delimiter
                string[] stats = line.Split("- ");

                // Cast to correct data types
                int size = int.Parse(stats[0]);
                string initials = stats[1];
                int score = int.Parse(stats[2]);
                int seconds = int.Parse(stats[3]);
                int difficulty = int.Parse(stats[4]);

                // Create instance of PlayerStats and add to topScores List<>
                topScores.Add(new PlayerStats(size, initials, score, seconds, difficulty));

            }
        }

        /// <summary>
        /// Player won current game, compare the score to the top scores in text file
        /// </summary>
        private void CompareStats()
        {
            // Add player to List of Top Scores 
            topScores.Add(player);

            // Sort the list in descending order (High to Low)
            topScores.Sort();

            // Only get the 5 top
            if (topScores.Count > 5)
            {
                // remove the 6th score from the list
                topScores.RemoveAt(5);
            }

            // Check if current game is a top 5 score
            if (topScores.Contains(player))
            {
                MessageBox.Show("Congratulations, New High Score!!\nEnter your Initials.");
                lblInitials.Visible = true;
                txtInitials.Visible = true;
                btnInitials.Visible = true;
            }
            else
            {
                // No new top score display
                DisplayTopScores();
            }
        }

        /// <summary>
        /// Display the 5 top high scores in the list box controls.
        /// Hide/Show controls as necessary.
        /// </summary>
        private void DisplayTopScores()
        {
            lblInitials.Visible = false;
            txtInitials.Visible = false;
            btnInitials.Visible = false;

            // Update list box
            //      Data type of the control has not changed, false
            listBinding.ResetBindings(false);
            lbTopScores.Visible = true;
        }

        /// <summary>
        /// Get player initials, player has set a new high score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitials_Click(object sender, EventArgs e)
        {
            if (txtInitials.Text.Length == 3)
            {
                player.Initials = txtInitials.Text;

                DisplayTopScores();

                SaveHighScores();
            }
            else
            {
                MessageBox.Show("Enter your three player identifiable initials.");
            }
        }

        /// <summary>
        /// Save the new top 5 High Scores
        /// </summary>
        private void SaveHighScores()
        {
            // Get the top scores for the other board sizes (not the board size for current game)
            var otherTopScores = new List<string>();

            if (board.Size == 5)
            {
                otherTopScores.AddRange(AllTopScores.Where(score => score.StartsWith("8") || score.StartsWith("12")));
            }
            else if (board.Size == 8)
            {
                otherTopScores.AddRange(AllTopScores.Where(score => score.StartsWith("5") || score.StartsWith("12")));
            }
            else if (board.Size == 12)
            {
                otherTopScores.AddRange(AllTopScores.Where(score => score.StartsWith("5") || score.StartsWith("8")));
            }

            // Convert the new Top scores for this board size to string type list
            List<string> updatedScores = new List<string>();

            foreach (PlayerStats player in topScores)
            {
                string updateLine = player.SaveStats();

                updatedScores.Add(updateLine);
            }

            // Clear list
            AllTopScores.Clear();
            // Add other scores (for other board sizes) and this scores (current board size) to list
            AllTopScores.AddRange(otherTopScores);
            AllTopScores.AddRange(updatedScores);

            // write on the text file
            File.WriteAllLines(topScoresFileLocation, AllTopScores);
        }

        /// <summary>
        /// Bind lists of scores with list box control in form
        /// </summary>
        private void SetListBindings()
        {
            // Binding Car inventory list
            listBinding.DataSource = topScores;
            lbTopScores.DataSource = listBinding;
            lbTopScores.DisplayMember = ToString();
        }

        /// <summary>
        /// Set Title Label
        /// </summary>
        /// <param name="size"></param>
        private void BoardSizeLabel()
        {
            switch (board.Size)
            {
                case 5:
                    lblBoardSize.Text = "Small 5 x 5 Board Top Scores:";
                    break;
                case 8:
                    lblBoardSize.Text = "Classic 8 x 8 Board Top Scores:";
                    break;
                case 12:
                    lblBoardSize.Text = "Large 12 x 12 Board Top Scores:";
                    break;
                default:
                    lblBoardSize.Text = "Error obtaining board size --!";
                    break;
            }
        }

    }
}
