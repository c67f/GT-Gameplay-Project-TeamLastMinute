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

    void Start()
    {
        // Get the target object's renderer to control visibility
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
            targetRenderer.enabled = false;  // Start with the object hidden
        }
    }

    // Function to trigger interaction actions (e.g., rotating the object)
    public virtual void Interact()
    {
        // Display text or perform action
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
