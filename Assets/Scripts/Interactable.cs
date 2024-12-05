using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public string interactMessage = "Press E to Interact";  // Text to display on interaction
    public string animationParameter = "";
    public GameObject targetObject;  // The object to be shown or interacted with
    public string targetScene;
    public int taskID;
    private Renderer targetRenderer;

    public AudioClip interactionSound;    // The sound effect to play
    private AudioSource audioSource;

    void Start()
    {
        // Get the target object's renderer to control visibility
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
            targetRenderer.enabled = false;  // Start with the object hidden
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the interaction sound to the AudioSource
        if (interactionSound != null)
        {
            audioSource.clip = interactionSound;
        }
    }

    public virtual void Interact()
    {
        if (audioSource != null && interactionSound != null)
        {
            audioSource.Play();
            Debug.Log("Interaction sound played!");
        }
        Debug.Log(interactMessage);
    }

    public void MakeObjectVisible()
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = true;  // Make the target object visible
            targetObject.gameObject.SetActive(true);
            Debug.Log("Target object is now visible!");
        }
    }
}
