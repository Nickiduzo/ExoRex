using System.Diagnostics;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;
    private float randomX;
    bool makeSpawn = false;
    float timeToSpawn = 0;

    public Transform leftCorner;
    public Transform rightCorner;

    [SerializeField]
    private BossBarElement barElement;
    private void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (IsBossDie())
        {
            leftCorner.gameObject.SetActive(true);
            rightCorner.gameObject.SetActive(true);
        }
        if (CheckToSpawn())
        {
            leftCorner.gameObject.SetActive(false);
            rightCorner.gameObject.SetActive(false);
            randomX = Random.Range(-6, 6);
            Instantiate(boss, new Vector2(randomX, -2), Quaternion.identity);
            DestroyAllEnemies();
            barElement.ActivateBossBar();
            makeSpawn = false;
        }
    }
    private bool CheckToSpawn()
    {
        if ((PointCounter.ReturnFullScore() == 10 || PointCounter.ReturnFullScore() == 50 || PointCounter.ReturnFullScore() == 150) && timeToSpawn <= 0 && makeSpawn == false)
        {
            makeSpawn = true;
            timeToSpawn = 50;
            return true;
        }
        return false;
    }
    private bool IsBossDie()
    {
        if (FindObjectOfType<BossBehaviour>() == null) return true;
        return false;
    }
    private void DestroyAllEnemies()
    {
        EnemyBehaviour[] enemies = FindObjectsOfType<EnemyBehaviour>();

        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}