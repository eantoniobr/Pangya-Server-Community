using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;

namespace Pangya_GameServer.Handles
{
    public class Handle_REQUEST_SERVER_TIME : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            // Nota: O pacote 0xBA geralmente não precisa de corpo na requisição, 
            // é apenas um trigger do cliente para pedir o horário.

            using (var response = new Packet())
            {
                response.init_plain(0xBA); 
                // Escreve o SYSTEMTIME (16 bytes) 
                response.WriteTime();

                session.Send(response);
            }

        await Task.CompletedTask;
        }
    }
}