using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<Mission> currentMissions = new List<Mission>();

    // Add a new mission
    public void AddMission(Mission newMission)
    {
        currentMissions.Add(newMission);
        Debug.Log("Mission added: " + newMission.missionName);
    }

    // Complete a mission
    public void CompleteMission(string missionName)
    {
        Mission mission = currentMissions.Find(m => m.missionName == missionName);
        if (mission != null)
        {
            mission.CompleteMission();
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
    }

    // Get the list of active missions
    public List<Mission> GetActiveMissions()
    {
        return currentMissions.FindAll(m => !m.isCompleted);
    }

    public List<string> GetCurrentMissionNames()
    {
        List<string> names = new List<string>();

        foreach (Mission mission in currentMissions)
        {
            if (!mission.isCompleted)
            {
                names.Add(mission.missionName);
            }
        }

        return names;
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

