using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestInventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder; // Container mit UI-Slots für die Truhe

    public List<SlotClass> chestItems = new List<SlotClass>(); // Inhalt der Truhe
    public GameObject[] slots;

    public void Start()
    {
        // Slots initialisieren
        slots = new GameObject[slotHolder.transform.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();
    }

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

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in chestItems)
        {
            if (slot.GetItem() == item)
                return slot;
        }
        return null;
    }

    public List<SlotClass> GetItems() => chestItems; // Für Transfer zwischen Spielerinventar
}


//auf item klicken
//item wird aus truhe gelöscht => sprite wird auf null gesetzt, trxt wird auf null gesetzt
//item wird wie gehabt in inventar eingefügt
//beides sollte auch umgekehrt funktionieren

//spieler in der nähe && spieler drückt f => inventar und truhe öffnen
//wenn der spieler mit f soll das inventar und die truhe wirder geschlossen werden
//nun soll sich der spieler frei bewegen können