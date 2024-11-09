using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static List<string> collectedColors = new List<string>();

    public static void AddColor(string color)
    {
        if (!collectedColors.Contains(color))
        {
            collectedColors.Add(color);
            Debug.Log(color + " added to inventory.");
        }
    }

    public static bool HasColor(string color)
    {
        return collectedColors.Contains(color);
    }
}
