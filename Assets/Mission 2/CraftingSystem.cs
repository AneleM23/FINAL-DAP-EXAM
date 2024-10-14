using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public InventorySystem inventory; // Reference to the InventorySystem
    public Text craftMessageText; // Reference to the UI Text for crafting messages
    public Text hutCountText; // Reference to the UI Text showing the number of huts built

    public string[] requiredItems = { "Wood", "Grass", "Stone" }; // Required items
    public int[] requiredQuantities = { 5, 3, 2 }; // Quantities required

    public GameObject hutPrefab; // Hut prefab reference (assigned in the Inspector)
    public Transform[] hutSpawnPoints; // Array of spawn points for huts

    private int hutsBuilt = 0; // Track how many huts have been built
    private int maxHuts = 3; // The goal is to craft 3 huts

    void Start()
    {
        UpdateHutCountUI(); // Initialize UI with starting value (Hut 0/3)
    }

    public void CraftHut()
    {
        if (hutsBuilt >= maxHuts)
        {
            ShowCraftMessage("All 3 huts have been built. Mission Complete!");
            return; // Prevent crafting more huts
        }

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
            ShowCraftMessage("Hut crafted successfully!");
            SpawnHut();

            // Deduct the required items from the inventory
            for (int i = 0; i < requiredItems.Length; i++)
            {
                inventory.RemoveItem(requiredItems[i], requiredQuantities[i]);
            }

            hutsBuilt++; // Increase the count of huts built
            UpdateHutCountUI(); // Update the UI to reflect hut progress
        }
        else
        {
            ShowCraftMessage("Not enough materials to craft the hut.");
        }
    }

    // Show a message in the UI
    void ShowCraftMessage(string message)
    {
        craftMessageText.text = message;
        craftMessageText.gameObject.SetActive(true); // Show the text

        // Hide the message after a delay
        Invoke("HideCraftMessage", 2f); // Hides the message after 2 seconds
    }

    void HideCraftMessage()
    {
        craftMessageText.gameObject.SetActive(false); // Hide the text again
    }

    // Update the UI to show the number of huts built in "Hut X/3" format
    void UpdateHutCountUI()
    {
        if (hutCountText != null)
        {
            hutCountText.text = "Hut " + hutsBuilt + " / " + maxHuts;
        }
    }

    // Spawn a hut at a predefined spawn point
    void SpawnHut()
    {
        if (hutPrefab != null && hutsBuilt < hutSpawnPoints.Length)
        {
            // Spawn the hut at the next spawn point
            Vector3 spawnPosition = hutSpawnPoints[hutsBuilt].position;
            Instantiate(hutPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Hut spawned successfully at " + spawnPosition);
        }
        else
        {
            Debug.LogError("Hut prefab or spawn points missing! Check the setup in the Inspector.");
        }
    }
}
