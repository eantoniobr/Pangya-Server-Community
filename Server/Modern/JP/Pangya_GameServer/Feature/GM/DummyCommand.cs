using Pangya_GameServer.Feature.GM;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Feature.GM
{
    public class DummyCommand : IGMCommand
    {
        public async Task Execute(Player s, Packet packet)
        {
            _smp.message_pool.getInstance().push(new message(
             $"[GM-Action] Por: {s.UserInfo.nickname} (UID: {s.UserInfo.uid})",
             type_msg.CL_ONLY_CONSOLE));
        }
    }
}