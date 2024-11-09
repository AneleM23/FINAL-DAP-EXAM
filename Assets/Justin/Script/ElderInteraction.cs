using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElderInteraction : MonoBehaviour
{
    public GameObject dialoguePanel; // Reference to the Dialogue Panel
    public Text dialogueText; // Reference to the Text component inside the panel
    public Button continueButton; // Reference to the Continue button
    public GameObject puzzleUI;
    public string[] dialogueLines; // Array of dialogue lines to display
    private int currentLine = 0; // To track the current dialogue line
    private bool playerInRange = false; // To check if player is within trigger area

    private void Start()
    {
        dialoguePanel.SetActive(false); // Initially hide the dialogue panel
        continueButton.onClick.AddListener(ProgressDialogue); // Add listener to the button
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player entered the trigger area
        {
            playerInRange = true;
            ShowDialogue(); // Show the dialogue panel
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player left the trigger area
        {
            playerInRange = false;
            dialoguePanel.SetActive(false); // Hide the dialogue panel
        }
    }

    // Show the first line of the dialogue when the player enters the trigger area
    private void ShowDialogue()
    {
        dialoguePanel.SetActive(true); // Activate the dialogue panel
        currentLine = 0; // Reset to the first line
        dialogueText.text = dialogueLines[currentLine]; // Display the first dialogue line
    }

    // Progress to the next line or start the mission if finished
    private void ProgressDialogue()
    {
        if (currentLine < dialogueLines.Length - 1)
        {
            currentLine++; // Move to the next dialogue line
            dialogueText.text = dialogueLines[currentLine]; // Update the text
        }
        else
        {
            StartMission(); // Start mission after the last dialogue line
        }
    }

    // Start the puzzle mission after the dialogue ends
    private void StartMission()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
        if (puzzleUI != null) // Check if puzzleUI is assigned to avoid errors
        {
            puzzleUI.SetActive(true); // Show the puzzle UI to start the mission
        }
        else
        {
            Debug.LogWarning("Puzzle UI is not assigned in the Inspector!");
        }
        Debug.Log("Mission started! Begin solving the puzzle.");
    }
}
