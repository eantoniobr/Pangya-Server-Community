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
    public class Handle_PLAYER_TRADE_ENTER_SHOP : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        { 
            try
            {
                if (!Player.getState())
                {
                    throw new exception("[Error] Player nao esta connectado", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        12, 0));
                }

                if (Packet == null)
                {
                    throw new exception("[Error] Packet is null", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        12, 0));
                }

                var r = Player.GetRoom();

                if (r != null)
                {
                    if (r.GetTipo() == Flags.ROOM_INFO_TYPE.LOUNGE)
                        r._tradeShop.RequestChatRoomViewShop(Player, Packet.ReadUInt32());
                }
                else
                {
                    // não aqui mas no else tem que retornar erro para o cliente, que ele esta tentando Fechar um Personal Shop, mas ele nao esta em nenhum sala
                    // Isso é Hacker ou Bug
                    _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TRADE_ENTER_SHOP][Error][WARNIG] PLAYER [UID=" + Player.UserInfo.uid + "] tentou pedir Visit Count do personal shop dele. mas nao esta em nenhum sala[numero=" + (Player.UserInfo.Member.sala_numero) + "]. Hacker ou Bug [Tem que enviar a resposta para o cliente, por que ainda nao esta enviando]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TRADE_ENTER_SHOP][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                if (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) != STDA_ERROR_TYPE.ROOM)
                {
                    throw;
                }
            }
        }
    }
}