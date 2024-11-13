using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public bool hasRedPaint = false;
    public bool hasBluePaint = false;
    public bool hasYellowPaint = false;
    private bool missionTriggered = false; // Flag to prevent multiple triggers
    public bool isMissionActive = false; // New flag to check if elder interaction has occurred

    private void OnTriggerEnter(Collider other)
    {
        // Only allow paint collection if mission is active
        if (isMissionActive && other.CompareTag("PaintSupply"))
        {
            string color = other.gameObject.name;

            if (color == "RedPaint")
            {
                hasRedPaint = true;
                PlayerInventory.AddColor("Red");
            }
            else if (color == "BluePaint")
            {
                hasBluePaint = true;
                PlayerInventory.AddColor("Blue");
            }
            else if (color == "YellowPaint")
            {
                hasYellowPaint = true;
                PlayerInventory.AddColor("Yellow");
            }

            Destroy(other.gameObject); // Remove the collected paint object
        }

        // Check if all colors are collected and start mission only once
        if (HasAllColors() && !missionTriggered)
        {
            missionTriggered = true; // Set to true to prevent re-triggering
            FindObjectOfType<QuizManager>().StartMission(); // Call StartMission once
        }
    }

    public bool HasAllColors()
    {
        return hasRedPaint && hasBluePaint && hasYellowPaint;
    }

    // This method should be called by the elder NPC interaction to start the mission
    public void ActivateMission()
    {
        isMissionActive = true; // Set mission to active after elder interaction
    }
}
