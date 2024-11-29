using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerInteract : MonoBehaviour
{
    public float interactionRange = 3f;  // Range within which objects can be interacted with
    public Camera playerCamera;  // Reference to the player's camera
    public LayerMask interactableLayer;  // Layer for interactable objects
    public TextMeshProUGUI interactionText;  // Reference to UI Text for displaying interaction prompt


    public Slider timerBar;

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
            {
                currentInteractable.Interact();

                if (currentAnimator != null && !string.IsNullOrEmpty(currentInteractable.animationParameter))
                {
                    currentAnimator.SetBool(currentInteractable.animationParameter, true);
                    currentInteractable.MakeObjectVisible();
                    // Example: Add bonus time and update tasks
                    //Debug.Log(timerBar.value);
                    //timerBar.value += GameManager.Instance.interactBonusTime;
                    //GameManager.completedTasks += 3;
                    //Debug.Log(timerBar.value);
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
                interactionText.gameObject.SetActive(false);

                // Only reset the animator if it is not null and animationParameter is valid
                if (currentAnimator != null && currentInteractable != null && !string.IsNullOrEmpty(currentInteractable.animationParameter))
                {
                    currentAnimator.SetBool(currentInteractable.animationParameter, false);
                }

                currentInteractable = null;
                currentAnimator = null; // Reset currentAnimator since there's no interactable in range
            }
        }

    }
} 