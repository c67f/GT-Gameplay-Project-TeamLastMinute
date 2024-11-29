using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycleWithDayCount : MonoBehaviour
{
    [Header("Cycle Settings")]
    [Tooltip("Duration of a full day in seconds.")]
    public float dayDuration = 120f; // 2 minutes for a full day
    private float currentTime = 0f;

    [Header("Day Settings")]
    [Tooltip("Maximum number of days.")]
    public int maxDays = 3;
    private int currentDay = 1;

    [Header("UI Settings")]
    [Tooltip("The TextMeshProUGUI component to display the current day.")]
    public TextMeshProUGUI dayText; // Drag your TextMeshPro UI element here

    private void Start()
    {
        UpdateDayText(); // Set initial day text
    }

    private void Update()
    {
        // Update time
        currentTime += Time.deltaTime;

        // Check if the day has completed
        if (currentTime >= dayDuration && currentDay < maxDays)
        {
            currentTime = 0f; // Reset time for the next day
            currentDay++;
            UpdateDayText();
        }
    }

    private void UpdateDayText()
    {
        if (dayText != null)
        {
            dayText.text = "Day " + currentDay;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI assigned for the day text.");
        }
    }
}

