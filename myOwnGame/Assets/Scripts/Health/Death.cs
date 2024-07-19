using UnityEngine;

public class Death : MonoBehaviour
{
    public delegate void DeathHandler();
    public event DeathHandler OnDieActivate;

    public EnemyType enemyType;
    public void Die()
    {
        PointCounter.Instanse.UpdateKillCount(enemyType);
        OnDieActivate?.Invoke();
        InventoryManager.Instance.DropLoot(enemyType, transform.position);
        EffectManager.Instance.PlayDeathEffect(EnemyType.Enemy, transform.position);
        LevelSystem.instance.AddExperience(50);
        Destroy(gameObject);
    }
}
