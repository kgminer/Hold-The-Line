using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField]
    GameObject startTimerObject;
    float timeLeft = 5f;
    string seconds = null;
    private GUIStyle guiStyle = new GUIStyle();
    

    // Start is called before the first frame update

    void OnGUI()
    {
        Time.timeScale = 0;
        timeLeft -= Time.unscaledDeltaTime/2;
        string seconds = Mathf.Floor(timeLeft).ToString("0");

        int windowWidth = 400;
        int windowHeight = 400;
        int windowXLocation = ((Screen.width - windowWidth)/ 2);
        int windowYLocation = ((Screen.height - windowHeight)/ 2);

        guiStyle.fontSize = 100;
        guiStyle.normal.textColor = Color.blue;
        guiStyle.alignment = TextAnchor.MiddleCenter;

        if (timeLeft > 0)
        {
            GUI.Label(new Rect(windowXLocation, windowYLocation, windowWidth, windowHeight), seconds, guiStyle);
        }

        if (timeLeft <= 0)
        {
            print("timer expired");
            Time.timeScale = 1f;
            GUI.Label(new Rect(windowXLocation, windowYLocation, windowWidth, windowHeight), "GO!", guiStyle);
            Destroy(startTimerObject, 1f);
        }
    }
}
