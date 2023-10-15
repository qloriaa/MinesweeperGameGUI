using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGameGUI
{
    public partial class frmGame : Form
    {

        static public Board gameboard;
        public Button[,] btnGrid;


        public frmGame(int size, int difficulty)
        {
            InitializeComponent();

            gameboard = new Board(size, difficulty);
            btnGrid = new Button[gameboard.Size, gameboard.Size];

            // Set labels
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

            lblLiveCells.Text = gameboard.LiveCells.ToString();


            populateGrid();

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

                    // Add Button click event
                    btnGrid[row, col].Click += GridButton_Click;
                    // Add button to panel
                    pnlBoard.Controls.Add(btnGrid[row, col]);
                    // Position button on panel
                    btnGrid[row, col].Location = new Point(btnSize * row, btnSize * col);

                    ///// Tetsing 
                    btnGrid[row, col].Text = row.ToString() + ", " + col.ToString();

                    // Tag the control as string 
                    btnGrid[row, col].Tag = row.ToString() + "|" + col.ToString();
                }
            }


        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            // Get grid loaction of Button
            string[] location = (sender as Button).Tag.ToString().Split('|');
            int row = int.Parse(location[0]);
            int col = int.Parse(location[1]);

            // Display the content of the button
            Cell currCell = gameboard.Grid[row, col];
            (sender as Button).BackColor = Color.DarkGray;
            (sender as Button).Text = currCell.ToString();
        }

        /// <summary>
        /// Close this form and open up StartUp form to create new game. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmStartUp newGame = new frmStartUp();
            newGame.ShowDialog();

            this.Close();
        }

    }
}
