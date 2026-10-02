using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ACTIVE_ASSIST_GREEN : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            if (!_session.getState())
            {
                throw new exception("[Room::RequestActiveAssistGreen] [Error] player nao esta connectado", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    12, 0));
            }

            if (_packet == null)
            {
                throw new exception("[Room::RequestActiveAssistGreen] [Error] _packet is null", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    12, 0));
            }

            try
            {
                var r = _session.GetGameRoom() ?? throw new exception("[Room::RequestActiveAssistGreen] [Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou ativar Assist Green no jogo na sala[NUMERO=" + _session.GetRoom().GetRoomId() + "], mas a sala nao tem nenhum jogo inicializado. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1, 0x5201801));

                if (_session.UserInfo.AssistFlag)
                    r.RequestActiveAssistGreen(_session, _packet);
                else
                    _smp.message_pool.getInstance().push(new message("[Room::RequestActiveAssistGreen] [Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou ativar Assist Green no jogo na sala[NUMERO=" + r.GetRoomId() + "], mas ele nao tem o assist green. Hacker ou Bug", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Room::RequestActiveAssistGreen][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        } 
    }
}