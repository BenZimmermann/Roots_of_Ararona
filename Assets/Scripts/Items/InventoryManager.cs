
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder; //21
    [SerializeField] private GameObject slotHand;   //2
    [SerializeField] private GameObject slotArmor;  //67
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public List<SlotClass> itemsInventory = new List<SlotClass>();   //1
    public List<SlotClass> itemsHand = new List<SlotClass>();   //1
    public List<SlotClass> itemsArmor = new List<SlotClass>();   //1

    
    private GameObject[] slots;
    private GameObject[] handSlots;
    private GameObject[] armorSlots;


    public void Start()
    {
        //inv Slots
        slots = new GameObject[slotHolder.transform.childCount];

        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
                slots[i] = slotHolder.transform.GetChild(i).gameObject;
         }
        // Hand-Slots
        handSlots = new GameObject[slotHand.transform.childCount];
        for (int i = 0; i < slotHand.transform.childCount; i++)
        {
            handSlots[i] = slotHand.transform.GetChild(i).gameObject;
        }

        // Armor-Slots
        armorSlots = new GameObject[slotArmor.transform.childCount];
        for (int i = 0; i < slotArmor.transform.childCount; i++)
        {
            armorSlots[i] = slotArmor.transform.GetChild(i).gameObject;
        }

        RefreshUI();

        Add(itemToAdd);
        Remove(itemToRemove);
    }
    public void RefreshUI()
    {
        UpdateRefreshUI(slots, itemsInventory);
        UpdateRefreshUI(handSlots, itemsHand);
        UpdateRefreshUI(armorSlots, itemsArmor);
    }
    public void UpdateRefreshUI(GameObject[] SGroup, List<SlotClass> items)
    {
    
        for (int i = 0; i < SGroup.Length; i++)
        {
           // if (SGroup[i].ItemClass.isInInventory == false) return; // Check if the item is in the inventory before updating UI
            var image = SGroup[i].GetComponentsInChildren<Image>()[1];
            var text = SGroup[i].GetComponentInChildren<TMP_Text>();
           // SGroup[i].isInInventory = true; // Ensure the slot is marked as in inventory
            if (i < items.Count && items[i].HasItem())
            {
                image.enabled = true;
                image.sprite = items[i].GetItem().itemIcon;

                if (items[i].GetItem().isStackable)
                    text.text = items[i].GetQuantity().ToString();
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
    public bool Add(ItemClass item, ItemSlotType itemSlotType = ItemSlotType.Backpack)
    {
        if (item == null) return false;

        SlotClass slot = Contains(item, itemSlotType);
        switch (itemSlotType)
        {
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
            case ItemSlotType.Hands:

                if (temp != null)
                {
                    if (temp.GetQuantity() >= 1)
                        temp.AddQuantity(-1);
                    else
                    {
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

            case ItemSlotType.Hands:
                foreach (SlotClass slot in itemsHand)
                {
                    if (slot.GetItem() == item)
                    {
                        return slot;
                    }
                }
                return null;
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

public enum ItemSlotType
{
    Backpack,
    Hands,
    Armor
}