using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> waypoints = new List<GameObject>();
    public GameObject currentWaypoint;

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



    // Method to set a specific waypoint
    public void SetWaypoint(GameObject waypoint)
    {
        if (waypoints.Contains(waypoint))
        {
            currentWaypoint = waypoint;
        }
    }

    // Method to get the current waypoint
    public GameObject GetCurrentWaypoint()
    {
        return currentWaypoint;
    }
}
