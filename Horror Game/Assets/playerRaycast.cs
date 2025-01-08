using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject crosshair; // UI crosshair for aiming
    public float interactionDistance = 5f; // Max distance for interaction
    public LayerMask layers; // Layers to consider for raycasting

    private DoorController raycastedObj; // Reference to the DoorController

    void Start()
    {
        crosshair.SetActive(true); // Ensure crosshair is visible at all times
    }

    void Update()
    {
        // Perform the raycast and check for an object
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, interactionDistance, layers))
        {
            // Check if the object hit has a DoorController
            DoorController door = hit.collider.GetComponent<DoorController>();

            if (door != null)
            {
                raycastedObj = door;

                // Detect interaction input (e.g., pressing E)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    raycastedObj.ToggleDoor();
                }
            }
        }
        else
        {
            // Reset raycastedObj when not aiming at an interactive object
            raycastedObj = null;
        }
    }
}
