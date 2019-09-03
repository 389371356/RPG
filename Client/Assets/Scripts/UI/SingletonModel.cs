using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingletonModule
{
    void Init();
    void Cleanup();
}
public abstract class SingletonModule<T> : ISingletonModule where T : SingletonModule<T>, new()
{
    private static T _instance = default(T);
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
                _instance.Init();
            }
            return _instance;
        }
    }
    private bool m_HasInited = false;
    public SingletonModule()
    {
        SingletonModuleAppContext.RegisterModule(this);
    }
    public void Init()
    {
        if (m_HasInited == false)
        {
            OnInit();
            m_HasInited = true;
        }
    }
    public void Cleanup()
    {
        OnCleanup();
        m_HasInited = false;
    }
    protected abstract void OnInit();
    protected abstract void OnCleanup();
}
