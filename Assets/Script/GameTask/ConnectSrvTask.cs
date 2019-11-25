using System.Collections;
using Ctrl;
using Network;

namespace Task
{
    public class ConnectSrvTask : TaskBase
    {
        ServerType serverType;
        public void Init(ServerType type)
        {
            serverType = type;
            if(serverType == ServerType.LoginServer)
            {
                EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "连接登录服...");
                LoginControl.Instance.StartConnectLogin();
            }
            else if (serverType == ServerType.GateServer)
            {
                EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "连接网关服...");
                LoginControl.Instance.StartConnectGate();
            }
        }


        public override void OnUpdate()
        {
            if(NetworkManager.Instance.IsConnectServer(serverType))
            {
                OnComplete();
            }
        }
    }
}
