using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // The dialogue data

    [SerializeField] AudioSource zuluIntro;
    [SerializeField] AudioSource xhosaIntro;
    [SerializeField] AudioSource swatiIntro;
    [SerializeField] AudioSource tswanaIntro;
    [SerializeField] AudioSource vendaIntro;
    [SerializeField] AudioSource tsongaIntro;
    [SerializeField] AudioSource pediIntro;

    [SerializeField] AudioSource braaiDialogue;

    public void TriggerDialogue()
    {
        if (gameObject.name == "Gogo_Zulu")
        {
            zuluIntro.Play();
        }
        else if (gameObject.name == "Gogo_Xhosa")
        {
            xhosaIntro.Play();
        }
        else if (gameObject.name == "Gogo_Swati")
        {
            swatiIntro.Play();
        }
        else if (gameObject.name == "Gogo_Tswana")
        {
            tswanaIntro.Play();
        }
        else if (gameObject.name == "Gogo_Venda")
        {
            vendaIntro.Play();
        }
        else if (gameObject.name == "Gogo_Tsonga")
        {
            tsongaIntro.Play();
        }
        else if (gameObject.name == "Gogo_Pedi")
        {
            pediIntro.Play();
        }
        else if (braaiDialogue != null)
        {
            braaiDialogue.Play(); // Play dialogue audio if available
        }

        // Start the dialogue text
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        // Start specific missions based on the NPC
        StartSpecificMissions();
    }

    // Method to start missions based on the NPC name
    private void StartSpecificMissions()
    {
        if (gameObject.name == "Gogo_Pedi") // Replace with actual NPC name for the chicken mission
        {
            Mission_CatchChicken catchChickenMission = GetComponent<Mission_CatchChicken>();
            if (catchChickenMission != null)
            {
                catchChickenMission.StartCatchChickenMission();
            }
        }
        else if (gameObject.name == "Braai Master")
        {
            AfrikaansBraaiMission braaiMission = GetComponent<AfrikaansBraaiMission>();
            if (braaiMission != null)
            {
                braaiMission.InteractWithNPC();
            }
        }
    }

}

