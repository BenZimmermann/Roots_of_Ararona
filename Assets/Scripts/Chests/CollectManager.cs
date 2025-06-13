using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RewardEntry
{
    public ItemClass item;
    public int amount = 1;
}
public class CollectManager : MonoBehaviour
{
    public ChestInventoryManager chestInventoryManager; // Referenz zum ChestInventoryManager
    public InventoryManager inventoryManager; // Referenz zum InventoryManager

    public List<RewardEntry> Rewards = new List<RewardEntry>();  // <-- Jetzt eine Liste

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        chestInventoryManager = FindObjectOfType<ChestInventoryManager>();
    }

    public void CollectAll()
    {
        Debug.Log("Alles eingesammelt");
        Add();
        chestInventoryManager.RefreshUI();
        inventoryManager.RefreshUI();

    }

    public void Del()
    {
        chestInventoryManager.chestItems.Clear();
        Rewards.Clear();
    }

    public void Add()
    {
        if (inventoryManager != null && Rewards != null && Rewards.Count > 0)
        {
            foreach (RewardEntry reward in Rewards)
            {
                if (reward.item == null || reward.amount <= 0) continue;

                Debug.Log($"Versuche, {reward.amount}x {reward.item.itemName} hinzuzufügen");

                for (int i = 0; i < reward.amount; i++)
                {
                    bool success = inventoryManager.Add(reward.item);

                    if (!success)
                    {
                        Debug.Log($"Inventar voll oder Item nicht stapelbar: {reward.item.itemName} bei Stück {i + 1}");
                        break;
                    }
                }
            }

            Del();
        }
        else
        {
            Debug.LogWarning("Keine Items in Rewards oder Inventar nicht verfügbar.");
        }
    }
}
