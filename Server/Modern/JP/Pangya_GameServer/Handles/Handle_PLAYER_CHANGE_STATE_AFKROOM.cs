using System;
using System.Threading.Tasks;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_STATE_AFKROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var m_ci = _session.GetChannel();
            try
            {
                byte state = _packet.ReadByte();

                var r = _session.GetRoom();

                if (r == null)
                {
                    throw new exception("[Lobby.Room::RequestChangePlayerStateAFKRoom][Error] sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "] nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        10, 0));
                }

                PlayerRoomInfo pri = r.GetPlayerInfo(_session);

                PlayerLobbyInfo pci = m_ci.GetPlayerInfo(_session);

                if (pri == null)
                {
                    throw new exception("[Lobby.Room::RequestChangePlayerStateAFKRoom][Error] nao tem o info do player na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "].", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        11, 0));
                }

                if (pci == null)
                {
                    throw new exception("[Lobby.Room::RequestChangePlayerStateAFKRoom][Error] nao tem o info do player no canal.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        12, 0));
                }

                pci.state_flag.away = pri.state_flag.away = state;

                Packet p = new Packet(0x8E);
                p.WriteInt32(_session.ConnectionID);
                p.WriteByte(state);

                r.SendBroadCast(p);

                m_ci.Lobby.SendBroadCast(Handle_PACKET_RESPONSE.pacote046(new List<PlayerLobbyInfo>() { (pci == null) ? new PlayerLobbyInfo() : pci }, 3));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[requestChangePlayerStateAFKRoom][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}