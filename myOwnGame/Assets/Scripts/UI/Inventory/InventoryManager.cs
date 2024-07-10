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
                ThrowLootWithForce(loots[2], position, 0.2f, Random.Range(-15f, 15f));
            }
            return;
        }
        else if (randomChance <= 15)
        {
            for (int i = 0; i < ederiumAmount; i++)
            {
                ThrowLootWithForce(loots[1], position, 0.2f, Random.Range(-15f, 15f));
            }
            return;
        }
        else if (randomChance > 15)
        {
            for (int i = 0; i < aderitAmount; i++)
            {
                ThrowLootWithForce(loots[0], position, 0.2f, Random.Range(-15f, 15f));
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
                ThrowLootWithForce(loots[2], position, 0.2f, Random.Range(-15f, 15f));
            }
            return;
        }
        else if (randomChance > 15)
        {
            for (int i = 0; i < ederiumAmount; i++)
            {
                ThrowLootWithForce(loots[1], position, 0.2f, Random.Range(-15f, 15f));
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
    private void ThrowLootWithForce(GameObject lootPrefab, Vector3 position, float force, float angle)
    {
        // Instantiate the loot at the given position
        GameObject lootInstance = Instantiate(lootPrefab, position, Quaternion.identity);

        // Get the Rigidbody2D component attached to the instantiated loot
        Rigidbody2D rb = lootInstance.GetComponent<Rigidbody2D>();

        // Check if the Rigidbody2D component exists
        if (rb != null)
        {
            // Calculate the direction based on the angle
            float radians = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

            // Apply force to the Rigidbody2D in the calculated direction
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("The loot prefab does not have a Rigidbody2D component.");
        }
    }

}
