using UnityEngine;

[CreateAssetMenu(fileName = "ArenaConfig", menuName = "ScriptableObjects/ArenaConfig", order = 1)]
public class ArenaConfig : ScriptableObject
{
    public int maxEnemies = 20;
    public GameObject enemyPrefab; // Example reference to your enemy prefab
    // Add other configuration parameters as needed
}
