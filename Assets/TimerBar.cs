using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timerBar;
    public float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        timerBar.maxValue = startHealth;
        timerBar.minValue = 0;
        timerBar.value = timerBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        timerBar.value = timerBar.value - Time.deltaTime;
        if (timerBar.value <= 0)
        {
            Debug.Log("Game over!");
            GameOverSceneLoad();
        }
    }

    void GameOverSceneLoad()
    {
        SceneManager.LoadSceneAsync("Game Over", LoadSceneMode.Single);
    }
}
