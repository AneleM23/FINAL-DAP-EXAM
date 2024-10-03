using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;

    private Dictionary<string, int> items = new Dictionary<string, int>();


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName, int quantity)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] += quantity;
        }
        else
        {
            items.Add(itemName, quantity);
        }

        Debug.Log("Collected: " + itemName + " x " + quantity);
    }

    // Check if player has enough items for crafting
    public bool HasEnoughItems(string itemName, int requiredQuantity)
    {
        return items.ContainsKey(itemName) && items[itemName] >= requiredQuantity;
    }
}
