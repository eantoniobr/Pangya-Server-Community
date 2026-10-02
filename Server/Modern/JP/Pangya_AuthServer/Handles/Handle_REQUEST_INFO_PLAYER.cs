using Pangya_AuthServer.Server;
using Pangya_AuthServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities.Log;
using System.Security.Cryptography;

namespace Pangya_AuthServer.Handles
{
    public class Handle_REQUEST_INFO_PLAYER : IAuthPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            uint serverUid = 0;
            uint playerUid = 0;

            try
            {
                // 1. Leitura dos IDs do pacote
                serverUid = _packet.ReadUInt32();
                playerUid = _packet.ReadUInt32();

                if (serverUid > 0)
                {
                    // Busca um servidor específico por UID
                    var targetServer = AuthServer.getInstance().FindPlayer(serverUid);

                    if (targetServer != null)
                    {

                        _smp.message_pool.getInstance().push(new message(
                   $"[Handle_REQUEST_INFO_PLAYER][Sucess] SERVER[REQ: {_session.UserInfo.uid}, PLAYER: {playerUid}, FOR: {serverUid}]",
                   type_msg.CL_FILE_LOG_AND_CONSOLE));
                        // Envia comando 0x0B para o servidor alvo
                        using (var p = new Packet(0x0B))
                        {
                            p.WriteUInt32(_session.UserInfo.uid); // Quem pediu
                            p.WriteUInt32(playerUid);        // De quem quer saber

                            targetServer.SendAuth(p);
                        }
                    }
                    else
                    {
                        _smp.message_pool.getInstance().push(new message(
                   $"[Handle_REQUEST_INFO_PLAYER][Debug] SERVER[UID: {_session.UserInfo.uid}, PLAYER_INFO: {playerUid}, FOR: {serverUid}]",
                   type_msg.CL_FILE_LOG_AND_CONSOLE));
                        // Servidor alvo não encontrado: Retorna erro 0x0C para quem pediu
                        await SendErrorResponse(_session, serverUid, playerUid);
                    }
                }
                else
                {
                    // Se ServerUID for 0, o Pangya costuma fazer broadcast para todos os Game Servers (Tipo 1)
                    var gameServers = AuthServer.getInstance().FindPlayersByType(1);

                    Console.WriteLine($"[Request Info] Broadcast para {gameServers.Count} Game Servers buscando Player {playerUid}");

                    foreach (var srv in gameServers)
                    {
                        using (var p = new Packet(0x0B))
                        {
                            p.WriteUInt32(_session.UserInfo.uid);
                            p.WriteUInt32(playerUid);

                            srv.SendAuth(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Handle_REQUEST_INFO_PLAYER: {ex.Message}");
                // Em caso de falha crítica, avisa quem pediu que não foi possível completar a busca
                await SendErrorResponse(_session, serverUid, playerUid);
            }
        }

        private async Task SendErrorResponse(Player session, uint serverUid, uint playerUid)
        {
            using (var p = new Packet(0x0C))
            {
                p.WriteUInt32(serverUid);
                p.WriteInt32(-1); // Código de erro: Servidor/Player não encontrado
                p.WriteUInt32(playerUid);

                session.SendAuth(p);
            }
        }
    }
}