using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public InventorySystem inventory; // Reference to the InventorySystem
    public Text craftMessageText; // Reference to the UI Text for crafting messages

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
                Debug.Log("Not enough " + requiredItems[i]);
                break; 
            }
        }

        
        if (canCraft)
        {
            Debug.Log("Crafting Hut!");
            SpawnHut();
            ShowCraftMessage("Hut crafted successfully!");
        }
        else
        {
            ShowCraftMessage("Not enough materials to craft the hut.");
        }
    }

    void ShowCraftMessage(string message)
    {
        // Display the message
        craftMessageText.text = message;
        craftMessageText.gameObject.SetActive(true); // Show the text

        // Hide the message after a delay
        Invoke("HideCraftMessage", 2f); // Hides the message after 2 seconds
    }

    void HideCraftMessage()
    {
        craftMessageText.gameObject.SetActive(false); // Hide the text again
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
