using System;
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
        private User user;
        private GameLogic logic;
        private List<PictureBox> assets = new List<PictureBox>();

        public Form1()
        {
            logic = new GameLogic(this);
            InitializeComponent();
            this.gameTimer.Tick += new System.EventHandler(logic.gameEvent);
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
            logic.keyisdown(sender, e);
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            logic.keyisup(sender, e);
        }       

        protected void onLogin(object sender, EventArgs e)
        {
            if (e is LoginEventArgs)
            {
                LoginEventArgs eventArgs = (LoginEventArgs)e;
                user = eventArgs.User;
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
