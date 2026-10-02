using Pangya_AuthServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_AuthServer.Handles
{
    public class Handle_HEARTBEAT : IAuthPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                // Atualiza o timestamp para o monitor de conexões
                _session.last_activity = new SystemTime(DateTime.Now);

                // OpCode 0xFE - Mantém o link entre Auth e Sub-Servers
                using (var response = new Packet(0xFE))
                {
                    // Envia o tempo atual para sincronia
                    response.WriteTime(_session.last_activity); 
                    _session.SendAuth(response);
                }

                //_smp.message_pool.getInstance().push(new message(
                //   $"[Handle_HEART][Sucess] UPDATE SERVER {_session.m_pi.uid} ON",
                //   type_msg.CL_FILE_LOG_AND_CONSOLE)); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Critical] Falha no Handle_HEART para {_session.UserInfo.uid}: {ex.Message}");
            }
        }
    }
}