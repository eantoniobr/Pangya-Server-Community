using Pangya_AuthServer.Server;
using Pangya_AuthServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Repository;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Pangya_AuthServer.Handles
{
    public class Handle_PLAYER_LOGIN : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            // Initial log to track raw packet arrival (Hexdump)
            _smp.message_pool.getInstance().push(new message(
                $"[Handle_PLAYER_LOGIN][Debug] Packet Received: {Packet.Log()}",
                type_msg.CL_ONLY_FILE_LOG));

            try
            {
                // 1. Read Payload
                uint serverType = Packet.ReadUInt32();
                uint uid = Packet.ReadUInt32();
                string userId = Packet.ReadString();
                string loginKey = Packet.ReadString();
                string clientVersion = Packet.ReadString();
                uint packetVersion = Packet.ReadUInt32();

                // 2. Check for duplicate Player/server login
                var existingSession = AuthServer.getInstance().FindPlayer(uid);
                if (existingSession != null)
                {
                    AuthServer.getInstance().Disconnect(existingSession);
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_LOGIN][Warning] Duplicate login detected: ID={userId}, UID={uid}. Dropping old Player.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                // 3. Map to Player data
                Player.UserInfo.tipo = serverType;
                Player.UserInfo.uid = uid;
                Player.UserInfo.id = userId;
                Player.UserInfo.nickname = userId;

                // 4. Database Key Validation
                CmdAuthServerKey cmd_ask = new CmdAuthServerKey((int)uid);
                snmdb.NormalManagerDB.getInstance().add(0, cmd_ask);

                if (cmd_ask.getException().getCodeError() != 0)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_LOGIN][DB Error] UID={uid}: {cmd_ask.getException().getFullMessageError()}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                    return;
                }

                var authInfo = cmd_ask.getInfo();

                // 5. Security Check
                if (authInfo == null || !authInfo.checkKey(loginKey))
                {
                    string expected = authInfo?.key ?? "NULL";
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_LOGIN][Security Alert] Invalid Key for {userId} (UID: {uid}). Received: {loginKey}, Expected: {expected}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Optional: Send error packet (0x01 with error code) here before returning
                    return;
                }

                // 6. Update state and confirm authorization
                authInfo.valid = 0;
                snmdb.NormalManagerDB.getInstance().add(2, new CmdUpdateAuthServerKey(authInfo));

                Player.Authorized = true;

                using (var response = new Packet(0x01))
                {
                    response.WriteInt32(Player.ConnectionID);
                    Player.SendAuth(response);
                }

                // Final success log
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_LOGIN][Sucess] SERVER[ID: {userId}, UID: {uid}, OID: {Player.ConnectionID}]",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (Exception ex)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_LOGIN][Critical] Exception: {ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}