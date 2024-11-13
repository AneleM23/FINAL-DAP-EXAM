using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordTracker : MonoBehaviour
{
    private List<string> collectedLetters = new List<string>(); // Stores the collected letters
    public Text wordText; // Text component to display the word

    // Adds a letter to the list of collected letters
    public void AddLetter(string letter)
    {
        collectedLetters.Add(letter);
        UpdateWordText();
    }

    // Updates the word text with the collected letters
    private void UpdateWordText()
    {
        wordText.text = "Collected Word: " + string.Join("", collectedLetters);
    }

    // Shows the full word when the player presses a key (e.g., 'W' to view the word)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // Replace with any key you want for viewing the word
        {
            ShowWord();
        }
    }

    // Show the word in the UI (for example, a UI panel)
    private void ShowWord()
    {
        wordText.gameObject.SetActive(true); // Show the text
    }
}
