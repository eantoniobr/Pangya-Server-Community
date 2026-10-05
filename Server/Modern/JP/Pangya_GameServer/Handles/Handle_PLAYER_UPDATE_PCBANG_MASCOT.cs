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
    public class Handle_PLAYER_UPDATE_PCBANG_MASCOT : HandleBase<Player, Packet_EXAMPLE>
    { 
        public override async Task Handle()
        {
            var _session = session;
            var Packet = pkt; 
        await Task.CompletedTask;
        }
    }
}
