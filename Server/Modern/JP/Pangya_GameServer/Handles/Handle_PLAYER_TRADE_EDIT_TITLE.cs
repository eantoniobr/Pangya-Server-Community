using System;
using System.Threading.Tasks;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_TRADE_EDIT_TITLE : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {

            try
            {
                var r = Player.GetRoom();

                if (r != null)
                {
                    var p = new Packet(); 
                    if (r._tradeShop.RequestChatRoomChangeShopName(Player, Packet.ReadString(), p))
                    {
                        r.SendBroadCast(p);
                    }
                }
                else
                {
                    // não aqui mas no else tem que retornar erro para o cliente, que ele esta tentando Fechar um Personal Shop, mas ele nao esta em nenhum sala
                    // Isso é Hacker ou Bug
                    _smp.message_pool.getInstance().push(new message("[Error][WARNIG] PLAYER [UID=" + Player.UserInfo.uid + "] tentou trocar o nome do personal shop dele. mas nao esta em nenhum sala[numero=" + (Player.UserInfo.Member.sala_numero) + "]. Hacker ou Bug [Tem que enviar a resposta para o cliente, por que ainda nao esta enviando]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }  
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TRADE_EDIT_TITLE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                if (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) != STDA_ERROR_TYPE.ROOM)
                {
                    throw;
                }
            }
        }
    }
}