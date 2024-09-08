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
            swatiIntro.Play();
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

