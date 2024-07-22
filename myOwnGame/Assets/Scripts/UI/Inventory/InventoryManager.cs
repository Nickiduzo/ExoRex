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
    public ItemsConfig itemsConfig;
    public RecepsManager recepsManager;

    public GameObject[] loots;
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

    public void CollectRecep(Recipe recipe)
    {
        recepsManager.recipes.Add(recipe);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
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

    public void DropLoot(EnemyType enemyType, Vector3 position)
    {
        switch (enemyType) 
        {
            case EnemyType.Enemy:
                ThrowEnemyLoot(position);
                break;
            case EnemyType.RexBoss:
                ThrowRexLoot(position);
                break;
            case EnemyType.DinoBoss:
                ThrowDinoLoot(position);
                break;
            case EnemyType.ExoBoss:
                ThrowExotLoot(position);
                break;
            default: 
                ThrowEnemyLoot(position);
                break;
        }  
    }

    private void ThrowEnemyLoot(Vector3 position)
    {
        int aderitAmount = Random.Range(itemsConfig.Aderit.minAmount, itemsConfig.Aderit.maxAmount);
        int titaniumAmount = Random.Range(itemsConfig.Titanium.minAmount, itemsConfig.Titanium.maxAmount);
        int ederiumAmount = Random.Range(itemsConfig.Ederium.minAmount, itemsConfig.Ederium.maxAmount);

        float randomChance = Random.Range(0, 100f);

        if(randomChance <= 1)
        {
            for (int i = 0; i < titaniumAmount; i++)
            {
                itemsConfig.Titanium.amount++;
            }
            return;
        }
        else if (randomChance <= 15)
        {
            for (int i = 0; i < ederiumAmount; i++)
            {
                itemsConfig.Ederium.amount++;
            }
            return;
        }
        else if (randomChance > 15)
        {
            for (int i = 0; i < aderitAmount; i++)
            {
                itemsConfig.Aderit.amount++;
            }
            return;
        }
    }

    private void ThrowRexLoot(Vector3 position)
    {
        int titaniumAmount = Random.Range(itemsConfig.Titanium.minAmount, itemsConfig.Titanium.maxAmount);
        int ederiumAmount = Random.Range(itemsConfig.Ederium.minAmount, itemsConfig.Ederium.maxAmount);

        float randomChance = Random.Range(0, 100f);

        if (randomChance <= 15)
        {
            for (int i = 0; i < titaniumAmount; i++)
            {
                itemsConfig.Titanium.amount++;
            }
            return;
        }
        else if (randomChance > 15)
        {
            for (int i = 0; i < ederiumAmount; i++)
            {
                itemsConfig.Ederium.amount++;
            }
            return;
        }
    }

    private void ThrowDinoLoot(Vector3 position)
    {

    }

    private void ThrowExotLoot(Vector3 position)
    {

    }
}
