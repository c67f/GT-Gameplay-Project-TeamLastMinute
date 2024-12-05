using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(goToStartingCutscene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void goToStartingCutscene()
    {
        SceneManager.LoadSceneAsync("Opening Cutscene", LoadSceneMode.Single);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
