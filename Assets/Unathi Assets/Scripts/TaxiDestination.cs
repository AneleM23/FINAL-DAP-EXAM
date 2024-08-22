using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiDestination : MonoBehaviour
{
    public TaxiTransport taxi;
    public Transform[] destinationArray; // Array of possible destinations
    private Transform destination;

    [SerializeField] private int pickDestination = 1;

    void Update()
    {
        // Ensure pickDestination is within valid range and assign the corresponding destination
        if (pickDestination > 0 && pickDestination <= destinationArray.Length)
        {
            destination = destinationArray[pickDestination - 1];
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
            taxi.TransportPlayer(destination); // Transport the player to the selected destination
        }
        else
        {
            Debug.LogWarning("Destination not set or out of range!");
        }
    }
}
