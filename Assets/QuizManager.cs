using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public Text questionText;
    public Button[] answerButtons;

    private void Start()
    {
        // Set initial question and answers
        SetQuestion();
    }

    private void SetQuestion()
    {
        questionText.text = "What does this pattern represent?";
        answerButtons[0].GetComponentInChildren<Text>().text = "Triangles"; // Correct answer
        answerButtons[1].GetComponentInChildren<Text>().text = "Diamonds"; // Incorrect answer

        // Add listeners
        answerButtons[0].onClick.AddListener(() => Answer(true));
        answerButtons[1].onClick.AddListener(() => Answer(false));
    }

    private void Answer(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer!");
            // Proceed to next part of the mission or unlock something
        }
        else
        {
            Debug.Log("Incorrect answer. Try again!");
        }
        quizPanel.SetActive(false); // Hide quiz after answering
    }
}
