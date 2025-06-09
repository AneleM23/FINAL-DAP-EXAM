using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AfrikaansBraaiMission : MonoBehaviour
{
    public Text braaiUI; // Assign this in the Unity Inspector
    public float flipTime = 3f; // Time player has to flip
    private int flipsDone = 0;
    private bool canFlip = false;
    private float flipTimer = 0f;

    void Update()
    {
        if (canFlip)
        {
            flipTimer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.E))
            {
                FlipMeat();
            }

            if (flipTimer >= flipTime)
            {
                MissionFail();
            }
        }
    }

    public void StartMission()
    {
        StartMission();
    }

    public void StartBraai()
    {
        flipsDone = 0;
        StartCoroutine(BraaiRoutine());
    }

    IEnumerator BraaiRoutine()
    {
        for (int i = 0; i < 6; i++) // 3 times per side
        {
            braaiUI.text = "🔥 Flip die vleis! Druk E!";
            canFlip = true;
            flipTimer = 0f;

            yield return new WaitUntil(() => !canFlip); // Wait until flipped or failed
            yield return new WaitForSeconds(0.5f); // Delay between flips
        }

        braaiUI.text = "✅ Jy't dit gemaak! Vleis is perfek gebraai!";
    }

    void FlipMeat()
    {
        canFlip = false;
        braaiUI.text = $"✅ Omgedraai {++flipsDone}/6";
    }

    void MissionFail()
    {
        canFlip = false;
        braaiUI.text = "🔥 Die vleis het gebrand! Sending gefaal.";
        StopAllCoroutines();
    }
}
