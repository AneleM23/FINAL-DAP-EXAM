using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public QuizQuestion[] questions; // Define questions in the Inspector
    private int currentQuestionIndex = 0;

    // UI Elements
    public Text questionText; // Reference to the UI Text component for the question
    public Button[] optionButtons; // Array of buttons for answer options
    public GameObject quizPanel; // Panel to show quiz UI
    public GameObject completionPanel; // Panel to show completion message
    public GameObject startMissionPanel; // Panel asking if the player wants to begin the puzzle mission
    public Button yesButton; // Button for starting the quiz
    public Button noButton; // Button for canceling the quiz
    public Text startMissionText; // Message displayed on the confirmation panel

    private void Start()
    {
        // Hide quiz, completion, and startMission panels at the start
        quizPanel.SetActive(false);
        completionPanel.SetActive(false);
        startMissionPanel.SetActive(false); // Hide the startMission panel initially

        // Add listeners for the buttons
        yesButton.onClick.AddListener(StartQuiz);
        noButton.onClick.AddListener(CancelQuizStart);
    }

    // Function to show the startMission panel asking if the player wants to start the mission
    public void StartMission()
    {
        startMissionText.text = "Would you like to begin the puzzle mission?"; // Set the text on the startMission panel
        startMissionPanel.SetActive(true); // Show the startMission panel
    }

    // Function called when the player clicks "Yes" to start the quiz
    public void StartQuiz()
    {
        startMissionPanel.SetActive(false); // Hide the startMission panel
        quizPanel.SetActive(true); // Show the quiz panel
        currentQuestionIndex = 0; // Reset question index
        ShowQuestion(currentQuestionIndex); // Show the first question
    }

    // Function called when the player clicks "No" to cancel starting the quiz
    public void CancelQuizStart()
    {
        startMissionPanel.SetActive(false); // Hide the startMission panel
        // Optionally, you can add a message or additional logic here for when the player cancels
    }

    // Function to show the current question and its options
    public void ShowQuestion(int index)
    {
        if (index < questions.Length)
        {
            questionText.text = questions[index].question; // Set the question text
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = questions[index].options[i]; // Set button text
                optionButtons[i].interactable = true; // Enable buttons
                optionButtons[i].gameObject.SetActive(true); // Show buttons
            }
        }
        else
        {
            Debug.LogError("Question index out of bounds.");
        }
    }

    // Function to submit an answer
    public void SubmitAnswer(int selectedOptionIndex)
    {
        if (selectedOptionIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Length)
            {
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                CompleteQuiz();
            }
        }
        else
        {
            Debug.Log("Incorrect answer. Try again!");
        }
    }

    // Function to end the quiz and show the completion panel
    public void CompleteQuiz()
    {
        quizPanel.SetActive(false); // Hide the quiz panel
        completionPanel.SetActive(true); // Show the completion panel

        // Start coroutine to hide the completion panel after 3 seconds
        StartCoroutine(HideCompletionPanelAfterDelay(3f));
    }

    private IEnumerator HideCompletionPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        completionPanel.SetActive(false); // Hide the completion panel after the delay
    }
}

[System.Serializable]
public class QuizQuestion
{
    public string question; // The quiz question
    public string[] options; // The answer options
    public int correctAnswerIndex; // Index of the correct answer
}
