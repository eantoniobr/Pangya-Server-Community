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
    public class Handle_PLAYER_LOGIN : IAuthPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            // Initial log to track raw packet arrival (Hexdump)
            _smp.message_pool.getInstance().push(new message(
                $"[Handle_PLAYER_LOGIN][Debug] Packet Received: {_packet.Log()}",
                type_msg.CL_ONLY_FILE_LOG));

            try
            {
                // 1. Read Payload
                uint serverType = _packet.ReadUInt32();
                uint uid = _packet.ReadUInt32();
                string userId = _packet.ReadString();
                string loginKey = _packet.ReadString();
                string clientVersion = _packet.ReadString();
                uint packetVersion = _packet.ReadUInt32();

                // 2. Check for duplicate session/server login
                var existingSession = AuthServer.getInstance().FindPlayer(uid);
                if (existingSession != null)
                {
                    AuthServer.getInstance().Disconnect(existingSession);
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_LOGIN][Warning] Duplicate login detected: ID={userId}, UID={uid}. Dropping old session.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                // 3. Map to session data
                _session.UserInfo.tipo = serverType;
                _session.UserInfo.uid = uid;
                _session.UserInfo.id = userId;
                _session.UserInfo.nickname = userId;

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

                _session.Authorized = true;

                using (var response = new Packet(0x01))
                {
                    response.WriteInt32(_session.ConnectionID);
                    _session.SendAuth(response);
                }

                // Final success log
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_LOGIN][Sucess] SERVER[ID: {userId}, UID: {uid}, OID: {_session.ConnectionID}]",
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