using PangyaAPI.DataBase;

namespace Pangya_AuthServer.Repository
{
    public class CmdUpdateGuildRanking : Pangya_DB
    {
        public CmdUpdateGuildRanking()
        {
        }

        protected override void lineResult(ctx_res _result, uint _index_result)
        {

            // N�o usa por que � um UPDATE
            return;
        }

        protected override Response prepareConsulta()
        {

            var r = procedure(
                m_szConsulta, "");

            checkResponse(r, "Nao conseguiu atualizar Guild Ranking.");

            return r;
        }

        private string m_szConsulta = "pangya.USP_UPDATE_GUILD_RANKING";
    }
}
