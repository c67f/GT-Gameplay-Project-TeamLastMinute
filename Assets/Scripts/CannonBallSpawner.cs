using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawner : MonoBehaviour
{
    public GameObject cannonballPrefab;  // Cannonball prefab
    public Transform player;  // Reference to the player’s position
    public int cannonballCount = 5;  // Number of cannonballs to spawn
    public float spawnRange = 5f;  // Range for spawning the cannonballs around the player
    public float spawnHeight = -1f;  // Height above the ground to spawn the cannonballs

    void Start()
    {
        SpawnCannonballs();
    }

    void SpawnCannonballs()
    {
        for (int i = 0; i < cannonballCount; i++)
        {
            // Randomly determine the spawn position near the player
            Vector3 spawnPosition = player.position + new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight, Random.Range(-spawnRange, spawnRange));

            // Instantiate the cannonball at the spawn position
            Instantiate(cannonballPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
