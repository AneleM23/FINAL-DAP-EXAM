using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;         // Name of the item
    public Sprite itemImage;        // Image representing the item

    // Constructor to initialize the inventory item
    public Item(string name, Sprite image)
    {
        itemName = name;
        itemImage = image;
    }
}


