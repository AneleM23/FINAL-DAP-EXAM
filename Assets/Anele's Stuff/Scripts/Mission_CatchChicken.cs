using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_CatchChicken : MonoBehaviour
{
    public GameObject chicken; // The chicken GameObject to catch
    public Transform chickenSpawnPoint; // Location to spawn the chicken
    public Transform elderPosition; // Position of the elder NPC

    private bool missionStarted = false;
    private bool chickenCaught = false;

    private void Start()
    {
        chicken.SetActive(false); // Hide chicken until mission starts
    }

    public void StartCatchChickenMission()
    {
        missionStarted = true;
        chicken.transform.position = chickenSpawnPoint.position;
        chicken.SetActive(true); // Show chicken when mission starts
    }

    private void Update()
    {
        if (missionStarted && !chickenCaught)
        {
            // Check if player is close enough to the chicken to catch it
            float distanceToChicken = Vector3.Distance(transform.position, chicken.transform.position);
            if (distanceToChicken < 2f) // Adjust the distance as needed
            {
                CatchChicken();
            }
        }
    }

    private void CatchChicken()
    {
        chickenCaught = true;
        chicken.SetActive(false); // Hide the chicken after catching
        Debug.Log("Chicken caught! Return to the elder.");
    }

    public void CompleteMission()
    {
        if (chickenCaught && missionStarted)
        {
            Debug.Log("Mission complete: Chicken returned to the elder.");
            // Trigger any rewards or mission completion effects here
            missionStarted = false; // Reset the mission state
            chickenCaught = false; // Reset for potential future missions
        }
    }

}
