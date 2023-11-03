using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PoolBase<T> where T : MonoBehaviour
{
    private readonly Transform container;
    private readonly T prefab;
    private readonly List<T> freeElements = new();
    private readonly bool autoExpand;
    private readonly bool reusable;
    private List<T> pool;

    public PoolBase(T prefab, int countInPool, bool autoExpand, bool reusable = true, Transform container = null)
    {
        this.reusable = reusable;
        this.prefab = prefab;
        this.container = container;
        this.autoExpand = autoExpand;
        CreatePool(countInPool);
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var mono in pool.Where(mono => !mono.gameObject.activeInHierarchy))
        {
            freeElements.Add(mono);
        }

        if (freeElements.Count == 0)
        {
            element = null;
            return false;
        }

        element = freeElements[Random.Range(0, freeElements.Count)];
        element.gameObject.SetActive(true);
        freeElements.Clear();
        return true;
    }

    public bool HasFreeElement()
    {
        foreach (var mono in pool.Where(mono => !mono.gameObject.activeInHierarchy))
        {
            freeElements.Add(mono);
        }

        if (freeElements.Count == 0)
        {
            return false;
        }

        freeElements.Clear();
        return true;
    }
    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            if (!reusable)
                pool.Remove(element);

            return element;
        }

        if (autoExpand)
            CreateObject(true);

        throw new System.Exception($"There is no elements in pool of type {typeof(T)}");
    }

    private void CreatePool(int countInPool)
    {
        pool = new List<T>();

        for (int i = 0; i < countInPool; i++)
            CreateObject();
    }

    private void CreateObject(bool isActiveByDefault = false)
    {
        var createdObj = Object.Instantiate(prefab, container);
        createdObj.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObj);
    }
}
