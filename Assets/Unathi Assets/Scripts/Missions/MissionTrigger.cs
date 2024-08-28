using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    public string missionName;         // Name of the mission
    public string missionDescription;  // Description of the mission

    private MissionManager missionManager;

    void Start()
    {
        // Find the MissionManager in the scene
        missionManager = FindObjectOfType<MissionManager>();

        if (missionManager != null)
        {
            // Create a new mission and add it to the MissionManager
            Mission newMission = new Mission(missionName, missionDescription);
            missionManager.AddMission(newMission);

            Debug.Log("Mission added: " + missionName);
        }
        else
        {
            Debug.LogWarning("MissionManager not found in the scene.");
        }
    }
}

