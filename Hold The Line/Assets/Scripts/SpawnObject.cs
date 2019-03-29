using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    public Object powerupBlock;
    [SerializeField]
    public Vector3 spawnLocation = Vector3.zero;
    private float spawnRange = 2;
    [SerializeField]
    private float spawnTime = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnNewPowerup", spawnTime, spawnTime);
    }

    // Spawns a new powerup in a random location within the center of the map
    void SpawnNewPowerup()
    {
        spawnLocation.x = Random.Range(-spawnRange, spawnRange);
        spawnLocation.y = 0.64f;
        spawnLocation.z = Random.Range(-spawnRange, spawnRange);
        Instantiate(powerupBlock, spawnLocation, Quaternion.identity);
    }

}

