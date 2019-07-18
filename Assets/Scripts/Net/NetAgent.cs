using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NetAgent : MonoBehaviour
{
    public static NetAgent instance = null;
    private Thread netThread = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
        DontDestroyOnLoad(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
     //   NetManager.Instance.Start();
        ThreadStart threadStart = new ThreadStart(NetManager.Instance.Process);
        netThread = new Thread(threadStart);
        netThread.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Test
    /// </summary>
    public void StartC()
    {
        NetManager.Instance.Start();
    }
    void OnDestroy()
    {
        if (netThread != null)
        {
            netThread.Abort();
        }

    }
    /// <summary>
    /// 开始匹配对手
    /// </summary>
    public void StartMatch()
    {
        NetManager.Instance.Send<IMessage>(Protocol.Protocol.MATCH_START, null);
    }
}
