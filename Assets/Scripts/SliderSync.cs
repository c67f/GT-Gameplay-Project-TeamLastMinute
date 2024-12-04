using UnityEngine;
using UnityEngine.UI;

public class SliderSync : MonoBehaviour
{
    public Slider timerSlider; // Reference to the slider UI element

    private void Start()
    {
        // Sync the slider's range and initial value to `SliderManager.Instance.timer`
        if (SliderManager.Instance != null)
        {
            timerSlider.maxValue = 60f; // Match the timer max value
            timerSlider.value = SliderManager.Instance.timer; // Set current timer value
        }
    }

    private void Update()
    {
        // Update slider to reflect `SliderManager` value
        if (SliderManager.Instance != null)
        {
            timerSlider.value = SliderManager.Instance.timer;
        }
    }
}