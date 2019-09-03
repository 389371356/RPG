using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIModelDataChangeObserver
{
    void OnDataChanged(UIBaseModel model, uint propID, params object[] param);
    uint GetInterestedPropID(UIBaseModel model);
}
public abstract class UIBaseModel
{


    public virtual void Init()
    {

    }
    public virtual void OnCleanup()
    {

    }
    public abstract uint GetModelType();
}
