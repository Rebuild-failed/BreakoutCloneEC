using Google.Protobuf;
using Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class NetManager
{
    private static NetManager instance;
    public static NetManager Instance
    {
        get
        {
            lock (locker)
            {
                return instance ?? (instance = new NetManager());
            }
        }
    }
    private NetManager()
    {
       
    }
    private ClientSocket client = new ClientSocket("123.207.141.38", 1997);//默认采用1997端口
    private static readonly object locker=new object();

    public void Start()
    {      
        client.Connect();
    }
    public void Process()
    {
        client.StartReceive();
        while(client.IsActive())
        {
            if(client.msgQueue.Count>0)
            {
                ProcessNetMsg(client.msgQueue.Dequeue());
            }
        }
    }
    public void Send<T>(int procode, T value) where T :IMessage
    {
        if(client.IsActive())
        {
            client.Send(procode, value);
        }      
    }
    private void ProcessNetMsg(NetMessage msg)
    {
        switch(msg.ProtocolId)
        {
            case Protocol.Protocol.MATCH_SUCCEED:
                FDEventFactor.Broadcast(FDEvent.Match_Succeed);
                break;//TODO
            default:break;
        }
    }

}

