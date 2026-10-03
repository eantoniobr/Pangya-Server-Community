using Pangya_MessengerServer.Manager;
using PangyaAPI.Network.Models;

namespace Pangya_MessengerServer.Models
{
    public class PlayerInfo : PlayerInfoBase
    {
        public PlayerInfo()
        { 
            Clear(); 
        }

        public override void Clear()
        {
            m_logout = 0;
            base.Clear();
            m_cpi = new ChannelPlayerInfo();
            m_friend_manager = new FriendManager(); 
        }


        public byte m_state;
        public int m_logout; // Verifica se j� mandou pacote de deslogar 
        public ChannelPlayerInfo m_cpi = new ChannelPlayerInfo(); 
        public FriendManager m_friend_manager = new FriendManager();
    }
}
