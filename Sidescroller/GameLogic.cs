using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidescroller
{
    class GameLogic
    {
        public enum GameState
        {
            NOT_INITIALIZED,
            INITIALIZED,
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
        private double scoremultiplier = 1;
        private bool intersectingObstacle = false;
        private Random rnd = new Random();

        private GameState state;
        private User user;

        private Form1 view;

        public GameLogic(Form1 view)
        {
            this.view = view;
        }

        public void gameEvent(object sender, EventArgs e)
        {
            view.Invalidate();
            PictureBox trex = view.getTrex();

            trex.Top += jumpSpeed;
            view.setScore(finalScore);
            view.setLives(lives);
            view.setMoney(money);

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

            foreach (PictureBox asset in view.getAssets())
            {
                if (asset.Tag == "obstacle")
                {
                    asset.Left -= obstacleSpeed;
                    if (asset.Left + asset.Width < -60)
                    {
                        asset.Left = view.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                    }

                    if (trex.Bounds.IntersectsWith(asset.Bounds) && invincibilityTime <= 0)
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
                else if (asset.Tag == "coin")
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
                trex.Top = view.getFloor().Top - trex.Height;
                jumpSpeed = 0;
                jumping = false;
                doubleJumping = false;
            }

            obstacleSpeed = baseObstaclespeed + baseScore / 500;
            baseScore++;
            scoremultiplier = (1 + (double)baseScore / 1000);
            finalScore = baseScore * scoremultiplier;
        }

        private void die()
        {
            view.stopTimer();
            if (highscore < finalScore)
            {
                highscore = (int)Math.Floor(finalScore);
            }
            view.getTrex().Image = Properties.Resources.dead;
            // TODO: Press R to Restart Text
            view.setHighscore(highscore);
        }

        private void resetGame()
        {
            PictureBox trex = view.getTrex();
            gravity = baseGravity;
            trex.Top = view.getFloor().Top - trex.Height;
            jumpSpeed = baseJumpSpeed;
            jumping = false;
            doubleJumping = false;
            lives = baseLives;
            baseScore = 0;
            finalScore = 0;
            obstacleSpeed = baseObstaclespeed;
            view.setScore(finalScore);
            trex.Image = Properties.Resources.running;

            foreach (PictureBox asset in view.getAssets())
            {
                if ((asset.Tag == "obstacle" || asset.Tag == "coin"))
                {
                    int position = rnd.Next(minSpawnDistance, maxSpawnDistance);
                    asset.Left = view.Width + position + asset.Width * 3;
                }
            }

            view.startTimer();
        }

        public void keyisdown(object sender, KeyEventArgs e)
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

        public void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                spaceLetGo = true;
            }

            if (e.KeyCode == Keys.R && state == GameState.INITIALIZED)
            {
                state = GameState.STARTED;
                resetGame();
            }
        }

        public void setState(GameState state)
        {
            if (state != null && this.state != state)
                this.state = state;
        }
    }
}
