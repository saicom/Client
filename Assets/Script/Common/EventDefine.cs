using UnityEngine;
using System.Collections;

public enum EGameEvent
{
    eGameEvent_ErrorStr = 1,
    eGameEvent_ConnectServerFail,
    eGameEvent_ConnectServerSuccess,

    eGameEvent_ReConnectSuccess,
    eGameEvent_ReConnectFail,

    eGameEvent_InputUserData,
    
    eGameEvent_SelectServer,

    eGameEvent_IntoLobby,
    eGameEvent_CreateRole,

    eGameEvent_CreateRoleEnter,
    eGameEvent_CreateRoleExit,

    //登录窗口
    eGameEvent_LoginEnter,
    eGameEvent_LoginExit,
    eGameEvent_TipMsgChange,
    eGameEvent_InitGameFinish,
    eGameEvent_InitGameFail,

    //公告窗口
    eGameEvent_NoticeEnter,
    eGameEvent_NoticeExit,

    //等待窗口
    eGameEvent_WaitingEnter,
    eGameEvent_WaitingExit,

    //选服窗口
    eGameEvent_SelectSvrEnter,
    eGameEvent_SelectSvrExit,

}
