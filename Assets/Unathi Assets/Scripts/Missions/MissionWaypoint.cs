using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Text meter;
    public Vector3 offset;

    [SerializeField] WaypointManager waypoint;

    // Update is called once per frame
    void Update()
    {
        // Ensure waypoint and currentWaypoint are assigned
        if (waypoint == null || waypoint.currentWaypoint == null)
        {
            Debug.LogWarning("WaypointManager or currentWaypoint is not assigned.");
            return;
        }

        target = waypoint.currentWaypoint.transform;

        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().width / 2;
        float maxY = Screen.width - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position+ offset);

         if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
                      if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }   else
            {
                pos.x = minX;
            }
        }

           pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

       img.transform.position = pos;
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
    }
}