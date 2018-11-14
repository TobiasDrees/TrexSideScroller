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
        private const int gameLoopIntervall = 20;

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
        public GameState State
        { 
            get
            {
            return state;   
            }
            set 
            {
                if (value == GameState.INITIALIZED)
                    view.showStartText(true);
                else if (value == GameState.STARTED)
                    view.showStartText(false);
                state = value;
            }
        }
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


            if (invincibilityTime > 0)
            {
                invincibilityTime -= gameLoopIntervall;
                trex.Visible = !trex.Visible;
            }

            if (jumping)
            {
                jumpSpeed += gravity;
            }

            intersectingObstacle = false;

            foreach (PictureBox asset in view.getAssets())
            {
                if ((String) asset.Tag == "obstacle")
                {
                    // Move assets
                    asset.Left -= obstacleSpeed;
                    if (asset.Left + asset.Width < -60)
                    {
                        asset.Left = view.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                    }

                    // Collision trex and asset
                    if (trex.Bounds.IntersectsWith(asset.Bounds) && invincibilityTime <= 0)
                    {
                        intersectingObstacle = true;

                        // Workaround for hitboxes
                        if (damageBuildupTime <= 0)
                        {
                            lives -= 1;
                            view.setLives(lives);
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
                else if ((String) asset.Tag == "coin")
                {
                    asset.Left -= obstacleSpeed;
                    if (asset.Left + asset.Width < -60)
                    {
                        asset.Left = view.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                        asset.Top = view.ClientSize.Height - rnd.Next(100, 400);
                    }

                    if (trex.Bounds.IntersectsWith(asset.Bounds))
                    {
                        money += 1;
                        view.setMoney(money);
                        baseScore += 25;
                        asset.Left = view.ClientSize.Width + rnd.Next(minSpawnDistance, maxSpawnDistance);
                        asset.Top = view.ClientSize.Height - rnd.Next(100, 400);
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
            view.setScore(finalScore);
        }

        public void retry()
        {
            resetGame();
        }

        private void die()
        {
            view.stopTimer();
            if (highscore < finalScore)
            {
                highscore = (int)Math.Floor(finalScore);
            }
            view.getTrex().Image = Properties.Resources.dead;
            view.setHighscore(highscore);

            State = GameState.FINISHED;
            view.setEndMenuVisibility(true);
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
            view.setLives(lives);
            trex.Image = Properties.Resources.running;

            foreach (PictureBox asset in view.getAssets())
            {
                if ((((String) asset.Tag) == "obstacle" || ((String) asset.Tag) == "coin"))
                {
                    int position = rnd.Next(minSpawnDistance, maxSpawnDistance);
                    asset.Left = view.Width + position + asset.Width * 3;
                }
            }

            State = GameState.STARTED;
            view.startTimer();            
        }

        public void keyisdown(object sender, KeyEventArgs e)
        {
            if (State == GameState.STARTED)
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
        }

        public void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && State == GameState.STARTED)
            {
                spaceLetGo = true;
            }

            if (e.KeyCode == Keys.Space && State == GameState.INITIALIZED)
            {
                resetGame();
            }
        }
    }
}
