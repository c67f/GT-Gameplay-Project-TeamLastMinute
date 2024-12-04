using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    public TMP_Text task0;
    public TMP_Text task1;
    public TMP_Text task2;
    public Toggle[] togglesArray = new Toggle[GameManager.maxTasks];

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (GameManager.currTasks.Count >= 3)
        {
            task0.text = GameManager.currTasks[0].taskText;
            task1.text = GameManager.currTasks[1].taskText;
            task2.text = GameManager.currTasks[2].taskText;
        }
        if (GameManager.completedTasks > 0)
        {

            for (int i = 0; i < GameManager.maxTasks; i++)
            {
                //Mark checkboxes if completed
                togglesArray[i].isOn = GameManager.currTasks[i].completed;
                Debug.Log(togglesArray[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}