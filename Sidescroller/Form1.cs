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
        enum GameState
        {
            INIT,
            STARTED,
            FINISHED
        }

        private const int baseJumpSpeed = 30;
        private const int baseObstaclespeed = 10;
        private const int baseGravity = 3;
        private const int minSpawnDistance = 0;
        private const int maxSpawnDistance = 800;
        private const int baseLives = 3;
        private const int baseInvincibilityTime = 1000;
        private const int baseDamageBuildupTime = 40;

        private bool doubleJumpUnlocked = true;
        private bool jumping = false;
        private bool doubleJumping = false;
        private bool spaceLetGo = true;
        private int jumpSpeed = baseJumpSpeed;
        private int gravity = baseGravity;
        private int baseScore = 0;
        private double finalScore = 0;
        private int obstacleSpeed = baseObstaclespeed;
        private int lives = baseLives;
        private int invincibilityTime = 0;
        private int damageBuildupTime = baseDamageBuildupTime;
        private int money = 0;
        private int highscore = 0;
        private double scoreMultiplier = 1;
        private bool intersectingObstacle = false;
        private Random rnd = new Random();

        private GameState state;

        public Form1()
        {
            state = GameState.STARTED;
            InitializeComponent();
        }

        private void gameEvent(object sender, EventArgs e)
        {
            this.Invalidate();

            trex.Top += jumpSpeed;
            scoreText.Text = "Score: " + Math.Floor(finalScore);
            livesText.Text = "Lives: " + lives;
            moneyText.Text = "Money: $" + money;

            if (invincibilityTime > 0)
            {
                invincibilityTime -= 20;
                trex.Visible = !trex.Visible;
            }

            if (jumping)
            {
                jumpSpeed += gravity;
            }

            intersectingObstacle = false;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Tag == "obstacle")
                    {
                        x.Left -= obstacleSpeed;
                        if (x.Left + x.Width < -60)
                        {
                            x.Left = this.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                        }

                        if (trex.Bounds.IntersectsWith(x.Bounds) && invincibilityTime <= 0)
                        {
                            intersectingObstacle = true;

                            if (damageBuildupTime <= 0)
                            {
                                lives -= 1;
                                damageBuildupTime = baseDamageBuildupTime;

                                if (lives == 0)
                                {
                                    die();
                                }
                                else
                                {
                                    invincibilityTime = baseInvincibilityTime;
                                }
                            }
                        }
                    }
                    else if (x.Tag == "coin")
                    {
                        x.Left -= obstacleSpeed;
                        if (x.Left + x.Width < -60)
                        {
                            x.Left = this.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                            x.Top = this.ClientSize.Height - rnd.Next(100, 400);
                        }

                        if (trex.Bounds.IntersectsWith(x.Bounds))
                        {
                            money += 1;
                            baseScore += 25;
                            x.Left = this.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                            x.Top = this.ClientSize.Height - rnd.Next(100, 400);
                        }
                    }
                }
            }

            if (intersectingObstacle)
            {
                damageBuildupTime -= 20;
            }
            else
            {
                damageBuildupTime = baseDamageBuildupTime;

            }

            if (trex.Top >= 380)
            {
                trex.Top = floor.Top - trex.Height;
                jumpSpeed = 0;
                jumping = false;
                doubleJumping = false;
            }

            obstacleSpeed = baseObstaclespeed + baseScore / 500;
            baseScore++;
            scoreMultiplier = (1 + (double)baseScore / 1000);
            finalScore = baseScore * scoreMultiplier;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                if (!jumping)
                {
                    jumping = true;
                    jumpSpeed = -baseJumpSpeed;
                    spaceLetGo = false;
                }

                if (doubleJumpUnlocked && !doubleJumping && spaceLetGo)
                {
                    jumpSpeed = -baseJumpSpeed;
                    doubleJumping = true;
                }
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                spaceLetGo = true;
            }

            if (e.KeyCode == Keys.R && state == GameState.STARTED)
            {
                resetGame();
            }
        }

        private void die()
        {
            gameTimer.Stop();
            if (highscore < finalScore)
            {
                highscore = (int)Math.Floor(finalScore);
            }
            trex.Image = Properties.Resources.dead;
            scoreText.Text += "  Press R to restart";
            highscoreText.Text = "Highscore: " + highscore;
        }

        private void resetGame()
        {
            gravity = baseGravity;
            trex.Top = floor.Top - trex.Height;
            jumpSpeed = baseJumpSpeed;
            jumping = false;
            doubleJumping = false;
            lives = baseLives;
            baseScore = 0;
            finalScore = 0;
            obstacleSpeed = baseObstaclespeed;
            scoreText.Text = "Score: " + finalScore;
            trex.Image = Properties.Resources.running;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (x.Tag == "obstacle" || x.Tag == "coin"))
                {
                    int position = rnd.Next(minSpawnDistance, maxSpawnDistance);
                    x.Left = this.Width + position + x.Width * 3;
                }
            }

            gameTimer.Start();
        }
    }
}
