using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    protected static T _instance;

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this as T;
        DontDestroyOnLoad(gameObject);
        InitSvc();
    }
    
    public virtual void InitSvc() { }

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)Object.FindObjectOfType(typeof(T));
            }
            return _instance;
        }
        protected set
        {
            _instance = value;
        }
    }

    public static bool HasInstance
    {
        get { return _instance != null; }
    }

}
