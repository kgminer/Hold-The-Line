using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HUD HUD;
    public Ball Ball;
    public SplitScreen splitScreen;
    public GameObject TopLeftBase;
    public GameObject BottomLeftBase;
    public GameObject TopRightBase;
    public GameObject BottomRightBase;

    public static int activePlayers;
    public static int state;
    public static bool topDownCameraMode;
    private int winningBase, numberOfPlayersAtStart;
    public const int RUNNING = 1, PAUSE = 2, GAME_OVER = 3;
    public const int NO_WINNER = 0, TOP_LEFT = 1, TOP_RIGHT = 2, BOTTOM_LEFT = 3, BOTTOM_RIGHT = 4;

    // Start is called before the first frame update
    void Start()
    {
        // Increases the difficulty every 45 seconds.
        InvokeRepeating("IncreaseDifficulty", 10.0f, 15.0f);

        // Begins sudden death mode after 10 minutes.
        Invoke("SuddenDeath", 600.0f);

        // Enables the correct amount of players according to what the user has chosen.
        switch (activePlayers)
        {
            case 2:
                TopRightBase.SetActive(false);
                BottomLeftBase.SetActive(false);
                break;
            case 3:
                BottomRightBase.SetActive(false);
                break;

            case 4:
                //Keep all 4 players
                break;
            default:
                // an error has occurred because the default case should never be reached in this situation.
                break;
        }

        HUD.ConfigureUILabels();

        //Configures cameras based on which camera setting is selected
        if(topDownCameraMode)
        {
            splitScreen.ConfigureTopDown();
        }
        else
        {
            splitScreen.ConfigureSplitScreen();
        }

        Time.timeScale = 1f;
        GameManager.state = RUNNING;
        numberOfPlayersAtStart = GameManager.activePlayers;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.state)
        {
            case RUNNING:
                if (Input.GetButtonDown("Start"))
                {
                    GameManager.state = PAUSE;
                }
                if (activePlayers == 1)
                {
                    GameManager.state = GAME_OVER;
                }
                break;
            case PAUSE:
                HUD.OpenPausePanel();
                break;
            case GAME_OVER:
                if (TopLeftBase.activeSelf)
                {
                    winningBase = TOP_LEFT;
                }
                else if (TopRightBase.activeSelf)
                {
                    winningBase = TOP_RIGHT;
                }
                else if (BottomLeftBase.activeSelf)
                {
                    winningBase = BOTTOM_LEFT;
                }
                else if (BottomRightBase.activeSelf)
                {
                    winningBase = BOTTOM_RIGHT;
                }
                else
                {
                    winningBase = NO_WINNER;
                }
                HUD.ConfigureWinnerLabel(winningBase, numberOfPlayersAtStart);
                HUD.OpenGameOverPanel();
                break;
        }
    }

    // Spawns a new ball and increases the speed of all balls every time it is invoked.
    void IncreaseDifficulty()
    {
        Debug.Log("We made it");
        Instantiate(Ball, new Vector3(0,0.38f,0), Quaternion.identity);
        Ball.SetSpeed(Ball.GetSpeed() + 5);
    }

    // Starts sudden death mode which increases the damage of the balls.
    void SuddenDeath()
    {

    }
}
