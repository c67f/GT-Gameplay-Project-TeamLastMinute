using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public string interactMessage = "Press E to Interact";  // Text to display on interaction

    // Function to trigger interaction actions (e.g., rotating the object)
    public virtual void Interact()
    {
        // Display text or perform action
        Debug.Log(interactMessage);
    }
}
