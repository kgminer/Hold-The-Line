using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;
    [SerializeField]
    private Camera topLeftCamera;
    [SerializeField]
    private Camera topRightCamera;
    [SerializeField]
    private Camera bottomLeftCamera;
    [SerializeField]
    private Camera bottomRightCamera;

    public void ConfigureTopDown()
    {
        topDownCamera.gameObject.SetActive(true);
        topLeftCamera.gameObject.SetActive(false);
        topRightCamera.gameObject.SetActive(false);
        bottomLeftCamera.gameObject.SetActive(false);
        bottomRightCamera.gameObject.SetActive(false);
    }

    public void ConfigureSplitScreen()
    {
        topDownCamera.gameObject.SetActive(false);

        switch (GameManager.activePlayers)
        {
            case 2:
                SetTwoPlayer();
                break;
            case 3:
                SetThreePlayer();
                break;

            case 4:
                SetFourPlayer();
                break;
            default:
                // an error has occurred because the default case should never be reached in this situation.
                break;
        }
    }

    public void SetTwoPlayer()
    {
        topLeftCamera.rect = new Rect(0, 0.5f, 1f, 0.5f);
        topRightCamera.gameObject.SetActive(false);
        bottomLeftCamera.gameObject.SetActive(false);
        bottomRightCamera.rect = new Rect(0, 0, 1f, 0.5f);
    }

    public void SetThreePlayer()
    {
        topLeftCamera.rect = new Rect(0, 0.5f, 1f, 0.5f);
        topRightCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
        bottomLeftCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        bottomRightCamera.gameObject.SetActive(false);
    }

    public void SetFourPlayer()
    {
        topLeftCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        topRightCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        bottomLeftCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
        bottomRightCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
    }
}