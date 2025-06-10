using System.Collections;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Food", fileName = "New Food Class")]
public class FoodClass : ItemClass
{
    [Header("Food")]
    public bool consumable = true;
    public float healthRestored;

    //reverence to all item classes but every is null except food and item class
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MaterialClass GetMaterial() { return null; }
    public override FoodClass GetFood() { return this; }

    public override ArmorClass GetArmor() { return null; }
}

