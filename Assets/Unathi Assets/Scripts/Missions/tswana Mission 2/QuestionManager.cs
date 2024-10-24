using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   

public class QuestionManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] options; // Array for the multiple choices
        public int correctAnswerIndex; // Index of the correct answer
    }

    public Question[] questions; // Array to hold all questions
    public GameObject questionPanel; // The panel that will display the questions
    public TextMeshProUGUI questionText; // UI text for question
    public TextMeshProUGUI[] optionTexts; // UI text for the options (assuming 4 options)
    private int currentQuestionIndex = 0;
    public int correctAnswers = 0;

    [SerializeField] GameObject question2;
    [SerializeField] GameObject question3;

    [SerializeField] MissionManager mission;


    void Start()
    {
         // Start with the first question
         //StartMission();
    }

    public void StartMission()
    {
        ShowQuestion(currentQuestionIndex);
    }

    void Update()
    {
        if (currentQuestionIndex == 0)
        {
            question2.SetActive(false);
            question3.SetActive(false);
        }  else if (currentQuestionIndex == 1)
        {
            question2.SetActive(true);
            question3.SetActive(false);
        }  else if (currentQuestionIndex == 2)
        {
            question2.SetActive(false);
            question3.SetActive(true);
        }
    }

    // Method to display a question
    public void ShowQuestion(int questionIndex)
    {
        Question question = questions[questionIndex];
        questionText.text = question.questionText;

        for (int i = 0; i < optionTexts.Length; i++)
        {
            optionTexts[i].text = question.options[i]; // Set option texts
        }

        questionPanel.SetActive(true); // Show the panel
    }

    // Method to check the answer selected by the player
    public void CheckAnswer(int selectedOption)
    {
        if (selectedOption == questions[currentQuestionIndex].correctAnswerIndex)
        {
            Debug.Log("Correct Answer!");
            correctAnswers++;
            NextQuestion();
        }
        else
        {
            Debug.Log("Incorrect Answer!");
            NextQuestion();
        }
    }

    // Move to the next question
    private void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("All questions completed!");
            

            if (correctAnswers < 3)
            {
                FindObjectOfType<UI_Manager>().MissionFail();
            }         else if (correctAnswers == 3)
            {
                MissionTrigger missionTrigger = GameObject.Find("TswanaMan").GetComponent<MissionTrigger>();

                if (missionTrigger != null)
                {
                    mission.CompleteMission(missionTrigger.missionName);
                }
            }

            currentQuestionIndex = 0;
            correctAnswers = 0;
            questionPanel.SetActive(false); // Hide the panel when done
        }
    }
}

