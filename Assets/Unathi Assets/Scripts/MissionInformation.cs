using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInformation : MonoBehaviour
{
    [SerializeField ] MissionTrigger missionTrigger;

    public string missionName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        missionName = missionTrigger.missionName;
    }
}
