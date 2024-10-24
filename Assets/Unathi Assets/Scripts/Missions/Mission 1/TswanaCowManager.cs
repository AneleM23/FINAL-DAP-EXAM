using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TswanaCowManager : MonoBehaviour
{
    [SerializeField] MissionManager missionManager;

    public MissionTrigger missionTrigger;

    [SerializeField] Transform forest;

    [SerializeField] Transform kraal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool missionCompleted = missionManager.GetCurrentMissionNames().Contains(missionTrigger.missionName);

        if (missionCompleted)
        {
            transform.position = forest.position;
        }
        else
        {
            transform.position = kraal.position;
        }
    }
}
