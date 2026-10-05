using System;
using System.Threading.Tasks;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using Pangya_GameServer.Server;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_TRADE_CLOSE_SHOP : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                var r = Player.GetRoom();

                if (r == null)
                {
                    _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestCloseSaleShop][Error][WARNIG] PLAYER [UID=" + Player.UserInfo.uid + "] Channel[ID=" + Player.GetChannel().getId() + "] tentou deletar um personal shop dele, mas nao esta em nenhum sala[numero=" + (Player.UserInfo.Member.sala_numero) + "]. Hacker ou Bug [Tem que enviar a resposta para o cliente, por que ainda nao esta enviando]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                var p = new Packet();

                if (r._tradeShop.RequestChatRoomCloseShop(Player, p))
                {
                    r.SendBroadCast(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestCloseSaleShop][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                if (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) != STDA_ERROR_TYPE.ROOM) throw;
            }
        }
    }
}