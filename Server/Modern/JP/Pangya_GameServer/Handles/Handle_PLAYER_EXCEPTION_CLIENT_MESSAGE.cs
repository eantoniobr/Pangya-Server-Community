using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_EXCEPTION_PLAYER_REQ_MESSAGE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            //esse aqui avisa se deu exception no client

            try
            {
                byte tipo = _packet.ReadByte();

                var exception_msg = _packet.ReadPStr();
                if (tipo == 1)//se o cara dar pause, dar como cheat
                {
                    //lembro que tem como desmembrar a mesnagem
                }
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_EXCEPTION_PLAYER_REQ_MESSAGE][Log] PLAYER[UID=" + (_session.UserInfo.uid) + ", EXTIPO="  + ((ushort)tipo) + ", MSG=" + exception_msg + "]", type_msg.CL_ONLY_CONSOLE));
                //
                GameServer.getInstance().Disconnect(_session);//send desconection
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}