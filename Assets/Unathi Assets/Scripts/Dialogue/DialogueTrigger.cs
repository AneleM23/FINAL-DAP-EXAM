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
    [SerializeField] AudioSource ndebeleIntro;
    [SerializeField] AudioSource sothoIntro;

    public void TriggerDialogue()
    {
        if (gameObject.name == "Gogo_Zulu")
        {
            zuluIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Xhosa")
        {
            xhosaIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Swati")
        {
            swatiIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Tswana")
        {
            tswanaIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Venda")
        {
            vendaIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Tsonga")
        {
            tsongaIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Pedi")
        {
            pediIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Ndebele")
        {
            ndebeleIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        else if (gameObject.name == "Gogo_Sotho")
        {
            sothoIntro.Play();

            MissionInformation info = GetComponentInChildren<MissionInformation>();

            if (info != null)
            {
                info.canCollectCow = true;
            }
        }
        

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

