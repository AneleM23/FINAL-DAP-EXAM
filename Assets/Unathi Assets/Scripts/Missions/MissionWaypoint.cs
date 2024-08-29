using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public Image img; // The waypoint image
    public Transform target; // The target transform
    public Text meter; // Text for showing distance
    public Vector3 offset; // Offset for position

    [SerializeField] private MissionManager missionManager; // Reference to the MissionManager

    [SerializeField] WaypointManager waypoint;

    // Update is called once per frame
    void Update()
    {

        target = waypoint.currentWaypoint.transform;


        // Ensure MissionManager is assigned
        if (missionManager == null)
        {
            Debug.LogWarning("MissionManager is not assigned.");
            return;
        }

        // Check if there are any active missions
        bool hasActiveMissions = missionManager.GetActiveMissions().Count > 0;

        // Update the visibility of the waypoint image
        img.gameObject.SetActive(hasActiveMissions);

        if (!hasActiveMissions)
        {
            // If no active missions, do not update the waypoint
            return;
        }

        // Ensure target is assigned
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned.");
            return;
        }

        // Update waypoint image position and distance display
        UpdateWaypoint();
    }

    private void UpdateWaypoint()
    {
        // Update the waypoint image position
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().width / 2;
        float maxY = Screen.height - minY; // Use Screen.height for Y-axis

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (Vector3.Dot((target.position - Camera.main.transform.position), Camera.main.transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
        meter.text = ((int)Vector3.Distance(target.position, Camera.main.transform.position)).ToString() + "m";
    }
}
