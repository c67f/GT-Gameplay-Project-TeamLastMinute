using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the anchor moves horizontally
    public float dropSpeed = 2f;  // Speed at which the anchor "falls" (moves downward)
    public bool isDropped = false;  // Flag to check if the anchor is dropped
    public LayerMask rockLayer;  // The layer mask for rocks (used for collision detection)

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;  // Store the initial position of the anchor
    }

    void Update()
    {
        if (isDropped)
        {
            // Let the anchor fall by adjusting its Y position
            DropAnchor();
        }
        else
        {
            // Allow horizontal movement (left and right) with input
            MoveAnchor();

            if (Input.GetKeyDown(KeyCode.Space))  // Press Space to drop the anchor
            {
                isDropped = true;
            }
        }
    }

    void MoveAnchor()
    {
        // Allow horizontal movement (left and right) with input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the anchor along the x and z axes (left-right and forward-backward)
        Vector3 move = new Vector3(0, vertical, horizontal) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);  // Translate the position without physics
    }

    void DropAnchor()
    {
        // Adjust the Y position to simulate the anchor dropping
        if (transform.position.y > 0f)  // Ensure it doesn't drop below ground (0 or another value)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - dropSpeed * Time.deltaTime, transform.position.z);
        }
        else
        {
            // Optionally, stop the drop once it reaches the ground
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);  // Stop at y=0 (ground level)
            isDropped = false;  // Stop dropping once it reaches the ground
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("Anchor hit a rock");
        }
    }

}
