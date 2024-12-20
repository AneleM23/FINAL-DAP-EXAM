using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    public Transform camRig;

    public Transform battlePos;
    public Transform camBattlePos;
    public Transform camNormalPos;

    public GameObject battleCanvas;
    public GameObject normalCanvas;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle()
    {
        player.position = battlePos.position;
        player.rotation = battlePos.rotation;
        player.gameObject.GetComponent<MyPlayerController>().enabled = false;
        player.gameObject.GetComponentInChildren<ThirdPersonCamera>().enabled = false;

        cam.SetParent(null);
        cam.position = camBattlePos.position;
        cam.rotation = camBattlePos.rotation;

        battleCanvas.SetActive(true);
        normalCanvas.SetActive(false);

        FindObjectOfType<BattleManager>().missionActive = true;
    }

    public void EndBattle()
    {
        player.gameObject.GetComponent<MyPlayerController>().enabled = true;
        player.gameObject.GetComponentInChildren<ThirdPersonCamera>().enabled = true;

        cam.SetParent(camRig.transform);
        cam.position = camNormalPos.position;
        cam.rotation = camNormalPos.rotation;

        battleCanvas.SetActive(false);
        normalCanvas.SetActive(true);

        FindObjectOfType<BattleManager>().missionActive = false;
    }
}
