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
    public class Handle_PLAYER_PLAYER_STATE_CHARACTER_LOUNGE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                var r = _session.GetRoom() ?? throw new exception("[Error] sala[NUMERO=" + _session.UserInfo.Member.sala_numero + "] nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        10, 0));

                if (r.GetTipo() != ROOM_INFO_TYPE.LOUNGE)
                {
                    throw new exception("[Error] sala[NUMERO=" + _session.UserInfo.Member.sala_numero + "] nao é um lounge.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        12, 0));
                }

                if (!_session.UserInfo.CharacterLoungeStates.TryGetValue(_session.Inventory.UserEquippedItem.CharacterEquiped.id, out StateCharacterLounge state))
                {
                    throw new exception("[Error] sala[NUMERO=" + _session.UserInfo.Member.sala_numero + "] nao tem os estados do character na lounge.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        13, 0));
                }

                Packet p = new(0x196);
                p.WriteInt32(_session.ConnectionID);
                p.WriteBytes(state.ToArray());
                r.SendBroadCast(p);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_PLAYER_STATE_CHARACTER_LOUNGE][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}