using UnityEngine;

namespace Task
{
    public class LoadConfigTask : TaskBase
    {
        public override void OnUpdate()
        {
            EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "加载游戏配置文件...");
            bool res = ConfigMgr.Instance.load(GameDefine.GameConstDefine.ConfigPath);
            if (res)
            {
                OnComplete();

                var task = TaskManager.Instance.GenerateTask<ConnectSrvTask>();
                task.Init(Network.ServerType.BalanceServer);
            }
            else
            {
                OnFailure();
                EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "加载游戏配置文件失败！");
            }
        }
    }
}