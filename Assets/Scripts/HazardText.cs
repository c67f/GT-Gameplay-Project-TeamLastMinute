using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HazardText : MonoBehaviour
{
    public string hazard;
    public TMP_Text hazardTextComponent;

    private void Awake()
    {
        switch (GameManager.currTasks[0].num) //placeholder/incomplete: currently just looks at first task, not all 3
        {
            case 0:
                hazardTextComponent.text = "-Fog";
                break;

            case 1:
                hazardTextComponent.text = "-Stormy seas";
                break;

            case 2:
                hazardTextComponent.text = "-Task 3";
                break;

            case 3:
                hazardTextComponent.text = "-Task 4";
                break;

            case 4:
                hazardTextComponent.text = "-Task 5";
                break;

            case 5:
                hazardTextComponent.text = "-Task 6";
                break;

            case 6:
                hazardTextComponent.text = "-Task 7";
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    
}
