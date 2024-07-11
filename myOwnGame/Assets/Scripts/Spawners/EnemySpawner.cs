using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject rexPrefab;
    [SerializeField] private PointCounter counter;
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rightCorner;

    [SerializeField] private ArenaConfig arenaConfig;
   
    private ArenaMode currentMode;

    private float startDelay = 3f;
    private float delay = 2.5f;

    private bool bossSpawned = false;
    private void Awake()
    {
        InitializeSpawner();
    }
    private void InitializeSpawner()
    {
        currentMode = arenaConfig.currentMode;
        startDelay = currentMode.startDelay;
        delay = currentMode.spawnDelay;
        InvokeRepeating("SpawnEnemy", startDelay, delay);
    }
    private void OnEnable()
    {
        RexEnemy.OnBossDestroyed += BossDestroyed;
    }

    private void OnDisable()
    {
        RexEnemy.OnBossDestroyed -= BossDestroyed;
    }
    private void SpawnEnemy()
    {
        int currentScore = counter.ReturnFullScore();

        if (currentScore % 10 == 0 && currentScore > 0)
        {
            if (!bossSpawned)
            {
                InstantiateRexEnemy(rexPrefab);
                bossSpawned = true;
            }
        }
        else
        {
            InstantiateEnemy(enemyPrefab);
        }
    }
    private void InstantiateRexEnemy(GameObject gameObject)
    {
        GameObject rex = Instantiate(gameObject, GetRandomPosition(), Quaternion.identity);
        RexEnemy rexScript = rex.GetComponent<RexEnemy>();

        if (rexScript != null)
        {
            rexScript.SetSpeeds(currentMode.bossPatrolSpeed, currentMode.bossChaseSpeed);
        }
    }
    private void InstantiateEnemy(GameObject gameObject)
    {
        GameObject enemy = Instantiate(gameObject, GetRandomPosition(), Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.SetSpeeds(currentMode.patrolSpeed, currentMode.chaseSpeed);
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
