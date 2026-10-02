using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core; 

namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_NOTIFY_GIFT_ITEM : IPacketHandler<Player>
    { 
        public async Task Handle(Player _session, Packet _packet)
        {
        }
    }
}
