using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> collectedItems = new List<Item>(); // List to store collected items
    public Transform itemsParent; // Parent transform where item images will be displayed
    public GameObject itemImagePrefab; // Prefab for item image UI

    // Method to add an item to the inventory
    public void AddItem(Item newItem)
    {
        collectedItems.Add(newItem);

        // Instantiate the item image in the UI
        GameObject newItemImage = Instantiate(itemImagePrefab, itemsParent);
        newItemImage.GetComponent<Image>().sprite = newItem.itemImage;
        newItemImage.GetComponentInChildren<Text>().text = newItem.itemName;
    }
}

