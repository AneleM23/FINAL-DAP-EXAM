using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2_Venda : MonoBehaviour
{
    [SerializeField] VendaCowManager vendaMission1;

    [SerializeField] MissionManager mission;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] Sprite itemSprite;

    bool missionAdded;

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == vendaMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Water Spirit";
        mission.missionDescription = "Learn about the Venda people's beliefs.";
        mission.itemSprite = itemSprite;
        mission.itemName = "Ndilo";
        waypoints.waypoints.Add(gameObject);
    }
}
