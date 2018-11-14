﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidescroller
{
    public partial class Form1 : Form
    {
        public User User { get; private set; }
        private GameLogic logic;
        private List<PictureBox> assets = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            assignAssets();
        }

        private void assignAssets()
        {
            assets.Add(coin);
            assets.Add(obstacle4);
            assets.Add(obstacle3);
            assets.Add(obstacle1);
            assets.Add(trex);
            assets.Add(obstacle2);
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (logic != null)
            {
                logic.keyisdown(sender, e);
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (logic != null)
            {
                logic.keyisup(sender, e);
            }
        }       

        protected void onLogin(object sender, EventArgs e)
        {
            if (e is LoginEventArgs)
            {
                LoginEventArgs eventArgs = (LoginEventArgs)e;
                User = eventArgs.User;
                User.BoughtUpgrades = SQLManager.Instance.selectUserUpgrades(User.Id);
                this.upgradeMenu.User = User;
                this.upgradeMenu.updateButtonVisibility();
                logic = new GameLogic(this);
                this.gameTimer.Tick += new System.EventHandler(logic.gameEvent);
                logic.setState(Sidescroller.GameLogic.GameState.INITIALIZED);
            }
        }

        public PictureBox getTrex()
        {
            return trex;
        }

        public PictureBox getFloor()
        {
            return floor;
        }

        public void setScore(double score)
        {
            this.scoreText.Text = "Score: " + Math.Floor(score);
        }

        public void setLives(int lives)
        {
            this.livesText.Text = "Lives: " + lives;
        }

        public void setMoney(int money)
        {
            this.moneyText.Text = "Money: $" + money;
        }

        public void setHighscore(int highscore)
        {
            this.highscoreText.Text = "Highscore: " + highscore;
        }

        public List<PictureBox> getAssets()
        {
            return assets;
        }

        public void stopTimer() {
            this.gameTimer.Stop();
        }

        public void startTimer()
        {
            this.gameTimer.Start();
        }
    }
}
