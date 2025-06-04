using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Material", fileName = "New Material Class")]
public class MaterialClass : ItemClass
{
    [Header("Material")]
    public MaterialType materialtype;
    public enum MaterialType
    {
        Stone,
        Stick,
        wood,
        iron,
        coal,
        copper,
    }
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MaterialClass GetMaterial() { return this; }
    public override FoodClass GetFood() { return null; }
}
