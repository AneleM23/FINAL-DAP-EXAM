using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendaM2Manager : MonoBehaviour
{
    public Transform vendaMan; // Assign the Venda man in the inspector
    public Transform lakePosition; // Position near the lake
    public Transform villagePosition; // Original village position
    public GameObject prayPrompt; // UI prompt for praying

    [SerializeField] private bool missionStarted = false;
    [SerializeField] private bool reachedLake = false;
    [SerializeField] private bool missionComplete = false;

    [SerializeField] MissionManager mission;

    void Start()
    {
        prayPrompt.SetActive(false);
    }

    // Call this in DialogueManager to start the mission
    public void StartMission()
    {
        missionStarted = true;
        MoveVendaManToLake();
    }

    void Update()
    {
        if (missionStarted && !missionComplete)
        {
            Transform player = GameObject.Find("Player").GetComponent<Transform>();
            float playerDistance = Vector3.Distance(player.position, vendaMan.position);

            // Show prompt when near the Venda man
            if (playerDistance < 3.5f && reachedLake)
            {
                prayPrompt.SetActive(true);
            }
            else
            {
                prayPrompt.SetActive(false);
            }
        }
    }

    void MoveVendaManToLake()
    {
        vendaMan.position = lakePosition.position;
        reachedLake = true;
    }

    public void Pray()
    {
        MissionTrigger missionTrigger = GetComponent<MissionTrigger>();

        if (missionTrigger != null)
        {
            {
                mission.CompleteMission(missionTrigger.missionName);
            }

            prayPrompt.SetActive(false);
            missionComplete = true;
            ReturnVendaManToVillage();
        }

        void ReturnVendaManToVillage()
        {
            vendaMan.position = villagePosition.position;
            // Optionally, add further completion logic here.
        }
    }
}
