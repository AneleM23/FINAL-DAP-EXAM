using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue("Siyalemukela! Our patterns tell our stories. I’ll show you how to paint one.");
        }
    }

    private void ShowDialogue(string message)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = message;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialoguePanel.SetActive(false);
        }
    }
}
