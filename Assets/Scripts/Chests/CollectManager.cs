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
    [SerializeField] private AudioClip Collect;
    private AudioSource audioSource;

    public ChestInventoryManager chestInventoryManager; // Referenz zum ChestInventoryManager
    public InventoryManager inventoryManager; // Referenz zum InventoryManager

    public List<RewardEntry> Rewards = new List<RewardEntry>();  // <-- Jetzt eine Liste

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        chestInventoryManager = FindObjectOfType<ChestInventoryManager>();
        audioSource = GetComponent<AudioSource>();
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
    public void PlaySound()
    {
        audioSource.clip = Collect;
        audioSource.Play();
    }

    public void Add()
    {
        if (inventoryManager != null && Rewards != null && Rewards.Count > 0)
        {
            foreach (RewardEntry reward in Rewards)
            {
                if (reward.item == null || reward.amount <= 0) continue;

                Debug.Log($"Versuche, {reward.amount}x {reward.item.itemName} hinzuzuf�gen");

                for (int i = 0; i < reward.amount; i++)
                {
                    bool success = inventoryManager.Add(reward.item);

                    if (!success)
                    {
                        Debug.Log($"Inventar voll oder Item nicht stapelbar: {reward.item.itemName} bei St�ck {i + 1}");
                        break;
                    }
                }
            }

            Del();
        }
        else
        {
            Debug.Log("Keine Items in Rewards oder Inventar nicht verf�gbar.");
        }
    }
}
