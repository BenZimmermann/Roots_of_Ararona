using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    // This is the base class for all items in the game.
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    [TextArea]public string itemDescription;
    public bool isEquippable = false;
    public bool isStackable  = true;
    public bool isInInventory = false;
    //reverence to the item classes
    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MaterialClass GetMaterial();
    public abstract FoodClass GetFood();
    public abstract ArmorClass GetArmor();
}

