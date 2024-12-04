using UnityEngine;

public class SliderManager : MonoBehaviour
{
    public static SliderManager Instance { get; private set; } // Singleton instance

    public float timer = 60f; // Timer duration
    public bool isPaused = false; // Optional pause state

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); // Prevent duplicates
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Persist across scenes
        }
    }

    void Start()
    {
        Debug.Log("SliderManager timer is initialized to: " + timer);
    }

    private void Update()
    {
        if (!isPaused && timer > 0)
        {
            timer -= Time.deltaTime; // Decrement the timer
            if (timer <= 0)
            {
                timer = 0;
                // You can call some global event here (e.g., game over or load a specific scene)
                Debug.Log("Time's up!");
            }
        }
    }

    public void AddTime(float timeToAdd)
    {
        timer += timeToAdd;
        Debug.Log($"Added {timeToAdd} seconds to the timer. New Timer: {timer}");
    }

    public void SubtractTime(float timeToSubtract)
    {
        timer -= timeToSubtract;
        if (timer < 0) timer = 0; // Prevent negative time
        Debug.Log($"Subtracted {timeToSubtract} seconds from the timer. New Timer: {timer}");
    }
}