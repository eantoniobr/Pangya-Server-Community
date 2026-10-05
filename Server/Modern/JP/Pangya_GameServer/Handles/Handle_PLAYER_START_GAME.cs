using System;
using System.Threading.Tasks;
using PangyaAPI.Utilities.Log;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Server;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_START_GAME : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            var m_ci = Player.GetChannel();
            try
            {
                var r = Player.GetRoom();

                if (r == null)
                {
                    throw new exception("[Error] PLAYER [UID=" + Player.UserInfo.uid + "]  tentou comecar o jogo na sala[NUMERO=" + (Player.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x5900201));
                }

                if (r.RequestStartGame(Player, Packet))
                {
                    // Atualiza na lobby a sala, que acabou de começar o jogo
                    if (r.GetTipo() != ROOM_INFO_TYPE.PRACTICE && r.GetTipo() != ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE)
                    {
                        // Atualiza info da sala na lobby
                        m_ci.SendUpdateRoomInfo(r.GetInfo(), 3);
                    }
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_START_GAME][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}