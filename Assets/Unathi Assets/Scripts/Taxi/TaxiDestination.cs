using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiDestination : MonoBehaviour
{
    [SerializeField] TaxiUI taxiUI;

    private float dpadCooldown = 0.3f;
    private float lastDpadTime;

    public TaxiTransport taxi;
    public Transform[] destinationArray; // Array of possible destinations
    [SerializeField] private Transform destination;

    public GameObject[] zuluIcons;
    public GameObject[] xhosaIcons;
    public GameObject[] tswanaIcons;
    public GameObject[] swatiIcons;
    public GameObject[] sothoIcons;
    public GameObject[] pediIcons;
    public GameObject[] vendaIcons;
    public GameObject[] tsongaIcons;
    public GameObject[] afrikaansIcons;
    public GameObject[] ndebeleIcons;

    [SerializeField] private int pickDestination;

    void Update()
    {
        // Handle destination logic
        if (pickDestination > 0 && pickDestination <= destinationArray.Length)
        {
            destination = destinationArray[pickDestination - 1];
        }

        // D-Pad Input with cooldown
        float dpad = Input.GetAxisRaw("DPadHorizontal");

        if (taxiUI.taxiUI.activeInHierarchy && Time.time > lastDpadTime + dpadCooldown)
        {
            if (dpad > 0.5f)
            {
                IncreasePickDestination();
                lastDpadTime = Time.time;
            }
            else if (dpad < -0.5f)
            {
                DecreasePickDestination();
                lastDpadTime = Time.time;
            }
        }

        // Show relevant icon
        switch (pickDestination)
        {
            case 1: SetToFalse(); zuluIcons[0].SetActive(true); break;
            case 2: SetToFalse(); xhosaIcons[0].SetActive(true); break;
            case 3: SetToFalse(); tswanaIcons[0].SetActive(true); break;
            case 4: SetToFalse(); swatiIcons[0].SetActive(true); break;
            case 5: SetToFalse(); sothoIcons[0].SetActive(true); break;
            case 6: SetToFalse(); pediIcons[0].SetActive(true); break;
            case 7: SetToFalse(); afrikaansIcons[0].SetActive(true); break;
            case 8: SetToFalse(); vendaIcons[0].SetActive(true); break;
            case 9: SetToFalse(); ndebeleIcons[0].SetActive(true); break;
            case 10: SetToFalse(); tsongaIcons[0].SetActive(true); break;
        }

        if (taxiUI.taxiUI.activeInHierarchy && Input.GetButtonDown("Submit"))
        {
            PickDestination();
        }
    }

    public void IncreasePickDestination()
    {
        if (pickDestination < destinationArray.Length)
        {
            pickDestination++;
        }
    }

    public void DecreasePickDestination()
    {
        if (pickDestination > 1)
        {
            pickDestination--;
        }
    }

    public void PickDestination()
    {
        if (destination != null)
        {
            StartCoroutine(taxi.TransportPlayer(destination)); // Transport the player to the selected destination
        }
        else
        {
            Debug.LogWarning("Destination not set or out of range!");
        }
    }

    void SetToFalse()
    {
        for (int i = 0; i < zuluIcons.Length; i++)
        {
            zuluIcons[i].SetActive(false);
        }

        for (int i = 0; i < xhosaIcons.Length; i++)
        {
            xhosaIcons[i].SetActive(false);
        }

        for (int i = 0; i < tswanaIcons.Length; i++)
        {
            tswanaIcons[i].SetActive(false);
        }

        for (int i = 0; i < swatiIcons.Length; i++)
        {
            swatiIcons[i].SetActive(false);
        }

        for (int i = 0; i < sothoIcons.Length; i++)
        {
            sothoIcons[i].SetActive(false);
        }

        for (int i = 0; i < pediIcons.Length; i++)
        {
            pediIcons[i].SetActive(false);
        }

        for (int i = 0; i < afrikaansIcons.Length; i++)
        {
            afrikaansIcons[i].SetActive(false);
        }

        for (int i = 0; i < vendaIcons.Length; i++)
        {
            vendaIcons[i].SetActive(false);
        }

        for (int i = 0; i < ndebeleIcons.Length; i++)
        {
            ndebeleIcons[i].SetActive(false);
        }

        for (int i = 0; i < tsongaIcons.Length; i++)
        {
            tsongaIcons[i].SetActive(false);
        }
    }
}
