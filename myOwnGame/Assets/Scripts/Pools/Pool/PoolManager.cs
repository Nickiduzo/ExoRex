using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private Dictionary<string, object> pools = new Dictionary<string, object>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CreatePool<T>(T prefab, int initialSize, Transform parentTransform) where T : MonoBehaviour
    {
        string key = typeof(T).Name + "Pool";
        Pool<T> newPool = new Pool<T>(prefab, initialSize, parentTransform);
        pools.Add(key, newPool);
    }

    public Pool<T> GetPool<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name + "Pool";
        if (pools.ContainsKey(key))
            return (Pool<T>)pools[key];
        return null;
    }
}
