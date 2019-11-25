using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class cdnServerInfo
{
    public uint serverId;
    public string serverName;
    public string serverState;
}

[Serializable]
public class cdnInfo
{
    public string notice;
    public List<cdnServerInfo> serverList = new List<cdnServerInfo>();
    public List<string> loginList = new List<string>();
    public void Print()
    {
        foreach(cdnServerInfo info in serverList)
        {
            Debug.LogError("serverId:"+info.serverId + ",name:"+info.serverName + ",state:"+info.serverState);
        }
        foreach(string l in loginList)
        {
            Debug.LogError("server:"+l);
        }
    }
}

namespace Model
{
    public class NoticeModel : Singleton<NoticeModel>
    {
        public uint NewServerId;
        private int _index = 0; //balance轮训索引
        private Dictionary<uint, cdnServerInfo> _serverMap = new Dictionary<uint, cdnServerInfo>();
        private cdnInfo _cdnInfo;
        public cdnInfo ServerCdnInfo
        {
            get
            {
                return _cdnInfo;
            }
            set
            {
                _cdnInfo = value;
                NewServerId = _getNewestServerId();
                LoginModel.Instance.SelectServerId = NewServerId;
            }
        }


        public void Reset()
        {
            _index = 0;
        }

        public string RandLoginAddr()
        {
            if(_index >= ServerCdnInfo.loginList.Count)
            {
                return "";
            }
            return ServerCdnInfo.loginList[_index++];
        }

        private uint _getNewestServerId()
        {
            uint maxId = 0;
            for(int i = 0; i < _cdnInfo.serverList.Count; ++i)
            {
                cdnServerInfo serverInfo = _cdnInfo.serverList[i];
                _serverMap[serverInfo.serverId] = serverInfo;
                if(serverInfo.serverId > maxId)
                {
                    maxId = serverInfo.serverId;
                }
            }

            return maxId;
        }

        public cdnServerInfo GetNewServer()
        {
            if(_serverMap.ContainsKey(NewServerId) == false)
            {
                return null;
            }

            return _serverMap[NewServerId];
        }

        public int GetServerCount()
        {
            return _serverMap.Count;
        }

        public cdnServerInfo GetServerInfoByIndex(int index)
        {
            if(index >= _cdnInfo.serverList.Count)
            {
                return null;
            }
            return _cdnInfo.serverList[index];
        }

        public cdnServerInfo GetServerInfoById(uint id)
        {
            for(int i = 0; i < _cdnInfo.serverList.Count; ++i)
            {
                if (id == _cdnInfo.serverList[i].serverId)
                {
                    return _cdnInfo.serverList[i];
                }
            }

            return null;
        }
    }
}
