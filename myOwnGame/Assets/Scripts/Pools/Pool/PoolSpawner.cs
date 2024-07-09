using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    public Pool<Enemy> enemyPool;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public ArenaConfig arenaConfig; // Reference to ArenaConfig ScriptableObject

    private void Start()
    {
        if (arenaConfig == null)
        {
            Debug.LogError("ArenaConfig reference is not set in PoolSpawner!");
            return;
        }

        // Example: Assuming Enemy is a MonoBehaviour representing your enemy object
        enemyPool = new Pool<Enemy>(/* prefab: */ arenaConfig.enemyPrefab, /* initialSize: */ arenaConfig.maxEnemies, /* parentTransform: */ transform);
    }

    private void SpawnEnemy()
    {
        Enemy enemy = enemyPool.GetObjectFromPool();
        enemy.transform.position = GetRandomPosition();
        enemy.gameObject.SetActive(true);
        // Customize further enemy setup here
    }

    private Vector2 GetRandomPosition()
    {
        float xPos = Random.Range(leftSpawnPoint.position.x, rightSpawnPoint.position.x);
        float yPos = leftSpawnPoint.position.y;
        return new Vector2(xPos,yPos);
    }
}
