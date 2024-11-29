using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public GameObject anchorPrefab;  // Reference to the anchor prefab
    public Transform spawnPoint;    // Spawn point for the anchor
    public Vector3 anchorScale = new Vector3(2f, 2f, 2f);  // Desired size of the anchor
    public float moveSpeed = 5f;    // Speed for anchor movement before dropping
    public float rotationAngleY = 90f;  // Y-axis rotation to face the player
    public LayerMask rockLayer;     // Layer mask for rocks (used for collision detection)

    private GameObject currentAnchor;  // Reference to the spawned anchor instance
    private Rigidbody currentAnchorRb; // Rigidbody for the current anchor
    private bool isDropped = false;    // Flag to check if the anchor is dropped

    void Start()
    {
        SpawnAnchor();
    }

    void Update()
    {
        if (currentAnchor != null)
        {
            if (isDropped)
            {
                // Let the anchor drop, but ensure it's stationary otherwise
                currentAnchorRb.useGravity = true;
            }
            else
            {
                // Allow player to move the anchor until it's dropped
                if (Input.GetKey(KeyCode.Space))  // Drop anchor when Space is pressed
                {
                    DropAnchor();
                }
                else
                {
                    MoveAnchor();
                }
            }
        }
    }

    void SpawnAnchor()
    {
        if (spawnPoint != null && anchorPrefab != null)
        {
            // Instantiate the anchor at the spawn point
            currentAnchor = Instantiate(anchorPrefab, spawnPoint.position, spawnPoint.rotation);

            // Adjust the scale of the anchor
            currentAnchor.transform.localScale = anchorScale;
            currentAnchor.transform.rotation = Quaternion.Euler(0, rotationAngleY, 0);

            // Disable physics until the anchor is dropped
            currentAnchorRb = currentAnchor.GetComponent<Rigidbody>();
            currentAnchorRb.useGravity = false;
            //currentAnchorRb.isKinematic = true;  // Make the anchor stationary
        }
        else
        {
            Debug.LogWarning("Spawn Point or Anchor Prefab is not assigned!");
        }
    }

    void MoveAnchor()
    {
        if (currentAnchor == null) return;

        // Control anchor's movement using player input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical) * Time.deltaTime * moveSpeed;
        currentAnchor.transform.Translate(move);
    }

    void DropAnchor()
    {
        if (currentAnchorRb != null)
        {
            isDropped = true;
            currentAnchorRb.isKinematic = false; // Allow physics to affect the anchor
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered by: {other.gameObject.name}");
    }


}
