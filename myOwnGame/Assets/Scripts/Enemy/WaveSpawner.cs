using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie; 
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rigthCorner;

    private float startDelay = 2f;
    private float spawnDelay = 3f;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnDelay);
    }
 
    private void SpawnEnemy()
    {
        Instantiate(zombie, GetRandomPosition(), Quaternion.identity);
    }
    private Vector3 GetRandomPosition()
    {
        float xPosition = Random.Range(leftCorner.position.x, rigthCorner.position.x);
        return new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
