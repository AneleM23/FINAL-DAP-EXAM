using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;

    [SerializeField] SceneManagement scenes;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        nameText.text = dialogue.npcName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);

        if (nameText.text == "Zulu Boss")
        {
            scenes.StartBattle();  // Example from your original script
        }
    }

    // Added method to show basic dialogue
    public void ShowDialogue(string message)
    {
        dialogueText.text = message;
        dialogueBox.SetActive(true);
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }

}



