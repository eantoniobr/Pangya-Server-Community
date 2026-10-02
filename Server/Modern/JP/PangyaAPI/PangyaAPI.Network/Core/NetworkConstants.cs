using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Core
{
    public class NetworkConstants
    {
        public const int DefaultBufferSize = 4096;
        public const int MaxPacketSize = 8192;
        public const int HeaderSize = 4;

        public const int DisconnectTimeoutMs = 30000;
    }
}
