using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HUD HUD;
    public Ball Ball;
    public GameObject WinnerLabel;
    public GameObject TopLeftBase;
    public GameObject BottomLeftBase;
    public GameObject TopRightBase;
    public GameObject BottomRightBase;

    public static int activePlayers;
    public static int state;
    public const int RUNNING = 1, PAUSE = 2, GAME_OVER = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Increases the difficulty every 45 seconds.
        InvokeRepeating("IncreaseDiffictulty", 45.0f, 45.0f);

        // Begins sudden death mode after 10 minutes.
        Invoke("SuddenDeath", 600.0f);

        // Enables the correct amount of players according to what the user has chosen.
        switch (activePlayers)
        {
            case 2:
                TopRightBase.SetActive(false);
                BottomLeftBase.SetActive(false);
                HUD.SetBottomRightLabelText("Player 2");
                HUD.SetTopRightLabelText("");
                HUD.SetBottomLeftLabelText("");
                break;
            case 3:
                BottomRightBase.SetActive(false);
                HUD.SetBottomRightLabelText("");
                break;

            case 4:
                //Keep all 4 players
                break;
            default:
                // an error has occurred because the default case should never be reached in this situation.
                break;
        }
        Time.timeScale = 1f;
        GameManager.state = RUNNING;
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
                    WinnerLabel.GetComponent<Text>().text = HUD.getTopLeftLabelText() + " Wins!";
                }
                else if (TopRightBase.activeSelf)
                {
                    WinnerLabel.GetComponent<Text>().text = HUD.getTopRightLabelText() + " Wins!";
                }
                else if (BottomLeftBase.activeSelf)
                {
                    WinnerLabel.GetComponent<Text>().text = HUD.getBottomLeftLabelText() + " Wins!";
                }
                else if (BottomRightBase.activeSelf)
                {
                    WinnerLabel.GetComponent<Text>().text = HUD.getBottomRightLabelText() + " Wins!";
                }
                else
                {
                    WinnerLabel.GetComponent<Text>().text = "No one wins...";
                }

                HUD.OpenGameOverPanel();
                break;
        }
    }

    // Spawns a new ball and increases the speed of all balls every time it is invoked.
    void IncreaseDifficulty()
    {
        Instantiate(Ball, new Vector3(0,0.38f,0), Quaternion.identity);
        Ball.SetSpeed(Ball.GetSpeed() + 5);
    }

    // Starts sudden death mode which increases the damage of the balls.
    void SuddenDeath()
    {

    }
}
