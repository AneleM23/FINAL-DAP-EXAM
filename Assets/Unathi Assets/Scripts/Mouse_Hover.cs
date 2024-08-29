using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Hover : MonoBehaviour
{
    public Text objectNameText; // UI Text element to display the object's name
    public LayerMask interactableLayer; // LayerMask to define which objects are interactable
    public float hoverDistance = 10f; // Max distance for detecting objects

    MissionManager missionManager;

    void Start()
    {
        missionManager= GameObject.Find("MissionsManager").GetComponent<MissionManager> ();
    }

    private void Update()
    {
        DetectObject();
    }

    void DetectObject()
    {
        // Cast a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits an object on the interactable layer within the hoverDistance
        if (Physics.Raycast(ray, out hit, hoverDistance, interactableLayer))
        {
            // Get the name of the object
            string objectName = hit.collider.gameObject.name;

            // Display the object's name in the UI
            objectNameText.text = objectName;

            // If right-click is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // Empty space for additional functionality
                Debug.Log("Right-clicked on: " + objectName);
                // You can add your custom code here to interact with the object
                missionManager.CompleteMission(hit.collider.gameObject.GetComponent<MissionInformation>().missionName);
            }
        }
        else
        {
            // Clear the text if no object is detected
            objectNameText.text = "";
        }
    }
}
