using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amadumbe : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Check if the player has clicked on the amadumbe
        Mission_Amadumbe amadumbe = FindObjectOfType<Mission_Amadumbe>();

        if (amadumbe != null)
        {
            amadumbe.CollectAmadumbe(); // Call the collect function
            Destroy(gameObject); // Remove the amadumbe from the scene
        }
    }


}
