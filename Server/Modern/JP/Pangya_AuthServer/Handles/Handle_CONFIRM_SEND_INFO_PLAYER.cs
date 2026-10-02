using Pangya_AuthServer.Manager;
using Pangya_AuthServer.Server;
using Pangya_AuthServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_AuthServer.Handles
{
    public class Handle_CONFIRM_SEND_INFO_PLAYER : IAuthPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                // 1. Read packet data
                uint reqServerUid = _packet.ReadUInt32();
                int option = _packet.ReadInt32();
                uint playerUid = _packet.ReadUInt32();

                string playerId = string.Empty;
                string playerIp = string.Empty;

                if (option == 1)
                {
                    playerId = _packet.ReadString();
                    playerIp = _packet.ReadString();
                }

                // 2. Check if the target is the AuthServer itself
                if (reqServerUid == AuthServer.getInstance().m_si.uid)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_CONFIRM_SEND_INFO_PLAYER][Self-Target] Confirmation ignored: Server UID {reqServerUid} is the AuthServer. Player: {playerUid}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                    return;
                }

                // 3. Find the target server session
                var targetServer = AuthServer.getInstance().FindPlayer(reqServerUid);

                if (targetServer != null)
                {
                    // Success Log
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_CONFIRM_SEND_INFO_PLAYER][Sucess] Routing confirmation: SOURCE[Server: {_session.UserInfo.uid}] -> DEST[Server: {reqServerUid}] PLAYER: {playerUid}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // 4. Build response (OpCode 0x0C)
                    using (var p = new Packet(0x0C))
                    {
                        p.WriteUInt32(_session.UserInfo.uid); // Sender UID
                        p.WriteInt32(option);
                        p.WriteUInt32(playerUid);

                        if (option == 1)
                        {
                            p.WriteString(playerId);
                            p.WriteString(playerIp);
                        }

                        // 5. Send packet to target server
                        targetServer.SendAuth(p);
                    }
                }
                else
                {
                    // Warning Log
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_CONFIRM_SEND_INFO_PLAYER][Warning] Target offline: Server {reqServerUid} not found for Player {playerUid}.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (Exception ex)
            {
                // Error Log
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_CONFIRM_SEND_INFO_PLAYER][Exception] {ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}