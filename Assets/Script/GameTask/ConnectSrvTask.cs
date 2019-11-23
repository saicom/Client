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
            if(serverType == ServerType.BalanceServer)
            {
                EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "连接负载均衡服...");
                LoginControl.Instance.StartConnectBalance();
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
                var task = TaskManager.Instance.GenerateTask<LoadNoticeTask>();
                task.Init();
            }
        }
    }
}
