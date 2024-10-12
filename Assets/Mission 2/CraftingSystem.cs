using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public InventorySystem inventory; // Reference to the InventorySystem
    public Text craftingMessageText; // Reference to the UI Text for crafting messages

    public string[] requiredItems = { "Wood", "Grass", "Stone" }; // Required items
    public int[] requiredQuantities = { 5, 3, 2 }; // Quantities required

    public void CraftHut()
    {
        bool canCraft = true;

        // Check if the player has enough items
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (!inventory.HasEnoughItems(requiredItems[i], requiredQuantities[i]))
            {
                canCraft = false;
                break; 
            }
        }

        
        if (canCraft)
        {
            Debug.Log("Crafting Hut!");
            craftingMessageText.text = " Crafting Hut"; 
            SpawnHut();
        }
        else
        {
            Debug.Log("Can't craft hut, need more items.");
            craftingMessageText.text = "Can't craft hut, need more items."; // Update the message
        }
    }

    void SpawnHut()
    {
        GameObject hutPrefab = Resources.Load<GameObject>("HutPrefab");
        if (hutPrefab != null)
        {
            Instantiate(hutPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("HutPrefab not found in Resources folder!");
        }
    }

}
