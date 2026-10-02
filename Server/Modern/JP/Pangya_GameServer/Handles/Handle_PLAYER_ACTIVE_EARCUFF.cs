using System;
using System.Threading.Tasks;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ACTIVE_EARCUFF : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
           
            try
            {
                var r = _session.GetGameRoom() ?? throw new exception("[Handle_PLAYER_ACTIVE_EARCUFF][Error] PLAYER [UID=" + _session.UserInfo.uid + "]  tentou ativar Earcuff no jogo na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x6201901));

               r.RequestActiveEarcuff(_session, _packet);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_ACTIVE_EARCUFF][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}