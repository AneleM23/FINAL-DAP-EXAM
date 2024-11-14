using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PediM2Manager : MonoBehaviour
{
    [SerializeField] PediCowManager pediMission1;

    [SerializeField] MissionManager mission;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] Sprite itemSprite;

    bool missionAdded;

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == pediMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Cath chickens!";
        mission.missionDescription = "Go and help the Pedi man with farming!";
        mission.itemSprite = itemSprite;
        mission.itemName = "Isihlangu";
        waypoints.waypoints.Add(gameObject);
    }
}
