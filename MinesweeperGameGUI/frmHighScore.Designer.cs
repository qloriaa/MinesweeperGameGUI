namespace MinesweeperGameGUI
{
    partial class frmHighScore
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
            lblBoardSize = new Label();
            lbTopScores = new ListBox();
            lblInitials = new Label();
            txtInitials = new TextBox();
            btnInitials = new Button();
            SuspendLayout();
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblBoardSize.Location = new Point(102, 50);
            lblBoardSize.Margin = new Padding(4, 0, 4, 0);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(503, 43);
            lblBoardSize.TabIndex = 0;
            lblBoardSize.Text = "Classic 8 x 8 Board Top Scores:";
            // 
            // lbTopScores
            // 
            lbTopScores.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbTopScores.FormattingEnabled = true;
            lbTopScores.ItemHeight = 42;
            lbTopScores.Location = new Point(83, 167);
            lbTopScores.Margin = new Padding(4, 3, 4, 3);
            lbTopScores.Name = "lbTopScores";
            lbTopScores.Size = new Size(554, 214);
            lbTopScores.TabIndex = 1;
            lbTopScores.Visible = false;
            // 
            // lblInitials
            // 
            lblInitials.AutoSize = true;
            lblInitials.Location = new Point(102, 119);
            lblInitials.Name = "lblInitials";
            lblInitials.Size = new Size(277, 36);
            lblInitials.TabIndex = 2;
            lblInitials.Text = "Enter Player Initials:";
            lblInitials.Visible = false;
            // 
            // txtInitials
            // 
            txtInitials.CharacterCasing = CharacterCasing.Upper;
            txtInitials.Location = new Point(395, 116);
            txtInitials.MaxLength = 3;
            txtInitials.Name = "txtInitials";
            txtInitials.Size = new Size(108, 44);
            txtInitials.TabIndex = 3;
            txtInitials.Visible = false;
            // 
            // btnInitials
            // 
            btnInitials.BackColor = SystemColors.ButtonShadow;
            btnInitials.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnInitials.Location = new Point(528, 115);
            btnInitials.Name = "btnInitials";
            btnInitials.Size = new Size(77, 46);
            btnInitials.TabIndex = 4;
            btnInitials.Text = "OK";
            btnInitials.UseVisualStyleBackColor = false;
            btnInitials.Visible = false;
            btnInitials.Click += btnInitials_Click;
            // 
            // frmHighScore
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 430);
            Controls.Add(btnInitials);
            Controls.Add(txtInitials);
            Controls.Add(lblInitials);
            Controls.Add(lbTopScores);
            Controls.Add(lblBoardSize);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmHighScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Top Player Stats";
            Load += frmHighScore_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBoardSize;
        private ListBox lbTopScores;
        private Label lblInitials;
        private TextBox txtInitials;
        private Button btnInitials;
    }
}