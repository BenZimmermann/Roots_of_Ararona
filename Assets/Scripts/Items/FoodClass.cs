using System.Collections;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Food", fileName = "New Food Class")]
public class FoodClass : ItemClass
{
    [Header("Food")]
    public float healthRestored;
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MaterialClass GetMaterial() { return null; }
    public override FoodClass GetFood() { return this; }
}
