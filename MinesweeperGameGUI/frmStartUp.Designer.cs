namespace MinesweeperGameGUI
{
    partial class frmStartUp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbSize = new GroupBox();
            rbLarge = new RadioButton();
            rbSmall = new RadioButton();
            rbClassic = new RadioButton();
            gbDifficulty = new GroupBox();
            rbHard = new RadioButton();
            rbEasy = new RadioButton();
            rbMedium = new RadioButton();
            btnNewGame = new Button();
            gbSize.SuspendLayout();
            gbDifficulty.SuspendLayout();
            SuspendLayout();
            // 
            // gbSize
            // 
            gbSize.Controls.Add(rbLarge);
            gbSize.Controls.Add(rbSmall);
            gbSize.Controls.Add(rbClassic);
            gbSize.Location = new Point(46, 48);
            gbSize.Margin = new Padding(4, 3, 4, 3);
            gbSize.Name = "gbSize";
            gbSize.Padding = new Padding(4, 3, 4, 3);
            gbSize.Size = new Size(368, 335);
            gbSize.TabIndex = 0;
            gbSize.TabStop = false;
            gbSize.Text = "Select Board Size";
            // 
            // rbLarge
            // 
            rbLarge.AutoSize = true;
            rbLarge.Location = new Point(41, 238);
            rbLarge.Name = "rbLarge";
            rbLarge.Size = new Size(221, 40);
            rbLarge.TabIndex = 2;
            rbLarge.TabStop = true;
            rbLarge.Tag = "12";
            rbLarge.Text = "Large 12 x 12";
            rbLarge.UseVisualStyleBackColor = true;
            // 
            // rbSmall
            // 
            rbSmall.AutoSize = true;
            rbSmall.Location = new Point(41, 71);
            rbSmall.Name = "rbSmall";
            rbSmall.Size = new Size(190, 40);
            rbSmall.TabIndex = 1;
            rbSmall.TabStop = true;
            rbSmall.Tag = "5";
            rbSmall.Text = "Small 5 x 5";
            rbSmall.UseVisualStyleBackColor = true;
            // 
            // rbClassic
            // 
            rbClassic.AutoSize = true;
            rbClassic.Checked = true;
            rbClassic.Location = new Point(41, 151);
            rbClassic.Name = "rbClassic";
            rbClassic.Size = new Size(206, 40);
            rbClassic.TabIndex = 0;
            rbClassic.TabStop = true;
            rbClassic.Tag = "8";
            rbClassic.Text = "Classic 8 x 8";
            rbClassic.UseVisualStyleBackColor = true;
            // 
            // gbDifficulty
            // 
            gbDifficulty.Controls.Add(rbHard);
            gbDifficulty.Controls.Add(rbEasy);
            gbDifficulty.Controls.Add(rbMedium);
            gbDifficulty.Location = new Point(490, 48);
            gbDifficulty.Margin = new Padding(4, 3, 4, 3);
            gbDifficulty.Name = "gbDifficulty";
            gbDifficulty.Padding = new Padding(4, 3, 4, 3);
            gbDifficulty.Size = new Size(403, 335);
            gbDifficulty.TabIndex = 3;
            gbDifficulty.TabStop = false;
            gbDifficulty.Text = "Select Game Difficulty";
            // 
            // rbHard
            // 
            rbHard.AutoSize = true;
            rbHard.Location = new Point(48, 238);
            rbHard.Name = "rbHard";
            rbHard.Size = new Size(199, 40);
            rbHard.TabIndex = 2;
            rbHard.TabStop = true;
            rbHard.Tag = "50";
            rbHard.Text = "Hard (50%)";
            rbHard.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            rbEasy.AutoSize = true;
            rbEasy.Location = new Point(48, 71);
            rbEasy.Name = "rbEasy";
            rbEasy.Size = new Size(195, 40);
            rbEasy.TabIndex = 1;
            rbEasy.TabStop = true;
            rbEasy.Tag = "10";
            rbEasy.Text = "Easy (10%)";
            rbEasy.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            rbMedium.AutoSize = true;
            rbMedium.Checked = true;
            rbMedium.Location = new Point(48, 151);
            rbMedium.Name = "rbMedium";
            rbMedium.Size = new Size(240, 40);
            rbMedium.TabIndex = 0;
            rbMedium.TabStop = true;
            rbMedium.Tag = "30";
            rbMedium.Text = "Medium (30%)";
            rbMedium.UseVisualStyleBackColor = true;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(294, 412);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(327, 56);
            btnNewGame.TabIndex = 4;
            btnNewGame.Text = "Start New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // frmStartUp
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 504);
            Controls.Add(btnNewGame);
            Controls.Add(gbDifficulty);
            Controls.Add(gbSize);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmStartUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "*5";
            gbSize.ResumeLayout(false);
            gbSize.PerformLayout();
            gbDifficulty.ResumeLayout(false);
            gbDifficulty.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbSize;
        private RadioButton rbSmall;
        private RadioButton rbClassic;
        private RadioButton rbLarge;
        private GroupBox gbDifficulty;
        private RadioButton rbHard;
        private RadioButton rbEasy;
        private RadioButton rbMedium;
        private Button btnNewGame;
    }
}