using UnityEngine;

public enum LootType
{
    Ederium,
    Titanium,
    Aderit
}

[System.Serializable]
public class Loot
{
    public LootType lootType;
    public int minAmount;
    public int maxAmount;
    [Range(0, 100)]
    public float dropChance;
}
