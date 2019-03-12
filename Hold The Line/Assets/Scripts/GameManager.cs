using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    private bool isPaused = false;
    private int activePlayers = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        /*
        activePlayers = checkActivePlayers();

        if (activePlayers == 1)
        {
            GameOver();
        }
        */
    }

    public void ResumeGame()
    {
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void PauseGame()
    {
        isPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }

    // TODO
    // Until we have some way to check if a player has been eliminated.
    /*
    int checkActivePlayers()
    {
        int result = 0;

        for (all players)
            if (player is alive)
                result++;

        return result;
    }
    */
}
