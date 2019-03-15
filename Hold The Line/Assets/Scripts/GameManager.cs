using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUD HUD;

    private static int activePlayers;

    // Start is called before the first frame update
    void Start()
    {
        switch (activePlayers)
        {
            case 2:
                // Player2.setActive(false);
                // Player3.setActive(false);
                // Change player4 display name to player2
                break;
            case 3:
                // Player4.setActive(false);
                break;

            default:
                // Keep all 4 players
                break;
        }
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
    private int checkActivePlayers()
    {
        int result = 0;

        for (all players)
            if (player is alive)
                result++;

        return result;
    }
    */
}
