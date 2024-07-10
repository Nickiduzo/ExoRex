using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public string itemName;
    public int amount;
    public Sprite icon;

    public int minAmount;
    public int maxAmount;
    [Range(0, 100)]
    public float dropChance;
}
