using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f; // Range within which the player can interact
    public LayerMask dialogueLayer; // Layer to detect objects with DialogueTrigger
    public GameObject interactionButton; // UI button to display

    private DialogueTrigger nearestDialogueTrigger;
    private MissionManager missionManager;

    void Start()
    {
        // Find the MissionManager in the scene
        missionManager = FindObjectOfType<MissionManager>();
        if (missionManager == null)
        {
            Debug.LogWarning("MissionManager not found in the scene.");
        }
    }

    void Update()
    {
        CheckForDialogueTriggers();
    }

    void CheckForDialogueTriggers()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange, dialogueLayer);
        float closestDistance = Mathf.Infinity;
        nearestDialogueTrigger = null;

        foreach (Collider collider in hitColliders)
        {
            DialogueTrigger trigger = collider.GetComponent<DialogueTrigger>();
            MissionTrigger missionTrigger = collider.GetComponent<MissionTrigger>();

            if (trigger != null)
            {
                // Debug information
                Debug.Log("Found DialogueTrigger on: " + collider.name);

                // Check if the object has a MissionTrigger component and if the mission is complete
                if (missionTrigger != null)
                {
                    bool missionCompleted = missionManager.GetCurrentMissionNames().Contains(missionTrigger.missionName);
                    Debug.Log("Mission name: " + missionTrigger.missionName + " completed: " + missionCompleted);

                    if (!missionCompleted)
                    {
                        continue; // Skip this object if the mission is completed
                    }
                }

                float distance = Vector3.Distance(transform.position, trigger.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestDialogueTrigger = trigger;
                }
            }
        }

        // Activate or deactivate the interaction button based on whether a DialogueTrigger is nearby
        bool buttonShouldBeActive = nearestDialogueTrigger != null;
        interactionButton.SetActive(buttonShouldBeActive);
        Debug.Log("Interaction button active: " + buttonShouldBeActive);
    }

    public void HandleInput()
    {
        if (nearestDialogueTrigger != null) // "Interact" can be mapped to a key like "E"
        {
            nearestDialogueTrigger.TriggerDialogue();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
