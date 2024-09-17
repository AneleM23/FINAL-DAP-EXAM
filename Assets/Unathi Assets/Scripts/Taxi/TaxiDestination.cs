using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiDestination : MonoBehaviour
{
    public TaxiTransport taxi;
    public Transform[] destinationArray; // Array of possible destinations
    [SerializeField] private Transform destination;

    public GameObject[] zuluIcons;
    public GameObject[] xhosaIcons;
    public GameObject[] tswanaIcons;
    public GameObject[] swatiIcons;
    public GameObject[] sothoIcons;

    [SerializeField] private int pickDestination;

    void Update()
    {
        // Ensure pickDestination is within valid range and assign the corresponding destination
        if (pickDestination > 0 && pickDestination <= destinationArray.Length)
        {
            destination = destinationArray[pickDestination - 1];
        }

        switch (pickDestination)
        {
            case 1:
                SetToFalse();
                zuluIcons[0].SetActive(true);
                break;
            case 2:
                SetToFalse();
                xhosaIcons[0].SetActive(true);
                break;
            case 3:
                SetToFalse();
                tswanaIcons[0].SetActive(true);
                break;
            case 4:
                SetToFalse();
                swatiIcons[0].SetActive(true);
                break;
            case 5:
                SetToFalse();
                sothoIcons[0].SetActive(true);
                break;
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
    }
}
