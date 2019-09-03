using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;

public class LoginSystem : SystemBase
{
    public static LoginSystem Instance = null;
    
    public override void InitSys() {
        base.InitSys();

        Instance = this;
        PECommon.Log("Init LoginSys...");
    }
    /// <summary>
    /// 进入登录场景
    /// </summary>
    public void EnterLogin() {
        //异步的加载登录场景
        //并显示加载的进度
        resSvc.AsyncLoadScene(Consts.LOGIN, () => {
            //加载完成以后再打开注册登录界面
            audioSvc.PlayBGM(resSvc.LoadAudioClip(Consts.BGM));
        });
    }

}
