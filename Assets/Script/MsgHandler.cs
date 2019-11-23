using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Google.Protobuf;
using Ctrl;
using Login;
using ErrCode;
using Game;
using GameDefine;

public class MsgHandlerManager : Singleton<MsgHandlerManager> {
    public delegate void MsgHandler(byte[] buffer, Int64 errCode);
    private Dictionary<MessageId, MsgHandler> msgHandlers = new Dictionary<MessageId, MsgHandler>();

    /// <summary>
    /// 初始化协议处理函数
    /// </summary>
    public void Init()
    {
        Register(MessageId.LoginScQueryServerAddrAck, OnLoginScQueryServerAddrAck); 
        //Register(MessageId.LoginScLoginAck, OnLoginScLoginAck); 
        //Register(MessageId.LoginScCreateAccountAck, OnLoginScCreateAccountAck); 
        //Register(MessageId.GameScLoginGameAck, OnGameScLoginGameAck); 
        //Register(MessageId.GameScSetNickNameAck, OnGameScSetNickNameAck); 
        //Register(MessageId.GameScItemChangeNtf, OnGameScItemChangeNtf); 
        //Register(MessageId.GameScUpdateUserBaseInfoNtf, OnGameScUpdateUserBaseInfoNtf);
        //Register(MessageId.GameScGmCommandAck, OnGameScGmCommandAck);
        //Register(MessageId.GameScChatAck, OnGameScChatAck);
        //Register(MessageId.GameScQueryFriendListAck, OnGameScQueryFriendListAck);
        //Register(MessageId.GameScQueryFriendApplyListAck, OnGameScQueryFriendApplyListAck);
        //Register(MessageId.GameScAddFriendAck, OnGameScAddFriendAck);
        //Register(MessageId.GameScDeleteFriendAck, OnGameScDeleteFriendAck);
        //Register(MessageId.GameScFriendPointRecordNtf, OnGameScFriendPointRecordNtf);
        //Register(MessageId.GameScFriendPointRecvNtf, OnGameScFriendPointRecvNtf);
    }


    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="stream">消息流</param>
    /// <param name="cmdId">消息号</param>
    /// <param name="errCode">消息号</param>
    /// <returns></returns>
    public bool Process(System.IO.MemoryStream stream, int cmdId, Int64 errCode)
    {
        MessageId id = (MessageId)cmdId;
        if(msgHandlers.ContainsKey(id) == false)
        {
            return false;
        }
        msgHandlers[id](stream.ToArray(), errCode);
        return true;
    }

    /// <summary>
    /// 注册处理函数
    /// </summary>
    /// <param name="cmdId"> 消息id</param>
    /// <param name="handler">处理函数</param>
    public void Register(MessageId cmdId, MsgHandler handler)
    {
        if (msgHandlers.ContainsKey(cmdId))
        {
            Debug.Log("duplicate cmd handler:" + cmdId);
            return;
        }
        else
        {
            msgHandlers.Add(cmdId, handler);
        }
    }

    public void OnLoginScQueryServerAddrAck(byte[] buffer, Int64 errCode)
    {
        SCQueryServerAddrAck msg = new SCQueryServerAddrAck();
        msg = SCQueryServerAddrAck.Parser.ParseFrom(buffer);
        if (msg == null)
        {
            Debug.LogError("parse msg faild SCQueryServerAddrAck");
            return;
        }
        LoginControl.Instance.StartConnectGate(msg.ServerAddr);
    }

    ///// 账号登录成功
    //public void OnLoginScLoginAck(byte[] buffer, Int64 errCode)
    //{
    //    SCLoginAck msg = new SCLoginAck();
    //    msg = SCLoginAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild OnLoginScLoginAck");
    //        return;
    //    }

    //    if (msg.Result == (int)ErrorCode.NoError)
    //    {
    //        Debug.Log("login sucess " + msg.UserId);
    //        LoginControl.Instance.OnLoginSucess(msg.UserId);
    //        if(LoginControl.Instance.ChangeAccount == false)
    //        {
    //            LoginControl.Instance.EnterGame(msg.UserId);
    //        }

    //        EventCenter.Broadcast(EGameEvent.eGameEvent_LoginSuccess);
    //    }
    //    else
    //    {
    //        Debug.Log("login fail " + (ErrorCode)msg.Result);
    //        EventCenter.Broadcast(EGameEvent.eGameEvent_LoginFail);
    //    }
    //}

    //public void OnLoginScCreateAccountAck(byte[] buffer, Int64 errCode)
    //{
    //    SCCreateAccountAck msg = new SCCreateAccountAck();
    //    msg = SCCreateAccountAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCCreateAccountAck");
    //        return;
    //    }

    //    if (msg.Result == (int)ErrorCode.NoError)
    //    {
    //        PlayerPrefs.SetString("UserName", msg.AccountName);
    //        PlayerPrefs.SetString("Password", msg.Passwd);
    //        Debug.Log("register visitor success,"  + msg.AccountName + "," + msg.Passwd);
    //        LoginControl.Instance.EnterGame(msg.UserId);
    //    }
    //    else
    //    {
    //        EventCenter.Broadcast<int>(EGameEvent.eGameEvent_CreateAccountFail, msg.Result);
    //    }
    //}
    //public void OnGameScLoginGameAck(byte[] buffer, Int64 errCode)
    //{
    //    SCLoginGameAck msg = new SCLoginGameAck();
    //    msg = SCLoginGameAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCLoginGameAck");
    //        return;
    //    }

    //    if (msg.Error == (uint)ErrorCode.NoError)
    //    {
    //        GameUserModel.Instance.SetRoleBaseInfo(msg.RoleData.BaseInfo);
    //        InventoryModel.Instance.SetRoleBagInfo(msg.RoleData.BagInfo);
    //        FriendModel.Instance.SetFriendInfo(msg.RoleData.FriendInfo);
    //        if(msg.RoleData.BaseInfo.NickName == "")
    //        {
    //            EventCenter.SendEvent(new CEvent(EGameEvent.eGameEvent_CreateRole));
    //        }
    //        else
    //        {
    //            EventCenter.SendEvent(new CEvent(EGameEvent.eGameEvent_IntoLobby));
    //        }
    //    }
    //    else
    //    {
    //        EventCenter.Broadcast<uint>(EGameEvent.eGameEvent_EnterGameFail, msg.Error);
    //    }
    //}

    //public void OnGameScSetNickNameAck(byte[] buffer, Int64 errCode)
    //{
    //    SCSetNickNameAck msg = new SCSetNickNameAck();
    //    msg = SCSetNickNameAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCLoginGameAck");
    //        return;
    //    }

    //    if (msg.Result == (uint)ErrorCode.NoError)
    //    {
    //        EventCenter.SendEvent(new CEvent(EGameEvent.eGameEvent_IntoLobby));
    //    }
    //    else
    //    {
    //        EventCenter.Broadcast<uint>(EGameEvent.eGameEvent_CreateRoleFail, msg.Result);
    //    }
    //}
    //private void OnGameScItemChangeNtf(byte[] buffer, Int64 errCode)
    //{
    //    SCItemChangeNtf msg = new SCItemChangeNtf();
    //    msg = SCItemChangeNtf.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCItemChangeNtf");
    //        return;
    //    }
    //    for(int i = 0; i < msg.ItemList.Count; ++i)
    //    {
    //        InventoryModel.Instance.UpdateItem(msg.ItemList[i]);
    //    }
    //}
    //private void OnGameScUpdateUserBaseInfoNtf(byte[] buffer, Int64 errCode)
    //{
    //    SCUpdateUserBaseInfoNtf msg = new SCUpdateUserBaseInfoNtf();
    //    msg = SCUpdateUserBaseInfoNtf.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCUpdateUserBaseInfoNtf");
    //        return;
    //    }
    //    GameUserModel.Instance.UpdateRoleBase(msg.BaseInfo, msg.ChangeFlag);
    //    LobbyControl.Instance.UpdateBaseInfo();
    //}
    //private void OnGameScGmCommandAck(byte[] buffer, Int64 errCode)
    //{
    //    SCGMCommandAck msg = new SCGMCommandAck();
    //    msg = SCGMCommandAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCGMCommandAck");
    //        return;
    //    }
    //    string tip = msg.Result ? "成功" : "失败";
    //    GameMethod.ShowOkMsg(tip, "确定", () => { });
    //}

    //private void OnGameScChatAck(byte[] buffer, Int64 errCode)
    //{
    //    SCChatAck msg = new SCChatAck();
    //    msg = SCChatAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCChatAck");
    //        return;
    //    }

    //    ChatControl.Instance.RecvNewChatMsg(msg);
    //}

    //private void OnGameScQueryFriendListAck(byte[] buffer, Int64 errCode)
    //{
    //    SCQueryFriendListAck msg = new SCQueryFriendListAck();
    //    msg = SCQueryFriendListAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCQueryFriendListAck");
    //        return;
    //    }

    //    FriendsControl.Instance.OnGetFriendList(msg);
    //}

    //private void OnGameScQueryFriendApplyListAck(byte[] buffer, Int64 errCode)
    //{
    //    SCQueryFriendApplyListAck msg = new SCQueryFriendApplyListAck();
    //    msg = SCQueryFriendApplyListAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCQueryFriendApplyListAck");
    //        return;
    //    }

    //    FriendsControl.Instance.OnGetFriendApplyList(msg);
    //}
    //private void OnGameScAddFriendAck(byte[] buffer, long errCode)
    //{
    //    SCAddFriendAck msg = new SCAddFriendAck();
    //    msg = SCAddFriendAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCAddFriendAck");
    //        return;
    //    }
    //    if(errCode == 0)
    //    {
    //        GameMethod.ShowFlowMsg("申请成功");
    //    }
    //}

    //private void OnGameScDeleteFriendAck(byte[] buffer, long errCode)
    //{
    //    SCDeleteFriendAck msg = new SCDeleteFriendAck();
    //    msg = SCDeleteFriendAck.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCDeleteFriendAck");
    //        return;
    //    }
    //    if(errCode == 0)
    //    {
    //        FriendsControl.Instance.OnDeleteFriend(errCode);
    //        GameMethod.ShowFlowMsg("删除成功");
    //    }
    //}

    //private void OnGameScFriendPointRecvNtf(byte[] buffer, long errCode)
    //{
    //    SCFriendPointRecvNtf msg = new SCFriendPointRecvNtf();
    //    msg = SCFriendPointRecvNtf.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCFriendPointRecvNtf");
    //        return;
    //    }
    //    if(errCode == 0)
    //    {
    //        FriendsControl.Instance.OnRecvFriendPoint(msg.FromId);
    //    }
    //}

    //private void OnGameScFriendPointRecordNtf(byte[] buffer, long errCode)
    //{
    //    SCFriendPointRecordNtf msg = new SCFriendPointRecordNtf();
    //    msg = SCFriendPointRecordNtf.Parser.ParseFrom(buffer);
    //    if (msg == null)
    //    {
    //        Debug.LogError("parse msg faild SCFriendPointRecordNtf");
    //        return;
    //    }
    //    if(errCode == 0)
    //    {
    //        FriendsControl.Instance.OnNotifyFriendPointRecord(msg);
    //    }
    //}
}
