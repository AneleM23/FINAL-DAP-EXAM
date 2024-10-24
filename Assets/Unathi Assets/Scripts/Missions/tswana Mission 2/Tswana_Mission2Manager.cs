using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tswana_Mission2Manager : MonoBehaviour
{
    [SerializeField] TswanaCowManager tswanaMission1;

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
        bool missionCompleted = mission.GetActiveMissions().Exists(m => m.missionName == tswanaMission1.missionTrigger.missionName);

        if (!missionAdded && !missionCompleted)
        {
            SetMissionTrigger();
            missionAdded = true;
        }
    }

    void SetMissionTrigger()
    {
        MissionTrigger mission = gameObject.AddComponent<MissionTrigger>();
        mission.missionName = "Tswana Culture";
        mission.missionDescription = "Go and learn more about Batswana!";
        mission.itemSprite = itemSprite;
        mission.itemName = "Leteisi blanket";
        waypoints.waypoints.Add(gameObject);
    }
}
