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
    public List<string> balanceList = new List<string>();
    public void Print()
    {
        //Debug.LogError("notice:" + notice);
        foreach(cdnServerInfo info in serverList)
        {
            Debug.LogError("serverId:"+info.serverId + ",name:"+info.serverName + ",state:"+info.serverState);
        }
        foreach(string l in balanceList)
        {
            Debug.LogError("server:"+l);
        }
    }
}

namespace Model
{
    public class NoticeModel : Singleton<NoticeModel>
    {
        private int _index = 0; //balance轮训索引
        private uint _serverId = 0;  //默认选择服务器
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
                if(SettingHelper.HasSetting(SettingDefine.ServerId))
                {
                    _serverId = (uint)SettingHelper.GetInt(SettingDefine.ServerId);
                }
                else
                {
                    _serverId = _getNewestServerId();
                }
            }
        }

        public uint CurServerId
        {
            get
            {
                return _serverId;
            }
        }

        public void Reset()
        {
            _index = 0;
        }

        public string RandBalanceAddr()
        {
            if(_index >= ServerCdnInfo.balanceList.Count)
            {
                return "";
            }
            return ServerCdnInfo.balanceList[_index++];
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

        public cdnServerInfo GetSuggestServer()
        {
            if(_serverMap.ContainsKey(_serverId) == false)
            {
                return null;
            }

            return _serverMap[_serverId];
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
	}
}
