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
    public class Handle_PLAYER_REPLY_CONTINUE_VERSUS : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            try
            {
                var room = _session.GetGameRoom() ?? throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou responder se quer continuar o versus ou nao na sala[NUMERO=" + _session.GetRoom()?.GetRoomId() + "], mas a sala nao tem nenhum jogo inicializado. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1, 0x556001));

                byte opt = _packet.ReadByte();
              
                if (opt == 0)
                {
                    if (room.GetSessions().Count() > 0)
                    {
                        if (room.FinishGame(room.GetSessions().First(), 2))
                        {
                            room.GameFinish();
                        }
                    }
                    else
                    {
                        room.GameFinish();
                    }
                }
                else if (opt == 1)
                {
                    room.RequestReplyContinue();
                }
                else
                {
                    _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_REPLY_CONTINUE_VERSUS][Error] PLAYER[UID=" + _session.UserInfo.uid + "] respondeu uma opcao invalida para continuar o versus na sala[NUMERO=" + _session.GetRoom()?.GetRoomId() + "]. Hacker ou Bug", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_REPLY_CONTINUE_VERSUS][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}