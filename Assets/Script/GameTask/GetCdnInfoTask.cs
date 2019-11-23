using Model;
using System.Collections;
using UnityEngine;

namespace Task
{
    public class GetCdnInfoTask : TaskBase
    {
        private bool finish = false;

        private IEnumerator Work()
        {
            yield return 0;
            EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "加载服务器列表...");
            WWW w = new WWW("http://118.190.203.203/server.json");
            yield return w;
            if (w.error == null)
            {
                cdnInfo info = JsonUtility.FromJson<cdnInfo>(w.text);
                if (info.serverList.Count == 0)
                {
                    EventCenter.Broadcast<string>(EGameEvent.eGameEvent_TipMsgChange, "服务器列表加载失败...");
                    OnFailure();
                    yield break;
                }
                NoticeModel.Instance.ServerCdnInfo = info;
                info.Print();
            }
            else
            {
                //sdUICharacter.Instance.ShowLoginMsg("读取分区信息错误：" + w.error);
                Debug.LogError("读取分区信息错误:" + w.error);
                EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFail);
                OnFailure();
                yield break;
            }
            yield return new WaitForSeconds(.9f);
            finish = true;
        }

        public void Init()
        {
            Mono.StartCoroutine(Work());
        }

        public override void OnUpdate()
        {
            if (finish)
            {
                OnComplete();
                TaskManager.Instance.GenerateTask<LoadConfigTask>();
            }
        }
    }
}