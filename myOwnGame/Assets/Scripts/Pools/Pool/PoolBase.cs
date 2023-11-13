using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolBase<T>
{
    private Queue<T> pool = new Queue<T>();
    private List<T> activate = new List<T>();

    private Func<T> preloadFunc;
    private Action<T> getAction;
    private Action<T> returnAction;

    public PoolBase(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
    {
        this.preloadFunc = preloadFunc;
        this.getAction = getAction;
        this.returnAction = returnAction;
 
        if (preloadFunc == null)
        {
            Debug.Log("Pizdec - pool unwork(null)");
            return;
        }

        for (int i = 0; i < preloadCount; i++)
        {
            Return(preloadFunc());
        }
    }

    public T Get()
    {
        T item = pool.Count > 0 ? pool.Dequeue() : preloadFunc();
        getAction(item);
        activate.Add(item);

        return item;
    }

    public void Return(T item)
    {
        returnAction(item);
        pool.Enqueue(item);
        activate.Remove(item);
    }

    public void ReturnAll()
    {
        foreach (T item in activate.ToArray())
        {
            Return(item);
        }
    }
}
