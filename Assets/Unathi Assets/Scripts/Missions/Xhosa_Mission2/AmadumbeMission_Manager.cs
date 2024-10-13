using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmadumbeMission_Manager : MonoBehaviour
{
    [SerializeField] XhosaCowManager xhosaMission1;

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
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == xhosaMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Help the Farmer!";
        mission.missionDescription = "Help the farmer collect ingredients!";
        mission.itemSprite = itemSprite;
        mission.itemName = "Inxili";
        waypoints.waypoints.Add(gameObject);
        GetComponent<MissionInformation>().missionTrigger = mission;
    }
}
