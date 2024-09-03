using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> waypoints = new List<GameObject>();
    public GameObject currentWaypoint;

    [SerializeField] MissionManager mission;

    void Start()
    {
        // Find all objects with the MissionTrigger script
        MissionTrigger[] missionTriggers = FindObjectsOfType<MissionTrigger>();

        foreach (MissionTrigger missionTrigger in missionTriggers)
        {
            waypoints.Add(missionTrigger.gameObject);
        }

        // Set the first mission in the collection as the default waypoint
        if (waypoints.Count > 0)
        {
            currentWaypoint = waypoints[0];
        }
    }

    void Update()
    {
        if (currentWaypoint != null)
        {
            // Get the MissionTrigger attached to the current waypoint
            MissionTrigger missionTrigger = currentWaypoint.GetComponent<MissionTrigger>();

            if (missionTrigger != null)
            {
                // Check if the current mission is completed
                Mission currentMission = mission.currentMissions.Find(m => m.missionName == missionTrigger.missionName);

                if (currentMission == null || currentMission.isCompleted)
                {
                    // Remove the completed mission's waypoint
                    RemoveCompletedMissionWaypoints();

                    // Set the waypoint to the first active mission
                    SetWaypointToFirstActiveMission();
                }
            }
        }
    }

    // Method to remove waypoints of completed missions
    private void RemoveCompletedMissionWaypoints()
    {
        // Create a temporary list to store completed waypoints
        List<GameObject> completedWaypoints = new List<GameObject>();

        foreach (GameObject waypoint in waypoints)
        {
            MissionTrigger missionTrigger = waypoint.GetComponent<MissionTrigger>();
            if (missionTrigger != null)
            {
                Mission missionToCheck = mission.currentMissions.Find(m => m.missionName == missionTrigger.missionName);
                if (missionToCheck != null && missionToCheck.isCompleted)
                {
                    completedWaypoints.Add(waypoint);
                }
            }
        }

        // Remove completed waypoints from the waypoints list
        foreach (GameObject completedWaypoint in completedWaypoints)
        {
            waypoints.Remove(completedWaypoint);
        }
    }

    // Method to set a specific waypoint
    public void SetWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Count)
        {
            currentWaypoint = waypoints[index];
            Debug.Log("Waypoint set to: " + currentWaypoint.name);
        }
        else
        {
            Debug.LogWarning("Invalid mission index");
        }
    }

    // Method to set the waypoint to the first active mission
    private void SetWaypointToFirstActiveMission()
    {
        List<Mission> activeMissions = mission.GetActiveMissions();

        if (activeMissions.Count > 0)
        {
            Mission firstMission = activeMissions[0];
            GameObject firstMissionObject = waypoints.Find(wp => wp.GetComponent<MissionTrigger>().missionName == firstMission.missionName);

            if (firstMissionObject != null)
            {
                SetWaypoint(waypoints.IndexOf(firstMissionObject));
            }
            else
            {
                Debug.LogWarning("First active mission's GameObject not found in waypoints");
            }
        }
        else
        {
            Debug.Log("No active missions available");
        }
    }

    // Method to get the current waypoint
    public GameObject GetCurrentWaypoint()
    {
        return currentWaypoint;
    }
}

