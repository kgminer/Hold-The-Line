using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    public Object powerupBlock;
    [SerializeField]
    public Transform spawnLocation;
    private 
    void SpawnNewPowerup()
    {
        Instantiate(powerupBlock, spawnLocation);
    }

}
