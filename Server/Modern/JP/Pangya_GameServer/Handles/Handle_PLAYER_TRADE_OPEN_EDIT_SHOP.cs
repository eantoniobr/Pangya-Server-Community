using System;
using System.Threading.Tasks;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities; 
using PangyaAPI.Utilities.Log;
using static Pangya_GameServer.Models.DefineConstants;
using Pangya_GameServer.Server;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_TRADE_OPEN_EDIT_SHOP : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                var r = _session.GetRoom();

                if (r == null)
                {
                    _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestOpenEditSaleShop][Error][WARNIG] PLAYER [UID=" + _session.UserInfo.uid + "] Channel[ID=" + _session.GetChannel().getId() + "] tentou abrir ou editar um/o personal shop para ele, mas nao esta em nenhum sala[numero=" + (_session.UserInfo.Member.sala_numero) + "]. Hacker ou Bug [Tem que enviar a resposta para o cliente, por que ainda nao esta enviando]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    return;
                }

                if (!_session.getState())
                {
                    throw new exception("[Room::RequestOpenEditSaleShop] [Error] player nao esta connectado", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        12, 0));
                }
                if (_packet == null)
                {
                    throw new exception("[Room::RequestOpenEditSaleShop] [Error] _packet is null", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        12, 0));
                }

                var p = new Packet();
                if (r._tradeShop.RequestChatRoomOpenShopToEdit(_session, p))
                {
                    r.SendBroadCast(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestOpenEditSaleShop][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                if (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) != STDA_ERROR_TYPE.ROOM) throw;
            }
        }
    }
}