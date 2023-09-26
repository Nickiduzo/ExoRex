using UnityEngine;

public enum OreType
{
    None,
    Copper,
    Aluminium,
    Titanium
}
[CreateAssetMenu(fileName = "New Ore Object", menuName = "Inventory System/Pickup Items/Ore")]
public class OreObject : PickupItemObject
{
    public OreType OreType = OreType.None;
}
