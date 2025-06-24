using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission_Amadumbe : MonoBehaviour
{

    // Added variables for collecting amadumbe
    private int amadumbeCollected = 0; // Track the number of amadumbe collected
    public Text amadumbeCountText; // Reference to UI text for displaying count
    public bool missionActive = false; // Track if the mission is active
    public bool missionComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAmadumbeUI(); // Initialize UI on start
        amadumbeCountText.gameObject.SetActive(false); // Hide the UI initially
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text for amadumbe count if the mission is active
        UpdateAmadumbeUI();
    }


    // Method to collect amadumbe
    public void CollectAmadumbe()
    {
       if (!missionActive || missionComplete) return; // Prevent collection if mission hasn't started or is done

    amadumbeCollected++;
    UpdateAmadumbeUI(); // Update UI after collecting
    CheckMissionCompletion(); // Check if the mission is completed

    }

    // Start the mission
    public void StartMission()
    {
        missionActive = true;
        amadumbeCountText.gameObject.SetActive(true); // Show the UI when the mission starts
        amadumbeCollected = 0; // Reset the count
        UpdateAmadumbeUI(); // Update the UI at the start of the mission
    }

    // Complete the mission
    public void CompleteMission()
    {
        missionActive = false;
        missionComplete=true;
        amadumbeCountText.gameObject.SetActive(false); // Hide the UI when the mission is complete
        Debug.Log("Mission Complete! You collected " + amadumbeCollected + " amadumbe.");
    }

    // Update UI Text to display collected amadumbe
    void UpdateAmadumbeUI()
    {
        if (missionActive && amadumbeCountText != null)
        {
            amadumbeCountText.text = "Amadumbe Collected: " + amadumbeCollected + "/5";
        }
        else if (!missionActive && amadumbeCountText != null)
        {
            amadumbeCountText.gameObject.SetActive(false); // Hide the UI if the mission is not active
        }
    }

    // Check if the mission is completed
    void CheckMissionCompletion()
    {
        if (amadumbeCollected >= 5)
        {
            CompleteMission(); // Complete the mission if the player has collected enough amadumbe
        }
    }

}
