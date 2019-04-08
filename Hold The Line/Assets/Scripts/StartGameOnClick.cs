using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameOnClick : MonoBehaviour
{
    public GameManager GameManager
    {
        get => default;
        set
        {
        }
    }

    public void StartByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void SetNumberOfPlayers(int players)
    {
        GameManager.activePlayers = players;
    }
}
