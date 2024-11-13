using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public string npcName = "Elder";
    public DialogueManager dialogueManager; // Reference to your DialogueManager script
    public QuizManager quizManager; // Reference to your QuizManager script
    public CollectItem collectItemScript; // Reference to the CollectItem script
    private bool hasPlayerStartedMission = false;
    private bool hasPlayerCollectedAllColors = false;
    private bool hasShownCompletionDialogue = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasPlayerStartedMission)
            {
                // First interaction: Start mission and allow paint collection
                StartMissionDialogue();
                hasPlayerStartedMission = true;

                // Activate mission to allow paint collection
                collectItemScript.ActivateMission();
            }
            else if (hasPlayerCollectedAllColors && !hasShownCompletionDialogue)
            {
                // Second interaction: Mission complete and quiz begins
                CompleteMissionDialogue();
                hasShownCompletionDialogue = true;
            }
        }
    }

    public void SetAllColorsCollected()
    {
        hasPlayerCollectedAllColors = true;
    }

    private void StartMissionDialogue()
    {
        string[] welcomeDialogue = new string[]
        {
            "Welcome, young one. I have a task for you.",
            "Collect the 3 paint colors scattered around the village.",
            "There is a quiz you must answer after collecting all 3 paint colors."
        };

        Dialogue dialogue = new Dialogue { npcName = npcName, sentences = welcomeDialogue };
        dialogueManager.StartDialogue(dialogue);
    }

    private void CompleteMissionDialogue()
    {
        string[] completionDialogue = new string[]
        {
            "Well done! You have gathered all the colors.",
            "Now, let's see how well you know our culture. Answer this quiz to win the traditional treasure."
        };

        Dialogue dialogue = new Dialogue { npcName = npcName, sentences = completionDialogue };
        dialogueManager.StartDialogue(dialogue);
    }
}
