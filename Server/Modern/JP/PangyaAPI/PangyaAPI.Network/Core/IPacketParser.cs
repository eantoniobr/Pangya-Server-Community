using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Core
{
    public interface IPacketParser
    {
        List<Packet> Parse(int _parseKey, byte[] data, int length);
    }

    public interface IAuthPacketParser
    {
        List<Packet> Parse(int _parseKey, byte[] data, int length);
    }
}
