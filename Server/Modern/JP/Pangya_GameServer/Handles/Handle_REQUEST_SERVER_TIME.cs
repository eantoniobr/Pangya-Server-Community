using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;

namespace Pangya_GameServer.Handles
{
    public class Handle_REQUEST_SERVER_TIME : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            // Nota: O pacote 0xBA geralmente não precisa de corpo na requisição, 
            // é apenas um trigger do cliente para pedir o horário.

            using (var response = new Packet())
            {
                response.init_plain(0xBA); 
                // Escreve o SYSTEMTIME (16 bytes) 
                response.WriteTime();

                Player.Send(response);
            }

        await Task.CompletedTask;
        }
    }
}