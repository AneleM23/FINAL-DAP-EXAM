using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInformation : MonoBehaviour
{
    public MissionTrigger missionTrigger;

    public string missionName;

    public bool canCollectCow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (missionTrigger != null) 
        missionName = missionTrigger.missionName;
    }
}
