// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: cmd_def.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from cmd_def.proto</summary>
public static partial class CmdDefReflection {

  #region Descriptor
  /// <summary>File descriptor for cmd_def.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static CmdDefReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg1jbWRfZGVmLnByb3RvKkIKB0xvZ2luSWQSEwoPTG9naW5JZF9JbnZhbGlk",
          "EAASEQoNTG9naW5JZF9CZWdpbhABEg8KC0xvZ2luSWRfRW5kEGQq6A0KCU1l",
          "c3NhZ2VJZBIQCgxNc2dfU3RhcnRfSWQQABIfChtMT0dJTl9DU19DUkVBVEVf",
          "QUNDT1VOVF9SRVEQARIfChtMT0dJTl9TQ19DUkVBVEVfQUNDT1VOVF9BQ0sQ",
          "AhIWChJMT0dJTl9DU19MT0dJTl9SRVEQAxIWChJMT0dJTl9TQ19MT0dJTl9B",
          "Q0sQBBIiCh5MT0dJTl9DU19RVUVSWV9TRVJWRVJfQUREUl9SRVEQBRIiCh5M",
          "T0dJTl9TQ19RVUVSWV9TRVJWRVJfQUREUl9BQ0sQBhIfChtTRVJWRVJfQ1Nf",
          "UVVFUllfR0FNRV9JRF9SRVEQZRIfChtTRVJWRVJfU0NfUVVFUllfR0FNRV9J",
          "RF9BQ0sQZhIbChdTRVJWRVJfU1NfR0FNRV9MT0FEX05URhBnEiIKHlNFUlZF",
          "Ul9DU19OT1RJRllfR0FURV9BRERSX05URhBoEicKIlNFUlZFUl9TU19DTElF",
          "TlRfU0VTU0lPTl9DTE9TRV9OVEYQyAESGwoWR0FNRV9DU19MT0dJTl9HQU1F",
          "X1JFURDpBxIbChZHQU1FX1NDX0xPR0lOX0dBTUVfQUNLEOoHEh4KGUdBTUVf",
          "Q1NfU0VUX05JQ0tfTkFNRV9SRVEQsAkSHgoZR0FNRV9TQ19TRVRfTklDS19O",
          "QU1FX0FDSxCxCRIbChZHQU1FX0NTX0dNX0NPTU1BTkRfUkVRELIJEhsKFkdB",
          "TUVfU0NfR01fQ09NTUFORF9BQ0sQswkSGgoVR0FNRV9TQ19LSUNLX1VTRVJf",
          "TlRGELQJEhYKEUdBTUVfU0NfRVJST1JfTlRGELUJEhwKF0dBTUVfU0NfSVRF",
          "TV9DSEFOR0VfTlRGELYJEh0KGEdBTUVfQ1NfT1BFUkFURV9JVEVNX1JFURC3",
          "CRIdChhHQU1FX1NDX09QRVJBVEVfSVRFTV9BQ0sQuAkSJgohR0FNRV9TQ19V",
          "UERBVEVfVVNFUl9CQVNFX0lORk9fTlRGELkJEhUKEEdBTUVfQ1NfQ0hBVF9S",
          "RVEQugkSFQoQR0FNRV9TQ19DSEFUX0FDSxC7CRIbChZHQU1FX0NTX0FERF9G",
          "UklFTkRfUkVREPgKEhsKFkdBTUVfU0NfQUREX0ZSSUVORF9BQ0sQ+QoSIQoc",
          "R0FNRV9TQ19BRERfRlJJRU5EX0FQUExZX05URhD6ChIlCiBHQU1FX0NTX09Q",
          "RVJBVEVfRlJJRU5EX0FQUExZX1JFURD7ChIlCiBHQU1FX1NDX09QRVJBVEVf",
          "RlJJRU5EX0FQUExZX0FDSxD8ChIbChZHQU1FX1NDX0FERF9GUklFTkRfTlRG",
          "EP0KEh4KGUdBTUVfQ1NfREVMRVRFX0ZSSUVORF9SRVEQ/goSHgoZR0FNRV9T",
          "Q19ERUxFVEVfRlJJRU5EX0FDSxD/ChIeChlHQU1FX1NDX0RFTEVURV9GUklF",
          "TkRfTlRGEIALEiIKHUdBTUVfQ1NfUVVFUllfRlJJRU5EX0xJU1RfUkVREIEL",
          "EiIKHUdBTUVfU0NfUVVFUllfRlJJRU5EX0xJU1RfQUNLEIILEiUKIEdBTUVf",
          "Q1NfRlJJRU5EX1BPSU5UX09QRVJBVEVfUkVREIMLEiUKIEdBTUVfU0NfRlJJ",
          "RU5EX1BPSU5UX09QRVJBVEVfQUNLEIQLEiIKHUdBTUVfU0NfRlJJRU5EX1BP",
          "SU5UX1JFQ1ZfTlRGEIULEigKI0dBTUVfQ1NfUVVFUllfRlJJRU5EX0FQUExZ",
          "X0xJU1RfUkVREIYLEigKI0dBTUVfU0NfUVVFUllfRlJJRU5EX0FQUExZX0xJ",
          "U1RfQUNLEIcLEiQKH0dBTUVfU0NfRlJJRU5EX1BPSU5UX1JFQ09SRF9OVEYQ",
          "iAsSHgoYREJfQ1NfUVVFUllfUk9VVEVfSURfUkVREKCcARIeChhEQl9TQ19R",
          "VUVSWV9ST1VURV9JRF9BQ0sQoZwBEiIKHERCX0NTX1FVRVJZX1VTRVJfQUND",
          "T1VOVF9SRVEQ6J0BEiIKHERCX1NDX1FVRVJZX1VTRVJfQUNDT1VOVF9BQ0sQ",
          "6Z0BEiAKGkRCX0NTX0NIRUNLX0xPR0lOX1NFU1NfUkVREOqdARIgChpEQl9T",
          "Q19DSEVDS19MT0dJTl9TRVNTX0FDSxDrnQESHgoYREJfQ1NfU0FWRV9VU0VS",
          "X0JBU0VfUkVRELCfARIeChhEQl9DU19TQVZFX1VTRVJfSVRFTV9SRVEQsZ8B",
          "EiAKGkRCX0NTX1NBVkVfVVNFUl9GUklFTkRfUkVREPigARIdChdEQl9DU19E",
          "Ql9BRERfRlJJRU5EX1JFURD5oAESIAoaREJfQ1NfREJfREVMRVRFX0ZSSUVO",
          "RF9SRVEQ+qABYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(new[] {typeof(global::LoginId), typeof(global::MessageId), }, null));
  }
  #endregion

}
#region Enums
public enum LoginId {
  [pbr::OriginalName("LoginId_Invalid")] Invalid = 0,
  [pbr::OriginalName("LoginId_Begin")] Begin = 1,
  [pbr::OriginalName("LoginId_End")] End = 100,
}

public enum MessageId {
  [pbr::OriginalName("Msg_Start_Id")] MsgStartId = 0,
  /// <summary>
  /// 	创建角色 **CSCreateAccountReq **login.proto **login-*,db-*;system:login
  /// </summary>
  [pbr::OriginalName("LOGIN_CS_CREATE_ACCOUNT_REQ")] LoginCsCreateAccountReq = 1,
  /// <summary>
  /// 	创建角色结果 **SCCreateAccountAck **login.proto **login-*,gate-*;system:login
  /// </summary>
  [pbr::OriginalName("LOGIN_SC_CREATE_ACCOUNT_ACK")] LoginScCreateAccountAck = 2,
  /// <summary>
  /// 	登录验证 **CSLoginReq **login.proto **login-*,db-*;system:login
  /// </summary>
  [pbr::OriginalName("LOGIN_CS_LOGIN_REQ")] LoginCsLoginReq = 3,
  /// <summary>
  /// 	登录验证结果 **SCLoginAck **login.proto **login-*,gate-*;system:login
  /// </summary>
  [pbr::OriginalName("LOGIN_SC_LOGIN_ACK")] LoginScLoginAck = 4,
  /// <summary>
  /// 	客户端请求gate服务器地址 **CSQueryServerAddrReq **login.proto **balance-*;system:login
  /// </summary>
  [pbr::OriginalName("LOGIN_CS_QUERY_SERVER_ADDR_REQ")] LoginCsQueryServerAddrReq = 5,
  /// <summary>
  /// 	客户端请求gate服务器地址 **SCQueryServerAddrAck **login.proto **client-*;system:login
  /// </summary>
  [pbr::OriginalName("LOGIN_SC_QUERY_SERVER_ADDR_ACK")] LoginScQueryServerAddrAck = 6,
  /// <summary>
  /// 	请求游戏服务器id **CSQueryGameIdReq **server.proto **game-*;system:server
  /// </summary>
  [pbr::OriginalName("SERVER_CS_QUERY_GAME_ID_REQ")] ServerCsQueryGameIdReq = 101,
  /// <summary>
  /// 	请求游戏服务器id结果 **SCQueryGameIdAck **server.proto **gate-*;system:server
  /// </summary>
  [pbr::OriginalName("SERVER_SC_QUERY_GAME_ID_ACK")] ServerScQueryGameIdAck = 102,
  /// <summary>
  /// 	通知游戏服的负载人数 **SSGameLoadNtf **server.proto **gate-*;system:server
  /// </summary>
  [pbr::OriginalName("SERVER_SS_GAME_LOAD_NTF")] ServerSsGameLoadNtf = 103,
  /// <summary>
  /// 	gate服务器的地址通知 **CSNotifyGateAddrNtf **server.proto **balance-*;system:server
  /// </summary>
  [pbr::OriginalName("SERVER_CS_NOTIFY_GATE_ADDR_NTF")] ServerCsNotifyGateAddrNtf = 104,
  /// <summary>
  /// 	客户端断开通知 **SSClientSessionCloseNtf **server.proto **game-*;system:user
  /// </summary>
  [pbr::OriginalName("SERVER_SS_CLIENT_SESSION_CLOSE_NTF")] ServerSsClientSessionCloseNtf = 200,
  /// <summary>
  /// 	客户端登录请求 **CSLoginGameReq **client_game.proto **gate-*,game-*,db-*;system:login
  /// </summary>
  [pbr::OriginalName("GAME_CS_LOGIN_GAME_REQ")] GameCsLoginGameReq = 1001,
  /// <summary>
  /// 	客户端登录回应 **SCLoginGameAck **client_game.proto **game-*;system:login
  /// </summary>
  [pbr::OriginalName("GAME_SC_LOGIN_GAME_ACK")] GameScLoginGameAck = 1002,
  /// <summary>
  /// 	设置角色名 **CSSetNickNameReq **client_game.proto **game-*,db-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_CS_SET_NICK_NAME_REQ")] GameCsSetNickNameReq = 1200,
  /// <summary>
  /// 	设置角色名结果 **SCSetNickNameAck **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_SET_NICK_NAME_ACK")] GameScSetNickNameAck = 1201,
  /// <summary>
  /// 	gm指令 **CSGMCommandReq **client_game.proto **game-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_CS_GM_COMMAND_REQ")] GameCsGmCommandReq = 1202,
  /// <summary>
  /// 	gm指令结果 **SCGMCommandAck **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_GM_COMMAND_ACK")] GameScGmCommandAck = 1203,
  /// <summary>
  /// 	游戏服通知gate踢人 **SCKickUserNtf **client_game.proto **gate-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_KICK_USER_NTF")] GameScKickUserNtf = 1204,
  /// <summary>
  /// 	通用错误协议 **SCErrorNtf **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_ERROR_NTF")] GameScErrorNtf = 1205,
  /// <summary>
  /// 	背包道具变更通知 **SCItemChangeNtf **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_ITEM_CHANGE_NTF")] GameScItemChangeNtf = 1206,
  /// <summary>
  /// 	使用/出售道具请求 **CSOperateItemReq **client_game.proto **game-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_CS_OPERATE_ITEM_REQ")] GameCsOperateItemReq = 1207,
  /// <summary>
  /// 	使用/出售道具结果 **SCOperateItemAck **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_OPERATE_ITEM_ACK")] GameScOperateItemAck = 1208,
  /// <summary>
  /// 	更新角色基础信息通知 **SCUpdateUserBaseInfoNtf **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_UPDATE_USER_BASE_INFO_NTF")] GameScUpdateUserBaseInfoNtf = 1209,
  /// <summary>
  /// 	聊天请求 **CSChatReq **client_game.proto **game-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_CS_CHAT_REQ")] GameCsChatReq = 1210,
  /// <summary>
  /// 	聊天回应 **SCChatAck **client_game.proto **client-*;system:user
  /// </summary>
  [pbr::OriginalName("GAME_SC_CHAT_ACK")] GameScChatAck = 1211,
  /// <summary>
  /// 	添加好友请求 **CSAddFriendReq **client_game.proto **game-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_CS_ADD_FRIEND_REQ")] GameCsAddFriendReq = 1400,
  /// <summary>
  /// 	添加好友回应 **SCAddFriendAck **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_ADD_FRIEND_ACK")] GameScAddFriendAck = 1401,
  /// <summary>
  /// 	好友申请通知 **SCAddFriendApplyNtf **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_ADD_FRIEND_APPLY_NTF")] GameScAddFriendApplyNtf = 1402,
  /// <summary>
  /// 	处理好友申请请求 **CSOperateFriendApplyReq **client_game.proto **game-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_CS_OPERATE_FRIEND_APPLY_REQ")] GameCsOperateFriendApplyReq = 1403,
  /// <summary>
  /// 	处理好友申请回应 **SCOperateFriendApplyAck **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_OPERATE_FRIEND_APPLY_ACK")] GameScOperateFriendApplyAck = 1404,
  /// <summary>
  /// 	添加好友通知 **SCAddFriendNtf **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_ADD_FRIEND_NTF")] GameScAddFriendNtf = 1405,
  /// <summary>
  /// 	删除好友请求 **CSDeleteFriendReq **client_game.proto **game-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_CS_DELETE_FRIEND_REQ")] GameCsDeleteFriendReq = 1406,
  /// <summary>
  /// 	删除好友回应 **SCDeleteFriendAck **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_DELETE_FRIEND_ACK")] GameScDeleteFriendAck = 1407,
  /// <summary>
  /// 	删除好友通知 **SCDeleteFriendNtf **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_DELETE_FRIEND_NTF")] GameScDeleteFriendNtf = 1408,
  /// <summary>
  /// 	请求好友列表 **CSQueryFriendListReq **client_game.proto **game-*,db-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_CS_QUERY_FRIEND_LIST_REQ")] GameCsQueryFriendListReq = 1409,
  /// <summary>
  /// 	请求好友列表回应 **SCQueryFriendListAck **client_game.proto **game-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_QUERY_FRIEND_LIST_ACK")] GameScQueryFriendListAck = 1410,
  /// <summary>
  /// 	好友体力操作请求 **CSFriendPointOperateReq **client_game.proto **game-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_CS_FRIEND_POINT_OPERATE_REQ")] GameCsFriendPointOperateReq = 1411,
  /// <summary>
  /// 	好友体力操作回应 **SCFriendPointOperateAck **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_FRIEND_POINT_OPERATE_ACK")] GameScFriendPointOperateAck = 1412,
  /// <summary>
  /// 	收到好友体力通知 **SCFriendPointRecvNtf **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_FRIEND_POINT_RECV_NTF")] GameScFriendPointRecvNtf = 1413,
  /// <summary>
  /// 	请求好友申请列表 **CSQueryFriendApplyListReq **client_game.proto **game-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_CS_QUERY_FRIEND_APPLY_LIST_REQ")] GameCsQueryFriendApplyListReq = 1414,
  /// <summary>
  /// 	请求好友申请列表回应 **SCQueryFriendApplyListAck **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_QUERY_FRIEND_APPLY_LIST_ACK")] GameScQueryFriendApplyListAck = 1415,
  /// <summary>
  /// 	SCFriendPointRecordNtf **SCFriendPointRecordNtf **client_game.proto **client-*;system:friend
  /// </summary>
  [pbr::OriginalName("GAME_SC_FRIEND_POINT_RECORD_NTF")] GameScFriendPointRecordNtf = 1416,
  /// <summary>
  /// 	dbrouter请求db的route id **CSQueryRouteIdReq **db.proto **db-*;system:server
  /// </summary>
  [pbr::OriginalName("DB_CS_QUERY_ROUTE_ID_REQ")] DbCsQueryRouteIdReq = 20000,
  /// <summary>
  /// 	db回应dbrouter routeid **SCQueryRouteIdAck **db.proto **db_router-db;system:server
  /// </summary>
  [pbr::OriginalName("DB_SC_QUERY_ROUTE_ID_ACK")] DbScQueryRouteIdAck = 20001,
  /// <summary>
  /// 	查询角色 **CSQueryUserAccountReq **db.proto **db-*;system:login
  /// </summary>
  [pbr::OriginalName("DB_CS_QUERY_USER_ACCOUNT_REQ")] DbCsQueryUserAccountReq = 20200,
  /// <summary>
  /// 	查询结果 **SCQueryUserAccountAck **db.proto **game-*;system:login
  /// </summary>
  [pbr::OriginalName("DB_SC_QUERY_USER_ACCOUNT_ACK")] DbScQueryUserAccountAck = 20201,
  /// <summary>
  /// 	检验login sess合法性 **CSCheckLoginSessReq **db.proto **db-*;system:login
  /// </summary>
  [pbr::OriginalName("DB_CS_CHECK_LOGIN_SESS_REQ")] DbCsCheckLoginSessReq = 20202,
  /// <summary>
  /// 	检验login sess合法性结果 **SCCheckLoginSessAck **db.proto **game-*;system:login
  /// </summary>
  [pbr::OriginalName("DB_SC_CHECK_LOGIN_SESS_ACK")] DbScCheckLoginSessAck = 20203,
  /// <summary>
  /// 	保存玩家基本信息 **CSSaveUserBaseReq **db.proto **db-*;system:user
  /// </summary>
  [pbr::OriginalName("DB_CS_SAVE_USER_BASE_REQ")] DbCsSaveUserBaseReq = 20400,
  /// <summary>
  /// 	保存玩家道具信息 **CSSaveUserItemReq **db.proto **db-*;system:user
  /// </summary>
  [pbr::OriginalName("DB_CS_SAVE_USER_ITEM_REQ")] DbCsSaveUserItemReq = 20401,
  /// <summary>
  /// 	保存玩家好友信息 **CSSaveUserFriendReq **db.proto **db-*;system:friend
  /// </summary>
  [pbr::OriginalName("DB_CS_SAVE_USER_FRIEND_REQ")] DbCsSaveUserFriendReq = 20600,
  /// <summary>
  /// 	添加好友 **CSDbAddFriendReq **db.proto **db-*;system:friend
  /// </summary>
  [pbr::OriginalName("DB_CS_DB_ADD_FRIEND_REQ")] DbCsDbAddFriendReq = 20601,
  /// <summary>
  /// 	删除好友 **CSDbDeleteFriendReq **db.proto **db-*;system:friend
  /// </summary>
  [pbr::OriginalName("DB_CS_DB_DELETE_FRIEND_REQ")] DbCsDbDeleteFriendReq = 20602,
}

#endregion


#endregion Designer generated code
