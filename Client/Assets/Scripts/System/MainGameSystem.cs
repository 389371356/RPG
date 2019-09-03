using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;

public class MainGameSystem : SystemBase
{
    public static MainGameSystem Instance = null;
    public override void InitSys()
    {
        base.InitSys();

        Instance = this;
        PECommon.Log("Init MainGameSystem...");
    }
    public void EnterMainGame()
    {
        //异步的加载登录场景
        //并显示加载的进度
        resSvc.AsyncLoadScene(Consts.MAIN_GAME, () => {
            
            //audioSvc.PlayBGM(resSvc.LoadAudioClip(Consts.BGM));
        });
    }
}
