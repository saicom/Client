// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: login.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Login {

  /// <summary>Holder for reflection information generated from login.proto</summary>
  public static partial class LoginReflection {

    #region Descriptor
    /// <summary>File descriptor for login.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LoginReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgtsb2dpbi5wcm90bxIFbG9naW4iJwoUQ1NRdWVyeVNlcnZlckFkZHJSZXES",
            "DwoHem9uZV9pZBgBIAEoDSIrChRTQ1F1ZXJ5U2VydmVyQWRkckFjaxITCgtz",
            "ZXJ2ZXJfYWRkchgBIAEoCSJiChJDU0NyZWF0ZUFjY291bnRSZXESFAoMYWNj",
            "b3VudF9uYW1lGAEgASgJEg4KBnBhc3N3ZBgCIAEoCRITCgtwbGF0Zm9ybV9p",
            "ZBgDIAEoDRIRCglzZXJ2ZXJfaWQYBCABKA0ibwoSU0NDcmVhdGVBY2NvdW50",
            "QWNrEg4KBnJlc3VsdBgBIAEoBRIUCgxhY2NvdW50X25hbWUYAiABKAkSDgoG",
            "cGFzc3dkGAMgASgJEg8KB3VzZXJfaWQYBCABKA0SEgoKbG9naW5fc2VzcxgF",
            "IAEoCSJHCgpDU0xvZ2luUmVxEhQKDGFjY291bnRfbmFtZRgBIAEoCRIOCgZw",
            "YXNzd2QYAiABKAkSEwoLcGxhdGZvcm1faWQYAyABKA0iLQoKU0NMb2dpbkFj",
            "axIOCgZyZXN1bHQYASABKAUSDwoHdXNlcl9pZBgCIAEoDWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Login.CSQueryServerAddrReq), global::Login.CSQueryServerAddrReq.Parser, new[]{ "ZoneId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Login.SCQueryServerAddrAck), global::Login.SCQueryServerAddrAck.Parser, new[]{ "ServerAddr" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Login.CSCreateAccountReq), global::Login.CSCreateAccountReq.Parser, new[]{ "AccountName", "Passwd", "PlatformId", "ServerId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Login.SCCreateAccountAck), global::Login.SCCreateAccountAck.Parser, new[]{ "Result", "AccountName", "Passwd", "UserId", "LoginSess" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Login.CSLoginReq), global::Login.CSLoginReq.Parser, new[]{ "AccountName", "Passwd", "PlatformId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Login.SCLoginAck), global::Login.SCLoginAck.Parser, new[]{ "Result", "UserId" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// 客户端请求gate服务器地址
  /// </summary>
  public sealed partial class CSQueryServerAddrReq : pb::IMessage<CSQueryServerAddrReq> {
    private static readonly pb::MessageParser<CSQueryServerAddrReq> _parser = new pb::MessageParser<CSQueryServerAddrReq>(() => new CSQueryServerAddrReq());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CSQueryServerAddrReq> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Login.LoginReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSQueryServerAddrReq() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSQueryServerAddrReq(CSQueryServerAddrReq other) : this() {
      zoneId_ = other.zoneId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSQueryServerAddrReq Clone() {
      return new CSQueryServerAddrReq(this);
    }

    /// <summary>Field number for the "zone_id" field.</summary>
    public const int ZoneIdFieldNumber = 1;
    private uint zoneId_;
    /// <summary>
    /// 区id
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ZoneId {
      get { return zoneId_; }
      set {
        zoneId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CSQueryServerAddrReq);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CSQueryServerAddrReq other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ZoneId != other.ZoneId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ZoneId != 0) hash ^= ZoneId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ZoneId != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(ZoneId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ZoneId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ZoneId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CSQueryServerAddrReq other) {
      if (other == null) {
        return;
      }
      if (other.ZoneId != 0) {
        ZoneId = other.ZoneId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            ZoneId = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 客户端请求gate服务器地址
  /// </summary>
  public sealed partial class SCQueryServerAddrAck : pb::IMessage<SCQueryServerAddrAck> {
    private static readonly pb::MessageParser<SCQueryServerAddrAck> _parser = new pb::MessageParser<SCQueryServerAddrAck>(() => new SCQueryServerAddrAck());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SCQueryServerAddrAck> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Login.LoginReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCQueryServerAddrAck() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCQueryServerAddrAck(SCQueryServerAddrAck other) : this() {
      serverAddr_ = other.serverAddr_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCQueryServerAddrAck Clone() {
      return new SCQueryServerAddrAck(this);
    }

    /// <summary>Field number for the "server_addr" field.</summary>
    public const int ServerAddrFieldNumber = 1;
    private string serverAddr_ = "";
    /// <summary>
    /// ip:port
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ServerAddr {
      get { return serverAddr_; }
      set {
        serverAddr_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SCQueryServerAddrAck);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SCQueryServerAddrAck other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ServerAddr != other.ServerAddr) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ServerAddr.Length != 0) hash ^= ServerAddr.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ServerAddr.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ServerAddr);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ServerAddr.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ServerAddr);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SCQueryServerAddrAck other) {
      if (other == null) {
        return;
      }
      if (other.ServerAddr.Length != 0) {
        ServerAddr = other.ServerAddr;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            ServerAddr = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 创建角色
  /// </summary>
  public sealed partial class CSCreateAccountReq : pb::IMessage<CSCreateAccountReq> {
    private static readonly pb::MessageParser<CSCreateAccountReq> _parser = new pb::MessageParser<CSCreateAccountReq>(() => new CSCreateAccountReq());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CSCreateAccountReq> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Login.LoginReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSCreateAccountReq() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSCreateAccountReq(CSCreateAccountReq other) : this() {
      accountName_ = other.accountName_;
      passwd_ = other.passwd_;
      platformId_ = other.platformId_;
      serverId_ = other.serverId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSCreateAccountReq Clone() {
      return new CSCreateAccountReq(this);
    }

    /// <summary>Field number for the "account_name" field.</summary>
    public const int AccountNameFieldNumber = 1;
    private string accountName_ = "";
    /// <summary>
    /// 游客账号密码为空
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AccountName {
      get { return accountName_; }
      set {
        accountName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "passwd" field.</summary>
    public const int PasswdFieldNumber = 2;
    private string passwd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Passwd {
      get { return passwd_; }
      set {
        passwd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "platform_id" field.</summary>
    public const int PlatformIdFieldNumber = 3;
    private uint platformId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint PlatformId {
      get { return platformId_; }
      set {
        platformId_ = value;
      }
    }

    /// <summary>Field number for the "server_id" field.</summary>
    public const int ServerIdFieldNumber = 4;
    private uint serverId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ServerId {
      get { return serverId_; }
      set {
        serverId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CSCreateAccountReq);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CSCreateAccountReq other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AccountName != other.AccountName) return false;
      if (Passwd != other.Passwd) return false;
      if (PlatformId != other.PlatformId) return false;
      if (ServerId != other.ServerId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AccountName.Length != 0) hash ^= AccountName.GetHashCode();
      if (Passwd.Length != 0) hash ^= Passwd.GetHashCode();
      if (PlatformId != 0) hash ^= PlatformId.GetHashCode();
      if (ServerId != 0) hash ^= ServerId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AccountName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AccountName);
      }
      if (Passwd.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Passwd);
      }
      if (PlatformId != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(PlatformId);
      }
      if (ServerId != 0) {
        output.WriteRawTag(32);
        output.WriteUInt32(ServerId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AccountName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AccountName);
      }
      if (Passwd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Passwd);
      }
      if (PlatformId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(PlatformId);
      }
      if (ServerId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ServerId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CSCreateAccountReq other) {
      if (other == null) {
        return;
      }
      if (other.AccountName.Length != 0) {
        AccountName = other.AccountName;
      }
      if (other.Passwd.Length != 0) {
        Passwd = other.Passwd;
      }
      if (other.PlatformId != 0) {
        PlatformId = other.PlatformId;
      }
      if (other.ServerId != 0) {
        ServerId = other.ServerId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            AccountName = input.ReadString();
            break;
          }
          case 18: {
            Passwd = input.ReadString();
            break;
          }
          case 24: {
            PlatformId = input.ReadUInt32();
            break;
          }
          case 32: {
            ServerId = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 创建角色结果
  /// </summary>
  public sealed partial class SCCreateAccountAck : pb::IMessage<SCCreateAccountAck> {
    private static readonly pb::MessageParser<SCCreateAccountAck> _parser = new pb::MessageParser<SCCreateAccountAck>(() => new SCCreateAccountAck());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SCCreateAccountAck> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Login.LoginReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCCreateAccountAck() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCCreateAccountAck(SCCreateAccountAck other) : this() {
      result_ = other.result_;
      accountName_ = other.accountName_;
      passwd_ = other.passwd_;
      userId_ = other.userId_;
      loginSess_ = other.loginSess_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCCreateAccountAck Clone() {
      return new SCCreateAccountAck(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private int result_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    /// <summary>Field number for the "account_name" field.</summary>
    public const int AccountNameFieldNumber = 2;
    private string accountName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AccountName {
      get { return accountName_; }
      set {
        accountName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "passwd" field.</summary>
    public const int PasswdFieldNumber = 3;
    private string passwd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Passwd {
      get { return passwd_; }
      set {
        passwd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "user_id" field.</summary>
    public const int UserIdFieldNumber = 4;
    private uint userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    /// <summary>Field number for the "login_sess" field.</summary>
    public const int LoginSessFieldNumber = 5;
    private string loginSess_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string LoginSess {
      get { return loginSess_; }
      set {
        loginSess_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SCCreateAccountAck);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SCCreateAccountAck other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Result != other.Result) return false;
      if (AccountName != other.AccountName) return false;
      if (Passwd != other.Passwd) return false;
      if (UserId != other.UserId) return false;
      if (LoginSess != other.LoginSess) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != 0) hash ^= Result.GetHashCode();
      if (AccountName.Length != 0) hash ^= AccountName.GetHashCode();
      if (Passwd.Length != 0) hash ^= Passwd.GetHashCode();
      if (UserId != 0) hash ^= UserId.GetHashCode();
      if (LoginSess.Length != 0) hash ^= LoginSess.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Result);
      }
      if (AccountName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(AccountName);
      }
      if (Passwd.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Passwd);
      }
      if (UserId != 0) {
        output.WriteRawTag(32);
        output.WriteUInt32(UserId);
      }
      if (LoginSess.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(LoginSess);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Result);
      }
      if (AccountName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AccountName);
      }
      if (Passwd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Passwd);
      }
      if (UserId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(UserId);
      }
      if (LoginSess.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LoginSess);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SCCreateAccountAck other) {
      if (other == null) {
        return;
      }
      if (other.Result != 0) {
        Result = other.Result;
      }
      if (other.AccountName.Length != 0) {
        AccountName = other.AccountName;
      }
      if (other.Passwd.Length != 0) {
        Passwd = other.Passwd;
      }
      if (other.UserId != 0) {
        UserId = other.UserId;
      }
      if (other.LoginSess.Length != 0) {
        LoginSess = other.LoginSess;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Result = input.ReadInt32();
            break;
          }
          case 18: {
            AccountName = input.ReadString();
            break;
          }
          case 26: {
            Passwd = input.ReadString();
            break;
          }
          case 32: {
            UserId = input.ReadUInt32();
            break;
          }
          case 42: {
            LoginSess = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 登录验证
  /// </summary>
  public sealed partial class CSLoginReq : pb::IMessage<CSLoginReq> {
    private static readonly pb::MessageParser<CSLoginReq> _parser = new pb::MessageParser<CSLoginReq>(() => new CSLoginReq());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CSLoginReq> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Login.LoginReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSLoginReq() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSLoginReq(CSLoginReq other) : this() {
      accountName_ = other.accountName_;
      passwd_ = other.passwd_;
      platformId_ = other.platformId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CSLoginReq Clone() {
      return new CSLoginReq(this);
    }

    /// <summary>Field number for the "account_name" field.</summary>
    public const int AccountNameFieldNumber = 1;
    private string accountName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AccountName {
      get { return accountName_; }
      set {
        accountName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "passwd" field.</summary>
    public const int PasswdFieldNumber = 2;
    private string passwd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Passwd {
      get { return passwd_; }
      set {
        passwd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "platform_id" field.</summary>
    public const int PlatformIdFieldNumber = 3;
    private uint platformId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint PlatformId {
      get { return platformId_; }
      set {
        platformId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CSLoginReq);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CSLoginReq other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AccountName != other.AccountName) return false;
      if (Passwd != other.Passwd) return false;
      if (PlatformId != other.PlatformId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AccountName.Length != 0) hash ^= AccountName.GetHashCode();
      if (Passwd.Length != 0) hash ^= Passwd.GetHashCode();
      if (PlatformId != 0) hash ^= PlatformId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AccountName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AccountName);
      }
      if (Passwd.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Passwd);
      }
      if (PlatformId != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(PlatformId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AccountName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AccountName);
      }
      if (Passwd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Passwd);
      }
      if (PlatformId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(PlatformId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CSLoginReq other) {
      if (other == null) {
        return;
      }
      if (other.AccountName.Length != 0) {
        AccountName = other.AccountName;
      }
      if (other.Passwd.Length != 0) {
        Passwd = other.Passwd;
      }
      if (other.PlatformId != 0) {
        PlatformId = other.PlatformId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            AccountName = input.ReadString();
            break;
          }
          case 18: {
            Passwd = input.ReadString();
            break;
          }
          case 24: {
            PlatformId = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 登录验证结果
  /// </summary>
  public sealed partial class SCLoginAck : pb::IMessage<SCLoginAck> {
    private static readonly pb::MessageParser<SCLoginAck> _parser = new pb::MessageParser<SCLoginAck>(() => new SCLoginAck());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SCLoginAck> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Login.LoginReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCLoginAck() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCLoginAck(SCLoginAck other) : this() {
      result_ = other.result_;
      userId_ = other.userId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SCLoginAck Clone() {
      return new SCLoginAck(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private int result_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    /// <summary>Field number for the "user_id" field.</summary>
    public const int UserIdFieldNumber = 2;
    private uint userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SCLoginAck);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SCLoginAck other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Result != other.Result) return false;
      if (UserId != other.UserId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != 0) hash ^= Result.GetHashCode();
      if (UserId != 0) hash ^= UserId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Result);
      }
      if (UserId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(UserId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Result);
      }
      if (UserId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(UserId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SCLoginAck other) {
      if (other == null) {
        return;
      }
      if (other.Result != 0) {
        Result = other.Result;
      }
      if (other.UserId != 0) {
        UserId = other.UserId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Result = input.ReadInt32();
            break;
          }
          case 16: {
            UserId = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code