using Pangya_GameServer.Engine;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models.Generic;
using PangyaAPI.IFF.Regions.JP.Models.IFF;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_STATE_READY_ROOM : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            var m_ci = Player.GetChannel();
            try
            {
                var r = Player.GetRoom();

                if (r == null)
                {
                    throw new exception("[Handle_PLAYER_CHANGE_PLAYER_STATE_READY_ROOM][Error] PLAYER[UID=" + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + "] sala[NUMERO=" + (Player.UserInfo.Member.sala_numero) + "] nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0));
                }

                if (Packet.Size == 0)
                {
                    throw new exception("[Handle_PLAYER_CHANGE_PLAYER_STATE_READY_ROOM][Error] Size PLAYER[UID=" + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + "] sala[NUMERO=" + (Player.UserInfo.Member.sala_numero) + "] nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0));
                }

                byte ready = Packet.ReadByte();

                PlayerRoomInfo pri = r.GetPlayerInfo(Player);
                // Update state of ready
                pri.state_flag.ready = (byte)(ready == 0 ? 1 : 0);//invertido

                Packet p = new(0x78); // Estado de Ready do Player na sala

                p.WriteInt32(Player.ConnectionID);
                p.WriteByte(ready);
                r.SendBroadCast(p);

                r.UpdatePlayerInfo(Player);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_CHANGE_PLAYER_STATE_READY_ROOM][ErrorSystem] PLAYER[UID=" + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + "] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}