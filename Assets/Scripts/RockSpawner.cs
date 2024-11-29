using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;  // The rock prefab to spawn
    public int numberOfRocks = 5;  // Number of rocks to spawn
    public float spawnRadius = 10f;  // Radius around the spawner to place rocks
    public float yOffset = 1f;  // Height for the rocks (to adjust if needed)

    void Start()
    {
        SpawnRocks();
    }

    void SpawnRocks()
    {
        for (int i = 0; i < numberOfRocks; i++)
        {
            // Random position within the spawn radius
            Vector3 spawnPosition = new Vector3(
                transform.position.x + Random.Range(-spawnRadius, spawnRadius),
                transform.position.y + yOffset,
                transform.position.z + Random.Range(-spawnRadius, spawnRadius)
            );

            // Instantiate the rock at the random position
            GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);

            // Set a random scale for each rock (adjust the range as desired)
            float randomScale = Random.Range(3f, 5f);  // Random scale between 1.5 and 3
            rock.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }

}
