using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordMatchingPuzzle : MonoBehaviour
{
    // UI Elements
    public Text feedbackText;               // Text that gives feedback
    public Text instructionText;            // Instruction Text "Match the English and Tsonga words!"
    public Button[] englishButtons;         // Buttons for English words
    public Button[] tsongaButtons;          // Buttons for Tsonga words
    public GameObject completionPanel;      // Panel to show when the puzzle is completed
    public GameObject startMissionPanel;    // Panel to ask the player to start the mission
    public Text startMissionText;           // Text for the start mission question
    public Button startButton;              // Button to start the mission
    public Button cancelButton;             // Button to cancel the mission

    // Variables for tracking matches and mission state
    private int selectedEnglishIndex = -1;  // Track which English word is selected
    private bool isWaitingForMatch = false; // Flag to track if we're waiting for a Tsonga word match
    private bool missionStarted = false;    // Track if the mission has already started

    // List of correct English-Tsonga word pairs
    private string[] englishWords = { "Hello", "Goodbye", "See", "I Love You" };
    private string[] tsongaWords = { "Xewani", "Ndzi pfumelela", "Vona", "Ndzi rhandza wena" };

    private void Start()
    {
        // Initially hide everything
        completionPanel.SetActive(false);
        HidePuzzleButtons();
        feedbackText.gameObject.SetActive(false);  // Hide feedback text initially
        instructionText.gameObject.SetActive(false); // Hide instructions initially

        // Show the start mission panel if mission hasn’t started
        if (!missionStarted)
        {
            startMissionPanel.SetActive(true);
            startMissionText.text = "Would you like to start the mission?";
        }

        // Set up event listeners for start and cancel buttons
        startButton.onClick.AddListener(StartMission);
        cancelButton.onClick.AddListener(CancelMission);

        // Set up event listeners for button clicks on puzzle buttons
        for (int i = 0; i < englishButtons.Length; i++)
        {
            int index = i;  // Capture the index in the closure
            englishButtons[i].onClick.AddListener(() => OnEnglishButtonClicked(index));
            tsongaButtons[i].onClick.AddListener(() => OnTsongaButtonClicked(index));
        }

        Debug.Log(gameObject.name);
    }

    // Start the mission when the player clicks "Yes"
    public void StartMission()
    {
        missionStarted = true;  // Set the mission as started
        startMissionPanel.SetActive(false);  // Hide the start mission panel
        StartCoroutine(ShowPuzzleInstructions());  // Begin showing instructions and puzzle
    }

    // Cancel the mission if the player clicks "No"
    private void CancelMission()
    {
        startMissionPanel.SetActive(false);  // Hide the start mission panel
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "Mission canceled.";
    }

    // Show instruction text, then reveal puzzle buttons
    private IEnumerator ShowPuzzleInstructions()
    {
        instructionText.gameObject.SetActive(true);
        instructionText.text = "Match the English and Tsonga words!";

        yield return new WaitForSeconds(3);

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
            feedbackText.text = "You need to select a Tsonga word first!";
            feedbackText.gameObject.SetActive(true);
            return;
        }

        selectedEnglishIndex = index;
        isWaitingForMatch = true;
        feedbackText.text = "Select the Tsonga word to match: " + englishWords[selectedEnglishIndex];
        feedbackText.gameObject.SetActive(true);
    }

    // Handle when a Tsonga button is clicked
    private void OnTsongaButtonClicked(int index)
    {
        if (!isWaitingForMatch) return;

        if (selectedEnglishIndex == index)
        {
            feedbackText.text = "Correct!";
            feedbackText.gameObject.SetActive(true);
            englishButtons[selectedEnglishIndex].gameObject.SetActive(false);
            tsongaButtons[index].gameObject.SetActive(false);
        }
        else
        {
            feedbackText.text = "Try again!";
            feedbackText.gameObject.SetActive(true);
        }

        CheckPuzzleCompletion();
        isWaitingForMatch = false;
    }

    // Check if all the puzzle pieces are correctly matched
    private void CheckPuzzleCompletion()
    {
        bool allCorrect = true;
        foreach (var button in englishButtons)
        {
            if (button.gameObject.activeSelf)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            ShowCompletionPanel();
        }
    }

    // Show the completion panel when puzzle is solved
    private void ShowCompletionPanel()
    {
        completionPanel.SetActive(true);
        feedbackText.gameObject.SetActive(false);
        StartCoroutine(HideCompletionPanelAfterDelay(5f));  // Hide after 5 seconds
    }

    // Coroutine to hide the completion panel after a delay
    private IEnumerator HideCompletionPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        completionPanel.SetActive(false);  // Hide the completion panel after the delay
    }
}
