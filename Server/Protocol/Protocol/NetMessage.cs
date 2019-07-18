// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: NetMessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Protocol {

  /// <summary>Holder for reflection information generated from NetMessage.proto</summary>
  public static partial class NetMessageReflection {

    #region Descriptor
    /// <summary>File descriptor for NetMessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NetMessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBOZXRNZXNzYWdlLnByb3RvEghQcm90b2NvbBoZZ29vZ2xlL3Byb3RvYnVm",
            "L2FueS5wcm90byJFCgpOZXRNZXNzYWdlEhIKCnByb3RvY29sSWQYASABKAUS",
            "IwoFdmFsdWUYAiABKAsyFC5nb29nbGUucHJvdG9idWYuQW55YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.AnyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Protocol.NetMessage), global::Protocol.NetMessage.Parser, new[]{ "ProtocolId", "Value" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NetMessage : pb::IMessage<NetMessage> {
    private static readonly pb::MessageParser<NetMessage> _parser = new pb::MessageParser<NetMessage>(() => new NetMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NetMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protocol.NetMessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NetMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NetMessage(NetMessage other) : this() {
      protocolId_ = other.protocolId_;
      value_ = other.value_ != null ? other.value_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NetMessage Clone() {
      return new NetMessage(this);
    }

    /// <summary>Field number for the "protocolId" field.</summary>
    public const int ProtocolIdFieldNumber = 1;
    private int protocolId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ProtocolId {
      get { return protocolId_; }
      set {
        protocolId_ = value;
      }
    }

    /// <summary>Field number for the "value" field.</summary>
    public const int ValueFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Any value_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Any Value {
      get { return value_; }
      set {
        value_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NetMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NetMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ProtocolId != other.ProtocolId) return false;
      if (!object.Equals(Value, other.Value)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ProtocolId != 0) hash ^= ProtocolId.GetHashCode();
      if (value_ != null) hash ^= Value.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ProtocolId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ProtocolId);
      }
      if (value_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Value);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ProtocolId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ProtocolId);
      }
      if (value_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Value);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NetMessage other) {
      if (other == null) {
        return;
      }
      if (other.ProtocolId != 0) {
        ProtocolId = other.ProtocolId;
      }
      if (other.value_ != null) {
        if (value_ == null) {
          Value = new global::Google.Protobuf.WellKnownTypes.Any();
        }
        Value.MergeFrom(other.Value);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ProtocolId = input.ReadInt32();
            break;
          }
          case 18: {
            if (value_ == null) {
              Value = new global::Google.Protobuf.WellKnownTypes.Any();
            }
            input.ReadMessage(Value);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code