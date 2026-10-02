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
    public class Handle_PLAYER_EXIT_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet pkt)
        {
            try
            {
            var _channel = _session.GetChannel();
                byte option = pkt.ReadByte();
                short roomId = pkt.ReadInt16();
                uint gamePang = pkt.ReadUInt32();
                uint gameBonus = pkt.ReadUInt32();
                byte[] roomKey = pkt.ReadBytes(8);

                var code = _channel?.LeaveRoomMultiPlayer(_session, 1);
                if (code > Channels.Channel.LEAVE_ROOM_STATE.DO_NOTHING)
                {
                    // Log de depuração
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_EXIT_ROOM][Sucess] PLAYER[UID: {_session.UserInfo.uid}, RID: {_session.UserInfo.Member.sala_numero}] EXIT TO ROOM. Option: {option}, Pang: {gamePang}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE)); 
					//atualiza.
					_channel.UpdatePlayerInfo(_session);
                    _channel.SendUpdatePlayerInfo(_session, 3);
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