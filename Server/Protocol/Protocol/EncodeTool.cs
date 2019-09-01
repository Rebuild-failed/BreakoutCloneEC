using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Google.Protobuf;

public class EncodeTool
{
    /// <summary>
    /// 封包 长度（2字节）+数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public static byte[] EncodePacket(byte[] data)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                short length = (short)data.Length;
                bw.Write(length);
                bw.Write(data);                
                return ms.ToArray();
            }
        }
    }
    /// <summary>
    /// 拆包
    /// </summary>
    /// <param name="dataCache">数据缓存</param>
    /// <returns></returns>
    public static byte[] DecodePacket(ref List<byte> dataCache)
    {
        if (dataCache.Count < 2)
        {
            throw new Exception("数据长度不足");
        }
        using (MemoryStream ms = new MemoryStream(dataCache.ToArray()))
        {
            using (BinaryReader br = new BinaryReader(ms))
            {
                short length = br.ReadInt16();
                byte[] data = br.ReadBytes(length);
                dataCache.RemoveRange(0, sizeof(short) + length);
                return data;
            }
        }
    }
    /// <summary>
    /// Google Protobuf 序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static byte[] Serialize<T>(T obj) where T :IMessage
    {
        using (MemoryStream ms = new MemoryStream())
        {
            // Save the person to a stream
            obj.WriteTo(ms);
            return ms.ToArray();

        }
    }
    /// <summary>
    /// Google Protobuf 反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static T Deserialize<T>(byte[] data) where T : class, IMessage, new()
    {
        T obj = new T();
        IMessage message = obj.Descriptor.Parser.ParseFrom(data);
        return message as T;
    }

}
