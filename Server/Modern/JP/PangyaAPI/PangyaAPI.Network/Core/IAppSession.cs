using PangyaAPI.Network.Flags;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PangyaAPI.Network.Core
{
    public interface IAppSession : IDisposable
    {
        //------------------- FIELDS -------------------\\
        int ConnectionID { get; }
        int _ParseKey { get; }
        bool Connected { get; }
        IPEndPoint _RemoteIP { get; }
        string _IpAddress { get; }
        bool _MarkedIp { get; }
        bool Authorized { get; }
        int Tick { get; set; }
        int TicketBot { get; set; }
        int TimeStart { get; set; }
        IAppServer Server { get; }
        DateTime LastPacketTime { get; }
        CloseReason Reason { get; }
        bool ConnectionTimeOut { get; }
        double SecondsConnectedWithoutHandshake { get; }
        double SecondsSinceLastPacket { get; }
        //------------------- METHODS -------------------\\
        void MarkHandshakeDone();
        void UpdateLastPacket();
        bool IsHandshakeExpired(int timeoutSeconds);
        bool IsIdle(int idleSeconds);
        void SetHandshakeCts(CancellationTokenSource cts);
        void Send(Packet buffer, bool IsRaw = false, int debug = 0);
        void Send(List<Packet> list_buffer);
        Task<int> ReceiveAsync(byte[] buffer);
        Task<int> ReceiveAsync(byte[] buffer, CancellationToken token);
        void Disconnect();
        byte GetStateLogged();
        uint GetUID();
        uint GetCapability();
        string GetNickname();
        string GetID();
        void MakeIp();
        string GetIP();
        void GenerateParseKey();
        void SetReason(CloseReason reason);
        bool Clear();
    }
}
