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

    enum PossibleTasks
    {
        Wheel,
        Sails,
        Task3,
        Task4,
        Task5,
        Task6,
        Task7,
    }

    int[] PossibleTasksArray = { 0, 1, 2, 3, 4, 5, 6 };

    static public List<int> currTasks = new List<int>();

    public int maxTasks;

    private void Awake()
    {
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
            currTasks.Add(PossibleTasksArray[Random.Range(0, 7)]);
        }
        //SceneManager.LoadSceneAsync("NewDayScreen", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
