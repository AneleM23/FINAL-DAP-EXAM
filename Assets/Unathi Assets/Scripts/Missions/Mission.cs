using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
    public string missionName;
    public string missionDescription;
    public bool isCompleted;

    public Mission(string name, string description)
    {
        missionName = name;
        missionDescription = description;
        isCompleted = false;
    }

    public void CompleteMission()
    {
        isCompleted = true;
        Debug.Log("Mission completed: " + missionName);
    }
}

