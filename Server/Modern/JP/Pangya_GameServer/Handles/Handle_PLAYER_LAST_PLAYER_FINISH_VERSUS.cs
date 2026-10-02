using System;
using System.Threading.Tasks;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Roms.GameBase.Modes;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_LAST_PLAYER_FINISH_VERSUS : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            try
            {
                var r = _session.GetGameRoom() ?? throw new exception("[Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou finalizar o Versus na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x555001));

                if (r is StrokeBase)
                {
                    if (r.GetSessions().Count > 0)
                    {
                        var lastPlayer = r.GetSessions()?.FirstOrDefault();
                        if (r.FinishGame(lastPlayer, 2))
                        {
                            _session.GetRoom()?.FinishGame();
                        }

                    }
                    else
                    {
                        _session.GetRoom()?.FinishGame();
                    }

                    _session.GetChannel()?.SendListUpdateRooms(_session.GetRoom().GetInfo());

                }
                else
                {
                    _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_LAST_PLAYER_FINISH_VERSUS][ErrorSystem] O jogo da sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "] nao e do tipo Versus. Hacker ou Bug", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_LAST_PLAYER_FINISH_VERSUS][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}