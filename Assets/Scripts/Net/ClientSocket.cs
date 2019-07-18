using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Protocol;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
/// <summary>
/// socket封装
/// </summary>
public class ClientSocket
{
    public Queue<NetMessage> msgQueue = new Queue<NetMessage>();
    private Socket socket;
    private string ip;
    private int port;
    private byte[] buffer = new byte[1024];//接受缓存区
    private List<byte> dataCache = new List<byte>();//数据缓存
    private bool isProcessing = false;

    /// <summary>
    /// 构造socket
    /// </summary>
    /// <param name="ip">ipv4地址</param>
    /// <param name="port">端口号</param>
    public ClientSocket(string ip, int port)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.ip = ip;
        this.port = port;
    }
    public bool IsActive()
    {
        try
        {
            return !(socket.Poll(100, SelectMode.SelectRead) && socket.Available == 0);
        }
        catch (SocketException) { return false; }
    }
    /// <summary>
    /// 建立tcp连接
    /// </summary>
    public void Connect()
    {
        try
        {
            socket.Connect(ip, port);
            Debug.Log("服务器连接成功");
        }
        catch (Exception e)
        {
            Debug.LogError("Socket创建失败"+e.Message.ToString());
        }
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <typeparam name="T">Google Protobuf</typeparam>
    /// <param name="procode"> 协议编码</param>
    /// <param name="value">内容对象</param>
    public void Send<T>(int procode, T value) where T : IMessage
    {
        NetMessage msg = new NetMessage();
        msg.ProtocolId = procode;
        msg.Value = Any.Pack(value);
        Send(msg);
    }
    public void Send(NetMessage msg)
    {
        byte[] data = EncodeTool.Serialize(msg);
        byte[] packet = EncodeTool.EncodePacket(data);

        try
        {
            socket.Send(packet);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
    /// <summary>
    /// 开始接受消息
    /// </summary>
    public void StartReceive()
    {
        if (socket == null && socket.Connected)
        {
            Debug.LogError("socket无效，无法通信");
            return;
        }
        socket.BeginReceive(buffer, 0, 1024, SocketFlags.None, ReceiveCallBack, socket);
    }
    private void ReceiveCallBack(IAsyncResult result)
    {
        try
        {
            int lenght = socket.EndReceive(result);
            byte[] temp = new byte[lenght];
            Buffer.BlockCopy(buffer, 0, temp, 0, lenght);
            dataCache.AddRange(temp);
            if (isProcessing == false)
            {
                ProcessData();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

    }
    private void ProcessData()
    {
        isProcessing = true;
        //拆包
        byte[] data = EncodeTool.DecodePacket(ref dataCache);
        //无完整包退出递归
        if (data == null)
        {
            Debug.LogError("拆包失败");
            isProcessing = false;
            return;
        }
        NetMessage msg = EncodeTool.Deserialize<NetMessage>(data);
        if(msg == null)
        {
            Debug.LogError("反序列化失败");
            isProcessing = false;
            return;
        }
        msgQueue.Enqueue(msg);
        ProcessData();
    }
}
