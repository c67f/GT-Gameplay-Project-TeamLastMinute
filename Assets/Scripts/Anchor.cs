using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Anchor : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the anchor moves horizontally
    public float dropSpeed = 2f;  // Speed at which the anchor "falls" (moves downward)
    public bool isDropped = false;  // Flag to check if the anchor is dropped
    public LayerMask rockLayer;  // Layer for collision detection
    private bool hasCollided = false; // Tracks whether the anchor collided with something
    public Slider timerBar;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;  // Store the initial position of the anchor
    }

    void Update()
    {
        if (isDropped)
        {
            DropAnchor();
        }
        else
        {
            MoveAnchor();
            if (Input.GetKeyDown(KeyCode.Space))  // Press Space to drop the anchor
            {
                Debug.Log("Dropping the anchor...");
                isDropped = true;  // Start dropping the anchor
            }
        }
    }

    void MoveAnchor()
    {
        // Allow player to move the anchor horizontally or vertically using WASD / arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(0, vertical, horizontal) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);  // Move the anchor in world space
    }

    void DropAnchor()
    {
        // Simulate the anchor "falling" downwards
        if (transform.position.y > 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - dropSpeed * Time.deltaTime, transform.position.z);
        }
        else
        {
            // Anchor reaches the ground
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            isDropped = false; // Anchor has stopped dropping

            // Check if no collision occurred
            if (!hasCollided)
            {
                Debug.Log("Anchor is fine (didn't hit anything)."); // No collisions detected
                SliderManager.Instance.AddTime(5);
                StartCoroutine(TransitionToGameplay());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        hasCollided = true; // Mark that the anchor has collided with something

        // Check what the anchor hits
        if (other.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("Anchor hit a rock");
            SliderManager.Instance.SubtractTime(3);
        }


        // Transition to Gameplay for either situation
        StartCoroutine(TransitionToGameplay());
    }

    private IEnumerator TransitionToGameplay()
    {
        Debug.Log("Transitioning to Gameplay...");
        yield return new WaitForSeconds(2f); // Add a small pause before transitioning
        SceneManager.LoadScene("Gameplay");
    }
}