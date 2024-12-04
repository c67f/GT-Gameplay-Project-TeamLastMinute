using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PointerController : MonoBehaviour
{
    public Transform pointA; // Reference to the starting point
    public Transform pointB; // Reference to the ending point
    public RectTransform safeZone; // Reference to the safe zone RectTransform
    public float moveSpeed = 100f; // Speed of the pointer movement

    private float direction = 1f; // 1 for moving towards B, -1 for moving towards A
    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    public Slider timerBar;
    public int maxKeyPresses = 3; // Maximum allowed key presses
    public int currentKeyPresses = 0;

    public int taskID = 0;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;

        //if (timerBar != null)
        //{
        //    timerBar.value = SliderManager.Instance.SliderValue;
        //    //timerBar.maxValue = SliderManager.Instance.SliderMaxValue; // Restore max value if needed
        //}
    }

    void Update()
    {
        // Move the pointer towards the target position
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Change direction if the pointer reaches one of the points
        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            direction = -1f;
        }

        // Check for input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
    }

    void CheckSuccess()
    {
        if (currentKeyPresses < maxKeyPresses)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
            {
                SliderManager.Instance.AddTime(5);
            }
            else
            {
                SliderManager.Instance.SubtractTime(3);
            }
            currentKeyPresses++;
        } else
        {
            SceneManager.LoadScene("Gameplay"); 
        }
    }


}