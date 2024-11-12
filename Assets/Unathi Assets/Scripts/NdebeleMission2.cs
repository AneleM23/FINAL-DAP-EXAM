using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NdebeleMission2 : MonoBehaviour
{
    [SerializeField] NdebeleCowManager ndebeleMission1;

    [SerializeField] MissionManager mission;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] Sprite itemSprite;

    bool missionAdded;

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == ndebeleMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Ndebele culture!";
        mission.missionDescription = "See how much knowledge you have about the Ndebele culture!";
        mission.itemSprite = itemSprite;
        mission.itemName = "";
        waypoints.waypoints.Add(gameObject);
    }
}
