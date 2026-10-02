using System;
using System.Threading.Tasks;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
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
using System;
using System.Threading.Tasks;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_TEAM_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            Packet p = new();

            try
            {

                var r = (_session.GetRoom()) ?? throw new exception("[Lobby.Room::RequestChangePlayerTeamRoom][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou trocar de team(time) na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas a sala nao existe. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        10, 0));

                byte team = _packet.ReadByte();

                PlayerRoomInfo pPri = r.GetPlayerInfo(_session);

                if (pPri == null)
                {
                    throw new exception("[Room::RequestChangeTeam] [Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou trocar o team(time) na sala[NUMERO=" + r.GetRoomId() + "], mas a sala nao tem o info do player. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1505, 0));
                }

                if (r.TeamCount() < 2)
                {
                    throw new exception("[Room::RequestChangeTeam] [Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou trocar o team(time) na sala[NUMERO=" + r.GetRoomId() + "], mas a sala nao tem teans(times) suficiente. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1506, 0));
                }

                // Sai do outro team(time) se ele estiver
                try
                {

                    r.DeletePlayerTeam(_session, 3);

                }
                catch (exception e)
                {

                    _smp.message_pool.getInstance().push(new message("[Room::RequestChangeTeam][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                // Add o Player ao (team)time
                r.AddPlayerTeam(_session, team);

                pPri.state_flag.team = team;

                r.UpdatePlayerInfo(_session);


                p = new Packet((ushort)0x7D);

                p.WriteInt32(_session.ConnectionID);

                p.WriteByte(team);

                r.SendBroadCast(p);
            }
            catch (exception e)
            {

                _smp.message_pool.getInstance().push(new message("[Room::RequestChangeTeam][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}