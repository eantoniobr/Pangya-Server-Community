using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core; 
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_SERVER_LIST : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
			try
			{
				GameServer.getInstance().SendUpdateServerList(session);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}