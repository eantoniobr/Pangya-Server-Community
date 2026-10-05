using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_SERVER : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                var server_uid = Packet.ReadUInt32();

                // Busca o servidor alvo na lista global
                var targetServer = GameServer.getInstance().m_server_list.FirstOrDefault(c => c.uid == server_uid);

                if (targetServer == null)
                {
                    throw new exception(
                        $"[Handle_PLAYER_CHANGE_SERVER][Error] PLAYER[UID={Player.UserInfo.uid}] tentou trocar para o Server[UID={server_uid}], mas ele não existe.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 0x7500001, 1));
                }

                // Validação de Lobby (Ex: Bloqueia saída de Grand Prix para server comum se não permitido)
                if (Player.UserInfo.Lobby == 176 && !targetServer.propriedade.grand_prix)
                {
                    throw new exception(
                        $"[Handle_PLAYER_CHANGE_SERVER][Error] PLAYER[UID={Player.UserInfo.uid}] bloqueado: Server destino não suporta Grand Prix.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 0x7500002, 2));
                }

                // 1. Gera Auth Key no DB

                string auth_key_game = CommandDB.GetAuthKeyGame(Player.UserInfo.uid, server_uid);

                // 2. Atualiza Auth Key de Login
                CommandDB.UpdateAuthKeyLogin(Player.UserInfo.uid); 

                // 3. Resposta ao Cliente (0x1D4) 
                Player.Send(Handle_PACKET_RESPONSE.pacote1D4(auth_key_game));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_CHANGE_SERVER][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Falha crítica: Reenvia lista de servidores para o Player recuperar o estado da UI
                GameServer.getInstance().SendUpdateServerList(Player);
            } 
        }
    }
}