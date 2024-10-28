using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission_Braai : MonoBehaviour
{
    public int flipsRequired = 3; // Number of flips required per side
    public float flipInterval = 6f; // Time in seconds between required flips
    public Text indicatorText; // UI indicator to tell player to flip the meat

    private int currentFlips = 0;
    private bool isFlipping = false;
    private float flipTimer;
    private bool missionStarted = false;

    // Method to start the braai mission
    public void StartBraaiMission()
    {
        missionStarted = true;
        currentFlips = 0;
        flipTimer = flipInterval;
        indicatorText.text = "Flip the meat!";
        StartCoroutine(BraaiRoutine());
    }

    // Coroutine to handle the braai flipping timing
    private IEnumerator BraaiRoutine()
    {
        while (missionStarted && currentFlips < flipsRequired * 2) // Multiply by 2 for both sides
        {
            flipTimer -= Time.deltaTime;
            if (flipTimer <= 0f)
            {
                indicatorText.text = "Flip now!";
                isFlipping = true;
            }
            yield return null;
        }

        // End mission if all flips were completed successfully
        if (currentFlips >= flipsRequired * 2)
        {
            indicatorText.text = "Braai complete! You win!";
            missionStarted = false;
        }
    }

    // Public method for player to flip meat
    public void FlipMeat()
    {
        if (!missionStarted || !isFlipping) return;

        if (flipTimer >= -1f && flipTimer <= 1f) // Check if flip was close enough to the timer
        {
            currentFlips++;
            indicatorText.text = $"Flips: {currentFlips}/{flipsRequired * 2}";

            if (currentFlips < flipsRequired * 2)
            {
                // Reset the timer and continue to the next flip
                flipTimer = flipInterval;
                isFlipping = false;
            }
        }
        else
        {
            // Fail condition if player flips too late or too early
            indicatorText.text = "The meat burned! You lose.";
            missionStarted = false;
        }
    }

    // Check for mouse click input
    void Update()
    {
        if (missionStarted && Input.GetMouseButtonDown(0)) // Only accept input when mission is active
        {
            FlipMeat();
        }
    }


}
