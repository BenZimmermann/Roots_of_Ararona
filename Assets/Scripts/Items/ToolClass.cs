using System.Collections;
using UnityEngine;

// This script defines the ToolClass, which inherits from ItemClass.
[CreateAssetMenu(menuName = "Items/Tool", fileName = "New Tool Class")]
public class ToolClass : ItemClass
{
    //list of all tools
    [Header("Tools")]
    public ToolType tooltype;
    public enum ToolType
    {
        Iron_Sword,
        Stone_Sword,
    }

    //reference to all item classes but every is null except tool and item class
    public override ItemClass GetItem() { return this; }
    public  override ToolClass GetTool() { return this; }
    public override MaterialClass GetMaterial() { return null; }
    public override ArmorClass GetArmor() { return null; }
    public override FoodClass GetFood() { return null; }
}
