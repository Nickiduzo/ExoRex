using UnityEngine;

public class Death : MonoBehaviour
{
    public delegate void DeathHandler();
    public event DeathHandler OnDieActivate;

    public void Die()
    {
        PointCounter.Instanse.UpdateKillCount(1);
        OnDieActivate?.Invoke();
        EffectManager.Instance.PlayDeathEffect(EnemyType.Enemy, transform.position);
        gameObject.SetActive(false);
    }
}
