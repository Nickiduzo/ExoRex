using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; set; }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject rexPrefab;
    [SerializeField] private PointCounter counter;
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rightCorner;

    private float startDelay = 3f;
    private float delay = 2.5f;

    private bool bossSpawned = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(Instance);
        
        InvokeRepeating("SpawnEnemy", startDelay, delay);
    }

    private void SpawnEnemy()
    {
        int currentScore = counter.ReturnFullScore();

        if (currentScore % 10 == 0 && currentScore > 0)
        {
            if (!bossSpawned)
            {
                Instantiate(rexPrefab, GetRandomPosition(), Quaternion.identity);
                bossSpawned = true;
            }
        }
        else
        {
            Instantiate(enemyPrefab,GetRandomPosition(), Quaternion.identity);
        }
    }
    
    private Vector2 GetRandomPosition()
    {
        float xPos = Random.Range(leftCorner.position.x, rightCorner.position.x);
        float yPos = leftCorner.position.y;
        return new Vector2(xPos, yPos);
    }

    public void BossDestroyed()
    {
        bossSpawned = false;
    }
}
