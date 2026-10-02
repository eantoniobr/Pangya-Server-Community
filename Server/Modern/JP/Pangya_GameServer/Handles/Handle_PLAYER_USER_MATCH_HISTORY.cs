using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_USER_MATCH_HISTORY : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            session.Send(Handle_PACKET_RESPONSE.pacote10E(session.UserInfo.GameHistory));

            await Task.CompletedTask;
        }
    }
}