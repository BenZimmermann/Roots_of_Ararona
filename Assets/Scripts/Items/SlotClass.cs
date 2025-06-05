using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
   [SerializeField] private ItemClass item;
   [SerializeField] public int quantity;


    public SlotClass()
    {
        item = null;
        quantity = 0;
    }

    public SlotClass(ItemClass _item, int _quantity)
    {
        this.item = _item;
        this.quantity = _quantity;
    }
    public bool HasItem()
    {
        return item != null && quantity > 0;
    }

    public ItemClass GetItem()
    {
        return item;
    }
    public int GetQuantity()
    {
        return quantity;
    }
    public void AddQuantity(int _quantity)
    {
        quantity += _quantity;
    }
    public void SubQuantity(int _quantity)
    {
        quantity -= _quantity;
    }
}
