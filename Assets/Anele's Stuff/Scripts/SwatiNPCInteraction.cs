using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatiNPCInteraction : MonoBehaviour
{
    public SwatiDialogueSystem dialogueSystem; // Reference to the dialogue system
    public string npcName = "Swati NPC";       // Name of the NPC

    private bool playerInRange = false;        // Check if the player is close

    // Example dialogue for the NPC
    private string[] swatiDialogue = new string[]
    {
        "Welcome! Let me share a bit about Swati culture.",
        "Swati people value tradition and family.",
        "We have unique ceremonies, like the Umhlanga, where maidens honor the queen mother.",
        "Respect for elders and unity within the community define our identity.",
        "Thank you for learning about our culture! Here's an artifact to celebrate your knowledge."
    };

    // Trigger dialogue when the player is in range
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueSystem.StartDialogue(npcName, swatiDialogue); // Start dialogue on E key press
        }
    }

    // Detect when the player enters the interaction range
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Player is in range
        }
    }

    // Detect when the player leaves the interaction range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Player is out of range
        }
    }

}
