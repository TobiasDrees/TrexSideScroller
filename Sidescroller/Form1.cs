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
        public User User { get; private set; }
        private Int32 score = 0;
        public Int32 Score
        {
            get
            {
                return score; 
            }
            set
            {
                score = value;
                this.scoreText.Text = "Score: " + score;
            }
        }

        public Int32 Highscore
        {
            get
            {
                Int32 val;
                try
                {
                    val = Convert.ToInt32(this.highscoreText.Text.Substring(12));
                }
                catch (Exception) 
                {
                    val = 0;
                }
                return val;
            }
            set
            {
                this.highscoreText.Text = "Highscore: " + value;
            }
        }

        public Int32 Money
        {
            get
            {
                Int32 val;
                try
                 {
                     string s = this.moneyText.Text.Substring(8);
                    val = Convert.ToInt32(s);
                }
                catch (Exception)
                {
                    val = 0;
                }
                return val;
            }
            set
            {
                this.moneyText.Text = "Money: $" + value;
                User.Money = value;
            }
        }

        public Int32 Lifes
        {
            get
            {
                Int32 val;
                try
                {
                    val = Convert.ToInt32(this.lifesText.Text.Substring(7));
                }
                catch (Exception)
                {
                    val = 0;
                }
                return val;
            }
            set
            {
                this.lifesText.Text = "Lifes: " + value;
            }
        }

        private GameLogic logic;
        private List<PictureBox> assets = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            upgradeMenu.View = this;
            assignAssets();
        }

        public void setEndMenuVisibility(bool visible)
        {
            this.endMenu.Visible = visible;
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
                logic.keyisdown(sender, e);
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (logic != null)
                logic.keyisup(sender, e);
        }       

        protected void onLogin(object sender, EventArgs e)
        {
            if (e is LoginEventArgs && logic == null || e is LoginEventArgs && logic != null && logic.State == GameLogic.GameState.NOT_INITIALIZED)
            {
                LoginEventArgs eventArgs = (LoginEventArgs)e;
                User = eventArgs.User;
                User.BoughtUpgrades = SQLManager.Instance.selectUserUpgrades(User.Id);
                Money = User.Money;
                this.upgradeMenu.updateButtonVisibility();
                logic = new GameLogic(this);
                this.gameTimer.Tick += new System.EventHandler(logic.gameEvent);
                logic.State = Sidescroller.GameLogic.GameState.INITIALIZED;
            }
        }

        protected void onRetry(object sender, EventArgs e)
        {
            if (logic.State == GameLogic.GameState.FINISHED)
                logic.State = GameLogic.GameState.INITIALIZED;
        }

        protected void onHighscore(object sender, EventArgs e)
        {
            this.highscorePanel.loadHighscore();
            this.highscorePanel.Visible = true;
        }

        protected void onUpgrades(object sender, EventArgs e)
        {
            this.upgradeMenu.Visible = true;
        }

        protected void showEndMenu(object sender, EventArgs e)
        {
            setEndMenuVisibility(true);
            this.endMenu.Focus();
        }

        public PictureBox getTrex()
        {
            return trex;
        }

        public PictureBox getFloor()
        {
            return floor;
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

        public void showStartText(bool b)
        {
            this.lblPressSpaceToStart.Visible = b;
        }

    }
}
