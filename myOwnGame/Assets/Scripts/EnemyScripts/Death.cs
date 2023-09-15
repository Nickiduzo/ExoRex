using UnityEngine;

public class Death : MonoBehaviour
{
    public delegate void DeathHandler();
    public event DeathHandler OnDieActivate;

    public void Die()
    {
        PointCounter.Instanse.UpdateKillCount(1);
        OnDieActivate?.Invoke();
        Destroy(gameObject,0.8f);
    }
}
