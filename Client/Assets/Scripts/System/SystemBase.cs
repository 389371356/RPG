using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBase : MonoBehaviour
{
    protected ResourcesService resSvc;
    protected AudioService audioSvc;
    protected NetService netSvc;
    protected TimerService timerSvc;

    public virtual void InitSys()
    {
        resSvc = ResourcesService.Instance;
        audioSvc = AudioService.Instance;
        netSvc = NetService.Instance;
        timerSvc = TimerService.Instance;
    }
}
