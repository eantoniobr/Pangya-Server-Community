using PangyaAPI.DataBase.Models;
using System;

namespace PangyaAPI.DataBase.Repository
{
    public class CmdConnection : Pangya_DB
    { 
        protected override void lineResult(ctx_res _result, uint _index_result)
        {
           
        }

        protected override Response prepareConsulta()
        { 
            return consulta("SELECT 1");
        }
    }
}