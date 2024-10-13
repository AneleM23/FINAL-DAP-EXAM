using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwatiDialogueSystem : MonoBehaviour
{
    public Text npcNameText;          // UI text for the NPC's name
    public Text dialogueText;         // UI text for the dialogue
    public GameObject dialogueBox;    // The dialogue box that shows the text
    public GameObject player;         // Reference to the player object

    private Queue<string> sentences;  // Queue of sentences for displaying dialogue
    private bool isDialogueActive = false; // Tracks if dialogue is currently active

    void Start()
    {
        sentences = new Queue<string>(); // Initialize the sentence queue
    }

    // Call this method to start the dialogue
    public void StartDialogue(string npcName, string[] dialogueSentences)
    {
        dialogueBox.SetActive(true);       // Show dialogue UI
        npcNameText.text = npcName;        // Set NPC name
        sentences.Clear();                 // Clear any old sentences

        foreach (string sentence in dialogueSentences)
        {
            sentences.Enqueue(sentence);   // Add each sentence to the queue
        }

        isDialogueActive = true;           // Mark dialogue as active
        DisplayNextSentence();             // Display the first sentence
    }

    // Call this method to display the next sentence
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(); // End if there are no more sentences
            return;
        }

        string sentence = sentences.Dequeue(); // Get the next sentence
        StopAllCoroutines();                   // Stop any previous typing coroutine
        StartCoroutine(TypeSentence(sentence)); // Type the next sentence
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; // Clear the text
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;   // Type each letter one by one
            yield return null;
        }
    }

    // Call this method to end the dialogue
    void EndDialogue()
    {
        dialogueBox.SetActive(false);  // Hide dialogue UI
        isDialogueActive = false;      // Dialogue is no longer active
        // You can reward the player here, for example:
        Debug.Log("Dialogue finished, reward player!");
    }

    // Call this method to update the dialogue on key press
    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence(); // Go to the next sentence on E key press
        }
    }

}
