using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject zombie; 
    public float waveTimer;

    public Transform leftCorner;
    public Transform rigthCorner;

    public Death death;
    private void Start()
    {
        waveTimer = 5;
        zombie.GetComponent<EnemyPatroller>().leftCorner = leftCorner;
        zombie.GetComponent<EnemyPatroller>().rightCorner = rigthCorner;
        zombie.GetComponent<HealthPoints>().death = death;
    }

    private void Update()
    {
        if (waveTimer <= 0)
        {
            SpawnEnemy(zombie);
            waveTimer = 5;
        }
        else
        {
            waveTimer -= Time.deltaTime;
        }
    }
    public void SpawnEnemy(GameObject enemy) => Instantiate(enemy,transform.position,transform.rotation);
 
}
