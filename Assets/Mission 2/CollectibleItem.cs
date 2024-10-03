using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public string itemName; // Name of the item (e.g., wood, grass)
    public int itemQuantity = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventorySystem.instance.AddItem(itemName, itemQuantity);
            Destroy(gameObject); // Remove item from the scene after collection
        }
    }
 
}
