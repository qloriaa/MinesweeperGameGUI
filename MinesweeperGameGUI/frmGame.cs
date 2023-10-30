using ClassLibrary;
using System.Diagnostics;

namespace MinesweeperGameGUI
{
    public partial class frmGame : Form
    {
        public Board gameboard;
        public Button[,] btnGrid;
        private Stopwatch time = new Stopwatch();
        private string imgFolderLoc = Directory.GetCurrentDirectory() + "\\Images\\";

        /// <summary>
        /// Form Constructor
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
        public frmGame(int size, int difficulty)
        {
            InitializeComponent();

            // initialize instance of gameboard and btnGrid
            gameboard = new Board(size, difficulty);
            btnGrid = new Button[gameboard.Size, gameboard.Size];

            // Set difficulty label
            switch (difficulty)
            {
                case 10:
                    lblDifficulty.Text = "Easy Difficulty";
                    break;
                case 30:
                    lblDifficulty.Text = "Medium Difficulty";
                    break;
                case 50:
                    lblDifficulty.Text = "Hard Difficulty";
                    break;
                default:
                    lblDifficulty.Text = "Error";
                    break;
            }
            // Display number of mines on board as label
            lblLiveCells.Text = gameboard.LiveCells.ToString();

            // Set up board
            populateGrid();

            // Start timer 
            time.Start();

            PrintConsole();
        }

        /// <summary>
        /// Fill panel with buttons to create gameboard UI
        /// </summary>
        private void populateGrid()
        {
            // format buttons to fit board
            int btnSize = pnlBoard.Width / gameboard.Size;
            // Make sure is a squared board
            pnlBoard.Height = pnlBoard.Width;

            // Create buttons and fill board panel
            for (int row = 0; row < gameboard.Size; row++)
            {
                for (int col = 0; col < gameboard.Size; col++)
                {
                    // create new button at grid location
                    btnGrid[row, col] = new Button();

                    // Set button properties
                    btnGrid[row, col].Width = btnSize;
                    btnGrid[row, col].Height = btnSize;

                    // Set Image
                    Bitmap image = Bitmap.FromFile(imgFolderLoc + "unopened.png") as Bitmap;
                    Bitmap resized = new Bitmap(image, new Size(btnSize, btnSize));
                    btnGrid[row, col].Image = resized;
                    btnGrid[row, col].FlatStyle = FlatStyle.Flat;

                    // Add Button click event
                    btnGrid[row, col].MouseUp += GridButton_Click;

                    // Add button to panel
                    pnlBoard.Controls.Add(btnGrid[row, col]);

                    // Position button on panel
                    btnGrid[row, col].Location = new Point(btnSize * row, btnSize * col);

                    // Tag the control as string 
                    btnGrid[row, col].Tag = row.ToString() + "|" + col.ToString();
                }
            }
        }

        /// <summary>
        /// Click event for the buttons on the panel representing a gameboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridButton_Click(object sender, MouseEventArgs e)
        {
            // Get grid location of Button
            string[] location = (sender as Button).Tag.ToString().Split('|');
            int row = int.Parse(location[0]);
            int col = int.Parse(location[1]);

            string imgName;

            // Check if right-click
            if (e.Button == MouseButtons.Right)
            {
                imgName = "flag.png";

            }
            else //left or middle click
            {
                imgName = GetImgName(row, col);
            }

            // Set Image
            Bitmap image = Bitmap.FromFile(imgFolderLoc + imgName) as Bitmap;
            Bitmap resized = new Bitmap(image, new Size((sender as Button).Width, (sender as Button).Height));
            btnGrid[row, col].Image = resized;
            btnGrid[row, col].FlatStyle = FlatStyle.Flat;

            // Mine revelaed?
            if (imgName == "explosion.png")
            {
                EndGame("GameOver.png", (sender as Button).Width);
            }

            // All safe cells revealed?
            if (gameboard.AllCellsVisited())
            {
                EndGame("YouWin.png", (sender as Button).Width);
            }
        }


        /// <summary>
        /// End Game with Game Over, Display all live cells as mines
        /// </summary>
        /// <param name="size"></param>
        private void EndGame(string result, int size)
        {
            // stop timer 
            time.Stop();

            string showMinesAs;

            // Check if Game was lost to display correct message and mine icon
            if (result == "GameOver.png")
            {
                showMinesAs = "Mine.png";
                MessageBox.Show("GAME OVER !!\nYou Lose.");
            }
            // if Game was won display correct message and flag icon
            else
            {
                showMinesAs = "flag.png";

                // Display message box
                if (time.Elapsed.Minutes > 0)
                {
                    MessageBox.Show(string.Format("YOU WIN !!\nTime Elapsed: {0} minutes {1} seconds",
                        time.Elapsed.Minutes.ToString(), time.Elapsed.Seconds.ToString()));
                }
                else
                {
                    MessageBox.Show(string.Format("YOU WIN !!\nTime Elapsed: {0} seconds", time.Elapsed.Seconds.ToString()));
                }
            }

            // Display Message
            pbEndGame.Image = Bitmap.FromFile(imgFolderLoc + result) as Bitmap;
            pbEndGame.BackColor = Color.Transparent;
            pbEndGame.Visible = true;

            // iterate through board
            for (int row = 0; row < gameboard.Size; row++)
            {
                for (int col = 0; col < gameboard.Size; col++)
                {
                    // Find live cells
                    if (gameboard.Grid[row, col].IsLive)
                    {
                        // Set Image
                        Bitmap image = Bitmap.FromFile(imgFolderLoc + showMinesAs) as Bitmap;
                        Bitmap resized = new Bitmap(image, new Size(size, size));
                        btnGrid[row, col].Image = resized;
                        btnGrid[row, col].FlatStyle = FlatStyle.Flat;
                    }
                }
            }
            pnlBoard.Enabled = false;

            DisplayTopScores();
        }

        private string GetImgName(int row, int col)
        {
            int liveNeighbors = -1;

            liveNeighbors = gameboard.Grid[row, col].LiveNeighbors;
            gameboard.Grid[row, col].IsVisited = true;

            switch (liveNeighbors)
            {
                case 0:
                    return "zero.png";
                case 1:
                    return "one.png";
                case 2:
                    return "two.png";
                case 3:
                    return "three.png";
                case 4:
                    return "four.png";
                case 5:
                    return "five.png";
                case 6:
                    return "six.png";
                case 7:
                    return "seven.png";
                case 8:
                    return "eight.png";
                case 9:
                    return "explosion.png";
                default:
                    return "error.png";
            }
        }

        /// <summary>
        /// Close this form and open up StartUp form to create new game. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();

            pbEndGame.Visible = false;
            frmStartUp newGame = new frmStartUp();
            newGame.ShowDialog();

            this.Close();
        }

        public void DisplayTopScores()
        {
            frmHighScore highScores = new frmHighScore(gameboard, time.Elapsed.Seconds);
            highScores.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = "Time Elapsed:  " + time.Elapsed.ToString(@"m\:ss");
        }

        /// <summary>
        /// Print initialized gameboard in Debug output console for debugging purposes
        /// </summary>
        private void PrintConsole()
        {
            // Print gameboard cells
            for (int col = 0; col < gameboard.Size; col++)
            {
                for (int row = 0; row < gameboard.Size; row++)
                {
                    Debug.Write("| " + gameboard.Grid[row, col].ToString() + " ");
                }

                Debug.WriteLine("");
            }
        }
    }
}
