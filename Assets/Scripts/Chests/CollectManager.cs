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
    //audio
    [SerializeField] private AudioClip Collect;
    private AudioSource audioSource;

    // References to other managers such as InventoryManager and ChestInventoryManager
    public ChestInventoryManager chestInventoryManager; 
    public InventoryManager inventoryManager;
    // This list holds the rewards that can be collected from the chest
    public List<RewardEntry> Rewards = new List<RewardEntry>();  

    void Start()
    {
        // Initialize references to InventoryManager and ChestInventoryManager
        inventoryManager = FindObjectOfType<InventoryManager>();
        chestInventoryManager = FindObjectOfType<ChestInventoryManager>();
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// button to collect all items from the chest and transfer them to the player's inventory.
    /// </summary>
    public void CollectAll()
    {
        Debug.Log("Alles eingesammelt");
        //calls the Add method to transfer items from the chest to the player's inventory
        Add();
        //refreshes the UI of both the chest and the inventory to reflect the changes
        chestInventoryManager.RefreshUI();
        inventoryManager.RefreshUI();

    }
    /// <summary>
    /// deletes the chest items and rewards after collection. to prevent them from being collected again.
    /// </summary>
    public void Del()
    {
        // Clear the chest items and rewards after collection
        chestInventoryManager.chestItems.Clear();
        Rewards.Clear();
    }
    /// <summary>
    /// Plays a sound when items are collected from the chest.
    /// </summary>
    public void PlaySound()
    {
        audioSource.clip = Collect;
        audioSource.Play();
    }
    /// <summary>
    /// adds the items from the Rewards list to the player's inventory.
    /// </summary>
    public void Add()
    {
        // Check if the inventory manager and rewards list are not null and contain items
        if (inventoryManager != null && Rewards != null && Rewards.Count > 0)
        {
            //adds every item in the Rewards list to the player's inventory
            //KI begin
            foreach (RewardEntry reward in Rewards)
            {
                // Check if the item is valid and has a positive amount
                if (reward.item == null || reward.amount <= 0) continue;
            //KI end
                Debug.Log($"Versuche, {reward.amount}x {reward.item.itemName} hinzuzufügen");
                // Check if the item can be added to the inventory
                for (int i = 0; i < reward.amount; i++)
                {
                    bool success = inventoryManager.Add(reward.item);
                    //if the inventory is full or the item cannot be stacked, it logs a message and breaks the loop
                    if (!success)
                    {
                        Debug.Log($"Inventar voll: {reward.item.itemName} bei Stück {i + 1}");
                        break;
                    }
                }
            }
            //after adding the items, the Del method is called to clear the chest items and rewards
            Del();
        }
        // If the inventory manager is null or the rewards list is empty, log a message
        else
        {
            Debug.Log("Keine Items in Rewards");
        }
    }
}
