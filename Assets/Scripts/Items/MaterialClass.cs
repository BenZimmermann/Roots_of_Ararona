using System.Collections;
using UnityEngine;

// This script defines the MaterialClass, which inherits from ItemClass.
[CreateAssetMenu(menuName ="Items/Material", fileName = "New Material Class")]
public class MaterialClass : ItemClass
{
    public bool isIngriedient = true;

    //reverence to all item classes but every is null except material and item class
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MaterialClass GetMaterial() { return this; }
    public override FoodClass GetFood() { return null; }
    public override ArmorClass GetArmor() { return null; }
}
