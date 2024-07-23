using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemsConfig itemsConfig;
    public RecepsManager recepsManager;

    public GameObject[] allReceps;
    #region Singleton
    public static InventoryManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void CollectRecep(Recipe recipe)
    {
        if (!recepsManager.recipes.Contains(recipe))
        {
            recepsManager.recipes.Add(recipe);
            recipe.isAvaible = true;
            recipe.isCollected = true;
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

        float randomChance = Random.Range(0f, 100.0f);

        Debug.Log($"Drop chance: " + randomChance);
        if (randomChance < 10)
        {
            DropRecipe(position, randomChance);
            itemsConfig.Titanium.amount += 3;
            itemsConfig.Ederium.amount += 25;
        }
        if (randomChance <= 15)
        {
            DropRecipe(position, randomChance);
            for (int i = 0; i < titaniumAmount; i++)
            {
                itemsConfig.Titanium.amount++;
            }
            return;
        }
        else if (randomChance > 15)
        {
            DropRecipe(position, randomChance);
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
    private void DropRecipe(Vector3 position, float dropChance)
    {
        int recipeIndex = Random.Range(0, allReceps.Length);
        GameObject recipe = Instantiate(allReceps[recipeIndex], position,Quaternion.identity);

        //foreach (GameObject recep in allReceps)
        //{
        //    RecipePickup example = recep.GetComponent<RecipePickup>();
        //    if (example.recipe.dropChance > dropChance) 
        //    {
        //        GameObject recipe = Instantiate(allReceps[recipeIndex], position,Quaternion.identity);
        //    }
        //}
    }
}
