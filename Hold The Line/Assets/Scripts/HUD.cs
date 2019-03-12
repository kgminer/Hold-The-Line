using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    
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
    }

    public void OpenGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
