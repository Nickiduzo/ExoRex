using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Queue<T> poolQueue = new Queue<T>();
    private T prefab;
    private Transform parentTransform;

    public Pool(T prefab, int initialSize, Transform parentTransform)
    {
        this.prefab = prefab;
        this.parentTransform = parentTransform;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    // Additional constructor to handle GameObjects directly
    public Pool(GameObject prefab, int initialSize, Transform parentTransform)
    {
        this.prefab = prefab.GetComponent<T>();
        this.parentTransform = parentTransform;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, parentTransform).GetComponent<T>();
            obj.gameObject.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    public T GetObjectFromPool()
    {
        if (poolQueue.Count == 0)
        {
            T obj = GameObject.Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(false);
            return obj;
        }
        else
        {
            T obj = poolQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
    }

    public void ReturnObjectToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
