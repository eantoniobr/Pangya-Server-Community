using Pangya_RankingServer.Models;
using PangyaAPI.DataBase;

namespace Pangya_RankingServer.Repository

{
    public class CmdRankConfigInfo : Pangya_DB
    {
        public CmdRankConfigInfo()
        {
            this.m_rft = new RankRefreshTime();
        }


        public RankRefreshTime getInfo()
        {
            return m_rft;
        }

        protected override void lineResult(ctx_res _result, uint _index_result)
        {

            checkColumnNumber(2, _result.cols);

            m_rft.setIntervalRefresh(IFNULL<uint>(_result.data[0]));

            if (is_valid_c_string(_result.data[1]))
            {
                m_rft.setLastRefreshDate(_result.GetString(1));
            }
        }

        protected override Response prepareConsulta()
        {

            m_rft.clear();

            var r = consulta(m_szConsulta);

            checkResponse(r, "Nao conseguiu pegar as configuracao do Rank.");

            return r;
        }

        private RankRefreshTime m_rft = new RankRefreshTime();

        private string m_szConsulta = "SELECT refresh_time_H, reg_date FROM pangya.pangya_rank_config";
    }
}
