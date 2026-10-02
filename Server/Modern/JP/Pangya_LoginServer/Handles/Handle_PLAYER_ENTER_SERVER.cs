using Pangya_LoginServer.DataBase;

using Pangya_LoginServer.Server;
using Pangya_LoginServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities.Log;

namespace Pangya_LoginServer.Handles
{
    public class Handle_PLAYER_ENTER_SERVER : IPacketHandler<Player>
    {
        public async Task Handle(Player player, Packet packet)
        {
            try
            {
                uint server_uid = packet.ReadUInt32();

                if (server_uid == 0)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_ENTER_SERVER][Log] UID inválido de {player.UserInfo.id}", type_msg.CL_ONLY_CONSOLE));
                    LoginServer.getInstance().Disconnect(player);
                    return;
                }

                // 2. Busca lista de servidores (Idealmente em cache para não pesar o DB)
                var servers = CommandDB.GetGame();
                var selectedServer = servers.FirstOrDefault(c => c.uid == server_uid);

                if (selectedServer != null)
                {
                    // 3. Registra e pega a chave 
                    string authKey = CommandDB.RegisterAndGetAuthKey(player.UserInfo.uid, server_uid);

                    if (string.IsNullOrEmpty(authKey))
                        throw new Exception("Falha ao gerar AuthKey no Banco de Dados.");

                    // 4. Envia chave de transição
                    player.Send(Handle_PACKET_RESPONSE.pacote003(authKey));
                    //enviar um aviso ao server que ele vai entrar..


                    _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_ENTER_SERVER][Log] PLAYER[UID: {player.UserInfo.uid}, ID: {player.UserInfo.id}, SRV: {selectedServer.nome}]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
                else
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_ENTER_SERVER][Log] Servidor {server_uid} offline ou inexistente.", type_msg.CL_ONLY_CONSOLE));

                    // Opcional: Enviar erro antes de desconectar
                    // player.Send(LoginPackets.pacoteError(0x0E));
                    LoginServer.getInstance().Disconnect(player);
                }
            }
            catch (Exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[SelectServer Error] {e.Message}", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}