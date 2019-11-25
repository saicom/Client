using UnityEngine;
using System;
using System.Collections.Generic;
using Login;


namespace Model
{
    public class LoginModel : Singleton<LoginModel>
    {
        public int TryConnectTimes = 0;
        public string GateAddress;
        private int MaxConnectTimes = 5;
        private string m_LoginSession;
        private Dictionary<uint, msgLoginUserInfo> m_UserDict = new Dictionary<uint, msgLoginUserInfo>();

        //最近登录服务器id
        public uint RecentUserId = 0;
        //自己选择的服务器id
        public uint SelectServerId = 0;

        public int GetUserCount()
        {
            return m_UserDict.Count;
        }
        

        public void Reset()
        {
            TryConnectTimes = 0;
        }

        public bool TryConnect()
        {
            return TryConnectTimes++ < MaxConnectTimes;
        }

        public void OnLoginAck(SCLoginAck ack)
        {
            m_LoginSession = ack.LoginSess;
            uint loginTs = 0;
            for(int i = 0; i < ack.UserList.Count; ++i)
            {
                msgLoginUserInfo userInfo = ack.UserList[i];
                m_UserDict.Add(userInfo.UserId, userInfo);
                if(loginTs <= userInfo.LastLoginTs)
                {
                    RecentUserId = userInfo.UserId;
                    SelectServerId = userInfo.ServerId;
                }
            }
        }

        public cdnServerInfo GetShowServer()
        {
            return NoticeModel.Instance.GetServerInfoById(SelectServerId);
        }

        public cdnServerInfo GetServerInfo(int index)
        {
            int i = 0;
            foreach(KeyValuePair<uint, msgLoginUserInfo> pair in m_UserDict)
            {
                if(i++ == index)
                {
                    uint serverId = pair.Value.ServerId;
                    return NoticeModel.Instance.GetServerInfoById(serverId);
                }
            }
            return null;
        }

        public void OnSelectServer(uint serverId)
        {
            SelectServerId = serverId;
            List<msgLoginUserInfo> userList = new List<msgLoginUserInfo>();
            foreach (KeyValuePair<uint, msgLoginUserInfo> pair in m_UserDict)
            {
                if(pair.Value.ServerId == serverId)
                {
                    userList.Add(pair.Value);
                }
            }
            if(userList.Count == 0)
            {
                RecentUserId = 0;
            }
            else
            {
                RecentUserId = userList[0].UserId;
            }
        }

        public void AddNewUser(SCCreateAccountAck ack)
        {
            RecentUserId = ack.UserId;
            msgLoginUserInfo userInfo = new msgLoginUserInfo();
            userInfo.UserId = ack.UserId;
            userInfo.UserNick = ack.UserId.ToString();
            userInfo.ServerId = SelectServerId;
            m_UserDict.Add(RecentUserId, userInfo);

            m_LoginSession = ack.LoginSess;
        }

    }
}
