using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Handles.Packets;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Handle;
using PangyaAPI.Network.Models;
using PangyaAPI.Network.Repository;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_LOGIN : HandleBase<Player, Packet_PLAYER_LOGIN>
    {
        public override async Task Handle()
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
                //nao usamos mais
                //ReadLoginPacket(Player, PacketResult, out uint ntreevUID, out ushort command,
                //                out kol.keys[0], out clientVersion, out bool hasClientVersion,
                //                out packetVersion, out macAddress, out bool hasMac, out kol.keys[1], out bool hasAuthKeyGame);

                bool hasAuthKeyLogin = !string.IsNullOrEmpty(kol.keys[0]);

                Player.ResetHandShake(); // Reseta o handshake para evitar problemas de sincronização

                // --- Validações básicas do pacote e do cliente ---
                if (!ValidateLoginPacket(PacketResult.HasClientVersion, clientVersion, packetVersion, hasAuthKeyLogin, kol.keys[0], PacketResult.HasMAC, PacketResult.MacAddress, PacketResult.HasGKey, kol.keys[1]))
                {
                    _smp.message_pool.getInstance().push(new message("[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID=" + (Player.UserInfo.uid) + $", UserID= {Player.UserInfo.id}, AuthKey[1]= {kol.keys[0]},  AuthKey[2]= {kol.keys[1]}, NtreevUID= {PacketResult.Command}, CVersion= {clientVersion}]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_INVALID_VERSION);
                    return;
                }

                // --- Ban checks (IP / MAC) ---
                if (GameServer.getInstance().haveBanList(Player.GetIP(), macAddress))
                    throw new exception($"PLAYER[UID={Player.UserInfo.uid}, IP={Player.GetIP()}, MAC={macAddress}] blocked by banlist.");

                // --- sanity: id non-empty ---
                if (string.IsNullOrEmpty(Player.UserInfo.id))
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={Player.UserInfo.uid}, IP={Player.GetIP()}] invalid id: {Player.UserInfo.id}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_INVALID_VERSION);
                    return;
                }

                // --- Retrieve Player info from DB ---
                var cmdPi = new CmdPlayerInfo(Player.UserInfo.uid); // waiter
                NormalManagerDB.getInstance().add(0, cmdPi);
                if (cmdPi.getException().getCodeError() != 0) throw cmdPi.getException();

                Player.UserInfo.Set(cmdPi.getInfo());

                if (Player.UserInfo.uid <= 0)
                {
                    _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={Player.UserInfo.uid}] not found in DB", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_INVALID_ID);
                    return;
                }

                // --- Anti-hack: verify client-supplied ID matches DB ID ---
                if (!string.Equals(cmdPi.getInfo().id, Player.UserInfo.id, StringComparison.Ordinal))
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={Player.UserInfo.uid}] client ID mismatch: client={Player.UserInfo.id}, db={cmdPi.getInfo().id}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_INVALID_ID);
                    return;
                }

                // --- Account block checks (temporary / forever / all-ip) ---
                CheckAccountBlock();

                // --- Packet version validation (after decrypt) ---
                packetVersion = PacketVersion(packetVersion);
                var serverPacketVersion = GameServer.getInstance().getInfo().packet_version;
                if (!GameServer.getInstance().canSameIDLogin() && packetVersion != serverPacketVersion)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={Player.UserInfo.uid}]. Client Packet Version not match. Server: {serverPacketVersion} != Client: {packetVersion}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_INVALID_VERSION);
                    return;
                }

                // --- AuthKey (login) check ---
                var cmdAkli = new CmdAuthKeyLoginInfo((int)Player.UserInfo.uid);
                NormalManagerDB.getInstance().add(0, cmdAkli);
                if (cmdAkli.getException().getCodeError() != 0) throw cmdAkli.getException();

                // NOTE: security: previously code used bitwise & and inverted booleans -> fixed
                if (!GameServer.getInstance().canSameIDLogin() && (!string.Equals(kol.keys[0], cmdAkli.getInfo().key, StringComparison.Ordinal) || cmdAkli.getInfo().valid == 0))
                {
                    _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={Player.UserInfo.uid}]. LKey invalid or reused.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_SECURITY_KEY);
                    return;
                }

                // --- AuthKey (game) check ---
                var cmdAkgi = new CmdAuthKeyGameInfo(Player.UserInfo.uid, (int)GameServer.getInstance().getUID());
                NormalManagerDB.getInstance().add(0, cmdAkgi);
                if (cmdAkgi.getException().getCodeError() != 0) throw cmdAkgi.getException();

                if (!GameServer.getInstance().canSameIDLogin() && (!string.Equals(kol.keys[1], cmdAkgi.getInfo().key, StringComparison.Ordinal) || cmdAkgi.getInfo().valid == 0))
                {
                    _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Warning] PLAYER[UID={Player.UserInfo.uid}]. GKey invalid or reused.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    Player.Authorized = false;
                    SendLoginAck(eLoginAck.ACK_SECURITY_KEY);
                    return;
                }

                // --- Client version checks (region/season/high/low) ---
                var cvServer = ClientVersion.MakeVersion(GameServer.getInstance().m_si.version_client);
                var cvClient = ClientVersion.MakeVersion(clientVersion);
                EvaluateClientVersion(cvServer, cvClient);

                // --- Member Info ---
                var cmdMi = new CmdMemberInfo(Player.UserInfo.uid);
                NormalManagerDB.getInstance().add(0, cmdMi);
                if (cmdMi.getException().getCodeError() != 0) throw cmdMi.getException();
                Player.setMemberInfo(cmdMi.getInfo());

                // --- GM handling ---
                Player.UserInfo.Member.oid = Player.ConnectionID;
                Player.UserInfo.Member.state_flag.visible = 1;
                Player.UserInfo.Member.state_flag.whisper = Player.UserInfo.WhisperState;
                Player.UserInfo.Member.state_flag.channel = (byte)(Player.UserInfo.WhisperState == 0 ? 1 : 0);
                if (Player.UserInfo.UserCapabilities.game_master)
                {
                    Player.m_gi.setGMUID(Player.UserInfo.uid);
                    Player.UserInfo.Member.state_flag.visible = Player.m_gi.visible;
                    Player.UserInfo.Member.state_flag.whisper = Player.m_gi.whisper;
                    Player.UserInfo.Member.state_flag.channel = Player.m_gi.channel;

                }

                // --- GS property checks (rookie, mantle) ---
                if (GameServer.getInstance().m_si.propriedade.only_rookie && Player.UserInfo.level >= 6)
                    throw new exception($"PLAYER[UID={Player.UserInfo.uid}, LEVEL={Player.UserInfo.level}] not allowed (rookie-only GS).");

                if (GameServer.getInstance().m_si.propriedade.mantle && !(Player.UserInfo.UserCapabilities.mantle || Player.UserInfo.UserCapabilities.game_master))
                    throw new exception($"PLAYER[UID={Player.UserInfo.uid}] lacks mantle capability.");

                // --- Overlap: if another Player with same UID exists ---
                var alreadyLogged = GameServer.getInstance().HasLoggedWithOuterSocket(Player);
                if (alreadyLogged != null)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[HANDLE_PLAYER_LOGIN][Error] existing Player for UID={Player.UserInfo.uid}, disconnecting existing.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    GameServer.getInstance().Disconnect(alreadyLogged);
                    //throw new exception($"Failed to disconnect existing Player UID={alreadyLogged.getUID()}");
                }

                // --- Merge block flags and authorize Player ---
                Player.UserInfo.block_flag.m_flag.ullFlag |= GameServer.getInstance().m_si.flag.ullFlag;
                Player.Authorized = true;

                // --- DB registration: Player logged into GS ---
                NormalManagerDB.getInstance().add(5, new CmdRegisterLogon(Player.UserInfo.uid, 0));

                NormalManagerDB.getInstance().add(7, new CmdRegisterLogonServer(Player.UserInfo.uid, GameServer.getInstance().m_si.uid));

                _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Sucess] PLAYER[OID={Player.ConnectionID}, UID={Player.UserInfo.uid}, NICK={Player.UserInfo.nickname}].", type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Papel shop init
                sPapelShopSystem.getInstance().InitPlayerPapelShopInfo(Player);

                // Create login manager task to load all data
                Player.Load(); 
                // Anti-bot timestamp
                Player.TicketBot = Environment.TickCount;
                
                Player.Send(HandlePacket_RESPONSE.pacote044(GameServer.getInstance().m_si, eLoginAck.ACK_AUTO_RECONNECT, Player));
            }
            catch (exception ex)
            {
                _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN][Error] {ex.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));
                Player.Authorized = false;

                // Generic error response
                p = new Packet(0x44);
                p.WriteUInt32(300);
                Player.Send(p);
                // Disconnect Player to be safe
                GameServer.getInstance().Disconnect(Player);
            }

        await Task.CompletedTask;
        }

        private bool ValidateLoginPacket(
            bool hasClientVersion, string cversion, uint packetVersion,
            bool hasAuthKeyLogin, string lkey, bool hasMacAddress, string mac,
            bool hasAuthKeyGame, string gkey)
        {
            // checks: patch present, uid present, auth keys exist, id length sanity
            if (packetVersion == 0)
            {
                SendLoginAck(eLoginAck.ACK_INVALID_VERSION);
                return false;
            }

            if (Player.UserInfo.uid == 0)
            {
                SendLoginAck(eLoginAck.ACK_LOGIN_FAIL);
                return false;
            }

            if (!hasClientVersion || string.IsNullOrEmpty(cversion))
            {
                SendLoginAck(eLoginAck.ACK_INVALID_VERSION);
                return false;
            }

            if (!hasAuthKeyLogin || string.IsNullOrEmpty(lkey))
            {
                SendLoginAck(eLoginAck.ACK_SECURITY_KEY);
                return false;
            }

            if (!hasMacAddress || string.IsNullOrEmpty(mac))
            {
                SendLoginAck(eLoginAck.ACK_BLOCKED_IP_ADDR);
                return false;
            }

            if (!hasAuthKeyGame || string.IsNullOrEmpty(gkey))
            {
                SendLoginAck(eLoginAck.ACK_INVALID_VERSION);
                return false;
            }
            if (string.IsNullOrEmpty(Player.UserInfo.id) || Player.UserInfo.id.Length >= 0x40)
            {
                SendLoginAck(eLoginAck.ACK_INVALID_ID);
                return false;
            }
            return true;
        }

        private void SendLoginAck(eLoginAck ack)
        {
            using (var p = new Packet(0x44))
            {
                p.WriteUInt32((byte)ack);
                Player.Send(p);
            }

            GameServer.getInstance().Disconnect(Player);
        }

        private async void CheckAccountBlock()
        {
            // Verifica aqui se a conta do Player está bloqueada
            if (Player.UserInfo.block_flag.m_id_state.ull_IDState != 0)
            {

                if (Player.UserInfo.block_flag.m_id_state.L_BLOCK_TEMPORARY && (Player.UserInfo.block_flag.m_id_state.block_time == -1 || Player.UserInfo.block_flag.m_id_state.block_time > 0))
                {

                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] Bloqueado por tempo[Time="
                            + (Player.UserInfo.block_flag.m_id_state.block_time == -1 ? ("indeterminado") : ((Player.UserInfo.block_flag.m_id_state.block_time / 60)
                            + "min " + (Player.UserInfo.block_flag.m_id_state.block_time % 60) + "sec"))
                            + "]. Player [UID=" + (Player.UserInfo.uid) + ", ID=" + (Player.UserInfo.id) + "]");

                }
                else if (Player.UserInfo.block_flag.m_id_state.L_BLOCK_FOREVER)
                {

                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] Bloqueado permanente. Player [UID=" + (Player.UserInfo.uid)
                            + ", ID=" + (Player.UserInfo.id) + "]");
                }

                else if (Player.UserInfo.block_flag.m_id_state.L_BLOCK_ALL_IP)
                {

                    // Bloquea todos os IP que o Player logar e da error de que a area dele foi bloqueada

                    // Add o ip do Player para a lista de ip banidos
                    NormalManagerDB.getInstance().add(9, new CmdInsertBlockIp(Player.GetIP(), Player.MacAdress));

                    // Resposta
                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] PLAYER[UID=" + (Player.UserInfo.uid) + ", IP=" + (Player.GetIP())
                            + "] Block ALL IP que o Player fizer login.");
                }
                else if (Player.UserInfo.block_flag.m_id_state.L_BLOCK_MAC_ADDRESS)
                {

                    // Bloquea o MAC Address que o Player logar e da error de que a area dele foi bloqueada

                    // Add o MAC Address do Player para a lista de MAC Address banidos
                    NormalManagerDB.getInstance().add(10, new CmdInsertBlockMac(Player.MacAdress));

                    // Resposta
                    throw new exception("[HANDLE_PLAYER_LOGIN][Error] PLAYER[UID=" + (Player.UserInfo.uid)
                            + ", IP=" + (Player.GetIP()) + ", MAC=" + Player.MacAdress + "] Block MAC Address que o Player fizer login.");

                }
            }
        }

        public uint PacketVersion(uint packet_version)
        {
            string PacketVerKey = "{782AE110-2EEF-4c61-B030-A53F17634F7D}";

            byte[] tmpPVer = BitConverter.GetBytes(packet_version);
            int index = 0;

            for (int i = 0; i < PacketVerKey.Length; i++)
            {
                tmpPVer[index] ^= (byte)PacketVerKey[i];
                index = (index == 3) ? 0 : index + 1;
            }
            return BitConverter.ToUInt32(tmpPVer, 0);
        }


        private void EvaluateClientVersion(ClientVersion serverVer, ClientVersion clientVer)
        {
            if (clientVer.flag == ClientVersion.COMPLETE_VERSION &&
                string.Equals(clientVer.region, serverVer.region) &&
                string.Equals(clientVer.season, serverVer.season))
            {
                if (clientVer.high != serverVer.high || clientVer.low < serverVer.low)
                    Player.UserInfo.block_flag.m_flag.all_game = true;
            }
            else
            {
                if (clientVer.high != serverVer.high || clientVer.low < serverVer.low)
                    Player.UserInfo.block_flag.m_flag.all_game = true;
            }
        } 
    }
}
