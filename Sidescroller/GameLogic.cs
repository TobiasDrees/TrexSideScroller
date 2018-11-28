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

        private const int JUMP_SPEED = -18;
        private const int BASE_ASSET_SPEED = 5;
        private const int GRAVITY = 1;
        private const int MIN_SPAWN_DIST = 0;
        private const int MAX_SPAWN_DIST = 800;
        private const int BASE_LIVES = 1;
        private const int INVINCIBILITY_TIME = 1000;
        private const int DAMAGE_BUILDUP_TIME = 40;
        private const int GAME_LOOP_INTERVAL = 10;

        private bool doubleJumpUnlocked = false;
        private bool jumping = false;
        private bool doubleJumping = false;
        private bool spaceLetGo = true;
        private int currJumpSpeed = 0;
        private Int32 currAssetSpeed = BASE_ASSET_SPEED;
        private int bonusLives = 0;
        private int currInvincibilityTime = 0;
        private int currDamageBuildupTime = DAMAGE_BUILDUP_TIME;
        private bool intersectingObstacle = false;
        private Random random = new Random();

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
        private Form1 view;

        public GameLogic(Form1 view)
        {
            state = GameState.NOT_INITIALIZED;
            this.view = view;
            if (view.User.BoughtUpgrades.Contains(1))
            {
                bonusLives++;
            }

            if (view.User.BoughtUpgrades.Contains(2))
            {
                bonusLives++;
            }

            if (view.User.BoughtUpgrades.Contains(3))
            {
                bonusLives++;
            }

            if (view.User.BoughtUpgrades.Contains(4))
            {
                bonusLives++;
            }

            if (view.User.BoughtUpgrades.Contains(5))
            {
                doubleJumpUnlocked = true;
            }

            view.Lives = BASE_LIVES + bonusLives;
        }

        public void gameEvent(object sender, EventArgs e)
        {
            view.Invalidate();
            PictureBox trex = view.getTrex();

            trex.Top += currJumpSpeed;

            if (currInvincibilityTime > 0)
            {
                currInvincibilityTime -= GAME_LOOP_INTERVAL;
                trex.Visible = !trex.Visible;
            }

            if (jumping)
            {
                currJumpSpeed += GRAVITY;
            }

            intersectingObstacle = false;

            foreach (PictureBox asset in view.getAssets())
            {
                if ((String) asset.Tag == "obstacle")
                {
                    // Move assets
                    asset.Left -= currAssetSpeed;
                    if (asset.Left + asset.Width < -60)
                    {
                        asset.Left = view.ClientSize.Width + random.Next(MIN_SPAWN_DIST, MAX_SPAWN_DIST);
                    }

                    // Collision trex and asset
                    if (trex.Bounds.IntersectsWith(asset.Bounds) && currInvincibilityTime <= 0)
                    {
                        intersectingObstacle = true;

                        // Workaround for hitboxes
                        if (currDamageBuildupTime <= 0)
                        {
                            view.Lifes -= 1;
                            currDamageBuildupTime = DAMAGE_BUILDUP_TIME;

                            if (view.Lives == 0)
                            {
                                die();
                                return;
                            }
                            else
                            {
                                currInvincibilityTime = INVINCIBILITY_TIME;
                            }
                        }
                    }
                }
                else if ((String) asset.Tag == "coin")
                {
                    asset.Left -= currAssetSpeed;
                    if (asset.Left + asset.Width < -60)
                    {
                        asset.Left = view.ClientSize.Width + random.Next(MIN_SPAWN_DIST, MAX_SPAWN_DIST);
                        asset.Top = view.ClientSize.Height - random.Next(100, 400);
                    }

                    if (trex.Bounds.IntersectsWith(asset.Bounds))
                    {
                        view.Money += 1;
                        view.Score += 25;
                        asset.Left = view.ClientSize.Width + random.Next(MIN_SPAWN_DIST, MAX_SPAWN_DIST);
                        asset.Top = view.ClientSize.Height - random.Next(100, 400);
                    }
                }
            }

            if (intersectingObstacle)
            {
                currDamageBuildupTime -= 20;
            }
            else
            {
                currDamageBuildupTime = DAMAGE_BUILDUP_TIME;
            }

            if (trex.Top >= 380)
            {
                trex.Top = view.getFloor().Top - trex.Height;
                currJumpSpeed = 0;
                jumping = false;
                doubleJumping = false;
            }

            Int32 score = view.Score;
            currAssetSpeed = BASE_ASSET_SPEED + (score / 5000);
            view.Score = ++score;
        }

        public void retry()
        {
            resetGame();
        }

        private void die()
        {
            view.stopTimer();
            if (view.Highscore < view.Score)
            {
                view.Highscore = view.Score;
            }
            view.getTrex().Image = Properties.Resources.dead;

            SQLManager.Instance.insertUserScore(view.User, view.Score);
            SQLManager.Instance.updateUserMoney(view.User);

            State = GameState.FINISHED;
            view.setEndMenuVisibility(true);
        }

        private void resetGame()
        {
            PictureBox trex = view.getTrex();
            trex.Top = view.getFloor().Top - trex.Height;
            currJumpSpeed = 0;
            jumping = false;
            doubleJumping = false;
            view.Lives = BASE_LIVES + bonusLives;
            view.Score = 0;
            currAssetSpeed = BASE_ASSET_SPEED;
            trex.Image = Properties.Resources.running;

            foreach (PictureBox asset in view.getAssets())
            {
                if ((((String) asset.Tag) == "obstacle" || ((String) asset.Tag) == "coin"))
                {
                    int position = random.Next(MIN_SPAWN_DIST, MAX_SPAWN_DIST);
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
                        currJumpSpeed = JUMP_SPEED;
                        spaceLetGo = false;
                    }

                    if (doubleJumpUnlocked && !doubleJumping && spaceLetGo)
                    {
                        currJumpSpeed = JUMP_SPEED;
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
