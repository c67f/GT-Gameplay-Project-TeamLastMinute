using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public float interactionRange = 3f; // How far the player can interact with objects
    public Camera playerCamera; // Camera used for raycasting
    public LayerMask interactableLayer; // Layer for interactable objects
    public TextMeshProUGUI interactionText; // UI text to display interaction prompts
    public Slider timerBar; // Reference to the timer slider, if applicable

    private Interactable currentInteractable; // Current interactable object
    private Animator currentAnimator; // Animator of the interactable object
    private bool isInteracting = false; // Prevents multiple interactions simultaneously

    void Start()
    {
        // Hide interaction text at the beginning
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Skip further checks if the player is already interacting
        if (isInteracting) return;

        // Check if there’s an interactable object in range
        CheckForInteractable();

        // Handle player input for interaction
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            Debug.Log($"Interacting with: {currentInteractable.name}");

            isInteracting = true; // Temporarily block new interactions
            currentInteractable.Interact();

            // Handle animation or directly transition depending on object setup
            if (currentAnimator != null && !string.IsNullOrEmpty(currentInteractable.animationParameter))
            {
                Debug.Log("Playing animation...");
                currentAnimator.SetBool(currentInteractable.animationParameter, true);

                // Wait for the animation and then transition
                StartCoroutine(WaitForAnimationAndTransition());
            }
            else
            {
                Debug.Log("No animation attached, skipping directly to scene transition...");

                // Start the coroutine without waiting for animation
                StartCoroutine(SceneTransitionOnly());
            }
        }
    }

    void CheckForInteractable()
    {
        // Cast a ray from the player's camera to detect interactable objects
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                interactionText.gameObject.SetActive(true); // Show interaction prompt
                interactionText.text = "Press E to interact"; // Update prompt text
                currentAnimator = interactable.GetComponent<Animator>(); // Get Animator, if available
            }
        }
        else
        {
            // No interactable object found, hide UI and reset references
            interactionText.gameObject.SetActive(false);
            if (currentAnimator != null && currentInteractable != null && !string.IsNullOrEmpty(currentInteractable.animationParameter))
            {
                currentAnimator.SetBool(currentInteractable.animationParameter, false);
            }
            currentInteractable = null;
            currentAnimator = null;
        }
    }

    private IEnumerator WaitForAnimationAndTransition()
    {
        Debug.Log("Starting WaitForAnimationAndTransition coroutine...");

        if (currentAnimator != null)
        {
            Debug.Log("Waiting for animation to finish...");
            // Wait for the animation to complete
            while (currentAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f || currentAnimator.IsInTransition(0))
            {
                yield return null; // Wait until animation is done
            }
        }

        // Save timer data (if needed)
        if (timerBar != null)
        {
            PlayerPrefs.SetFloat("TimerValue", SliderManager.Instance.timer);
            PlayerPrefs.Save(); // Save the timer value for persistence
        }

        // Transition to the target scene
        if (currentInteractable != null && !string.IsNullOrEmpty(currentInteractable.targetScene))
        {
            if (currentInteractable.taskID == GameManager.currTasks[0].num || currentInteractable.taskID == GameManager.currTasks[1].num || currentInteractable.taskID == GameManager.currTasks[2].num)
            {
                Debug.Log("Transitioning to scene: " + currentInteractable.targetScene);
                SceneManager.LoadScene(currentInteractable.targetScene);
            }
            else
            {
                Debug.Log("Object is not one of the current tasks");
            }    
        }
        else
        {
            Debug.LogWarning("Scene transition failed! Target scene is null or empty.");
        }

        isInteracting = false; // Allow future interactions
    }

    private IEnumerator SceneTransitionOnly()
    {
        Debug.Log("Starting direct scene transition...");

        // Save timer data (if applicable)
        if (timerBar != null)
        {
            PlayerPrefs.SetFloat("TimerValue", SliderManager.Instance.timer);
            PlayerPrefs.Save(); // Save the timer value
        }

        // Handle the scene transition directly
        if (currentInteractable != null && !string.IsNullOrEmpty(currentInteractable.targetScene))
        {
            Debug.Log("Transitioning to scene: " + currentInteractable.targetScene);
            SceneManager.LoadScene(currentInteractable.targetScene);
        }
        else
        {
            Debug.LogWarning("No target scene specified! Check the Interactable's setup.");
        }

        isInteracting = false; // Reset the interaction flag
        yield return null;
    }
}