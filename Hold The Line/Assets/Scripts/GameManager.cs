using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUD HUD;

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
            HUD.OpenPausePanel();
        }

        /*
        activePlayers = checkActivePlayers();

        if (activePlayers == 1)
        {
            HUD.OpenGameOverPanel();
        }
        */
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
