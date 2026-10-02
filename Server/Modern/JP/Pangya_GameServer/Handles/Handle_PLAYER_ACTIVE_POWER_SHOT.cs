using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ACTIVE_POWER_SHOT : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {

            try
            {
                var r = _session.GetGameRoom() ?? throw new exception("[Handle_PLAYER_ACTIVE_POWER_SHOT][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou ativar power shot, mas a sala [NUMERO=" + _session.UserInfo.Member.sala_numero + "] não foi encontrada. Hacker ou Bug",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 1, 0x5900801));
                
                r.RequestActivePowerShot(_session, _packet);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_ACTIVE_POWER_SHOT][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}