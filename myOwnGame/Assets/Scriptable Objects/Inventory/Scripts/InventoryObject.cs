using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public PickupItemObject Item;
    public int Amount;
    public InventorySlot(PickupItemObject item, int amount)
    {
        Item = item;
        Amount = amount;
    }

    public void AddAmount(int value)
    {
        Amount += value;
    }
}