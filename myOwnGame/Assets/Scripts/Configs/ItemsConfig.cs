using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Create new Items")]
public class ItemsConfig : ScriptableObject
{
	public Transform shopInventory;

    public Item Aderit;
    public Item Ederium;
    public Item Titanium;
}
