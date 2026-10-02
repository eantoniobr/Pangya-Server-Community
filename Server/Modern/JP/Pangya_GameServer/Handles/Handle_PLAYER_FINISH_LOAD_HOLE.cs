using Pangya_GameServer.Channels;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_FINISH_LOAD_HOLE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            try
            {
                var game = _session.GetGameRoom() ?? throw new exception("[Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou finalizar carregamento do hole do jogo na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x5900401));

                // Timer do tempo que a sala fica aberta para entrar depois que o Tourney começa
                if (game.RequestFinishLoadHole(_session, _packet))
                {
                    var InRoom = _session.GetRoom();

                    // Update State Room
                    InRoom.SetState(1);
                    InRoom.SetFlag(1);
                     
                    // 2. Iniciamos o Timer com o callback
                    game?.RequestStartAfterEnter(() =>
                    {
                        // A segurança aqui é total: se o player deslogar, as referências 
                        // 'channel' e 'room' continuam vivas dentro deste bloco.
                        if (_session.GetChannel() != null && InRoom != null)
                        {
                         Lobby.OnEntryTimeExpired(_session.GetChannel(), InRoom);
                        }
                    });
                    // Update Room ON LOBBY
                    _session.GetChannel()?.SendUpdateRoomInfo(InRoom.GetInfo(), 3);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_FINISH_LOAD_HOLE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}