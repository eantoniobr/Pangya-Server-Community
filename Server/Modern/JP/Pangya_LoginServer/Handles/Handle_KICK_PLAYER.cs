using Pangya_LoginServer.DataBase;

using Pangya_LoginServer.Server;
using Pangya_LoginServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities.Log;

namespace Pangya_LoginServer.Handles
{
    public class Handle_KICK_PLAYER : IPacketHandler<Player>
    {
        public async Task Handle(Player player, Packet packet)
        {
            try
            {
                // Log de tentativa de derrubar login duplicado
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_KICK_PLAYER][Log] Player {player.UserInfo.id} (UID: {player.UserInfo.uid}) solicitou derrubar login duplicado.",
                    type_msg.CL_FILE_LOG_AND_CONSOLE)); 

                // Derruba o player que está logado no game server
                // Se o Auth Server Estiver ligado manda por ele, se não tira pelo banco de dados mesmo
                if (LoginServer.getInstance().m_unit_connect != null)
                {

                    // [Auth Server] . Game Server UID = _session.m_pi.m_server_uid;
                    LoginServer.getInstance().m_unit_connect.SendDisconnectPlayer(player.UserInfo.m_server_uid, player.UserInfo.uid);

                }
                else
                {

                    // Auth Server não está online, resolver por aqui mesmo
                    CommandDB.RegisterLogon(player.UserInfo.uid, 0);

                   await Handle_PLAYER_LOGIN.SUCCESS_LOGIN(player, 0); 
                }

            }
            catch (Exception e)
            {
                // Se falhar (ex: Auth Server offline), envia erro 500053 (Duplicate Login Error)
                player.Send(Handle_PACKET_RESPONSE.pacote00E(player, "", 12, 500053));

                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_KICK_PLAYER][Error] Falha ao derrubar player: {e.Message}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}