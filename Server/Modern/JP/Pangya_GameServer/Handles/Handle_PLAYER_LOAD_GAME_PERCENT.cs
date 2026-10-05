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
    public class Handle_PLAYER_LOAD_GAME_PERCENT : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
           
            try
            {
                var r = Player.GetGameRoom() ?? throw new exception("[Error] PLAYER[UID: " + Player.UserInfo.uid + "] tentou mandar a porcentagem do jogo carregado na sala[NUMEROR=" + (Player.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x551001));


                r.RequestLoadGamePercent(Player, Packet);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_LOAD_GAME_PERCENT][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}