using ClassLibrary;
using System.Drawing;

namespace MinesweeperGameGUI
{
    public partial class frmStartUp : Form
    {

        public frmStartUp()
        {
            InitializeComponent();

            // Add radio button options to Size group box
            gbSize.Controls.Add(rbSmall);
            gbSize.Controls.Add(rbClassic);
            gbSize.Controls.Add(rbLarge);

            // Add radio button options to Difficulty group box
            gbDifficulty.Controls.Add(rbEasy);
            gbDifficulty.Controls.Add(rbMedium);
            gbDifficulty.Controls.Add(rbHard);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            int size = 0,
                difficulty = 0;
            
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
                difficulty = int.Parse(rbEasy.Tag.ToString());
            }
            else if (rbMedium.Checked)
            {
                difficulty = int.Parse(rbMedium.Tag.ToString());
            }
            else if (rbHard.Checked)
            {
                difficulty = int.Parse(rbHard.Tag.ToString());
            }


            // Open new form & close this form
            this.Hide();
            frmGame game = new frmGame(size, difficulty);
            game.ShowDialog();
            this.Close();
        }

    }
}