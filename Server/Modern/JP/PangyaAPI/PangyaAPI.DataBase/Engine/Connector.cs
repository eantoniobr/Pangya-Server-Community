using PangyaAPI.DataBase.Models;  
namespace PangyaAPI.DataBase.Engine
{
    public abstract class Connector
    {
        public enum ERROR_TYPE : uint
        {
            INVALID_HANDLE,
            INVALID_PARAMETER,
            ALLOC_HANDLE_FAIL_ENV,
            ALLOC_HANDLE_FAIL_DBC,
            ALLOC_HANDLE_FAIL_STMT,
            SET_ATTR_ENV_FAIL,
            CONNECT_DRIVER_FAIL,
            EXEC_QUERY_FAIL,
            FETCH_QUERY_FAIL,
            MORE_RESULTS,
            GERAL_ERROR,
            HAS_CONNECT
        }
        public Connector()
        {
            this.m_state = false;
            this.m_connected = false;
        }
        public Connector(DatabaseContext _m_ctx_db)
        {
            m_ctx_db = _m_ctx_db;

            this.m_state = false;
            this.m_connected = false;
            init();
        }


        /// <summary>
        ///recria dados da conexao em uma unica linha de string
        /// </summary>
        /// <returns></returns>    
        public void init()
        {

            if (m_ctx_db == null || string.IsNullOrEmpty(m_ctx_db.engine))
                throw new ArgumentNullException(nameof(m_ctx_db), "ctx_db ou engine não informado");

            m_ctx_db.Init();

            m_state = true;
        } 

        public bool is_connected()
        {
            return m_connected;
        }

        public abstract bool hasGoneAway();

        public abstract void connect();
        public abstract void reconnect();
        public abstract void disconnect();

        public abstract Response ExecQuery(string _query);
        public abstract Response ExecProc(string _proc_name, string values = null);
        public abstract Response ExecQueryWithParams(string _proc_name, string values = null/*, SqlDbType[] tipo = null, object[] valor = null, ParameterDirection Direcao = ParameterDirection.Input*/);
        public abstract Response ExecProcWithParams(string _proc_name, string values = null/*, SqlDbType[] tipo = null, object[] valor = null, ParameterDirection Direcao = ParameterDirection.Input*/);
        public abstract Response ExecProcWithParams(string _proc_name, object[] values = null/*, SqlDbType[] tipo = null, object[] valor = null, ParameterDirection Direcao = ParameterDirection.Input*/);
        public abstract string makeEscapeKeyword(string _value);

        public bool m_error = false;
        public string m_error_string = "";
        protected bool m_state;
        protected bool m_connected;
        public DatabaseContext m_ctx_db = new DatabaseContext();
    }
}
