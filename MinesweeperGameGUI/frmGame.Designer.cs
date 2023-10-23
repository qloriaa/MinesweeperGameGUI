namespace MinesweeperGameGUI
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            pnlBoard = new Panel();
            pbEndGame = new PictureBox();
            lblDifficulty = new Label();
            lblLiveCells = new Label();
            pictureBox1 = new PictureBox();
            btnNewGame = new Button();
            lblTimer = new Label();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbEndGame).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlBoard
            // 
            pnlBoard.BackColor = Color.Silver;
            pnlBoard.Location = new Point(109, 62);
            pnlBoard.Margin = new Padding(4, 3, 4, 3);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(1100, 1100);
            pnlBoard.TabIndex = 0;
            // 
            // pbEndGame
            // 
            pbEndGame.Image = (Image)resources.GetObject("pbEndGame.Image");
            pbEndGame.Location = new Point(1216, 274);
            pbEndGame.Name = "pbEndGame";
            pbEndGame.Size = new Size(364, 316);
            pbEndGame.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEndGame.TabIndex = 0;
            pbEndGame.TabStop = false;
            pbEndGame.Visible = false;
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.BackColor = Color.YellowGreen;
            lblDifficulty.Enabled = false;
            lblDifficulty.ForeColor = SystemColors.ActiveCaptionText;
            lblDifficulty.Location = new Point(1280, 274);
            lblDifficulty.Margin = new Padding(4, 0, 4, 0);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(224, 36);
            lblDifficulty.TabIndex = 1;
            lblDifficulty.Text = "Difficulty Level ";
            // 
            // lblLiveCells
            // 
            lblLiveCells.AutoSize = true;
            lblLiveCells.BackColor = Color.YellowGreen;
            lblLiveCells.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            lblLiveCells.Location = new Point(1332, 518);
            lblLiveCells.Margin = new Padding(4, 0, 4, 0);
            lblLiveCells.Name = "lblLiveCells";
            lblLiveCells.Size = new Size(143, 49);
            lblLiveCells.TabIndex = 2;
            lblLiveCells.Text = "Bombs";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SteelBlue;
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1332, 386);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = SystemColors.ButtonHighlight;
            btnNewGame.FlatAppearance.BorderSize = 2;
            btnNewGame.FlatStyle = FlatStyle.Popup;
            btnNewGame.Location = new Point(1303, 743);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(186, 73);
            btnNewGame.TabIndex = 3;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.YellowGreen;
            lblTimer.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimer.Location = new Point(1251, 671);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(293, 36);
            lblTimer.TabIndex = 4;
            lblTimer.Text = "Time Elapsed:   00:00";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // frmGame
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1574, 1229);
            Controls.Add(pbEndGame);
            Controls.Add(lblTimer);
            Controls.Add(btnNewGame);
            Controls.Add(pictureBox1);
            Controls.Add(lblLiveCells);
            Controls.Add(lblDifficulty);
            Controls.Add(pnlBoard);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmGame";
            Padding = new Padding(50);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            ((System.ComponentModel.ISupportInitialize)pbEndGame).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBoard;
        private Label lblDifficulty;
        private Label lblLiveCells;
        private PictureBox pictureBox1;
        private Button btnNewGame;
        private PictureBox pbEndGame;
        private Label lblTimer;
        private System.Windows.Forms.Timer timer;
    }
}