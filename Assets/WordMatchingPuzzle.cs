using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordMatchingPuzzle : MonoBehaviour
{
    // UI Elements
    public Text feedbackText;  // Text that gives feedback
    public Text instructionText;  // Instruction Text "Match the English and Tsonga words!"
    public Button[] englishButtons;  // Buttons for English words
    public Button[] tsongaButtons;  // Buttons for Tsonga words
    public GameObject completionPanel;  // Panel to show when the puzzle is completed

    // Variables for tracking matches
    private int selectedEnglishIndex = -1;  // Track which English word is selected
    private bool isWaitingForMatch = false; // Flag to track if we're waiting for a Tsonga word match

    // List of correct English-Tsonga word pairs
    private string[] englishWords = { "Hello", "Goodbye", "See", "I Love You" };
    private string[] tsongaWords = { "Xewani", "Ndzi pfumelela", "Vona", "Ndzi rhandza wena" };

    private void Start()
    {
        // Initially hide everything
        completionPanel.SetActive(false);
        HidePuzzleButtons();
        feedbackText.gameObject.SetActive(false);  // Hide feedback text initially

        // Set up event listeners for button clicks
        for (int i = 0; i < englishButtons.Length; i++)
        {
            int index = i;  // Capture the index in the closure
            englishButtons[i].onClick.AddListener(() => OnEnglishButtonClicked(index));
            tsongaButtons[i].onClick.AddListener(() => OnTsongaButtonClicked(index));
        }

        // Start the process to show the instruction text and then the puzzle
        StartCoroutine(ShowPuzzleInstructions());
    }

    // Show instruction text, then reveal puzzle buttons
    private IEnumerator ShowPuzzleInstructions()
    {
        // Show instruction text at the start of the puzzle
        instructionText.gameObject.SetActive(true);
        instructionText.text = "Match the English and Tsonga words!";

        // Wait for 3 seconds before hiding the instruction text
        yield return new WaitForSeconds(3);

        // Hide instruction text and show the puzzle buttons
        instructionText.gameObject.SetActive(false);
        ShowPuzzleButtons();  // Reveal puzzle buttons
    }

    // Show the puzzle buttons
    private void ShowPuzzleButtons()
    {
        foreach (var button in englishButtons)
        {
            button.gameObject.SetActive(true);
        }
        foreach (var button in tsongaButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    // Hide the puzzle buttons
    private void HidePuzzleButtons()
    {
        foreach (var button in englishButtons)
        {
            button.gameObject.SetActive(false);
        }
        foreach (var button in tsongaButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    // Handle when an English button is clicked
    private void OnEnglishButtonClicked(int index)
    {
        if (isWaitingForMatch)
        {
            feedbackText.text = "You need to select a Tsonga word first!"; // Feedback for trying to select English word before Tsonga
            feedbackText.gameObject.SetActive(true);
            return;
        }

        selectedEnglishIndex = index;
        isWaitingForMatch = true; // Now we are waiting for a Tsonga word match
        feedbackText.text = "Select the Tsonga word to match: " + englishWords[selectedEnglishIndex];  // Show which word to match
        feedbackText.gameObject.SetActive(true);
    }

    // Handle when a Tsonga button is clicked
    private void OnTsongaButtonClicked(int index)
    {
        if (!isWaitingForMatch) return;  // If we're not waiting for a match, ignore the click.

        // Correct matching logic
        if (selectedEnglishIndex == index)
        {
            feedbackText.text = "Correct!"; // Provide feedback
            feedbackText.gameObject.SetActive(true);
            englishButtons[selectedEnglishIndex].gameObject.SetActive(false);
            tsongaButtons[index].gameObject.SetActive(false); // Optionally disable the buttons that are correctly matched
        }
        else
        {
            feedbackText.text = "Try again!"; // Provide feedback for wrong match
            feedbackText.gameObject.SetActive(true);
        }

        // Check if the puzzle is complete
        CheckPuzzleCompletion();
        isWaitingForMatch = false;  // Stop waiting for a match after one Tsonga word is clicked
    }

    // Check if all the puzzle pieces are correctly matched
    private void CheckPuzzleCompletion()
    {
        bool allCorrect = true;
        foreach (var button in englishButtons)
        {
            if (button.gameObject.activeSelf) // If there's any active button, the puzzle isn't complete
            {
                allCorrect = false;
                break;
            }
        }

        // If all matches are correct, show the completion panel
        if (allCorrect)
        {
            ShowCompletionPanel();
        }
    }

    // Show the completion panel when puzzle is solved
    private void ShowCompletionPanel()
    {
        completionPanel.SetActive(true);  // Show the completion panel
        feedbackText.gameObject.SetActive(false);  // Hide feedback text when done
    }
}
