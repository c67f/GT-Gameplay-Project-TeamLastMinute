using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public float interactBonusTime = 5.0f;

    public string[] taskDescriptions =
    {
        "Use the steering wheel",
        "Trim the sails",
        "Task2",
        "Task3",
        "Task4",
        "Task5",
        "Task6"
    };
    public class Task
    {
        public int num;
        public string taskText;
        public bool completed;
        public Task(int a, bool b)
        {
            num = a;
            taskText = _instance.taskDescriptions[a]; //needs the object because it's a public class?
            completed = b;
        }
    }


    //enum PossibleTasks
    //{
    //    Wheel,
    //    Sails,
    //    Task3,
    //    Task4,
    //    Task5,
    //    Task6,
    //    Task7,
    //}

    int[] PossibleTasksArray = { 0, 1, 2, 3, 4, 5, 6 };

    public int maxTasks;

    static public List<Task> currTasks = new List<Task>();
    static public int completedTasks = 0;
    public int tasksNumGoal;


    private void Awake()
    {
        //Debug.Log(taskDescriptions[0]);
        //Singleton code:
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else
        {
            _instance = this;
        }

        //Pick 3 random tasks:
        for (int i = 0; i < maxTasks; i++)
        {
            currTasks.Add(new Task(PossibleTasksArray[Random.Range(0, 7)], false));
            Debug.Log(currTasks[0].taskText);
        }
        //SceneManager.LoadSceneAsync("NewDayScreen", LoadSceneMode.Single);
        completedTasks = 0;
        Debug.Log("completedTasks reset to 0");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

     //Update is called once per frame
    void Update()
    {
        if (completedTasks >= tasksNumGoal)
        {
            goToTransitionScene();
        }
    }

    void goToTransitionScene()
    {
        SceneManager.LoadSceneAsync("NewDayScreen", LoadSceneMode.Single);
    }
}
