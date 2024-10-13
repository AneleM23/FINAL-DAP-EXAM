using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amadumbe : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Check if the player has clicked on the amadumbe
        MyPlayerController playerController = FindObjectOfType<MyPlayerController>();
        if (playerController != null)
        {
            playerController.CollectAmadumbe(); // Call the collect function
            Destroy(gameObject); // Remove the amadumbe from the scene
        }
    }


}
