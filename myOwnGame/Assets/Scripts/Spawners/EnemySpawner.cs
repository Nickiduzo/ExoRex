using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rightCorner;
    [SerializeField] private float startDelay;
    [SerializeField] private float delay;
    [SerializeField] private GameObject enemy;
    
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, delay);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
    }
    private Vector2 GetRandomPosition()
    {
        float xPos = Random.Range(leftCorner.position.x, rightCorner.position.x);
        return new Vector2(xPos, transform.position.y);
    }
}
