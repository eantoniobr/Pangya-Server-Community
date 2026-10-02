using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;

using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Network.Repository;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_LOGIN : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet pkt)
        {
            Packet p = null;

            try
            {
                // --- Variáveis / estruturas ---
                uint packetVersion = 0;
                var kol = new KeysOfLogin();
                string clientVersion = string.Empty;
                string macAddress = string.Empty; // TODO: preencher se você medir MAC do client

                // --- Ler packet ---
                ReadLoginPacket(session, pkt, out uint ntreevUID, out ushort command,
                                out kol.keys[0], out clientVersion, out bool hasClientVersion,
                                out packetVersion, out macAddress, out bool hasMac, out kol.keys[1], out bool hasAuthKeyGame);

                bool hasAuthKeyLogin = !string.IsNullOrEmpty(kol.keys[0]);

                session.ResetHandShake(); // Reseta o handshake para evitar problemas de sincronização

                // --- Validações básicas do pacote e do cliente ---
                if (!ValidateLoginPacket(session, hasClientVersion, clientVersion, packetVersion, hasAuthKeyLogin, kol.keys[0], hasMac, macAddress, hasAuthKeyGame, kol.keys[1]))
                {
                    _smp.message_pool.getInstance().push(new message("[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID=" + (session.UserInfo.uid) + $", UserID= {session.UserInfo.id}, AuthKey[1]= {kol.keys[0]},  AuthKey[2]= {kol.keys[1]}, NtreevUID= {ntreevUID}, CVersion= {clientVersion}]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_INVALID_VERSION);
                    return;
                }

                // --- Ban checks (IP / MAC) ---
                if (GameServer.getInstance().haveBanList(session.GetIP(), macAddress))
                    throw new exception($"PLAYER[UID={session.UserInfo.uid}, IP={session.GetIP()}, MAC={macAddress}] blocked by banlist.");

                // --- sanity: id non-empty ---
                if (string.IsNullOrEmpty(session.UserInfo.id))
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={session.UserInfo.uid}, IP={session.GetIP()}] invalid id: {session.UserInfo.id}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_INVALID_VERSION);
                    return;
                }

                // --- Retrieve player info from DB ---
                var cmdPi = new CmdPlayerInfo(session.UserInfo.uid); // waiter
                NormalManagerDB.getInstance().add(0, cmdPi);
                if (cmdPi.getException().getCodeError() != 0) throw cmdPi.getException();

                session.UserInfo.Set(cmdPi.getInfo());

                if (session.UserInfo.uid <= 0)
                {
                    _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={session.UserInfo.uid}] not found in DB", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_INVALID_ID);
                    return;
                }

                // --- Anti-hack: verify client-supplied ID matches DB ID ---
                if (!string.Equals(cmdPi.getInfo().id, session.UserInfo.id, StringComparison.Ordinal))
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={session.UserInfo.uid}] client ID mismatch: client={session.UserInfo.id}, db={cmdPi.getInfo().id}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_INVALID_ID);
                    return;
                }

                // --- Account block checks (temporary / forever / all-ip) ---
                CheckAccountBlock(session);

                // --- Packet version validation (after decrypt) ---
                packetVersion = GameServer.getInstance().Version_Decrypt(packetVersion);
                var serverPacketVersion = GameServer.getInstance().getInfo().packet_version;
                if (!GameServer.getInstance().canSameIDLogin() && packetVersion != serverPacketVersion)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={session.UserInfo.uid}]. Client Packet Version not match. Server: {serverPacketVersion} != Client: {packetVersion}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_INVALID_VERSION);
                    return;
                }

                // --- AuthKey (login) check ---
                var cmdAkli = new CmdAuthKeyLoginInfo((int)session.UserInfo.uid);
                NormalManagerDB.getInstance().add(0, cmdAkli);
                if (cmdAkli.getException().getCodeError() != 0) throw cmdAkli.getException();

                // NOTE: security: previously code used bitwise & and inverted booleans -> fixed
                if (!GameServer.getInstance().canSameIDLogin() && (!string.Equals(kol.keys[0], cmdAkli.getInfo().key, StringComparison.Ordinal) || cmdAkli.getInfo().valid == 0))
                {
                    _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={session.UserInfo.uid}]. LKey invalid or reused.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_SECURITY_KEY);
                    return;
                }

                // --- AuthKey (game) check ---
                var cmdAkgi = new CmdAuthKeyGameInfo(session.UserInfo.uid, (int)GameServer.getInstance().getUID());
                NormalManagerDB.getInstance().add(0, cmdAkgi);
                if (cmdAkgi.getException().getCodeError() != 0) throw cmdAkgi.getException();

                if (!GameServer.getInstance().canSameIDLogin() && (!string.Equals(kol.keys[1], cmdAkgi.getInfo().key, StringComparison.Ordinal) || cmdAkgi.getInfo().valid == 0))
                {
                    _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={session.UserInfo.uid}]. GKey invalid or reused.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    session.Authorized = false;
                    SendLoginAck(session, eLoginAck.ACK_SECURITY_KEY);
                    return;
                }

                // --- Client version checks (region/season/high/low) ---
                var cvServer = ClientVersion.MakeVersion(GameServer.getInstance().m_si.version_client);
                var cvClient = ClientVersion.MakeVersion(clientVersion);
                EvaluateClientVersion(session, cvServer, cvClient);

                // --- Member Info ---
                var cmdMi = new CmdMemberInfo(session.UserInfo.uid);
                NormalManagerDB.getInstance().add(0, cmdMi);
                if (cmdMi.getException().getCodeError() != 0) throw cmdMi.getException();
                session.setMemberInfo(cmdMi.getInfo());

                // --- GM handling ---
                session.UserInfo.Member.oid = session.ConnectionID;
                session.UserInfo.Member.state_flag.visible = 1;
                session.UserInfo.Member.state_flag.whisper = session.UserInfo.WhisperState;
                session.UserInfo.Member.state_flag.channel = (byte)(session.UserInfo.WhisperState == 0 ? 1 : 0);
                if (session.UserInfo.UserCapabilities.game_master)
                {
                    session.m_gi.setGMUID(session.UserInfo.uid);
                    session.UserInfo.Member.state_flag.visible = session.m_gi.visible;
                    session.UserInfo.Member.state_flag.whisper = session.m_gi.whisper;
                    session.UserInfo.Member.state_flag.channel = session.m_gi.channel;

                }

                // --- GS property checks (rookie, mantle) ---
                if (GameServer.getInstance().m_si.propriedade.only_rookie && session.UserInfo.level >= 6)
                    throw new exception($"PLAYER[UID={session.UserInfo.uid}, LEVEL={session.UserInfo.level}] not allowed (rookie-only GS).");

                if (GameServer.getInstance().m_si.propriedade.mantle && !(session.UserInfo.UserCapabilities.mantle || session.UserInfo.UserCapabilities.game_master))
                    throw new exception($"PLAYER[UID={session.UserInfo.uid}] lacks mantle capability.");

                // --- Overlap: if another session with same UID exists ---
                var alreadyLogged = GameServer.getInstance().HasLoggedWithOuterSocket(session);
                if (alreadyLogged != null)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Error] existing session for UID={session.UserInfo.uid}, disconnecting existing.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    GameServer.getInstance().Disconnect(alreadyLogged);
                    //throw new exception($"Failed to disconnect existing session UID={alreadyLogged.getUID()}");
                }

                // --- Merge block flags and authorize session ---
                session.UserInfo.block_flag.m_flag.ullFlag |= GameServer.getInstance().m_si.flag.ullFlag;
                session.Authorized = true;

                // --- DB registration: player logged into GS ---
                NormalManagerDB.getInstance().add(5, new CmdRegisterLogon(session.UserInfo.uid, 0));

                NormalManagerDB.getInstance().add(7, new CmdRegisterLogonServer(session.UserInfo.uid, GameServer.getInstance().m_si.uid));

                _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Sucess] PLAYER[OID={session.ConnectionID}, UID={session.UserInfo.uid}, NICK={session.UserInfo.nickname}].", type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Papel shop init
                sPapelShopSystem.getInstance().InitPlayerPapelShopInfo(session);

                // Create login manager task to load all data
                session.Load(); 
                // Anti-bot timestamp
                session.TicketBot = Environment.TickCount;
                
                session.Send(Handle_PACKET_RESPONSE.pacote044(GameServer.getInstance().m_si, eLoginAck.ACK_AUTO_RECONNECT, session));
            }
            catch (exception ex)
            {
                _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Error] {ex.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));
                session.Authorized = false;

                // Generic error response
                p = new Packet(0x44);
                p.WriteUInt32(300);
                session.Send(p);
                // Disconnect session to be safe
                GameServer.getInstance().Disconnect(session);
            }

        await Task.CompletedTask;
        }

        /* ----------------------
           Helper methods used above
           ---------------------- */

        private void ReadLoginPacket(Player session, Packet pkt,
            out uint outNtreevUID, out ushort outCommand,
            out string outLKey, out string outClientVersion, out bool outHasClientVersion,
            out uint outPacketVersion, out string outMacAddress, out bool outHasMAC, out string outGKey, out bool outHasGKey)
        {
            outLKey = string.Empty;
            outClientVersion = string.Empty;
            outGKey = string.Empty;
            outMacAddress = string.Empty;

            session.UserInfo.id = pkt.ReadString();
            session.UserInfo.uid = pkt.ReadUInt32();
            outNtreevUID = pkt.ReadUInt32();
            outCommand = pkt.ReadUInt16();

            outLKey = pkt.ReadString();
            outHasClientVersion = pkt.ReadPStr(out outClientVersion) ? true : false;

            bool okPacketVersion = pkt.ReadUInt32(out outPacketVersion);
            outPacketVersion = okPacketVersion ? outPacketVersion : 0;
            outMacAddress = pkt.ReadString();
            outGKey = pkt.ReadString();
            outHasMAC = !string.IsNullOrEmpty(outMacAddress);
            outHasGKey = !string.IsNullOrEmpty(outGKey);
            session.MacAdress = outMacAddress;

        }

        private bool ValidateLoginPacket(Player session,
            bool hasClientVersion, string cversion, uint packetVersion,
            bool hasAuthKeyLogin, string lkey, bool hasMacAddress, string mac,
            bool hasAuthKeyGame, string gkey)
        {
            // checks: patch present, uid present, auth keys exist, id length sanity
            if (packetVersion == 0)
            {
                SendLoginAck(session, eLoginAck.ACK_INVALID_VERSION);
                return false;
            }

            if (session.UserInfo.uid == 0)
            {
                SendLoginAck(session, eLoginAck.ACK_LOGIN_FAIL);
                return false;
            }

            if (!hasClientVersion || string.IsNullOrEmpty(cversion))
            {
                SendLoginAck(session, eLoginAck.ACK_INVALID_VERSION);
                return false;
            }

            if (!hasAuthKeyLogin || string.IsNullOrEmpty(lkey))
            {
                SendLoginAck(session, eLoginAck.ACK_SECURITY_KEY);
                return false;
            }

            if (!hasMacAddress || string.IsNullOrEmpty(mac))
            {
                SendLoginAck(session, eLoginAck.ACK_BLOCKED_IP_ADDR);
                return false;
            }

            if (!hasAuthKeyGame || string.IsNullOrEmpty(gkey))
            {
                SendLoginAck(session, eLoginAck.ACK_INVALID_VERSION);
                return false;
            }
            if (string.IsNullOrEmpty(session.UserInfo.id) || session.UserInfo.id.Length >= 0x40)
            {
                SendLoginAck(session, eLoginAck.ACK_INVALID_ID);
                return false;
            }
            return true;
        }

        private void SendLoginAck(Player _session, eLoginAck ack)
        {
            using (var p = new Packet(0x44))
            {
                p.WriteUInt32((byte)ack);
                _session.Send(p);
            }

            GameServer.getInstance().Disconnect(_session);
        }

        private async void CheckAccountBlock(Player _session)
        {
            // Verifica aqui se a conta do player está bloqueada
            if (_session.UserInfo.block_flag.m_id_state.ull_IDState != 0)
            {

                if (_session.UserInfo.block_flag.m_id_state.L_BLOCK_TEMPORARY && (_session.UserInfo.block_flag.m_id_state.block_time == -1 || _session.UserInfo.block_flag.m_id_state.block_time > 0))
                {

                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] Bloqueado por tempo[Time="
                            + (_session.UserInfo.block_flag.m_id_state.block_time == -1 ? ("indeterminado") : ((_session.UserInfo.block_flag.m_id_state.block_time / 60)
                            + "min " + (_session.UserInfo.block_flag.m_id_state.block_time % 60) + "sec"))
                            + "]. player [UID=" + (_session.UserInfo.uid) + ", ID=" + (_session.UserInfo.id) + "]");

                }
                else if (_session.UserInfo.block_flag.m_id_state.L_BLOCK_FOREVER)
                {

                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] Bloqueado permanente. player [UID=" + (_session.UserInfo.uid)
                            + ", ID=" + (_session.UserInfo.id) + "]");
                }

                else if (_session.UserInfo.block_flag.m_id_state.L_BLOCK_ALL_IP)
                {

                    // Bloquea todos os IP que o player logar e da error de que a area dele foi bloqueada

                    // Add o ip do player para a lista de ip banidos
                    NormalManagerDB.getInstance().add(9, new CmdInsertBlockIp(_session.GetIP(), _session.MacAdress));

                    // Resposta
                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] PLAYER[UID=" + (_session.UserInfo.uid) + ", IP=" + (_session.GetIP())
                            + "] Block ALL IP que o player fizer login.");
                }
                else if (_session.UserInfo.block_flag.m_id_state.L_BLOCK_MAC_ADDRESS)
                {

                    // Bloquea o MAC Address que o player logar e da error de que a area dele foi bloqueada

                    // Add o MAC Address do player para a lista de MAC Address banidos
                    NormalManagerDB.getInstance().add(10, new CmdInsertBlockMac(_session.MacAdress));

                    // Resposta
                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] PLAYER[UID=" + (_session.UserInfo.uid)
                            + ", IP=" + (_session.GetIP()) + ", MAC=" + _session.MacAdress + "] Block MAC Address que o player fizer login.");

                }
            }
        }

        private void EvaluateClientVersion(Player session, ClientVersion serverVer, ClientVersion clientVer)
        {
            if (clientVer.flag == ClientVersion.COMPLETE_VERSION &&
                string.Equals(clientVer.region, serverVer.region) &&
                string.Equals(clientVer.season, serverVer.season))
            {
                if (clientVer.high != serverVer.high || clientVer.low < serverVer.low)
                    session.UserInfo.block_flag.m_flag.all_game = true;
            }
            else
            {
                if (clientVer.high != serverVer.high || clientVer.low < serverVer.low)
                    session.UserInfo.block_flag.m_flag.all_game = true;
            }
        } 
    }
}
