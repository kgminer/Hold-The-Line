using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    [SerializeField]
    static bool fourPlayer = false;
    [SerializeField]
    private Camera topLeftCamera;
    [SerializeField]
    private Camera topRightCamera;
    [SerializeField]
    private Camera bottomLeftCamera;
    [SerializeField]
    private Camera bottomRightCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (fourPlayer == true)
        {
            topLeftCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            topRightCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            bottomLeftCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
            bottomRightCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        }

    }

    public static void SetFourPlayer(bool fourPlayerState)
    {
        if (fourPlayerState == true)
        {
            fourPlayer = true;
        }
    }
}