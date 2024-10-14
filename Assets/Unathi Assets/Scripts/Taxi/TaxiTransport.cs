using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiTransport : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints where the taxi can go
    public Transform player; // Reference to the player
    public Transform taxi;

    public Transform circle;

    public float moveSpeed = 5f; // Speed at which the taxi moves
    public float stopDistance = 1f; // Distance to stop from the waypoint

    private Transform targetWaypoint; // The current target waypoint

    void Start()
    {
        // Set taxi to a random starting waypoint
        SetRandomWaypoint();
    }

    void Update()
    {
        
    }

    void SetRandomWaypoint()
    {
        int randomIndex = Random.Range(0, waypoints.Length);
        targetWaypoint = waypoints[randomIndex];
        taxi.transform.position = targetWaypoint.position;
    }

    public IEnumerator TransportPlayer(Transform destination)
    {
        // Set the target waypoint to the selected destination
        targetWaypoint = destination;

        // Move the taxi to the target waypoint
        taxi.transform.position = targetWaypoint.position;

        yield return new WaitForSeconds(0.2f);

        player.transform.position = circle.position;
    }

    public void SetNearestWaypoint()
    {
        // Find the nearest waypoint to the player's position
        float closestDistance = Mathf.Infinity;
        Transform nearestWaypoint = null;

        foreach (Transform waypoint in waypoints)
        {
            float distanceToPlayer = Vector3.Distance(player.position, waypoint.position);
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                nearestWaypoint = waypoint;
            }
        }

        // Set the target waypoint to the nearest waypoint found
        if (nearestWaypoint != null)
        {
            targetWaypoint = nearestWaypoint;
            taxi.transform.position = targetWaypoint.position;
        }
    }
}
