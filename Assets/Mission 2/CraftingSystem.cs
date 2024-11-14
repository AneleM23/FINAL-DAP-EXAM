 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       

public class CraftingSystem : MonoBehaviour
{
    public GameObject hutPrefab;
    public InventorySystem inventory; // Reference to the InventorySystem
    public Text craftMessageText; // Reference to the UI Text for crafting messages

    public string[] requiredItems = { "Wood", "Grass", "Stone" }; // Required items
    public int[] requiredQuantities = { 5, 3, 2 }; // Quantities required

    public List<Transform> spawnPoints; // Corrected declaration
    public GameObject craftButton;

    public Transform player; // Reference to the player's transform
    public float requiredDistance = 5f; // Set the distance threshold

    public int craftedHuts = 0;
    bool missionComplete = false;

    void Start()
    {
        craftButton.SetActive(false); // Make sure the craft button starts inactive
    }

    void Update()
    {
        if (craftedHuts == 3 && !missionComplete)
        {
            FindObjectOfType<MissionManager>().CompleteMission(GetComponent<MissionTrigger>().missionName);
            missionComplete = true;
        }

        CheckProximityToSpawnPoints();
    }

    void CheckProximityToSpawnPoints()
    {
        if (spawnPoints.Count == 0)
        {
            craftButton.SetActive(false); // No spawn points left, button stays inactive
            return;
        }

        // Loop through each spawn point to check distance
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (Vector3.Distance(player.position, spawnPoint.position) <= requiredDistance)
            {
                craftButton.SetActive(true); // Player is close enough, show the craft button
                return;
            }
        }

        craftButton.SetActive(false); // If none are close enough, hide the button
    }

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

            // Subtract the required items from the inventory
            for (int i = 0; i < requiredItems.Length; i++)
            {
                inventory.RemoveItems(requiredItems[i], requiredQuantities[i]);
            }

            // Spawn the hut and show the message
            SpawnHut();
            ShowCraftMessage("Hut crafted successfully!");
            craftedHuts++;
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
        int randSpawnPoint = Random.Range(0, spawnPoints.Count); // Get a random spawn point index

        if (hutPrefab != null)
        {
            // Instantiate the hut at the random spawn point's position
            Instantiate(hutPrefab, spawnPoints[randSpawnPoint].position, Quaternion.identity);

            // Deactivate the spawn point GameObject (including all its children)
            spawnPoints[randSpawnPoint].gameObject.SetActive(false);

            // Remove the spawn point from the list
            spawnPoints.RemoveAt(randSpawnPoint);

            // After removing a spawn point, check proximity again
            CheckProximityToSpawnPoints();
        }
        else
        {
            Debug.LogError("HutPrefab not found!");
        }
    }
}
