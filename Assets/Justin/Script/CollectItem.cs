using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public bool hasRedPaint, hasBluePaint, hasYellowPaint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PaintSupply"))
        {
            string color = other.gameObject.name; // Use the name to identify the color
            if (color == "RedPaint") hasRedPaint = true;
            if (color == "BluePaint") hasBluePaint = true;
            if (color == "YellowPaint") hasYellowPaint = true;

            Destroy(other.gameObject); // Remove paint from the scene after collection
        }
    }
}
