using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public bool hasRedPaint = false;
    public bool hasBluePaint = false;
    public bool hasYellowPaint = false;
    private bool missionTriggered = false; // New flag to prevent multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PaintSupply"))
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

            Destroy(other.gameObject);
        }

        // Check if all colors are collected and show the start mission prompt only once
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
}
