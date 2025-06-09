using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mission_Braai : MonoBehaviour
{
    public AfrikaansBraaiMission braaiMission;

    private bool isPlayerNear;
    private Transform player;
    public float interactionRange = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        isPlayerNear = Vector3.Distance(transform.position, player.position) <= interactionRange;

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            braaiMission.StartBraai();
        }
    }
}

