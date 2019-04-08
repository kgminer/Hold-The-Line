using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameManager GameManager
    {
        get => default;
        set
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boulder")
        {
            this.gameObject.SetActive(false);
            GameManager.activePlayers--;
        }
    }
}
