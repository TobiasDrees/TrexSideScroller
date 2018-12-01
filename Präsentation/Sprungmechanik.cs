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
    private const int GRAVITY = 1;

    private bool doubleJumpUnlocked = false;
    private bool jumping = false;
    private bool doubleJumping = false;
    private bool spaceLetGo = true;
    private int currJumpSpeed = 0;
    private Int32 currAssetSpeed = BASE_ASSET_SPEED;

    private GameState state;

    public void gameEvent(object sender, EventArgs e)
    {
        if (jumping)
        {
            trex.Top += currJumpSpeed;
            currJumpSpeed += GRAVITY;

            if (trex.Top >= 380)
            {
                trex.Top = view.getFloor().Top - trex.Height;
                currJumpSpeed = 0;
                jumping = false;
                doubleJumping = false;
            }
        }
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
        if (State == GameState.STARTED)
        {
            if (e.KeyCode == Keys.Space)
            {
                spaceLetGo = true;
            }
        }
    }
}