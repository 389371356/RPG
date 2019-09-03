using System;
using MySql.Data.MySqlClient;
using PEProtocol;

public class DBMgr {
    private static DBMgr instance = null;
    public static DBMgr Instance {
        get {
            if (instance == null) {
                instance = new DBMgr();
            }
            return instance;
        }
    }
    private MySqlConnection conn;

    public void Init() {
        conn = new MySqlConnection("server=localhost;User Id = root;passwrod=;Database=darkgod;Charset = utf8");
        conn.Open();
        PECommon.Log("DBMgr Init Done.");

        //QueryPlayerData("xxxx", "oooo");
    }


    public PlayerData QueryPlayerData(string acct, string pass) {
        bool isNew = true;
        PlayerData playerData = null;
        MySqlDataReader reader = null;
        try {
            MySqlCommand cmd = new MySqlCommand("select * from account where acct = @acct", conn);
            cmd.Parameters.AddWithValue("acct", acct);
            reader = cmd.ExecuteReader();
            if (reader.Read()) {
                isNew = false;
                string _pass = reader.GetString("pass");
                if (_pass.Equals(pass)) {
                    //密码正确，返回玩家数据
                    playerData = new PlayerData {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        
                        //TOADD
                    };

                    //TODO
                }
            }
        }
        catch (Exception e) {
            PECommon.Log("Query PlayerData By Acct&Pass Error:" + e, LogType.Error);
        }
        finally {
            if (reader != null) {
                reader.Close();
            }
            if (isNew) {
                //不存在账号数据，创建新的默认账号数据，并返回
                playerData = new PlayerData {
                    id = -1,
                    name = "",
                    
                    //TOADD
                };


                playerData.id = InsertNewAcctData(acct, pass, playerData);
            }
        }
        return playerData;
    }

    private int InsertNewAcctData(string acct, string pass, PlayerData pd) {
        int id = -1;
        try {
            MySqlCommand cmd = new MySqlCommand(
                "insert into account set acct=@acct,pass =@pass,name=@name", conn);
            cmd.Parameters.AddWithValue("acct", acct);
            cmd.Parameters.AddWithValue("pass", pass);
            cmd.Parameters.AddWithValue("name", pd.name);
            //TOADD
            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;
        }
        catch (Exception e) {
            PECommon.Log("Insert PlayerData Error:" + e, LogType.Error);
        }
        return id;
    }

    public bool QueryNameData(string name) {
        bool exist = false;
        MySqlDataReader reader = null;
        try {
            MySqlCommand cmd = new MySqlCommand("select * from account where name= @name", conn);
            cmd.Parameters.AddWithValue("name", name);
            reader = cmd.ExecuteReader();
            if (reader.Read()) {
                exist = true;
            }
        }
        catch (Exception e) {
            PECommon.Log("Query Name State Error:" + e, LogType.Error);
        }
        finally {
            if (reader != null) {
                reader.Close();
            }
        }

        return exist;
    }

    public bool UpdatePlayerData(int id, PlayerData playerData) {
        try {
            MySqlCommand cmd = new MySqlCommand(
            "update account set name=@name where id =@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", playerData.name);
            //TOADD Others
            cmd.ExecuteNonQuery();
        }
        catch (Exception e) {
            PECommon.Log("Update PlayerData Error:" + e, LogType.Error);
            return false;
        }
        return true;
    }
}
