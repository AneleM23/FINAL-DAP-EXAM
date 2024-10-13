using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;

    private Dictionary<string, int> items = new Dictionary<string, int>();

    public Text woodText;
    public Text grassText;
    public Text stoneText;

    public int requiredWood = 5;
    public int requiredGrass = 3;
    public int requiredStone = 2;

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

        UpdateUI();
    }

    // Method to remove items from inventory
    public void RemoveItems(string itemName, int quantity)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] -= quantity;

            // Ensure that the quantity does not go below zero
            if (items[itemName] < 0)
            {
                items[itemName] = 0;
            }

            Debug.Log(itemName + " removed: " + quantity);
        }
        else
        {
            Debug.LogWarning("Attempted to remove non-existent item: " + itemName);
        }

        UpdateUI(); // Update the UI after removing items
    }

    private void UpdateUI()
    {
        if (woodText != null)
        {
            int collectedWood = items.ContainsKey("Wood") ? items["Wood"] : 0;
            woodText.text = "Wood: " + collectedWood;
        }

        if (grassText != null)
        {
            int collectedGrass = items.ContainsKey("Grass") ? items["Grass"] : 0;
            grassText.text = "Grass: " + collectedGrass;
        }

        if (stoneText != null)
        {
            int collectedStone = items.ContainsKey("Stone") ? items["Stone"] : 0;
            stoneText.text = "Stone: " + collectedStone;
        }
    }

    // Check if player has enough items for crafting
    public bool HasEnoughItems(string itemName, int requiredQuantity)
    {
        return items.ContainsKey(itemName) && items[itemName] >= requiredQuantity;
    }
}
