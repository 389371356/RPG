using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SingletonModuleAppContext
{
    static private List<ISingletonModule> Modules = new List<ISingletonModule>();
    static internal void RegisterModule(ISingletonModule module)
    {
        Modules.Add(module);
    }
    static public void InitModules()
    {
        foreach (ISingletonModule s in Modules)
        {
            s.Init();
        }
    }
    static public void CleanupModules()
    {
        foreach (ISingletonModule s in Modules)
        {
            s.Cleanup();
        }
    }
}
