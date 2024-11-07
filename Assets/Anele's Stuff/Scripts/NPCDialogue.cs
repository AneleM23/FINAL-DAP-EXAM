using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string npcName;      // Name of the NPC (e.g., "Cultural Guide")
    [TextArea]                  // Enables multi-line input in Inspector
    public string funFact;      // The fun fact this NPC will share

    private DialogueManager dialogueManager;
    private Transform player;
    public float interactionRange = 3f;
    private bool isPlayerNear;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if player is within interaction range
        isPlayerNear = Vector3.Distance(transform.position, player.position) <= interactionRange;

        // Check if player presses 'E' and is near the NPC
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            StartFunFactDialogue();
        }
    }

    void StartFunFactDialogue()
    {
        // Create a new Dialogue instance to pass to DialogueManager
        Dialogue dialogue = new Dialogue();
        dialogue.npcName = npcName;
        dialogue.sentences = new string[] { funFact };  // Only one sentence (fun fact) in this case

        dialogueManager.StartDialogue(dialogue);
    }

}
