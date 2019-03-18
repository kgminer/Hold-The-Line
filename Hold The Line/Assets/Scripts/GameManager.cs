using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUD HUD;
    public GameObject TopLeftBase;
    public GameObject BottomLeftBase;
    public GameObject TopRightBase;
    public GameObject BottomRightBase;

    public static int activePlayers;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
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
