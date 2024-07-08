using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

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
    public void PlayDeathEffect(EnemyType enemyType, Vector3 position)
    {
        string effectPath = GetEffectPath(enemyType);
        GameObject effectPrefab = Resources.Load<GameObject>(effectPath);
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(effectPrefab,position,Quaternion.identity);
            Destroy(effect, 2);
        }
    }

    private string GetEffectPath(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Enemy:
                return "Effects/EnemyDeathEffect";
            case EnemyType.DinoBoss:
                return "Effects/DinoBossDeathEffect";
            case EnemyType.RexBoss:
                return "Effects/RexBossDeathEffect";
            case EnemyType.ExoBoss:
                return "Effects/ExoBossDeathEffect";
            default:
                return "Effects/EnemyDeathEffect";
        }
    }
}
