using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform ItemContent; // where will be show items
    public GameObject InventoryItem; // how will be show items
    public ItemsConfig config;

    private void Start()
    {
        ListItems();
    }
    public void ListItems()
    {
        foreach (Transform item in ItemContent)
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
