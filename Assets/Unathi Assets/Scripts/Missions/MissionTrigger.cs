using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTrigger : MonoBehaviour
{
    public string missionName;         // Name of the mission
    public string missionDescription;  // Description of the mission
    public Sprite itemSprite;          // The image sprite for the item
    public string itemName;            // The name of the item

    private MissionManager missionManager;

    void Start()
    {
        // Find the MissionManager in the scene
        missionManager = FindObjectOfType<MissionManager>();

        if (missionManager != null)
        {
            // Create a new mission and add it to the MissionManager
            Mission newMission = new Mission(missionName, missionDescription);

            // Create a new item and assign it to the mission
            Item missionItem = new Item(itemName, itemSprite);
            newMission.rewardItem = missionItem;

            missionManager.AddMission(newMission);

            //Debug.Log("Mission added: " + missionName + " with item: " + itemName);
        }
        else
        {
            Debug.LogWarning("MissionManager not found in the scene.");
        }
    }

}

