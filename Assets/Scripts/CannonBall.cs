using UnityEngine;
using UnityEngine.SceneManagement;

public class Cannonball : MonoBehaviour
{
    public float lifetime = 40f;  // Lifetime before the cannonball disappears
    public string collectibleTag = "Player";  // Tag to detect collection by the player
    public static int collected = 0; // Shared variable to track all collected cannonballs

    private void Start()
    {
        // Automatically return to gameplay after lifetime expires
        Invoke(nameof(TransitionToGameplay), lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(collectibleTag))
        {
            CollectCannonball();

            // Add bonus time via SliderManager
            if (SliderManager.Instance != null)
            {
                SliderManager.Instance.AddTime(5);
            }
        }
    }

    void CollectCannonball()
    {
        Debug.Log("Cannonball collected!");

        // Increment global counter
        collected++;
        Destroy(gameObject); // Destroy this collected cannonball

        // Check if all cannonballs are collected
        if (collected >= 5) // Modify this number if spawning more than 5 cannonballs
        {
            TransitionToGameplay();
        }
    }

    void TransitionToGameplay()
    {
        Debug.Log("Returning to Gameplay scene...");
        SceneManager.LoadScene("Gameplay"); // Replace "Gameplay" with your scene name
    }
}