using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Tool", fileName = "New Tool Class")]
public class ToolClass : ItemClass
{
    [Header("Tools")]
    public ToolType tooltype;
    public enum ToolType
    {
        Iron_Sword,
        Stone_Sword,
    }
    public override ItemClass GetItem() { return this; }
    public  override ToolClass GetTool() { return this; }
    public override MaterialClass GetMaterial() { return null; }
    public override ArmorClass GetArmor() { return null; }
    public override FoodClass GetFood() { return null; }
}
