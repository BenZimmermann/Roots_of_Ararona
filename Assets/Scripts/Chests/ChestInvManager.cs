using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestInventoryManager : MonoBehaviour
{
    //its similar to the inventory manager but for the chest, it manages the items in the chest and updates the UI accordingly.
    [SerializeField] private GameObject slotHolder;

    public List<SlotClass> chestItems = new List<SlotClass>();
    public GameObject[] slots;


    /// <summary>
    /// initializes the chest inventory manager, finds all slots in the slot holder, and refreshes the UI.
    /// </summary>
    public void Start()
    {
        
        slots = new GameObject[slotHolder.transform.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();
    }
    /// <summary>
    /// refreshes the UI of the chest inventory by updating each slot with the current items and their quantities. also adds the item icon and quantity text to the slots if they contain items.
    /// </summary>
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            var image = slots[i].GetComponentsInChildren<Image>()[1];
            var text = slots[i].GetComponentInChildren<TMP_Text>();

            if (i < chestItems.Count && chestItems[i].HasItem())
            {
                image.enabled = true;
                image.sprite = chestItems[i].GetItem().itemIcon;

                if (chestItems[i].GetItem().isStackable)
                    text.text = chestItems[i].GetQuantity().ToString();
                else
                    text.text = "";
            }
            else
            {
                image.enabled = false;
                image.sprite = null;
                text.text = "";
            }
        }
    }
    /// <summary>
    /// adds an item to the chest inventory. if the item already exists and is stackable, it increases the quantity. if there is space in the chest, it creates a new slot for the item.
    /// </summary>
    public bool Add(ItemClass item)
    {
        if (item == null) return false;

        SlotClass existingSlot = Contains(item);
        if (existingSlot != null && item.isStackable)
        {
            existingSlot.AddQuantity(1);
        }
        else
        {
            if (chestItems.Count < slots.Length)
                chestItems.Add(new SlotClass(item, 1));
            else
                return false;
        }

        RefreshUI();
        return true;
    }
    /// <summary>
    /// removes an item from the chest inventory. if the item exists and its quantity is greater than 1, it decreases the quantity by 1.
    /// </summary>

    public bool Remove(ItemClass item)
    {
        SlotClass existingSlot = Contains(item);

        if (existingSlot != null)
        {
            if (existingSlot.GetQuantity() > 1)
                existingSlot.AddQuantity(-1);
            else
                chestItems.Remove(existingSlot);

            RefreshUI();
            return true;
        }

        return false;
    }
    /// <summary>
    /// checks if the chest inventory contains a specific item. if it finds the item, it returns the corresponding slot; otherwise, it returns null.
    /// </summary>
    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in chestItems)
        {
            if (slot.GetItem() == item)
                return slot;
        }
        return null;
    }

    public List<SlotClass> GetItems() => chestItems;
}