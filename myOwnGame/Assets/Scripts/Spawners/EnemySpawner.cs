using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSpawner();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitializeSpawner()
    {
        currentMode = arenaConfig.currentMode;
        startDelay = currentMode.startDelay;
        delay = currentMode.spawnDelay;
        InvokeRepeating("SpawnEnemy", startDelay, delay);
    }

    private void OnDestroy()
    {
        CancelInvoke("SpawnEnemy");
    }

    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (Instance != this)
        {
            CancelInvoke("SpawnEnemy");
            Destroy(gameObject);
        }
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
