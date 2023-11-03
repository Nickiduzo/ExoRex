using UnityEngine;

public class CloudPool : MonoBehaviour
{
    [SerializeField] private MineConfig config;
    
    public PoolBase<Cloud>[] Pool { get; private set; }
    private void Awake()
    {
        Pool = new PoolBase<Cloud>[config.Clouds.Length];
        for (int i = 0; i < config.Clouds.Length; i++)
        {
            Pool[i] = new PoolBase<Cloud>(config.Clouds[i], 1, true, true, transform);
        }
    }
}
