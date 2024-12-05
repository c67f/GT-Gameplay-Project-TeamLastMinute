using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameplayFromCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCutsceneEnd());
    }

    IEnumerator WaitForCutsceneEnd()
    {
        yield return new WaitForSecondsRealtime(7.55f);
        goToMainScene();

    }
    void goToMainScene()
    {
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Single);
    }
}
