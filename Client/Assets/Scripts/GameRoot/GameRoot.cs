using System;
using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance
    {
        get { return _instance; }
    }
    
    private static GameRoot _instance = null;
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
        Init();
    }
    private void Init()
    {
        //服务模块初始化
        //NetService net = GetComponent<NetService>();
        //net.InitSvc();
        ResourcesService res = GetComponent<ResourcesService>();
        res.InitSvc();
        AudioService audio = GetComponent<AudioService>();
        audio.InitSvc();
        TimerService timer = GetComponent<TimerService>();
        timer.InitSvc();
        //业务系统初始化
        LoginSystem login = GetComponent<LoginSystem>();
        login.InitSys();
        //进入登录场景并加载相应UI
        login.EnterLogin();
    }

}
