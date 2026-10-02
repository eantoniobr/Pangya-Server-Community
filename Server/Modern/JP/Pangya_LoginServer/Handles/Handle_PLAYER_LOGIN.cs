using Pangya_LoginServer.DataBase;
using Pangya_LoginServer.Models;

using Pangya_LoginServer.Server;
using Pangya_LoginServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System.Text.RegularExpressions;
namespace Pangya_LoginServer.Handles
{
    public class Handle_PLAYER_LOGIN : IPacketHandler<Player>
    {
        private static readonly Regex InvalidIdRegex = new(@".*[\^$&,\\?`´~\|""@#¨'%*!\\].*", RegexOptions.Compiled);

        public async Task Handle(Player player, Packet packet)
        {
            try
            { 
                // 1. Extração de Dados
                var login = new LoginData(packet); 

                player.ResetHandShake(); // Reseta o handshake para evitar problemas de sincronização

                if (!ValidatePacket(login))
                    return;

                // 2. Validações de Fluxo (Early Return)
                if (!ValidateInput(player, login.id, login.password))
                {
                    player.SafeClose();
                    return;
                }

                player.UserInfo.MacAddress = login.mac_address; 
                // 3. Verificação de Segurança (IP/Ban/Manutenção)
                if (!CheckServerStatus(player))
                {
                    player.SafeClose();
                    return;
                }

                // 4. Autenticação no Banco
                var uid = Authenticate(player, login.id, login.password);
                if (uid == 0)
                {
                    player.SafeClose();
                    return;
                }


                // 5. Verificação de Multi-Login (Kick ou Bloqueio)
                if (!HandleDuplicateLogin(player, (uint)uid))
                {
                    player.SafeClose();
                    return;
                }
                // 6. Carregamento de Dados
                await ProcessPlayerState(player, (uint)uid);

            }
            catch (exception e)
            {

                LoginServer.getInstance().Disconnect(player);

                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_LOGIN][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }

        private bool ValidatePacket(LoginData login)
        {
            if (string.IsNullOrEmpty(login.id))
                throw new exception("PLAYER[UID=" + login.id + "] tentou contra o server[MESSAGE="
                        + login.id + "], vazio. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

            if (!Tools.Sanitize(login.id))
                throw new exception("PLAYER[UID=" + login.id + "] tentou contra o server[MESSAGE="
                        + login.id + "], tentativa de inject. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

            if (string.IsNullOrEmpty(login.mac_address))
                throw new exception("PLAYER[UID=" + login.id + "] tentou contra o server[MESSAGE="
                        + login.mac_address + "], vazio. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

            if (!Tools.Sanitize(login.mac_address))
                throw new exception("PLAYER[UID=" + login.id + "] tentou contra o server[MESSAGE="
                        + login.mac_address + "], tentativa de inject. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));


            if (string.IsNullOrEmpty(login.password))
                throw new exception("PLAYER[UID=" + login.id + "] tentou contra o server[MESSAGE="
                        + login.password + "], vazio. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

            if (!Tools.Sanitize(login.password))
                throw new exception("PLAYER[UID=" + login.id + "] tentou contra o server[MESSAGE="
                        + login.password + "], tentativa de inject. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

            return true;
        }

        private bool ValidateInput(Player player, string id, string pw)
        {
            if (string.IsNullOrEmpty(id) || id.Length <= 2 || InvalidIdRegex.IsMatch(id))
            {
                // Erro de ID Inválido (Packet 0x01, erro 6)
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0x6));
                return false;
            }
            return true;
        }

        private bool CheckServerStatus(Player player)
        {
            // Aqui você move a lógica de m_access_flag e IsUnderMaintenance
            if (LoginServer.getInstance().IsUnderMaintenance && !player.IsGM())
            {
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0x01, 7));
                return false;
            }

            if (LoginServer.getInstance().haveBanList(player.GetIP(), player.UserInfo.MacAddress))
            {
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 16)); 
                _smp.message_pool.getInstance().push("[HANDLE_PLAYER_LOGIN::CheckServerStatus][Log] Block por Regiao o IP/MAC: " + player.GetIP() + "/" + player.UserInfo.MacAddress, type_msg.CL_FILE_LOG_AND_CONSOLE);
                  
                return false;
            }

            return true;
        }

        private int Authenticate(Player player, string id, string pw)
        {
            var uid = CommandDB.VerifyID(id);
            if (uid <= 0)
            {
                // Lógica de auto-create ou erro de senha
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0x06, 1));
                return 0;
            }
            //so em modo release... para evitar problemas de teste com contas não confirmadas
#if RELEASE
 if (uid > 0 && !CommandDB.AccountConfirm(id))//verifica antes
            {
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0x07, 0, "Confirm you accout in Email"));
                _smp.message_pool.getInstance().push(new message($"[HANDLE_PLAYER_LOGIN::Authenticate][Log] PLAYER[ID: {id}, BETA ACCOUNT: FALSE]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                return 0;
            }
#endif

            var pwd_md5 = Tools.MD5Hash(pw);
            // Valida senha (MD5/SHA1 conforme seu banco)
            if (!CommandDB.VerifyPass((uint)uid, pwd_md5))
            {
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0x06, 1));
                return 0;
            }

            return uid;
        }

        private bool HandleDuplicateLogin(Player player, uint uid)
        { 
            var manager = LoginServer.getInstance().HasLoggedWithOuterSocket(player);
            if (manager != null)
            {
                if (!LoginServer.getInstance().canSameIDLogin())
                {
                    LoginServer.getInstance().Disconnect(manager);
                    return true;
                }
                return false;
            }
            else
            {
                var lc = CommandDB.IsLogonCheck(uid);
                if (lc.getLastCheck)//login duplicado...
                {
                    player.Authorized = true;
                    // Carrega o PlayerInfo (m_pi)
                    player.UserInfo.Set(CommandDB.GetPlayerInfo(uid));
                    player.Send(Handle_PACKET_RESPONSE.pacote001(player, 4));
                    return true;//tem que ser true
                }
            }

            return true;
        }

        private async Task ProcessPlayerState(Player player, uint uid)
        { 
            player.Authorized = true;
            // Carrega o PlayerInfo (m_pi)
            player.UserInfo.Set(CommandDB.GetPlayerInfo(uid));
            //atualiza o mac adress
            CommandDB.UpdatePlayerMacAddress(uid, player.UserInfo.MacAddress);
            // Lógica de Estados que estava no LoginServer.cs
            if (!CommandDB.IsFirstLogin(uid))
            {
                // Movemos o FIRST_LOGIN para cá
                player.UserInfo.m_state = 2;
                player.Send(Handle_PACKET_RESPONSE.pacote00F(player, 1));
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0xD8));//seta o nick
                return;
            }

            if (!CommandDB.IsFirstSet(uid))
            {
                // Movemos o FIRST_SET para cá
                player.UserInfo.m_state = 3;
                player.Send(Handle_PACKET_RESPONSE.pacote00F(player, 1));
                player.Send(Handle_PACKET_RESPONSE.pacote001(player, 0xD9));//cria o personagem
                return;
            }

            // Se chegou aqui, login com sucesso total 
            await SUCCESS_LOGIN(player);
        }

        public static async Task SUCCESS_LOGIN(Player _session, byte option = 0)
        {
            _session.UserInfo.m_state = 1;

            _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_LOGIN][Log] PLAYER[UID: {_session.UserInfo.uid}, ID: {_session.UserInfo.id}]", type_msg.CL_FILE_LOG_AND_CONSOLE));

            // Inicializamos as variáveis para evitar null reference
            List<ServerInfo> sis = new List<ServerInfo>();
            List<ServerInfo> msns = new List<ServerInfo>();
            ChatMacroUser _cmu = new ChatMacroUser();
            string auth_key_login = "";

            try
            {  
                sis = CommandDB.GetGame();
                msns = CommandDB.GetMsn();
                auth_key_login = CommandDB.GetAuthKeyLogin(_session.UserInfo.uid);

                if (option == 0)
                    _cmu = CommandDB.GetMacroUser(_session.UserInfo.uid);

                // Registro de Login (Pode ser await ou não, dependendo se você precisa confirmar o sucesso)
                CommandDB.RegisterPlayerLogin(_session.UserInfo.uid, _session.GetIP(), LoginServer.getInstance().getUID());
            }
            catch (Exception e) // Use Exception padrão do sistema ou a sua customizada
            {
                _smp.message_pool.getInstance().push(new message(
                    "[Handle_PLAYER_LOGIN][Log][ErrorSystem] " + e.Message,
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Lógica de tratamento de erro do seu sistema de DB
                // (Mantenha sua lógica de filtros de erro aqui se necessário)
                return; // Interrompe o login se houver falha crítica
            }

            // --- ENVIO DE PACOTES (A ordem importa no Pangya) ---

            // 1. Envia Auth Key (Pacote 0x10)
            _session.Send(Handle_PACKET_RESPONSE.pacote010(auth_key_login));

            // 2. Cookie/Session Confirm (Pacote 0x01)
            if (option == 0)
            {
                _session.Send(Handle_PACKET_RESPONSE.pacote001(_session));
            }

            // 3. Server List (Pacote 0x02)
            _session.Send(Handle_PACKET_RESPONSE.pacote002(sis));

            // 4. Messenger List (Pacote 0x09)
            _session.Send(Handle_PACKET_RESPONSE.pacote009(msns));

            // 5. Chat Macros (Pacote 0x06)
            if (option == 0)
            {
                _session.Send(Handle_PACKET_RESPONSE.pacote006(_cmu));
            }
        }
    }
}
