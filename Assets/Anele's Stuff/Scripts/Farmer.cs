using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // Find the DialogueManager in the scene
    }

    public void StartMission()
    {
        MyPlayerController playerController = FindObjectOfType<MyPlayerController>();
        if (playerController != null)
        {
            playerController.StartMission(); // Start the mission when the player interacts with the farmer
            ShowDialogue("Please collect 5 amadumbe for me!"); // Show dialogue for the player
        }
    }

    // Example of showing dialogue
    void ShowDialogue(string message)
    {
        if (dialogueManager != null)
        {
            dialogueManager.ShowDialogue(message); // Show the message using DialogueManager
        }
    }

    private void OnMouseDown()
    {
        StartMission(); // Start the mission when the player clicks on the farmer
    }

}
