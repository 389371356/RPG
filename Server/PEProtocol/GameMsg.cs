using System;
using PENet;

namespace PEProtocol {
    [Serializable]
    public class GameMsg : PEMsg {
        public ReqLogin reqLogin;
        public RspLogin rspLogin;
    }

    #region 登录相关
    [Serializable]
    public class ReqLogin {
        public string acct;
        public string pass;
    }

    [Serializable]
    public class RspLogin {
        public PlayerData playerData;
    }

    [Serializable]
    public class PlayerData {
        public int id;
        public string name;

        public string account;

        public string password;
        //TOADD
    }

#endregion
    public enum ErrorCode {
        None = 0,//没有错误
        ServerDataError,//服务器数据异常
        UpdateDBError,//更新数据库错误
        ClientDataError,//客户端数据异常

        AcctIsOnline,//账号已经上线
        WrongPass,//密码错误
        NameIsExist,//名字已经存在

        LackLevel,
        LackCoin,
        LackCrystal,
        LackDiamond,
        LackPower,
    }

    public enum CMD {
        None = 0,
        //登录相关 100
        ReqLogin = 101,
        RspLogin = 102,
    }

    public class SrvCfg {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}