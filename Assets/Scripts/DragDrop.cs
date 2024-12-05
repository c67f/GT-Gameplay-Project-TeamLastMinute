using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
{
    public static int cannon_collected = 0;            // Global counter for collected cannonballs
    public static int total_cannonballs = 4;          // Total cannonballs required to win

    private void Start()
    {
        // Ensure the cursor remains visible and unlocked during the mini-game
        ResetMiniGame(); 
        Cursor.lockState = CursorLockMode.None;       // Unlock the cursor
        Cursor.visible = true;                       // Make the cursor visible
    }

    private void OnMouseDown()
    {
        Debug.Log($"Cannonball collected! Current count: {cannon_collected + 1}");

        // Increment the global collection counter
        cannon_collected++;

        // Destroy this cannonball to indicate it was collected
        Destroy(gameObject);

        // Check if all cannonballs are collected
        if (cannon_collected >= total_cannonballs)
        {
            Debug.Log("All cannonballs collected! Transitioning to Gameplay...");
            TransitionToGameplay(); // Transition to the next scene
        }
    }

    private void TransitionToGameplay()
    {
        Debug.Log("Transitioning to Gameplay...");
        ResetMiniGame();
        SceneManager.LoadScene("Gameplay"); // Replace with the correct scene name
        
    }
    public static void ResetMiniGame()
    {
        // Reset all static variables for this mini-game
        cannon_collected = 0;
        Debug.Log("Cannonball mini-game has been reset.");
    }
}