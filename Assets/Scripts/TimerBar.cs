using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TimerBar : MonoBehaviour
{
    public Slider timerSlider; // Reference to the UI Slider
    public float maxTime = 60f; // Maximum timer value

    void Start()
    {
        // Initialize the slider to align with the current timer value in SliderManager
        if (SliderManager.Instance != null)
        {
            timerSlider.maxValue = maxTime; // Set the slider's range
            timerSlider.value = SliderManager.Instance.timer; // Sync slider to current timer
        }
    }

    void Update()
    {
        // Make sure the timer only updates if time remains
        if (SliderManager.Instance != null && SliderManager.Instance.timer > 0)
        {
            SliderManager.Instance.timer -= Time.deltaTime; // Decrement timer
            timerSlider.value = SliderManager.Instance.timer; // Reflect the updated value on the slider
        } else
        {
            return; 
        }

        // Handle timer expiration
        if (SliderManager.Instance != null && SliderManager.Instance.timer <= 0)
        {
            SliderManager.Instance.timer = 0; // Ensure timer doesn’t go negative
            Debug.Log("Time's up!");
            SceneManager.LoadScene("EndScene"); 
            // Add any additional "time up" logic here (e.g., game over or scene transition)
        }
    }
}