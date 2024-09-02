using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public List<Mission> currentMissions = new List<Mission>();
    public List<GameObject> missionButtons; // Assign your buttons in the Inspector

    // Add a new mission
    public void AddMission(Mission newMission)
    {
        currentMissions.Add(newMission);
        Debug.Log("Mission added: " + newMission.missionName);
        UpdateMissionButtons();
    }

    // Complete a mission
    public void CompleteMission(string missionName)
    {
        Mission mission = currentMissions.Find(m => m.missionName == missionName);
        if (mission != null)
        {
            mission.CompleteMission();
            UpdateMissionButtons();
        }
        else
        {
            Debug.LogWarning("Mission not found: " + missionName);
        }
    }

    // Remove a completed mission
    public void RemoveCompletedMissions()
    {
        currentMissions.RemoveAll(m => m.isCompleted);
        Debug.Log("Completed missions removed");
        UpdateMissionButtons();
    }

    // Get the list of active missions
    public List<Mission> GetActiveMissions()
    {
        return currentMissions.FindAll(m => !m.isCompleted);
    }

    // Get the list of current mission names, limited to the top 4
    public List<string> GetCurrentMissionNames()
    {
        List<string> names = new List<string>();
        int count = Mathf.Min(4, currentMissions.Count);

        for (int i = 0; i < count; i++)
        {
            if (!currentMissions[i].isCompleted)
            {
                names.Add(currentMissions[i].missionName);
            }
        }

        return names;
    }

    // Update mission buttons based on the number of active missions
    public void UpdateMissionButtons()
    {
        List<Mission> activeMissions = GetActiveMissions();
        int count = Mathf.Min(4, activeMissions.Count);

        for (int i = 0; i < missionButtons.Count; i++)
        {
            if (i < count)
            {
                missionButtons[i].SetActive(true);
                // Optionally set the button's text to the mission name
               // missionButtons[i].GetComponentInChildren<Text>().text = activeMissions[i].missionName;
            }
            else
            {
                missionButtons[i].SetActive(false);
            }
        }
    }

    //// Example usage
    //void Start()
    //{
    //    // Example of adding missions
    //    AddMission(new Mission("Collect 10 Coins", "Collect 10 coins in the forest"));
    //    AddMission(new Mission("Defeat the Boss", "Defeat the boss in the castle"));

    //    // Example of completing a mission
    //    CompleteMission("Collect 10 Coins");

    //    // Example of removing completed missions
    //    RemoveCompletedMissions();

    //    // Example of getting active missions
    //    List<Mission> activeMissions = GetActiveMissions();
    //    foreach (Mission mission in activeMissions)
    //    {
    //        Debug.Log("Active Mission: " + mission.missionName);
    //    }
    //}
}

