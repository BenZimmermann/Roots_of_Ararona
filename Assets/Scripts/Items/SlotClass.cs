using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
   [SerializeField] private ItemClass item;
   [SerializeField] public int quantity;


    // Constructor for SlotClass
    public SlotClass()
    {
        item = null;
        quantity = 0;
    }

    // Constructor for SlotClass with parameters
    public SlotClass(ItemClass _item, int _quantity)
    {
        this.item = _item;
        this.quantity = _quantity;
    }

    // Method to set the item and quantity
    public bool HasItem()
    {
        return item != null && quantity > 0;
    }

    // Method to get the item
    public ItemClass GetItem()
    {
        return item;
    }

    // Method to get the quantity
    public int GetQuantity()
    {
        return quantity;
    }

    //Method to add quantity to the slot
    public void AddQuantity(int _quantity)
    {
        quantity += _quantity;
    }

    // Method to subtract quantity from the slot
    public void SubQuantity(int _quantity)
    {
        quantity -= _quantity;
    }
}
