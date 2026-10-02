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
    public class Handle_PLAYER_LEAVE_CHIP_IN_PRACTICE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                var r = _session.GetGameRoom() ?? throw new exception("[Error] PLAYER [UID=" + _session.UserInfo.uid + "]  tentou sair do Chip-in Practice na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhum sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x6207701));


                if (r.GetTipo() != ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE)
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou sair do Chip-in Practice na sala[NUMERO=" + r.GetRoomId() + "], mas TIPO=" + Convert.ToString((ushort)r.GetTipo()) + " de jogo da sala nao é Chip-in Practice", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2, 0x6701002));
                }

                // Acabou o tempo /*Sai do Chip-in Practice*/
                if (r.FinishGame(_session, 2))
                {
                    _session.GetRoom().FinishGame();
                } 
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_LEAVE_CHIP_IN_PRACTICE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}