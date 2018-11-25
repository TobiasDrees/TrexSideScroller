namespace Sidescroller
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scoreText = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.livesText = new System.Windows.Forms.Label();
            this.moneyText = new System.Windows.Forms.Label();
            this.highscoreText = new System.Windows.Forms.Label();
            this.coin = new System.Windows.Forms.PictureBox();
            this.obstacle4 = new System.Windows.Forms.PictureBox();
            this.obstacle3 = new System.Windows.Forms.PictureBox();
            this.obstacle1 = new System.Windows.Forms.PictureBox();
            this.trex = new System.Windows.Forms.PictureBox();
            this.floor = new System.Windows.Forms.PictureBox();
            this.obstacle2 = new System.Windows.Forms.PictureBox();
            this.lblPressSpaceToStart = new System.Windows.Forms.Label();
            this.upgradeMenu = new Sidescroller.Upgrades();
            this.loginMask = new Sidescroller.LoginMask();
            this.endMenu = new Sidescroller.EndMenu();
            this.highscorePanel = new Sidescroller.HighscorePanel();
            ((System.ComponentModel.ISupportInitialize)(this.coin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle2)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.Location = new System.Drawing.Point(12, 9);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(88, 24);
            this.scoreText.TabIndex = 4;
            this.scoreText.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            // 
            // livesText
            // 
            this.livesText.AutoSize = true;
            this.livesText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesText.Location = new System.Drawing.Point(525, 9);
            this.livesText.Name = "livesText";
            this.livesText.Size = new System.Drawing.Size(81, 24);
            this.livesText.TabIndex = 8;
            this.livesText.Text = "Lives: 0";
            // 
            // moneyText
            // 
            this.moneyText.AutoSize = true;
            this.moneyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyText.Location = new System.Drawing.Point(12, 57);
            this.moneyText.Name = "moneyText";
            this.moneyText.Size = new System.Drawing.Size(96, 24);
            this.moneyText.TabIndex = 9;
            this.moneyText.Text = "Money: 0";
            // 
            // highscoreText
            // 
            this.highscoreText.AutoSize = true;
            this.highscoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreText.Location = new System.Drawing.Point(12, 33);
            this.highscoreText.Name = "highscoreText";
            this.highscoreText.Size = new System.Drawing.Size(129, 24);
            this.highscoreText.TabIndex = 10;
            this.highscoreText.Text = "Highscore: 0";
            // 
            // coin
            // 
            this.coin.Image = global::Sidescroller.Properties.Resources.coin;
            this.coin.Location = new System.Drawing.Point(210, 392);
            this.coin.Name = "coin";
            this.coin.Size = new System.Drawing.Size(40, 40);
            this.coin.TabIndex = 11;
            this.coin.TabStop = false;
            this.coin.Tag = "coin";
            // 
            // obstacle4
            // 
            this.obstacle4.Image = global::Sidescroller.Properties.Resources.bird;
            this.obstacle4.Location = new System.Drawing.Point(83, 155);
            this.obstacle4.Name = "obstacle4";
            this.obstacle4.Size = new System.Drawing.Size(46, 40);
            this.obstacle4.TabIndex = 7;
            this.obstacle4.TabStop = false;
            this.obstacle4.Tag = "obstacle";
            // 
            // obstacle3
            // 
            this.obstacle3.Image = global::Sidescroller.Properties.Resources.bird;
            this.obstacle3.Location = new System.Drawing.Point(483, 272);
            this.obstacle3.Name = "obstacle3";
            this.obstacle3.Size = new System.Drawing.Size(46, 40);
            this.obstacle3.TabIndex = 6;
            this.obstacle3.TabStop = false;
            this.obstacle3.Tag = "obstacle";
            // 
            // obstacle1
            // 
            this.obstacle1.Image = global::Sidescroller.Properties.Resources.obstacle_1;
            this.obstacle1.Location = new System.Drawing.Point(371, 406);
            this.obstacle1.Name = "obstacle1";
            this.obstacle1.Size = new System.Drawing.Size(23, 46);
            this.obstacle1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.obstacle1.TabIndex = 3;
            this.obstacle1.TabStop = false;
            this.obstacle1.Tag = "obstacle";
            // 
            // trex
            // 
            this.trex.BackColor = System.Drawing.Color.White;
            this.trex.Image = global::Sidescroller.Properties.Resources.running;
            this.trex.Location = new System.Drawing.Point(31, 392);
            this.trex.Name = "trex";
            this.trex.Size = new System.Drawing.Size(44, 60);
            this.trex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trex.TabIndex = 2;
            this.trex.TabStop = false;
            // 
            // floor
            // 
            this.floor.BackColor = System.Drawing.Color.Black;
            this.floor.Location = new System.Drawing.Point(-12, 452);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(652, 50);
            this.floor.TabIndex = 1;
            this.floor.TabStop = false;
            // 
            // obstacle2
            // 
            this.obstacle2.Image = global::Sidescroller.Properties.Resources.obstacle_2;
            this.obstacle2.Location = new System.Drawing.Point(534, 402);
            this.obstacle2.Name = "obstacle2";
            this.obstacle2.Size = new System.Drawing.Size(50, 50);
            this.obstacle2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacle2.TabIndex = 0;
            this.obstacle2.TabStop = false;
            this.obstacle2.Tag = "obstacle";
            // 
            // lblPressSpaceToStart
            // 
            this.lblPressSpaceToStart.AutoSize = true;
            this.lblPressSpaceToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressSpaceToStart.Location = new System.Drawing.Point(200, 106);
            this.lblPressSpaceToStart.Name = "lblPressSpaceToStart";
            this.lblPressSpaceToStart.Size = new System.Drawing.Size(194, 24);
            this.lblPressSpaceToStart.TabIndex = 14;
            this.lblPressSpaceToStart.Text = "Press Space to start";
            this.lblPressSpaceToStart.Visible = false;
            // 
            // upgradeMenu
            // 
            this.upgradeMenu.Form1 = null;
            this.upgradeMenu.Location = new System.Drawing.Point(145, 133);
            this.upgradeMenu.Name = "upgradeMenu";
            this.upgradeMenu.Size = new System.Drawing.Size(324, 127);
            this.upgradeMenu.TabIndex = 13;
            this.upgradeMenu.User = null;
            this.upgradeMenu.Visible = false;
            this.upgradeMenu.onBack += new System.EventHandler(this.showEndMenu);
            // 
            // loginMask
            // 
            this.loginMask.BackColor = System.Drawing.Color.Transparent;
            this.loginMask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginMask.Location = new System.Drawing.Point(195, 155);
            this.loginMask.Name = "loginMask";
            this.loginMask.Size = new System.Drawing.Size(237, 118);
            this.loginMask.TabIndex = 12;
            this.loginMask.onLogin += new System.EventHandler(this.onLogin);
            // 
            // endMenu
            // 
            this.endMenu.BackColor = System.Drawing.Color.Transparent;
            this.endMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.endMenu.Location = new System.Drawing.Point(228, 114);
            this.endMenu.Name = "endMenu";
            this.endMenu.Size = new System.Drawing.Size(156, 159);
            this.endMenu.TabIndex = 14;
            this.endMenu.Visible = false;
            this.endMenu.onRetry += new System.EventHandler(this.onRetry);
            this.endMenu.onHighscore += new System.EventHandler(this.onHighscore);
            this.endMenu.onUpgrades += new System.EventHandler(this.onUpgrades);
            // 
            // highscorePanel
            // 
            this.highscorePanel.BackColor = System.Drawing.Color.Transparent;
            this.highscorePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.highscorePanel.Location = new System.Drawing.Point(125, 33);
            this.highscorePanel.Name = "highscorePanel";
            this.highscorePanel.Size = new System.Drawing.Size(385, 391);
            this.highscorePanel.TabIndex = 14;
            this.highscorePanel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 476);
            this.Controls.Add(this.lblPressSpaceToStart);
            this.Controls.Add(this.upgradeMenu);
            this.Controls.Add(this.loginMask);
            this.Controls.Add(this.endMenu);
            this.Controls.Add(this.coin);
            this.Controls.Add(this.highscorePanel);
            this.Controls.Add(this.highscoreText);
            this.Controls.Add(this.moneyText);
            this.Controls.Add(this.livesText);
            this.Controls.Add(this.obstacle4);
            this.Controls.Add(this.obstacle3);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.obstacle1);
            this.Controls.Add(this.trex);
            this.Controls.Add(this.floor);
            this.Controls.Add(this.obstacle2);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T-Rex Sidescroller";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.coin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox obstacle2;
        private System.Windows.Forms.PictureBox floor;
        private System.Windows.Forms.PictureBox trex;
        private System.Windows.Forms.PictureBox obstacle1;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox obstacle3;
        private System.Windows.Forms.PictureBox obstacle4;
        private System.Windows.Forms.Label livesText;
        private System.Windows.Forms.Label moneyText;
        private System.Windows.Forms.Label highscoreText;
        private System.Windows.Forms.PictureBox coin;
        private LoginMask loginMask;
        private Upgrades upgradeMenu;
        private EndMenu endMenu;
        private HighscorePanel highscorePanel;
        private System.Windows.Forms.Label lblPressSpaceToStart;
    }
}

