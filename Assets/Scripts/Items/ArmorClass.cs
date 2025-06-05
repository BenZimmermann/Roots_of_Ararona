using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Armor", fileName = "New Armor Class")]
public class ArmorClass : ItemClass
{
    public float armorThoughness;

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override ArmorClass GetArmor() { return this; }
    public override MaterialClass GetMaterial() { return null; }
    public override FoodClass GetFood() { return null; }
}
