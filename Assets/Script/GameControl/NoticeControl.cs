using UnityEngine;
using System;
using System.Collections;
using Model;

namespace Ctrl
{
    public class NoticeControl : UnitySingleton<NoticeControl>
    {
        public void Enter()
        {
            //StartCoroutine(GetNoticeContent());
            EventCenter.Broadcast(EGameEvent.eGameEvent_NoticeEnter);
            EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFinish);
        }

        public void Exit()
        {
            EventCenter.Broadcast(EGameEvent.eGameEvent_NoticeExit);
        }

        public IEnumerator GetNoticeContent()
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
            EventCenter.Broadcast(EGameEvent.eGameEvent_NoticeEnter);
            EventCenter.Broadcast(EGameEvent.eGameEvent_InitGameFinish);
        }

    }
}
