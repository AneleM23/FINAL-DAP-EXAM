using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsongaMission2 : MonoBehaviour
{
    [SerializeField] TsongaCowManager tsongaMission1;

    [SerializeField] MissionManager mission;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] Sprite itemSprite;

    bool missionAdded;

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == tsongaMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Tsonga culture!";
        mission.missionDescription = "See how much knowledge you have about the Tsonga culture!";
        mission.itemSprite = itemSprite;
        mission.itemName = "Xibhelani";
        waypoints.waypoints.Add(gameObject);
    }
}
