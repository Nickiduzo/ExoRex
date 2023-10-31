using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;

    #region Singleton
    public static InventoryManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void AddItem(Item item)
    {
        bool itemExists = false;
        foreach (var existingItem in items)
        {
            if (existingItem == item)
            {
                existingItem.amount++;
                itemExists = true;
                break;
            }
        }

        if (!itemExists) items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Add(item);
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject material = Instantiate(InventoryItem, ItemContent);
            var itemNameText = material.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = material.transform.Find("ItemIcon").GetComponent<Image>();
            var itemAmount = material.transform.Find("Amount").GetComponent<TextMeshProUGUI>();

            itemNameText.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemAmount.text = item.amount.ToString();
        }
    }
}
