using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfrikaansBraaiMission : MonoBehaviour
{
    public Text missionDialogueText;   // UI element for displaying dialogue text
    public Text flipIndicatorText;     // UI element to tell the player to flip the meat
    public float flipInterval = 6f;    // Time in seconds to wait before each flip
    private int flipCount = 0;         // Counter for number of flips
    private float timeSinceLastFlip;
    private bool missionActive = false;
    private bool meatBurned = false;

    void Start()
    {
        flipIndicatorText.gameObject.SetActive(false); // Hide the flip indicator initially
    }

    void Update()
    {
        if (missionActive && !meatBurned)
        {
            timeSinceLastFlip += Time.deltaTime;

            // Show flip indicator if time to flip
            if (timeSinceLastFlip >= flipInterval)
            {
                flipIndicatorText.gameObject.SetActive(true); // Prompt player to flip the meat
            }

            // Check if the player missed the flip
            if (timeSinceLastFlip > flipInterval + 1) // 1-second buffer
            {
                BurnMeat(); // Fail the mission if flip missed
            }
        }
    }

    public void InteractWithNPC()
    {
        missionDialogueText.text = "Can you make a lekker braai?"; // Display initial dialogue
        StartMission();
    }

    void StartMission()
    {
        missionActive = true;
        flipCount = 0;
        timeSinceLastFlip = 0;
        flipIndicatorText.text = "Flip the meat!";
    }

    public void FlipMeat()
    {
        if (flipIndicatorText.gameObject.activeSelf && !meatBurned)
        {
            flipCount++;
            timeSinceLastFlip = 0; // Reset timer
            flipIndicatorText.gameObject.SetActive(false); // Hide the flip indicator until next flip

            if (flipCount >= 6) // 3 flips per side = 6 total flips
            {
                CompleteMission();
            }
        }
    }

    void BurnMeat()
    {
        missionActive = false;
        meatBurned = true;
        flipIndicatorText.text = "The meat burned!";
        Debug.Log("Mission failed: The meat burned.");
    }

    void CompleteMission()
    {
        missionActive = false;
        flipIndicatorText.text = "Braai complete! Enjoy your meal!";
        Debug.Log("Mission complete: You made a lekker braai!");
    }

}
