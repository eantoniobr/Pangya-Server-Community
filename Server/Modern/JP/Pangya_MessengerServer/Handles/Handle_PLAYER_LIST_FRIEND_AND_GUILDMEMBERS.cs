using Pangya_MessengerServer.Models;
using Pangya_MessengerServer.Server;
using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_FRIEND_GUILD_LIST : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet _packet)
        {
            try
            {
                MessengerServer.getInstance().SendUpdatedFriendList(session);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_FRIEND_GUILD_LIST][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

            }

            await Task.CompletedTask;
        }
    }
}