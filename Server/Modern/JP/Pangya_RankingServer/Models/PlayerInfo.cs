using Pangya_RankingServer.Manager;
using Pangya_RankingServer.Server;
using PangyaAPI.Network.Models;

namespace Pangya_RankingServer.Models
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
            m_sd = new SearchDataEx();
            m_state = 0;
        }
        public byte m_state;
        // Dados que usa para consultar o rank
        public SearchDataEx m_sd { get; set; } = new SearchDataEx(); // Search dados
    }
}
