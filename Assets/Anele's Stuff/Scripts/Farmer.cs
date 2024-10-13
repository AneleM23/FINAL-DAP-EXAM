using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void StartMission()
    {
        Mission_Amadumbe amadumbe = FindObjectOfType<Mission_Amadumbe>();
        if (amadumbe != null)
        {
            amadumbe.StartMission();
        }
    }
}
