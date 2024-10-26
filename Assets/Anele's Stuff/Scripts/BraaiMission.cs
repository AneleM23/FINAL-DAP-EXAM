using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BraaiMission : MonoBehaviour
{

    public GameObject npc;              // The NPC to trigger dialogue
    public GameObject braaiStand;       // The braai stand object
    public Transform braaiCameraPosition; // Position for the camera to focus on the braai stand
    public Transform originalCameraPosition; // Original position for the camera
    public Text missionStatusText;      // Mission status text (win/lose)
    public Text flipIndicatorText;      // Flip indicator text
    public int flipInterval = 6;        // Time interval to flip meat
    public int requiredFlips = 3;       // Number of flips needed per side
    public DialogueManager dialogueManager; // Reference to DialogueManager script
    public Dialogue braaiDialogue;      // Dialogue scriptable object for the braai mission dialogue

    private int playerFlips = 0;
    private float flipTimer = 0f;
    private bool missionStarted = false;
    private bool isFlipping = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        missionStatusText.gameObject.SetActive(false);
        flipIndicatorText.gameObject.SetActive(false);
    }

    void Update()
    {
        // NPC interaction to trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && !missionStarted)
        {
            TriggerDialogue();
        }

        // Mission mechanics after dialogue
        if (missionStarted)
        {
            flipTimer += Time.deltaTime;

            if (flipTimer >= flipInterval)
            {
                flipIndicatorText.text = "Flip the meat!";
                isFlipping = true;

                if (Input.GetKeyDown(KeyCode.Space)) // Flip meat
                {
                    if (Mathf.Abs(flipTimer - flipInterval) <= 1f)
                    {
                        playerFlips++;
                        flipTimer = 0f;
                        flipIndicatorText.text = "";
                        isFlipping = false;

                        if (playerFlips >= requiredFlips * 2) // Total flips per side
                        {
                            MissionComplete(true);
                        }
                    }
                    else
                    {
                        MissionComplete(false);
                    }
                }
            }
        }
    }

    void TriggerDialogue()
    {
        // Start the dialogue using DialogueManager
        dialogueManager.StartDialogue(braaiDialogue);
    }

    public void StartMission()
    {
        missionStarted = true;
        flipIndicatorText.gameObject.SetActive(true);
        mainCamera.transform.position = braaiCameraPosition.position;  // Shift camera focus to braai stand
        mainCamera.transform.rotation = braaiCameraPosition.rotation;
        flipTimer = 0f;
    }

    void MissionComplete(bool success)
    {
        missionStarted = false;
        flipIndicatorText.gameObject.SetActive(false);

        if (success)
        {
            missionStatusText.text = "You win!";
            // Add reward here
        }
        else
        {
            missionStatusText.text = "You lose! The meat is burnt.";
        }

        missionStatusText.gameObject.SetActive(true);
        mainCamera.transform.position = originalCameraPosition.position;  // Return camera to original position
        mainCamera.transform.rotation = originalCameraPosition.rotation;
    }

}
