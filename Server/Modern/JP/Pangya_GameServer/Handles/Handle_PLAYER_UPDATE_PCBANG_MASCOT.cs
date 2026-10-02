using System;
using System.Threading.Tasks;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_UPDATE_PCBANG_MASCOT : IPacketHandler<Player>
    { 
        public async Task Handle(Player session, Packet pkt)
        {
            var _session = session;
            var _packet = pkt; 
        await Task.CompletedTask;
        }
    }
}
