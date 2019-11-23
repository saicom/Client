// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: error_code.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ErrCode {

  /// <summary>Holder for reflection information generated from error_code.proto</summary>
  public static partial class ErrorCodeReflection {

    #region Descriptor
    /// <summary>File descriptor for error_code.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ErrorCodeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBlcnJvcl9jb2RlLnByb3RvEghlcnJfY29kZSrdAQoJRXJyb3JDb2RlEgsK",
            "B05vRXJyb3IQABITCg9Mb2dpbk90aGVyUGxhY2UQARITCg9Db25uZWN0R2Ft",
            "ZUZhaWwQAhISCg5Mb2dpbkV4Y2VwdGlvbhADEhQKEERiUXVlcnlFeGNlcHRp",
            "b24QBBIVChFEYkluc2VydEV4Y2VwdGlvbhAFEhUKEURiVXBkYXRlRXhjZXB0",
            "aW9uEAYSEQoNTG9naW5BdXRoRmFpbBAHEhQKEEludmFsaWRPcGVyYXRpb24Q",
            "CBIYChRUYXJnZXRGcmllbmRDb3VudE1heBAJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::ErrCode.ErrorCode), }, null));
    }
    #endregion

  }
  #region Enums
  public enum ErrorCode {
    /// <summary>
    /// 成功
    /// </summary>
    [pbr::OriginalName("NoError")] NoError = 0,
    /// <summary>
    /// 账号在别处登录
    /// </summary>
    [pbr::OriginalName("LoginOtherPlace")] LoginOtherPlace = 1,
    /// <summary>
    /// 连接游戏服失败
    /// </summary>
    [pbr::OriginalName("ConnectGameFail")] ConnectGameFail = 2,
    /// <summary>
    /// 登录异常
    /// </summary>
    [pbr::OriginalName("LoginException")] LoginException = 3,
    /// <summary>
    /// 查询异常
    /// </summary>
    [pbr::OriginalName("DbQueryException")] DbQueryException = 4,
    /// <summary>
    /// 插入异常
    /// </summary>
    [pbr::OriginalName("DbInsertException")] DbInsertException = 5,
    /// <summary>
    /// 更新异常
    /// </summary>
    [pbr::OriginalName("DbUpdateException")] DbUpdateException = 6,
    /// <summary>
    /// 登录验证失败
    /// </summary>
    [pbr::OriginalName("LoginAuthFail")] LoginAuthFail = 7,
    /// <summary>
    /// 非法操作
    /// </summary>
    [pbr::OriginalName("InvalidOperation")] InvalidOperation = 8,
    /// <summary>
    /// 对方好友已达上限
    /// </summary>
    [pbr::OriginalName("TargetFriendCountMax")] TargetFriendCountMax = 9,
  }

  #endregion

}

#endregion Designer generated code