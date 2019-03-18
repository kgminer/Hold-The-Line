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
}
