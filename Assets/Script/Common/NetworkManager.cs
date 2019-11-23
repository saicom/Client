using UnityEngine;
using System.Collections;
using SuperSocket.ClientEngine;
using System.Collections.Generic;
using System;
using System.Net;
using Google.Protobuf;
using Tools;
using System.Net.Sockets;
using System.Threading;
using Task;

namespace Network
{
    public enum ServerType
    {
        Invalid = 0,
        BalanceServer,
        GateServer,
        LoginServer,
    }
    public class NetworkManager : UnitySingleton<NetworkManager>
    {
        private TcpClient m_Client = null;
        private TcpClient m_Connecting = null;
        private string m_IP = "127.0.0.1";
        private Int32 m_Port = 40001;
        private Int32 m_n32ConnectTimes = 0;
        private ServerType m_serverType = ServerType.Invalid;
        private float m_CanConnectTime = 0f;
        private float m_RecvOverTime = 0f;
        private float mRecvOverDelayTime = 2f;
        private Int32 m_ConnectOverCount = 0;
        private float m_ConnectOverTime = 0f;
        private Int32 m_RecvOverCount = 0;
        private bool m_isConnect = false;
        public bool canReconnect = false;
        public byte[] m_RecvBuffer = new byte[2 * 1024 * 1024];
        public Int32 m_RecvPos = 0;
        IAsyncResult mRecvResult;
        IAsyncResult mConnectResult;
        //发送数据stream
        public System.IO.MemoryStream mSendStream = new System.IO.MemoryStream();
        //接收数据stream
        public List<int> mReceiveMsgIDs = new List<int>();
        public List<Int64> mReceiveMsgErrs = new List<Int64>();
        public List<System.IO.MemoryStream> mReceiveStreams = new List<System.IO.MemoryStream>();
        public List<System.IO.MemoryStream> mReceiveStreamsPool = new List<System.IO.MemoryStream>();

        public NetworkManager()
        {
            for (int i = 0; i < 50; ++i)
            {
                mReceiveStreamsPool.Add(new System.IO.MemoryStream());
            }
        }

        ~NetworkManager()
        {
            //接收stream
            foreach (System.IO.MemoryStream one in mReceiveStreams)
            {
                one.Close();
            }
            foreach (System.IO.MemoryStream one in mReceiveStreamsPool)
            {
                one.Close();
            }

            //发送stream
            if (mSendStream != null)
            {
                mSendStream.Close();
            }

            if (m_Client != null)
            {
                m_Client.Client.Shutdown(SocketShutdown.Both);
                m_Client.GetStream().Close();
                m_Client.Close();
                m_Client = null;
            }
        }


        public void Init(string ip, Int32 port, ServerType type)
        {
            Debug.Log("Set network ip:" + ip + " port:" + port + " type:" + type);
            m_IP = ip;
            m_Port = port;
            m_serverType = type;
            m_n32ConnectTimes = 0;
            canReconnect = true;
            m_RecvPos = 0;

#if UNITY_EDITOR
            mRecvOverDelayTime = 20000f;
#endif
        }

        public void UnInit()
        {
            canReconnect = false;
        }

        public void Connect()
        {
            if (!canReconnect) return;

            if (m_CanConnectTime > Time.time) return;

            if (m_Client != null)
                throw new Exception("fuck, The socket is connecting, cannot connect again!");

            if (m_Connecting != null)
                throw new Exception("fuck, The socket is connecting, cannot connect again!");

            Debug.Log("IClientSession Connect");

            IPAddress ipAddress = IPAddress.Parse(m_IP);

            try
            {
                m_Connecting = new TcpClient();

                mConnectResult = m_Connecting.BeginConnect(m_IP, m_Port, null, null);

                m_ConnectOverCount = 0;

                m_ConnectOverTime = Time.time + 2;
            }
            catch (Exception exc)
            {
                Debug.LogError(exc.ToString());

                m_Client = m_Connecting;

                m_Connecting = null;

                mConnectResult = null;

                OnConnectError(m_Client, null);
            }
        }

        public void Close(bool positive = false)
        {
            if (m_Client != null)
            {
                OnClosed(m_Client, null, positive);
            }
        }

        public void Update()
        {
            if (m_Client != null)
            {
                DealWithMsg();

                if (mRecvResult != null)
                {
                    if (m_RecvOverCount > 200 && Time.time > m_RecvOverTime)
                    {
                        Debug.LogError("recv data over 200, so close network.");
                        Close();
                        return;
                    }

                    ++m_RecvOverCount;

                    if (mRecvResult.IsCompleted)
                    {
                        try
                        {
                            Int32 n32BytesRead = m_Client.GetStream().EndRead(mRecvResult);
                            m_RecvPos += n32BytesRead;

                            if (n32BytesRead == 0)
                            {
                                Debug.LogError("can't recv data now, so close network 2.");
                                Close();
                                return;
                            }
                        }
                        catch (Exception exc)
                        {
                            Debug.LogError(exc.ToString());
                            Close();
                            return;
                        }

                        OnDataReceived(null, null);

                        if (m_Client != null)
                        {
                            try
                            {
                                mRecvResult = m_Client.GetStream().BeginRead(m_RecvBuffer, m_RecvPos, m_RecvBuffer.Length - m_RecvPos, null, null);
                                m_RecvOverTime = Time.time + mRecvOverDelayTime;
                                m_RecvOverCount = 0;
                            }
                            catch (Exception exc)
                            {
                                Debug.LogError(exc.ToString());
                                Close();
                                return;
                            }
                        }
                    }
                }

                if (m_Client != null && m_Client.Connected == false)
                {
                    Debug.LogError("client is close by system, so close it now.");
                    Close();
                    return;
                }
            }
            else if (m_Connecting != null)
            {
                if (m_ConnectOverCount > 200 && Time.time > m_ConnectOverTime)
                {
                    Debug.LogError("can't connect, so close network.");

                    m_Client = m_Connecting;

                    m_Connecting = null;

                    mConnectResult = null;

                    OnConnectError(m_Client, null);

                    return;
                }

                ++m_ConnectOverCount;

                if (mConnectResult.IsCompleted)
                {
                    m_Client = m_Connecting;

                    m_Connecting = null;

                    mConnectResult = null;

                    if (m_Client.Connected)
                    {
                        try
                        {
                            m_Client.NoDelay = true;

                            m_Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 2000);

                            m_Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 2000);

                            m_Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                            mRecvResult = m_Client.GetStream().BeginRead(m_RecvBuffer, 0, m_RecvBuffer.Length, null, null);

                            m_RecvOverTime = Time.time + mRecvOverDelayTime;

                            m_RecvOverCount = 0;

                            OnConnected(m_Client, null);
                        }
                        catch (Exception exc)
                        {
                            Debug.LogError(exc.ToString());
                            Close();
                            return;
                        }
                    }
                    else
                    {
                        OnConnectError(m_Client, null);
                    }
                }
            }
            else
            {
                Connect();
            }
        }

        public void SendMsg(IMessage pMsg, Int32 n32MsgID)
        {
            if (m_Client != null)
            {
                Debug.Log("send msg " + n32MsgID);
                ByteString bs = pMsg.ToByteString();
                CMsg pcMsg = new CMsg((int)bs.Length);
                pcMsg.SetProtocalID(n32MsgID);
                pcMsg.Add(bs.ToByteArray(), 0, (int)bs.Length);
#if UNITY_EDITOR
#else
                try
                {
#endif

#if LOG_FILE && UNITY_EDITOR
                if (n32MsgID != 8192 && n32MsgID != 16385)
                {
                    string msgName = "";
                    if (Enum.IsDefined(typeof(GCToBS.MsgNum), n32MsgID))
                    {
                        msgName = ((GCToBS.MsgNum)n32MsgID).ToString();
                    }
                    else if (Enum.IsDefined(typeof(GCToCS.MsgNum), n32MsgID))
                    {
                        msgName = ((GCToCS.MsgNum)n32MsgID).ToString();
                    }
                    else if (Enum.IsDefined(typeof(GCToLS.MsgID), n32MsgID))
                    {
                        msgName = ((GCToLS.MsgID)n32MsgID).ToString();
                    }
                    else if (Enum.IsDefined(typeof(GCToSS.MsgNum), n32MsgID))
                    {
                        msgName = ((GCToSS.MsgNum)n32MsgID).ToString();
                    }

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"E:\Log.txt", true))
                    {
                        sw.WriteLine(Time.time + "   发送消息：\t" + n32MsgID + "\t" + msgName);
                    }
                }
#endif
                m_Client.GetStream().Write(pcMsg.GetMsgBuffer(), 0, (int)pcMsg.GetMsgSize());
#if UNITY_EDITOR
#else
                }
                catch (Exception exc)
                {
                    Debug.LogError(exc.ToString());
                    Close();
                }
#endif
            }
        }

        public void OnConnected(object sender, EventArgs e)
        {
            m_isConnect = true;
            Debug.Log("connected");
            EventCenter.Broadcast<int>(EGameEvent.eGameEvent_ConnectServerSuccess, (int)m_serverType);
            switch (m_serverType)
            {
                case ServerType.BalanceServer:
                    {
                    }
                    break;
                case ServerType.GateServer:
                    {
                    }
                    break;
                case ServerType.LoginServer:
                    {
                    }
                    break;
            }
        }

        public void OnConnectError(object sender, ErrorEventArgs e)
        {
            m_isConnect = false;
            EventCenter.Broadcast<int>(EGameEvent.eGameEvent_ConnectServerFail, (int)m_serverType);
            Debug.LogError("connect error");

            try
            {
                m_Client.Client.Shutdown(SocketShutdown.Both);
                m_Client.GetStream().Close();
                m_Client.Close();
                m_Client = null;
            }
            catch (Exception exc)
            {
                Debug.Log(exc.ToString());
            }
            mRecvResult = null;
            m_Client = null;
            m_RecvPos = 0;
            m_RecvOverCount = 0;
            m_ConnectOverCount = 0;

        }

        public void OnClosed(object sender, EventArgs e, bool positive)
        {
            m_isConnect = false;
            if (positive == false)
            {
                EventCenter.Broadcast<int>(EGameEvent.eGameEvent_ConnectServerFail, (int)m_serverType);
            }
            Debug.LogError("on close error");

            try
            {
                m_Client.Client.Shutdown(SocketShutdown.Both);
                m_Client.GetStream().Close();
                m_Client.Close();
                m_Client = null;
            }
            catch (Exception exc)
            {
                Debug.Log(exc.ToString());
            }

            mRecvResult = null;
            m_Client = null;
            m_RecvPos = 0;
            m_RecvOverCount = 0;
            m_ConnectOverCount = 0;
            mReceiveStreams.Clear();
            mReceiveMsgIDs.Clear();
            mReceiveMsgErrs.Clear();
        }

        public void DealWithMsg()
        {
            while (mReceiveMsgIDs.Count > 0 && mReceiveStreams.Count > 0 && mReceiveMsgErrs.Count > 0)
            {
                int type = mReceiveMsgIDs[0];
                System.IO.MemoryStream iostream = mReceiveStreams[0];
                Int64 ErrCode = mReceiveMsgErrs[0];
                mReceiveMsgIDs.RemoveAt(0);
                mReceiveStreams.RemoveAt(0);
                mReceiveMsgErrs.RemoveAt(0);
#if UNITY_EDITOR
#else
                try
                {
#endif
#if LOG_FILE && UNITY_EDITOR
                if (type != 1)
                {
                    string msgName = "";
                    if (Enum.IsDefined(typeof(BSToGC.MsgID), type))
                    {
                        msgName = ((BSToGC.MsgID)type).ToString();
                    }
                    else if (Enum.IsDefined(typeof(LSToGC.MsgID), type))
                    {
                        msgName = ((LSToGC.MsgID)type).ToString();
                    }
                    else if (Enum.IsDefined(typeof(GSToGC.MsgID), type))
                    {
                        msgName = ((GSToGC.MsgID)type).ToString();
                    }

                   using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"E:\Log.txt", true))
                   {
                       sw.WriteLine(Time.time + "  收到消息：\t" + type + "\t" + msgName);
                    }
                }
#endif

                MsgHandlerManager.Instance.Process(iostream, type, ErrCode);

                if (mReceiveStreamsPool.Count < 50)
                {
                    mReceiveStreamsPool.Add(iostream);
                }
                else
                {
                    iostream = null;
                }

#if UNITY_EDITOR
#else
                }
                catch (Exception ecp)
                {
                    Debug.LogError("Handle Error msgid: " + type);
                }
#endif
            }
        }

        public void OnDataReceived(object sender, DataEventArgs e)
        {
            int m_CurPos = 0;
            while (m_RecvPos - m_CurPos >= 16)
            {
                int cmdId = BitConverter.ToInt32(m_RecvBuffer, m_CurPos);
                cmdId = IPAddress.NetworkToHostOrder(cmdId);
                int len = BitConverter.ToInt32(m_RecvBuffer, m_CurPos + 4);
                len = IPAddress.NetworkToHostOrder(len);
                UInt64 reserve = BitConverter.ToUInt64(m_RecvBuffer, m_CurPos + 8);
                Int64 error_code = IPAddress.NetworkToHostOrder(Convert.ToInt64(reserve));
                Debug.Log("Recv Message:" + "cmd=" + cmdId + ",len=" + len + ",error_code=" + error_code);
                if (len > m_RecvBuffer.Length)
                {
                    Debug.LogError("can't pause message");
                    break;
                }
                if (len > m_RecvPos - m_CurPos)
                {
                    break;//wait net recv more buffer to parse.
                }
                //获取stream
                System.IO.MemoryStream tempStream = null;
                if (mReceiveStreamsPool.Count > 0)
                {
                    tempStream = mReceiveStreamsPool[0];
                    tempStream.SetLength(0);
                    tempStream.Position = 0;
                    mReceiveStreamsPool.RemoveAt(0);
                }
                else
                {
                    tempStream = new System.IO.MemoryStream();
                }
                //往stream填充网络数据
                tempStream.Write(m_RecvBuffer, m_CurPos + 16, len - 16);
                tempStream.Position = 0;
                m_CurPos += len;
                mReceiveMsgIDs.Add(cmdId);
                mReceiveStreams.Add(tempStream);
                mReceiveMsgErrs.Add(error_code);
            }
            if (m_CurPos > 0)
            {
                m_RecvPos = m_RecvPos - m_CurPos;

                if (m_RecvPos < 0)
                {
                    Debug.LogError("m_RecvPos < 0");
                }

                if (m_RecvPos > 0)
                {
                    Buffer.BlockCopy(m_RecvBuffer, m_CurPos, m_RecvBuffer, 0, m_RecvPos);
                }
            }
        }

        public void ConnectServer(string addr, ServerType type)
        {
            if (IsConnectServer(type))
            {
                return;
            }
            Close(true);
            string[] address = addr.Split(':');
            if (address.Length < 2)
            {
                Debug.LogError("invalid address,type：" + type);
                return;
            }
            string ip = address[0];
            int port = Convert.ToInt32(address[1]);
            Init(ip, port, type);
            //StartCoroutine(DelayInvoke.Invoke<ServerType>(OpenConnectWaiting, 3f, type));
            ConnectWaitTask task = TaskManager.Instance.GenerateTask<ConnectWaitTask>();
            if (task != null)
            {
                task.Init(type);
            }
        }

        private void OpenConnectWaiting(ServerType type)
        {
            if (!(m_isConnect && m_serverType >= type))
            {
                //Debug.LogError("balaba " + type);
                UIUtils.OpenWaitingWnd();
            }
            else
            {
            }
        }

        public bool IsConnectServer(ServerType type)
        {
            return m_serverType == type && m_isConnect;
        }
    }
}