using Pangya_GameServer.Channels;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Pangya_GameServer.Models
{
    public static class NetworkExtensions
    {
        public static void SendBroadCast(this List<Player> Sessions, Packet p)
        {
            if (Sessions == null || p == null) return; 

            foreach (var _player in Sessions)
            {
                _player?.Send(p);
            }
        }

        public static void SendBroadCast(this List<Channel> channels, Packet p)
        {
            if (channels == null || channels.Count == 0 || p == null)
                return;

            foreach (var _channel in channels)
            {
                _channel.SendBroadcast(p);
            }
        }
    }
}
