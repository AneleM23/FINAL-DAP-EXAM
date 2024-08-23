using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiTransport : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints where the taxi can go
    public Transform player; // Reference to the player
    public Transform taxi;
    public float moveSpeed = 5f; // Speed at which the taxi moves
    public float stopDistance = 1f; // Distance to stop from the waypoint

    private Transform targetWaypoint; // The current target waypoint
    private bool isTransporting = false; // Whether the taxi is currently transporting the player

    void Start()
    {
        // Set taxi to a random starting waypoint
        SetRandomWaypoint();
    }

    void Update()
    {
        // Move taxi towards the target waypoint if not transporting
        if (!isTransporting && targetWaypoint != null)
        {
            MoveToWaypoint();
        }
    }

    void SetRandomWaypoint()
    {
        int randomIndex = Random.Range(0, waypoints.Length);
        targetWaypoint = waypoints[randomIndex];
        taxi.transform.position = targetWaypoint.position;
    }

    void MoveToWaypoint()
    {
        // Move the taxi towards the target waypoint
        Vector3 direction = targetWaypoint.position - taxi.transform.position;
        taxi.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Check if taxi is close enough to the waypoint to stop
        if (Vector3.Distance(taxi.transform.position, targetWaypoint.position) <= stopDistance)
        {
            isTransporting = false;
        }
    }

    public void TransportPlayer(Transform destination)
    {
        // Set the target waypoint to the selected destination
        targetWaypoint = destination;
        isTransporting = true;
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
