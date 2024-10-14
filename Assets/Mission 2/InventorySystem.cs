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

        UpdateUI();
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

    public void RemoveItem(string itemName, int quantity)
    {
        if (items.ContainsKey(itemName) && items[itemName] >= quantity)
        {
            items[itemName] -= quantity;

            // Ensure items don't go negative
            if (items[itemName] < 0)
            {
                items[itemName] = 0;
            }
        }

        UpdateUI();  // Update the UI after items are used
    }

    private void UpdateUI()
    {
        if (woodText != null)
        {
            int collectedWood = items.ContainsKey("Wood") ? items["Wood"] : 0;
            woodText.text = "Wood: " + collectedWood + " / " + requiredWood;
        }

        if (grassText != null)
        {
            int collectedGrass = items.ContainsKey("Grass") ? items["Grass"] : 0;
            grassText.text = "Grass: " + collectedGrass + " / " + requiredGrass;
        }

        if (stoneText != null)
        {
            int collectedStone = items.ContainsKey("Stone") ? items["Stone"] : 0;
            stoneText.text = "Stone: " + collectedStone + " / " + requiredStone;
        }
    }

    // Check if player has enough items for crafting
    public bool HasEnoughItems(string itemName, int requiredQuantity)
    {
        return items.ContainsKey(itemName) && items[itemName] >= requiredQuantity;
    }
}
