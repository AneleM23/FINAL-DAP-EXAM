using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amadumbe : MonoBehaviour
{
 private bool isCollected = false;

    private void OnMouseDown()
    {
        if (isCollected) return;

        isCollected = true;

        // Reference to the mission tracker
        Mission_Amadumbe mission = FindObjectOfType<Mission_Amadumbe>();
        if (mission != null)
        {
            mission.CollectAmadumbe(); // Increment counter
        }

        Destroy(gameObject); // Only THIS amadumbe disappears
    }


}
