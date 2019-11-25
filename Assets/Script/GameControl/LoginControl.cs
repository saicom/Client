using UnityEngine;
using System;
using System.Collections;
using GameData;
using Network;
using Login;
using ErrCode;
using System.IO;
using System.Linq;
using Game;
using System.Collections.Generic;
using Model;
using Task;


namespace Ctrl
{
    public enum EPlatformId
    {
        Official = 0,
    }

    public class LoginControl : UnitySingleton<LoginControl>
    {
        public String LoginAccountName
        {
            get;set;
        }
        public String LoginPassword
        {
            get;set;
        }
        //玩家主动切换账号
        public bool ChangeAccount
        {
            get;set;
        }


        public void Enter()
        {
            EventCenter.Broadcast(EGameEvent.eGameEvent_LoginEnter);
        }

        public void Exit()
        {
            EventCenter.Broadcast(EGameEvent.eGameEvent_LoginExit);
        }

        //登陆
        public void Login(string account, string pass)
        {
            CSLoginReq req = new CSLoginReq();
            req.AccountName = account;
            req.Passwd = pass;
            req.PlatformId = (uint)EPlatformId.Official;
            LoginAccountName = account;
            LoginPassword = pass;
            NetworkManager.Instance.SendMsg(req, (int)MessageId.LoginCsLoginReq);
            Debug.Log("login~~~~~~");
        }

        public void RegisterVisitor()
        {
            CSCreateAccountReq req = new CSCreateAccountReq();
            req.PlatformId = (uint)EPlatformId.Official;
            req.ServerId = LoginModel.Instance.SelectServerId;
            NetworkManager.Instance.SendMsg(req, (int)MessageId.LoginCsCreateAccountReq);
            Debug.Log("register visitor");
        }

        public void EnterGame()
        {
            uint userId = LoginModel.Instance.RecentUserId;
            if(userId == 0)
            {
                LoginControl.Instance.RegisterVisitor();
            }
            Debug.LogError("enter game:"+userId);
            StartConnectGate();
            //CSLoginGameReq req = new CSLoginGameReq();
            //req.UserId = userId;
            //NetworkManager.Instance.SendMsg(req, (int)MessageId.GameCsLoginGameReq);
            //Debug.Log("Enter game " + userId);
        }

        public void SetUserNick(String nick)
        {
            //check nick
        
            //GameUserModel.Instance.UserNick = nick;
            CSSetNickNameReq req = new CSSetNickNameReq();
            req.NickName = nick;
            NetworkManager.Instance.SendMsg(req, (int)MessageId.GameCsSetNickNameReq);
        }

        /*************************处理回调****************************/

        public void OnLoginSucess(SCLoginAck ack)
        {
            Debug.LogError("login success");
            LoginModel.Instance.OnLoginAck(ack);

            ChangeAccount = false;

            //拉取公告
            var task = TaskManager.Instance.GenerateTask<LoadNoticeTask>();
            task.Init();
        }

        //登陆错误反馈
        public void LoginError(int code)
        {
            //EventCenter.Broadcast<EErrorCode>(EGameEvent.eGameEvent_LoginError, (EErrorCode)code);
        }

        //接收GateServer信息
        public void RecvGateServerInfo(Stream stream)
        {
            //EventCenter.Broadcast(EGameEvent.eGameEvent_LoginSuccess);
        }

        //登陆失败
        public void LoginFail()
        {
            NetworkManager.Instance.canReconnect = false;
            //EventCenter.Broadcast(EGameEvent.eGameEvent_LoginFail);
        }

        public void InitGame()
        {
            GetCdnInfoTask task = TaskManager.Instance.GenerateTask<GetCdnInfoTask>();
            task.Init();
            //WWW w = new WWW("http://118.190.203.203/server.json");
            //yield return w;
            //if (w.error == null)
            //{
            //    cdnInfo info = JsonUtility.FromJson<cdnInfo>(w.text);
            //    if(info.serverList.Count == 0)
            //    {
            //        EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "服务器列表加载失败...");
            //        yield break;
            //    }
            //    NoticeModel.Instance.ServerCdnInfo = info;
            //    info.Print();
            //}
            //else
            //{
            //    //sdUICharacter.Instance.ShowLoginMsg("读取分区信息错误：" + w.error);
            //    Debug.LogError("读取分区信息错误:" + w.error);
            //    EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFail);
            //    yield break;
            //}
            //yield return new WaitForSeconds(.9f);
            //EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "加载游戏配置文件...");
            //ConfigMgr.Instance.load(GameDefine.GameConstDefine.ConfigPath);
            //yield return new WaitForSeconds(.9f);
            //EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "连接负载均衡服...");
            //StartConnectBalance();
            //yield return new WaitUntil(() => { return CheckConnectStatus(ServerType.BalanceServer); });
            //NoticeControl.Instance.Enter();
            //yield return new WaitUntil(() => { return _connectGate; });
            //EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "连接网关服...");
            //StartConnectGate();
            //yield return new WaitUntil(() => { return CheckConnectStatus(ServerType.GateServer); });
            //EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFinish);
        }

        public void OnConnectSuccess(ServerType serverType)
        {
            UIUtils.CloseWaitingWnd();
            NoticeModel.Instance.Reset();
            LoginModel.Instance.Reset();
            if(serverType == ServerType.LoginServer) {
                OnConnectLogin();
            }
            else if(serverType == ServerType.GateServer){
                Debug.LogError("connect gate success");
            }
        }

        public void OnConnectFail(ServerType serverType)
        {
            if (serverType == ServerType.LoginServer)
            {
                StartConnectLogin();
            }
            else if (serverType == ServerType.GateServer)
            {
                StartConnectGate();
            }
        }

        public void StartInitGame()
        {
            //StartCoroutine(InitGame());
            InitGame();
        }

        public void StartConnectLogin()
        {
            while (true)
            {
                string addr = NoticeModel.Instance.RandLoginAddr();
                if (addr == "")
                {
                    if (LoginModel.Instance.TryConnect())
                    {
                        NoticeModel.Instance.Reset();
                        continue;
                    }
                    EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFail);
                    break;
                }
                NetworkManager.Instance.ConnectServer(addr, ServerType.LoginServer);
                break;
            }
        }

        public void StartConnectGate()
        {
            CSQueryServerAddrReq req = new CSQueryServerAddrReq();
            req.ZoneId = LoginModel.Instance.SelectServerId;
            NetworkManager.Instance.SendMsg(req, (int)MessageId.LoginCsQueryServerAddrReq);
        }

        public void StartConnectGate(string addr)
        {
            if (addr == "")
            {
                EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "网关连接失败！");
                return;
            }
            if (LoginModel.Instance.TryConnect() == false)
            {
                EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFail);
                return;
            }
            NetworkManager.Instance.ConnectServer(addr, ServerType.GateServer);
            LoginModel.Instance.GateAddress = addr;
        }

        private void OnConnectLogin()
        {
            if(SettingHelper.HasSetting("AccountName") == false)
            {
                //本地无账号，则直接弹公告
                var task = TaskManager.Instance.GenerateTask<LoadNoticeTask>();
                task.Init();
            }
            else
            {
                string accountName = SettingHelper.GetString(SettingDefine.AccountName);
                string password = SettingHelper.GetString(SettingDefine.Password);
                Login(accountName, password);
            }
        }
        public void OnCreateAccountSuccess(SCCreateAccountAck ack)
        {
            SettingHelper.SetString(SettingDefine.AccountName, ack.AccountName);
            SettingHelper.SetString(SettingDefine.Password, ack.Passwd);
            //ack.LoginSess;
            //add user
            LoginModel.Instance.RecentUserId = ack.UserId;
            LoginModel.Instance.AddNewUser(ack.UserId);

            EnterGame();
        }
    }
}
