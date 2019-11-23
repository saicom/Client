using Ctrl;
using Model;
using System.Collections;
using UnityEngine;

namespace Task
{
    public class LoadNoticeTask : TaskBase
    {
        private bool finish = false;

        private IEnumerator Work()
        {
            string noticeUrl = NoticeModel.Instance.ServerCdnInfo.notice;
            WWW w = new WWW(noticeUrl);
            yield return w;
            if (w.error == null)
            {
                NoticeModel.Instance.ServerCdnInfo.notice = w.text;
            }
            else
            {
                Debug.LogError("读取公告失败:" + w.error);
                NoticeModel.Instance.ServerCdnInfo.notice = w.error;
                yield break;
            }
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
                NoticeControl.Instance.Enter();
            }
        }
    }
}
