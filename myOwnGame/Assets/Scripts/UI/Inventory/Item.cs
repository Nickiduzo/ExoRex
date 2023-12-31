using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int amount;
    public Sprite icon;
}
