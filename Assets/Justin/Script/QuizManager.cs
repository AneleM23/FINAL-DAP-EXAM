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
    public Button startQuizButton; // Button to start the quiz in the confirmation panel
    public Text confirmationMessage; // Text element for the confirmation message

    private void Start()
    {
        // Hide quiz, completion, and confirmation panels at the start
        quizPanel.SetActive(false);
        completionPanel.SetActive(false);

        // Assign StartQuiz to button click
        startQuizButton.onClick.AddListener(StartQuiz);
    }


    public void StartQuiz()
    {
        // Hide the confirmation panel and show the quiz panel
        quizPanel.SetActive(true); // Show the quiz panel
        currentQuestionIndex = 0; // Reset question index
        ShowQuestion(currentQuestionIndex); // Show the first question
    }

    public void ShowQuestion(int index)
    {
        if (index < questions.Length)
        {
            questionText.text = questions[index].question; // Set question text
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = questions[index].options[i]; // Set button text
                optionButtons[i].interactable = true; // Enable button
                optionButtons[i].gameObject.SetActive(true); // Show buttons
            }
        }
        else
        {
            Debug.LogError("Question index out of bounds.");
        }
    }

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

    public void CompleteQuiz()
    {
        quizPanel.SetActive(false); // Hide the quiz panel
        completionPanel.SetActive(true); // Show completion panel

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
