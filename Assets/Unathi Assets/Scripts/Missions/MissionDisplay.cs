using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MissionDisplay : MonoBehaviour
{
    public MissionManager missionManager;
    public Text missionText; // Assign this in the Unity Editor

    void Update()
    {
        UpdateMissionDisplay();
    }

    void UpdateMissionDisplay()
    {
        List<string> descriptions = missionManager.GetCurrentMissionNames();

        missionText.text = ""; // Clear the text first

        foreach (string description in descriptions)
        {
            missionText.text += description + "\n";
        }
    }
}

