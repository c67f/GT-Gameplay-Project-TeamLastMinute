using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float interactionRange = 3f;  // Range within which objects can be interacted with
    public Camera playerCamera;  // Reference to the player's camera
    public LayerMask interactableLayer;  // Layer for interactable objects
    public TextMeshProUGUI interactionText;  // Reference to UI Text for displaying interaction prompt

    private Interactable currentInteractable;
    private Animator currentAnimator; // Animator for the interactable object

    void Start()
    {
        interactionText.gameObject.SetActive(false);  // Hide interaction text initially
    }

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            // Interact with the object, triggering its animation
            currentInteractable.Interact();

            // Trigger the animation only when the player presses E
            if (currentAnimator != null)
            {
                currentAnimator.SetBool("isSpinning", true); // Set the animation parameter
            }
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Store the current interactable object and show interaction text
                currentInteractable = interactable;
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press E to interact";  // Update interaction message if necessary

                // Get the Animator of the current interactable object
                currentAnimator = interactable.GetComponent<Animator>();
            }
        }
        else
        {
            // Clear the interactable object when nothing is in range and hide interaction text
            currentInteractable = null;
            interactionText.gameObject.SetActive(false);
            currentAnimator.SetBool("isSpinning", false); 
        }
    }
}
