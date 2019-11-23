using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameDefine;
using System.Linq;
using Network;
using View;
using UnityEngine.UI;
using DG.Tweening;

public static class GameUtils
{
    public static Transform GetCanvas()
    {
        return GameEntry.Instance.transform.Find("/Canvas");
    }

    //public static void ShowOkMsg(string tip, string okStr, MsgBoxWindow.ClickCallback onConfirm)
    //{
    //    CEvent eve = new CEvent(EGameEvent.eGameEvent_MsgBoxOkEnter);
    //    eve.AddParam("tip", tip);
    //    eve.AddParam("okStr", okStr);
    //    eve.AddParam("onConfirm", onConfirm);
    //    EventCenter.SendEvent(eve);
    //}
    //public static void ShowOkCancelMsg(string tip, string okStr, string cancelStr, MsgBoxWindow.ClickCallback onConfirm, MsgBoxWindow.ClickCallback onCancel)
    //{
    //    CEvent eve = new CEvent(EGameEvent.eGameEvent_MsgBoxOkCancelEnter);
    //    eve.AddParam("tip", tip);
    //    eve.AddParam("okStr", okStr);
    //    eve.AddParam("cancelStr", cancelStr);
    //    eve.AddParam("onConfirm", onConfirm);
    //    eve.AddParam("onCancel", onCancel);
    //    EventCenter.SendEvent(eve);
    //}

    //public static void CloseMsgBox()
    //{
    //    EventCenter.Broadcast(EGameEvent.eGameEvent_MsgBoxExit);
    //}

    //public static void ScrollText(Text t, uint to, float duration = 0.5f)
    //{
    //    uint from = Convert.ToUInt32(t.text);
    //    DOTween.To(delegate (float value)
    //    {
    //            //向下取整
    //            var temp = Math.Floor(value);
    //            //向Text组件赋值
    //            t.text = temp.ToString();
    //    }, from, to, duration);
    //}

    //public static void ShowMarquee(string msg)
    //{
    //    MarqueeModel.Instance.AddNotify(msg);
    //    EventCenter.Broadcast(EGameEvent.eGameEvent_MarqueeEnter);
    //}

    //public static void ShowFlowMsg(string msg)
    //{
    //    EventCenter.Broadcast(EGameEvent.eGameEvent_FlowMsgExit);
    //    EventCenter.Broadcast<string>(EGameEvent.eGameEvent_FlowMsgEnter, msg);
    //}
}
