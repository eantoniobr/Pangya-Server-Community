using Pangya_GameServer.Engine;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models.Generic;
using PangyaAPI.IFF.Regions.JP.Models.IFF;
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
    public class Handle_PLAYER_CHECK_INVITE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var m_ci = _session.GetChannel();
            try
            {
                // Esse aqui o O Server Original nao retorna nada para o cliente, acho que é só um check
                uint uid = _packet.ReadUInt32();
                if (m_ci.sInvites.Any(c => c.invited_uid == uid))
                {
                    _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_CHECK_INVITE][Sucess] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + " ] enviou convite para o PLAYER [UID=" + uid + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_CHECK_INVITE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}