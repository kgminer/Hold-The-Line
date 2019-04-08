using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameManager GameManager
    {
        get => default;
        set
        {
        }
    }

    public void SetCameraMode(bool value)
    {
        GameManager.topDownCameraMode = value;
    }

    public void SetVolume(float newValue)
    {
        GameManager.audioVolume = newValue;
    }
}
