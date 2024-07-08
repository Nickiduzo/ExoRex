using System.Diagnostics;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static LootManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DropLoot(Loot[] possibleLoots, Vector3 position)
    {
        foreach (Loot loot in possibleLoots)
        {
            if (Random.Range(0f,100f) <= loot.dropChance)
            {
                int amount = Random.Range(loot.minAmount, loot.maxAmount + 1);

                UnityEngine.Debug.Log($"Dropped {amount} of {loot.lootType} at {position}");
            }
        }
    }
}
