using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable  = true; 
    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MaterialClass GetMaterial();
    public abstract FoodClass GetFood();
}
