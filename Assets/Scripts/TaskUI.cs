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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Debug.Log("task checklist awake");
        task0.text = GameManager.currTasks[0].taskText;
        task1.text = GameManager.currTasks[1].taskText;
        task2.text = GameManager.currTasks[2].taskText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
