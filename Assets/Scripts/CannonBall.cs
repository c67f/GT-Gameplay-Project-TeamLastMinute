using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float lifetime = 40f;  // Lifetime before the cannonball disappears
    public string collectibleTag = "Player";  // Tag to detect collection by the player

    private void Start()
    {
        Destroy(gameObject, lifetime);  // Destroy the cannonball after the specified lifetime
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collects the cannonball
        if (other.CompareTag(collectibleTag))
        {
            CollectCannonball();
        }
    }

    void CollectCannonball()
    {
        // Implement logic for what happens when the player collects the cannonball
        Debug.Log("Cannonball collected!");
        Destroy(gameObject);  // Destroy the cannonball when collected
    }
}
