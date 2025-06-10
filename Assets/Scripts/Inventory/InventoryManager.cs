
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    // Inventory Slots for Inventpry, Hand, and Armor
    [SerializeField] private GameObject slotHolder; //21
    [SerializeField] private GameObject slotHand;   //2
    [SerializeField] private GameObject slotArmor;  //4
    // Items to add and remove for testing purposes
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    // Inventory Lists for different item types
    public List<SlotClass> itemsInventory = new List<SlotClass>();   //1
    public List<SlotClass> itemsHand = new List<SlotClass>();   //1
    public List<SlotClass> itemsArmor = new List<SlotClass>();   //1

    // Array to hold the slot GameObjects for Inventory, Hand, and Armor
    private GameObject[] slots;
    private GameObject[] handSlots;
    private GameObject[] armorSlots;


    public void Start()
    {
        //inv Slots
        slots = new GameObject[slotHolder.transform.childCount];
        // Populate the slots array with the child GameObjects of slotHolder
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
                slots[i] = slotHolder.transform.GetChild(i).gameObject;
         }
        // Hand-Slots
        handSlots = new GameObject[slotHand.transform.childCount];
        // Populate the handSlots array with the child GameObjects of slotHand
        for (int i = 0; i < slotHand.transform.childCount; i++)
        {
            handSlots[i] = slotHand.transform.GetChild(i).gameObject;
        }
        // Armor-Slots
        armorSlots = new GameObject[slotArmor.transform.childCount];
        // Populate the armorSlots array with the child GameObjects of slotArmor
        for (int i = 0; i < slotArmor.transform.childCount; i++)
        {
            armorSlots[i] = slotArmor.transform.GetChild(i).gameObject;
        }

        // Initialize the UI
        RefreshUI();

        // Add items for testing if there is one 
        Add(itemToAdd);
        Remove(itemToRemove);
    }
    private void RefreshUI()
    {
        // Update the UI for Inventory, Hand, and Armor slots
        UpdateRefreshUI(slots, itemsInventory);
        UpdateRefreshUI(handSlots, itemsHand);
        UpdateRefreshUI(armorSlots, itemsArmor);
    }

    public void UpdateRefreshUI(GameObject[] SGroup, List<SlotClass> items)
    {
        //Check if the SGroup is null or empty
        for (int i = 0; i < SGroup.Length; i++)
        {
            //get the child Image and Text components of the slot GameObject
            var image = SGroup[i].GetComponentsInChildren<Image>()[1];
            var text = SGroup[i].GetComponentInChildren<TMP_Text>();
            // Check if the index is within the bounds of the items list
            if (i < items.Count && items[i].HasItem())
            {
                // If the item exists, enable the image and set the sprite and text
                image.enabled = true;
                image.sprite = items[i].GetItem().itemIcon;

                // Check if the item is stackable and set the text accordingly
                if (items[i].GetItem().isStackable)
                    text.text = items[i].GetQuantity().ToString();
                //if not stackable, set the text to empty
                else
                    text.text = "";
            }
            // If the index is out of bounds or the item does not exist, disable the image and clear the text
            else
            {
                image.enabled = false;
                image.sprite = null;
                text.text = "";
            }
        }
    }
    public bool Add(ItemClass item, ItemSlotType itemSlotType = ItemSlotType.Backpack)
    {
        //chek if an item is in the item slot
        if (item == null) return false;
        // Check if the item is already in the inventory, hand, or armor slots
        SlotClass slot = Contains(item, itemSlotType);
        switch (itemSlotType)
        {
            // Check the item slot type and add the item accordingly
            case ItemSlotType.Hands:
                if (slot != null && slot.GetItem().isStackable)
                    slot.AddQuantity(1);

                else
                {
                    if (itemsHand.Count <= slots.Length)
                        itemsHand.Add(new SlotClass(item, 1));
                    else
                        return false;
                }
                break;
            // Check the item slot type and add the item accordingly
            case ItemSlotType.Armor:
               
                if (slot != null && slot.GetItem().isStackable)
                    slot.AddQuantity(1);

                else
                {
                    if (itemsArmor.Count <= slots.Length)
                        itemsArmor.Add(new SlotClass(item, 1));
                    else
                        return false;
                }
                break;
            // Default case for Backpack items => the main inventory
            default:
                
                if (slot != null && slot.GetItem().isStackable)
                    slot.AddQuantity(1);

                else
                {
                    if (itemsInventory.Count <= slots.Length)
                        itemsInventory.Add(new SlotClass(item, 1));
                    else
                        return false;
                }
                break;
        }
        
     //   items.Add(item);   

        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item, ItemSlotType itemSlotType = ItemSlotType.Backpack)
    {
        SlotClass temp = Contains(item, itemSlotType);

        switch (itemSlotType)
        {
            // Check the item slot type and remove the item accordingly
            case ItemSlotType.Hands:

                if (temp != null)
                {
                    // If the item has a quantity greater than or equal to 1, reduce the quantity by 1
                    if (temp.GetQuantity() >= 1)
                        temp.AddQuantity(-1);
                    else
                    {
                        // If the quantity is 0, find the slot in itemsHand that contains the item and remove it
                        SlotClass slotToRemove = new SlotClass();
                        foreach (SlotClass slot in itemsHand)
                        {
                            if (slot.GetItem() == item)
                            {
                                slotToRemove = slot;
                                break;
                            }
                        }
                        itemsHand.Remove(slotToRemove);
                    }
                }
                else
                {
                    return false;
                }
                break;
            // Check the item slot type and remove the item accordingly
            case ItemSlotType.Armor:
                
                if (temp != null)
                {
                    if (temp.GetQuantity() >= 1)
                        temp.AddQuantity(-1);
                    else
                    {
                        SlotClass slotToRemove = new SlotClass();
                        foreach (SlotClass slot in itemsArmor)
                        {
                            if (slot.GetItem() == item)
                            {
                                slotToRemove = slot;
                                break;
                            }
                        }
                        itemsArmor.Remove(slotToRemove);
                    }
                }
                else
                {
                    return false;
                }
                break;
            // Default case for Backpack items => the main inventory
            default:
                if (temp != null)
                {
                    if (temp.GetQuantity() >= 1)
                        temp.AddQuantity(-1);
                    else
                    {
                        SlotClass slotToRemove = new SlotClass();
                        foreach (SlotClass slot in itemsInventory)
                        {
                            if (slot.GetItem() == item)
                            {
                                slotToRemove = slot;
                                break;
                            }
                        }
                        itemsInventory.Remove(slotToRemove);
                    }
                }
                else
                {
                    return false;
                }
                break;
        }

        //   items.Remove(item);
        
        RefreshUI();
        return true;
    }
    public SlotClass Contains(ItemClass item, ItemSlotType itemSlotType = ItemSlotType.Backpack)
    {
        switch (itemSlotType)
        {
            // Check if the item exists and search for the item accordingly
            case ItemSlotType.Hands:
                foreach (SlotClass slot in itemsHand)
                {
                    // Check if the item in the slot matches the item being searched for
                    if (slot.GetItem() == item)
                    {
                        return slot;
                    }
                }
                return null;
            // Check if the item exists and search for the item accordingly
            case ItemSlotType.Armor:
                foreach (SlotClass slot in itemsArmor)
                {
                    if (slot.GetItem() == item)
                    {
                        return slot;
                    }
                }
                return null;
            default:
                // Check if the item exists and search for the item accordingly
                foreach (SlotClass slot in itemsInventory)
                {
                    if (slot.GetItem() == item)
                    {
                        return slot;
                    }
                }
                return null;
        }


    }
}

// enum to define the type of item slot
public enum ItemSlotType
{
    Backpack,
    Hands,
    Armor
}