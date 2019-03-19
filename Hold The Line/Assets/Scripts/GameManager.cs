using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HUD HUD;
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
                    HUD.OpenPausePanel();
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
}
