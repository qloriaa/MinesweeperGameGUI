using ClassLibrary;
using System.Drawing;

//Changed difficulty to string type

namespace MinesweeperGameGUI
{
    public partial class frmStartUp : Form
    {

        public frmStartUp()
        {
            InitializeComponent();

            // Add radio button options to Size group box2
            gbSize.Controls.Add(rbSmall);
            gbSize.Controls.Add(rbClassic);
            gbSize.Controls.Add(rbLarge);

            // Add radio button options to Difficulty group box
            gbDifficulty.Controls.Add(rbEasy);
            gbDifficulty.Controls.Add(rbMedium);
            gbDifficulty.Controls.Add(rbHard);
        }

        /// <summary>
        /// Create a new Game using selected board settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            int size = 0;
            string difficulty = string.Empty;

            // Get selected size
            if (rbSmall.Checked)
            {
                size = int.Parse(rbSmall.Tag.ToString());
            }
            else if (rbClassic.Checked)
            {
                size = int.Parse(rbClassic.Tag.ToString());
            }
            else if (rbLarge.Checked)
            {
                size = int.Parse(rbLarge.Tag.ToString());
            }

            // Get selected difficulty
            if (rbEasy.Checked)
            {
                difficulty = rbEasy.Tag.ToString();
            }
            else if (rbMedium.Checked)
            {
                difficulty = rbMedium.Tag.ToString();
            }
            else if (rbHard.Checked)
            {
                difficulty = rbHard.Tag.ToString();
            }

            // Open new form & close this form
            this.Hide();
            frmGame game = new frmGame(size, difficulty);
            game.ShowDialog();
            this.Close();
        }

    }
}