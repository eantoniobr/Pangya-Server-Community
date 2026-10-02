using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CLUB_WORK_SHOP_EVENT_COUNT : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var p = new Packet();
            p.init_plain(0x24B); // packet id
            p.WriteInt32(0);//sub code!  
            for (int i = 0; i < 16; i++)
            {
                p.WriteByte((byte)(i + 1));                // subcode (fixo) 
            }
            _session.Send(p);

        await Task.CompletedTask;
        }
    }
}