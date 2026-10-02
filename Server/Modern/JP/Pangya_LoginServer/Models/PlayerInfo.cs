using PangyaAPI.Network.Models;

namespace Pangya_LoginServer.Models
{
    public class PlayerInfo : PlayerInfoBase
    {
        public PlayerInfo()
        {
             Clear();
        }
                        
        public override void Clear()
        { 
            base.Clear();  
            m_state = 0;
            m_place = 0;
            m_server_uid = 0;
        }

        public byte m_state;
        public byte m_place;
        public uint m_server_uid; // Server UID em que eles está conectado
    }
}
