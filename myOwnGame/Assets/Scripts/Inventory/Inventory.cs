using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] private List<ItemData> Items = new List<ItemData>();

    private void Awake()
    {
        Instance = this;
    }


    public void Add(ItemData item)
    {
        Items.Add(item);
    }
    public void Remove(ItemData item)
    {
        Items.Remove(item);
    }
}
