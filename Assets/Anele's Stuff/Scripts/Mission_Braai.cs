using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission_Braai : MonoBehaviour
{
    [SerializeField] AfrikaansCowManager afrikaansMission1;

    [SerializeField] MissionManager mission;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] Sprite itemSprite;

    bool missionAdded;

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == afrikaansMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Braai!";
        mission.missionDescription = "Learn how to braai some meat!";
        mission.itemSprite = itemSprite;
        mission.itemName = "";
        waypoints.waypoints.Add(gameObject);
    }
}
