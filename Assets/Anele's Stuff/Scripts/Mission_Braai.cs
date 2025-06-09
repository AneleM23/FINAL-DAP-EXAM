using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mission_Braai : MonoBehaviour
{
    public AfrikaansBraaiMission braaiMission;
    private DialogueManager dialogueManager;
    private Transform player;
    public float interactionRange = 3f;
    private bool isPlayerNear;
    private bool dialogueStarted = false;
    private bool missionStarted = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        isPlayerNear = Vector3.Distance(transform.position, player.position) <= interactionRange;

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !dialogueStarted)
        {
            dialogueStarted = true;

            // Start the braai-related dialogue
            Dialogue dialogue = new Dialogue
            {
                npcName = "Braai Master",
                sentences = new string[]
                {
                    "Welkom! Vandag gaan jy leer om vleis reg te braai!",
                    "Maak seker jy flip hom betyds — anders brand hy!"
                }
            };

            dialogueManager.StartDialogue(dialogue);
        }

        // ✅ Wait until the dialogue box disappears to trigger mission
        if (dialogueStarted && !missionStarted && !dialogueManager.dialogueBox.activeInHierarchy)
        {
            missionStarted = true;
            braaiMission.StartBraai();
        }
    }
}


