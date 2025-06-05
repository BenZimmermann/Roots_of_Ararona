using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    public string itemDescription;
    public bool isEquippable = false;
    public bool isStackable  = true;
    public bool isInInventory = false;
    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MaterialClass GetMaterial();
    public abstract FoodClass GetFood();
    public abstract ArmorClass GetArmor();
}
