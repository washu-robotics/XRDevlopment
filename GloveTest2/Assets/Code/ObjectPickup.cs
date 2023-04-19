using UnityEngine;
using OVRTouchSample;

public class ObjectPickup : MonoBehaviour
{
    // The OVRGrabber script, which is used to detect when the user picks up an object
    private OVRGrabber grabbedObject;

    // A bool variable to keep track of whether the object is currently being held
    private bool isHeld = false;

    void Start()
    {
        // Get the OVRGrabber script from the game object
        grabbedObject = GetComponent<OVRGrabber>();
    }

    void Update()
    {
        // Check if the object is currently being grabbed
        if (grabbedObject != null)
        {
            // Set the isHeld variable to true
            isHeld = true;
        }
        else
        {
            // Set the isHeld variable to false
            isHeld = false;
        }
    }
}
