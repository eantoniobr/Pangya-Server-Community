using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Core
{ 
    public interface IPacketHandler<TSession> where TSession : IAppSession
    {
        Task Handle();
    }

    public interface IAuthPacketHandler<TSession> where TSession : IAppSession
    {
        Task Handle(TSession session, Packet packet);
    }
}
