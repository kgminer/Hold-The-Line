using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void SetCameraMode(bool value)
    {
        GameManager.topDownCameraMode = value;
    }

    public void SetVolume(float newValue)
    {
        GameManager.audioVolume = newValue;
    }
}
