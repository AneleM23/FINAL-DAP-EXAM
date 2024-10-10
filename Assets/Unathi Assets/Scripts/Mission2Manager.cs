using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2Manager : MonoBehaviour
{
    [SerializeField] ZuluCowManager zuluMission1;

    [SerializeField] MissionManager mission;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] Sprite itemSprite;

    bool missionAdded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == zuluMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded=true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Boss Fight!";
        mission.missionDescription = "The Zulu chief wants you gone from his village!";
        mission.itemSprite = itemSprite;
        mission.itemName = "Isihlangu";
        waypoints.waypoints.Add(gameObject);
    }
}
