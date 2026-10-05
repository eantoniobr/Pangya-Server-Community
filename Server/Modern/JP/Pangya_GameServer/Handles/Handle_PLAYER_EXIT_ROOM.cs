using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_EXIT_ROOM : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
            var _channel = Player.GetChannel();
                byte option = pkt.ReadByte();
                short roomId = pkt.ReadInt16();
                uint gamePang = pkt.ReadUInt32();
                uint gameBonus = pkt.ReadUInt32();
                byte[] roomKey = pkt.ReadBytes(8);

                var code = _channel?.LeaveRoomMultiPlayer(Player, 1);
                if (code > Channels.Channel.LEAVE_ROOM_STATE.DO_NOTHING)
                {
                    // Log de depuração
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_EXIT_ROOM][Sucess] PLAYER[UID: {Player.UserInfo.uid}, RID: {Player.UserInfo.Member.sala_numero}] EXIT TO ROOM. Option: {option}, Pang: {gamePang}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE)); 
					//atualiza.
					_channel.UpdatePlayerInfo(Player);
                    _channel.SendUpdatePlayerInfo(Player, 3);
                } 
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_EXIT_ROOM][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}