using System;
using System.Threading.Tasks;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Models;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_MARKER_ON_COURSE : IPacketHandler<Player>
    {

        public async Task Handle(Player _session, Packet _packet)
        {
           
            try
            {
                var r = _session.GetGameRoom();

                if (r == null)
                {
                    throw new exception("[Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou marcar no course no jogo na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x552001));
                }

               r.RequestMarkerOnCourse(_session, _packet);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_MARKER_ON_COURSE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}