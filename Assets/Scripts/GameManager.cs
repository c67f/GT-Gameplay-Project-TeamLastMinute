using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    public float interactBonusTime = 5.0f;

    public string[] taskDescriptions = {
        "Use the steering wheel",
        "Trim the sails",
        "Deploy the anchor",
        "Secure the cannonballs",
        "Clear the rigging area",
        "Adjust the rigging",
        "Check the compass"
    };

    public class Task
    {
        public int num; // Task ID
        public string taskText; // Description
        public bool completed; // Whether the task is completed

        public Task(int a, bool b)
        {
            num = a;
            taskText = GameManager.Instance.taskDescriptions[a];
            completed = b;
        }
    }

    int[] PossibleTasksArray = { 0, 1, 2, 3, 4, 5, 6 }; // Possible task IDs
    public int maxTasks = 3; // Number of tasks to assign
    public static List<Task> currTasks = new List<Task>(); // Active tasks
    public static int completedTasks = 0; // Completed tasks counter
    public int tasksNumGoal = 3; // Goal: number of tasks to complete

    private void Awake()
    {
        // Singleton setup
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // Keep GameManager persistent

        if (currTasks.Count == 0)
        {
            InitializeTasks();
        }
        else
        {
            Debug.Log("Tasks already initialized. Skipping reinitialization.");
        }
    }

    private void InitializeTasks()
    {
        currTasks.Clear(); // Clear previous tasks
        completedTasks = 0; // Reset completion counter
        Debug.Log("Initializing GameManager tasks...");

        for (int i = 0; i < maxTasks; i++)
        {
            int randomTaskIndex = Random.Range(0, PossibleTasksArray.Length);
            currTasks.Add(new Task(randomTaskIndex, false)); // Add task to list
            Debug.Log($"Task {currTasks[i].num}: {currTasks[i].taskText} (Completed: {currTasks[i].completed})");
        }

        Debug.Log($"GameManager: Initialized {currTasks.Count} tasks.");
    }

    private void Update()
    {
        if (completedTasks >= tasksNumGoal)
        {
            Debug.Log("All tasks completed. Transitioning...");
            //GoToTransitionScene();
        }
    }

    public void CompleteTask(int taskId)
    {
        foreach (Task task in currTasks)
        {
            if (task.num == taskId && !task.completed)
            {
                task.completed = true; // Mark task as completed
                completedTasks++; // Increment completed counter
                Debug.Log($"Task Completed: {task.taskText} (ID: {task.num})");

                return;
            }
        }

        Debug.LogWarning($"Task with ID {taskId} not found or already completed.");
    }

    private void GoToTransitionScene()
    {
        SceneManager.LoadSceneAsync("NewDayScreen", LoadSceneMode.Single);
    }
}