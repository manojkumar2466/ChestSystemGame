using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private T instance;
    public T Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else if (instance)
        {
            Destroy(this.gameObject);
        }
    }
}
