using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject TopLeftLabel;
    public GameObject BottomLeftLabel;
    public GameObject TopRightLabel;
    public GameObject BottomRightLabel;
    public GameObject WinnerLabel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePausePanel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameManager.state = GameManager.RUNNING;
    }

    public void OpenGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ConfigureWinnerLabel(int winningBaseID, int playersInGame)
    {
        if(GameManager.topDownCameraMode)
        {
            switch(winningBaseID)
            {
                case GameManager.TOP_LEFT:
                    WinnerLabel.GetComponent<Text>().text = getTopLeftLabelText() + " Wins!";
                    break;
                case GameManager.TOP_RIGHT:
                    WinnerLabel.GetComponent<Text>().text = getTopRightLabelText() + " Wins!";
                    break;
                case GameManager.BOTTOM_LEFT:
                    WinnerLabel.GetComponent<Text>().text = getBottomLeftLabelText() + " Wins!";
                    break;
                case GameManager.BOTTOM_RIGHT:
                    WinnerLabel.GetComponent<Text>().text = getBottomRightLabelText() + " Wins!";
                    break;
                default:
                    WinnerLabel.GetComponent<Text>().text = "No one wins...";
                    break;
            }
        }
        else
        {
            switch(winningBaseID)
            {
                case GameManager.TOP_LEFT:
                    WinnerLabel.GetComponent<Text>().text = getTopLeftLabelText() + " Wins!";
                    break;
                case GameManager.TOP_RIGHT:
                    if(playersInGame == 3)
                    {
                        WinnerLabel.GetComponent<Text>().text = getBottomLeftLabelText() + " Wins!";
                    }
                    else
                    {
                        WinnerLabel.GetComponent<Text>().text = getTopRightLabelText() + " Wins!";
                    }
                    break;
                case GameManager.BOTTOM_LEFT:
                    if(playersInGame == 3)
                    {
                        WinnerLabel.GetComponent<Text>().text = getBottomRightLabelText() + " Wins!";
                    }
                    else
                    {
                        WinnerLabel.GetComponent<Text>().text = getBottomLeftLabelText() + " Wins!";
                    }
                    
                    break;
                case GameManager.BOTTOM_RIGHT:
                    if(playersInGame == 2)
                    {
                        WinnerLabel.GetComponent<Text>().text = getBottomLeftLabelText() + " Wins!";
                    }
                    else
                    {
                        WinnerLabel.GetComponent<Text>().text = getBottomRightLabelText() + " Wins!";
                    }
                    break;
                default:
                    WinnerLabel.GetComponent<Text>().text = "No one wins...";
                    break;
            }
        }
    }

    public void ConfigureUILabels()
    {
        if (GameManager.topDownCameraMode)
        {
            switch (GameManager.activePlayers)
            {
                case 2:
                    SetBottomRightLabelText("Player 2");
                    SetTopRightLabelText("");
                    SetBottomLeftLabelText("");
                    break;
                case 3:
                    SetBottomRightLabelText("");
                    break;

                case 4:
                    //Keep all 4 players
                    break;
                default:
                    // an error has occurred because the default case should never be reached in this situation.
                    break;
            }
        }
        else
        {
            switch (GameManager.activePlayers)
            {
                case 2:
                    SetBottomLeftLabelText("Player 2");
                    SetTopRightLabelText("");
                    SetBottomRightLabelText("");
                    break;
                case 3:
                    SetBottomLeftLabelText("Player 2");
                    SetBottomRightLabelText("Player 3");
                    SetTopRightLabelText("");
                    break;

                case 4:
                    //Keep all 4 players
                    break;
                default:
                    // an error has occurred because the default case should never be reached in this situation.
                    break;
            }
        }
    }

    public void SetTopLeftLabelText(string inputText)
    {
        TopLeftLabel.GetComponent<Text>().text = inputText;
    }

    public void SetBottomLeftLabelText(string inputText)
    {
        BottomLeftLabel.GetComponent<Text>().text = inputText;
    }

    public void SetTopRightLabelText(string inputText)
    {
        TopRightLabel.GetComponent<Text>().text = inputText;
    }

    public void SetBottomRightLabelText(string inputText)
    {
        BottomRightLabel.GetComponent<Text>().text = inputText;
    }

    public string getTopLeftLabelText()
    {
        return TopLeftLabel.GetComponent<Text>().text;
    }

    public string getTopRightLabelText()
    {
        return TopRightLabel.GetComponent<Text>().text;
    }

    public string getBottomLeftLabelText()
    {
        return BottomLeftLabel.GetComponent<Text>().text;
    }

    public string getBottomRightLabelText()
    {
        return BottomRightLabel.GetComponent<Text>().text;
    }
}
