using Network;
using UnityEngine;

namespace Task
{
    public class ConnectWaitTask : TaskBase
    {
        private ServerType serverType;
        private float duration = 0f;
        private float limit = 3f;

        public void Init(ServerType type)
        {
            serverType = type;
        }

        public override void OnUpdate()
        {
            bool isConnect = NetworkManager.Instance.IsConnectServer(serverType);
            if (isConnect)
            {
                OnComplete();
            }
            duration += Time.deltaTime;
            if (duration > limit)
            {
                UIUtils.OpenWaitingWnd();
            }
        }
    }
}