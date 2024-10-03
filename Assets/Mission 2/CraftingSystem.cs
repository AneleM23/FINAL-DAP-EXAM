using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{

    public InventorySystem inventory;

    public string[] requiredItems = { "Wood", "Grass" };
    public int[] requiredQuantities = { 5, 3 };

    public void CraftHut()
    {
        bool canCraft = true;

        // Check if the player has enough of each required item
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
            // Place the hut in the scene (trigger model spawn or animation)
            SpawnHut();
        }
        else
        {
            Debug.Log("Cannot craft the hut.");
        }
    }

    // Spawns the hut in the scene
    void SpawnHut()
    {
        // Example: Instantiate a prefab of the hut
        GameObject hutPrefab = Resources.Load<GameObject>("HutPrefab");
        Instantiate(hutPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
