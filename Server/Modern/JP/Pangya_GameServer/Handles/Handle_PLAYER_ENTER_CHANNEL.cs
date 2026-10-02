using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ENTER_CHANNEL : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var m_ci = _session.GetChannel();

            try
            {
                sbyte channel = _packet.ReadSByte();

                // No padrão de Handle, o enterChannel geralmente é disparado pelo ChannelManager ou PlayerService
                var c = GameServer.getInstance().EnterChannel(_session, channel);

                if (c != null)
                {
                    if (!sAttendanceRewardSystem.getInstance().isLoad())
                        sAttendanceRewardSystem.getInstance().load();

                    var m_ari = _session.UserInfo.Attendance;

                    // Lógica de Recompensa de Presença (Attendance)
                    if (m_ari.login == 2 || m_ari.login == 3)
                    { 
                        sAttendanceRewardSystem.getInstance().sendGrandPrixTicket(_session);
                        sAttendanceRewardSystem.getInstance().sendFortuneKey(_session);
                        sAttendanceRewardSystem.getInstance().sendBotTicket(_session);
                    }
                    else
                    {
                        if (sAttendanceRewardSystem.getInstance().passedOneDay(_session))
                        { 
                            sAttendanceRewardSystem.getInstance().sendGrandPrixTicket(_session);
                            sAttendanceRewardSystem.getInstance().sendFortuneKey(_session);
                            sAttendanceRewardSystem.getInstance().sendBotTicket(_session);
                        }
                    }

                    _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_ENTER_CHANNEL][Sucess] PLAYER[UID: {_session.UserInfo.uid}, CID: {channel}] ENTER TO CHANNEL.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_ENTER_CHANNEL][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}