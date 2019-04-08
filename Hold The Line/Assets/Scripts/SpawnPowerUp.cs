using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField]
    public Object powerupBlock;                     // set to Power Up Block Prefab in the Unity Editor
    private Vector3 spawnLocation = Vector3.zero;
    [SerializeField]
    private Transform powerupBlockTransform;        // set to Power Up Block Transform Prefab in the Unity Editor
    private float spawnRange = 4;
    [SerializeField]
    private float spawnTime = 15f;

    public PowerupHandler PowerupHandler
    {
        get => default;
        set
        {
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnNewPowerup", spawnTime, spawnTime);
    }

    // Spawns a new powerup in a random location within the center of the map
    private void SpawnNewPowerup()
    {
        spawnLocation.x = Random.Range(-spawnRange, spawnRange);
        spawnLocation.y = (powerupBlockTransform.localScale.y / 2);
        spawnLocation.z = Random.Range(-spawnRange, spawnRange);
        Instantiate(powerupBlock, spawnLocation, Quaternion.identity);
    }

}

