using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_USER_MATCH_HISTORY : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            Player.Send(HandlePacket_RESPONSE.pacote10E(Player.UserInfo.GameHistory));

            await Task.CompletedTask;
        }
    }
}