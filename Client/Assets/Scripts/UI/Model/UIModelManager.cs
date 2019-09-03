using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UIModelManager : SingletonModule<UIModelManager>
{
    private Dictionary<int, UIBaseModel> m_UIModels;
    private List<UIBaseModel> m_ModelLists;
    public T GetModel<T>() where T : UIBaseModel, new()
    {
        if (m_UIModels == null)
        {
            m_UIModels = new Dictionary<int, UIBaseModel>();
        }

        int hash = typeof(T).GetHashCode();
        UIBaseModel model = null;
        if (m_UIModels.TryGetValue(hash, out model) == false)
        {
            model = new T();
            model.Init();
            m_UIModels.Add(hash, model);
        }
        return (T)model;
    }
    protected override void OnInit()
    {
    }

    protected override void OnCleanup()
    {
        if (m_UIModels != null)
        {
            foreach (var item in GetModels())
            {
                item.OnCleanup();
            }
            m_UIModels = null;
            m_ModelLists = null;
        }
    }

    private IEnumerable<UIBaseModel> GetModels() //using model list to fix "InvalidOperationException: out of sync"
    {
        if (m_ModelLists == null)
        {
            m_ModelLists = new List<UIBaseModel>();
        }
        m_ModelLists.Clear();
        m_ModelLists.InsertRange(0, m_UIModels.Values);
        return m_ModelLists;
    }
}
