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
        startGameButton.onClick.AddListener(goToMainScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void goToMainScene()
    {
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Single);
    }
}
