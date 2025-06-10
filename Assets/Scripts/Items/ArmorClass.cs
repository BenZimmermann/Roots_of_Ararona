using System.Collections;
using UnityEngine;

// This script defines the ArmorClass, which inherits from ItemClass.
[CreateAssetMenu(menuName = "Items/Armor", fileName = "New Armor Class")]
public class ArmorClass : ItemClass
{
    public float armorThoughness;

    //reverence to all item classes but every is null except armor and item class
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override ArmorClass GetArmor() { return this; }
    public override MaterialClass GetMaterial() { return null; }
    public override FoodClass GetFood() { return null; }
}
