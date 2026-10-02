using System;
using System.Threading.Tasks;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Threading.Tasks;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_START_FIRST_HOLE_GRAND_ZODIAC : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
           
            try
            {
                var r = _session.GetGameRoom() ?? throw new exception("[Handle_PLAYER_START_FIRST_HOLE_GRAND_ZODIAC][Error] PLAYER [UID=" + _session.UserInfo.uid + "]  tentou comecar o primeiro hole do Grand Zodiac game na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhum sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x6207801));

                r.RequestStartFirstHoleGrandZodiac(_session, _packet);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_START_FIRST_HOLE_GRAND_ZODIAC][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}