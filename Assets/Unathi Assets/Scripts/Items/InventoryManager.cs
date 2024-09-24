using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> collectedItems = new List<Item>(); // List to store collected items
    public Transform itemsParent; // Parent transform where item images will be displayed
    public GameObject itemImagePrefab; // Prefab for item image UI

    [SerializeField] GameObject missionCompleteUI;

    // Method to add an item to the inventory
    public IEnumerator AddItem(Item newItem)
    {
        collectedItems.Add(newItem);

        missionCompleteUI.SetActive(true);

        // Instantiate the item image in the UI
        GameObject newItemImage = Instantiate(itemImagePrefab, itemsParent);
       GameObject itemImageUI = Instantiate(itemImagePrefab, missionCompleteUI.transform);

        newItemImage.GetComponent<Image>().sprite = newItem.itemImage;
        newItemImage.GetComponentInChildren<Text>().text = newItem.itemName;

        itemImageUI.GetComponent<Image>().sprite = newItem.itemImage;
        itemImageUI.GetComponentInChildren<Text>().text = newItem.itemName;

        yield return new WaitForSeconds(5);

        Destroy(itemImageUI);

        missionCompleteUI.SetActive(false);
    }

    IEnumerator DeleteUI()
    {
        yield return new WaitForSeconds(5);


    }
}

