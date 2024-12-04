//using UnityEngine;
//using UnityEngine.UI;

//public class SliderInitializer : MonoBehaviour
//{
//    public Slider slider; // Reference to the Slider component

//    void Start()
//    {
//        if (slider != null && SliderManager.Instance != null)
//        {
//            // Set the slider's value from the SliderManager
//            slider.value = SliderManager.Instance.SliderValue;
//        }
//        else
//        {
//            Debug.LogError("Slider component not assigned or SliderManager not found.");
//        }
//    }
//    void OnSliderValueChanged(float value)
//    {
//        // Save the new value using SliderManager
//        SliderManager.Instance.SaveSliderValue(value);
//    }
//}
