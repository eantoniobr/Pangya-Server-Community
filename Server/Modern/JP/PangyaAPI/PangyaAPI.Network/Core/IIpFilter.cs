using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Core
{
    public interface IIpFilter
    {
        bool IsBlocked(string ip);
        void OnConnect(string ip);
        void OnDisconnect(string ip);
    }
}
