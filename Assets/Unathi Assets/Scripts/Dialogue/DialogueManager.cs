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
        {
             venda.StartMission();
        }
    }
}

