using Pangya_MessengerServer.Models;
using PangyaAPI.DataBase;
using PangyaAPI.Network.Models;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Collections.Generic;

namespace Pangya_MessengerServer.Repository
{
    public class CmdPlayerInfo : Pangya_DB
    { 
        public CmdPlayerInfo(uint _uid)
        {
            this.m_uid = _uid;
            this.m_pi = new PlayerInfoBase();
        } 

        public uint getUID()
        {
            return (m_uid);
        }

        public void setUID(uint _uid)
        {
            m_uid = _uid;
        }

        public PlayerInfoBase getInfo()
        {
            return m_pi;
        }

        protected override void lineResult(ctx_res _result, uint _index_result)
        {

            checkColumnNumber(11, (uint)_result.cols);

            m_pi.uid = IFNULL<uint>(_result.data[0]);
            if (is_valid_c_string(_result.data[1]))
            {
                m_pi.id = _result.GetString(1);
            }
            if (is_valid_c_string(_result.data[2]))
            {
                m_pi.nickname = _result.GetString(2);
            }
            m_pi.m_cap = IFNULL<uint>(_result.data[3]);
            m_pi.guild_uid = IFNULL<uint>(_result.data[4]);

            if (is_valid_c_string(_result.data[5]))
            {
                m_pi.guild_name = _result.GetString(5);
            }

            m_pi.sex = IFNULL<byte>(_result.data[6]);
            m_pi.level = IFNULL<ushort>(_result.data[7]);
            m_pi.server_uid = IFNULL<uint>(_result.data[8]);
            m_pi.block_flag.setIDState(IFNULL<ulong>(_result.data[9]));
            m_pi.block_flag.m_id_state.block_time = IFNULL<int>(_result.data[10]);

            if (m_uid != m_pi.uid)
            {
                throw new exception("[CmdPlayerInfo::lineResult][Error] player[UID_resquest=" + Convert.ToString(m_uid) + ", UID_return=" + Convert.ToString(m_pi.uid) + "] retornou um consulta diferente do esperado. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.PANGYA_DB,
                    3, 0));
            }
        }

        protected override Response prepareConsulta()
        {

            if (m_uid == 0)
            {
                throw new exception("[CmdPlayerInfo::prepareConsulta][Error] m_uid is invalid(zero)", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.PANGYA_DB,
                    4, 0));
            }

            var r = procedure(
                m_szConsulta,
                Convert.ToString(m_uid));

            checkResponse(r, " nao conseguiu pegar o Info do Player[UID=" + Convert.ToString(m_uid) + "]");

            return r;
        }


        private uint m_uid = new uint();
        private PlayerInfoBase m_pi = new PlayerInfoBase();

        private const string m_szConsulta = "pangya.ProcGetPlayerInfoMessage";
    }
}
