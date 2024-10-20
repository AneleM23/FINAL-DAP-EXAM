using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SwatiMission2 : MonoBehaviour
{
    [SerializeField] SwatiCowManager swatiMission1;

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
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == swatiMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Storytelling";
        mission.missionDescription = "The Swati people have interesting stories to tell!";
        mission.itemSprite = itemSprite;
        mission.itemName = "Lihawu";
        waypoints.waypoints.Add(gameObject);
    }
}
