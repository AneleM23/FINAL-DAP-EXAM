using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;

    [SerializeField] SceneManagement scenes;
    [SerializeField] Mission_Amadumbe amadumbe;
    [SerializeField] MissionManager mission;
    [SerializeField] VendaM2Manager venda;
    [SerializeField] AfrikaansBraaiMission afrikaans;
    [SerializeField] WordMatchingPuzzle tsonga;
    [SerializeField] QuizManager ndebele;
    [SerializeField] Mission_CatchChicken pedi;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        nameText.text = dialogue.npcName;
        sentences.Clear();

        // Add all sentences to the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // If no more sentences remain, end the dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Display the next sentence
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

        // Trigger missions based on the NPC's name
        if (nameText.text == "Zulu Boss")
            scenes.StartBattle();
        else if (nameText.text == "Xhosa Farmer")
            amadumbe.StartMission();
        else if (nameText.text == "Swazi Elder")
        {
            MissionTrigger missionTrigger = GameObject.Find("SwatiMan").GetComponent<MissionTrigger>();
            WaypointManager waypoints = GameObject.Find("WaypointManager").GetComponent<WaypointManager>();

            if (missionTrigger != null)
            {
                mission.CompleteMission(missionTrigger.missionName);
                waypoints.waypoints.Remove(missionTrigger.gameObject);
            }
        }
        else if (nameText.text == "Tswana Man")
            FindObjectOfType<QuestionManager>().StartMission();
        else if (nameText.text == "Venda Man")
            venda.StartMission();
        else if (nameText.text == "Afrikaans Boy")
            afrikaans.StartMission();
        else if (nameText.text == "Tsonga Boy")
            tsonga.StartMission();
        else if (nameText.text == "Ndebele Man")
            FindObjectOfType<QuizManager>().StartMission();
        else if (nameText.text == "Pedi Man")
            pedi.StartCatchChickenMission();
    }

}

