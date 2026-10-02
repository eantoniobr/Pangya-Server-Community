using PangyaAPI.DataBase;
using PangyaAPI.DataBase.Manager;
using PangyaAPI.DataBase.Models;
using PangyaAPI.DataBase.Repository;
using PangyaAPI.Utilities;
using System;
using static PangyaAPI.DataBase.Models.NormalDB;

namespace PangyaAPI.DataBase.Manager
{
    public class NormalManager
    {
        public NormalManager()
        {
        }

        public int add(msg_t _msg)
        {
            if (_msg.IsFunc())
            {
                _msg.execFunc();
            }
            else
            {
                _msg.execQuery();
            }
            return 0;
        }
        public int add(int _id,
            ref Pangya_DB _pangya_db,
        Action<int, Pangya_DB, object> _callback_response,
            object _arg)
        {

            add(new msg_t(_id, _pangya_db, _callback_response, _arg));

            return 0;
        }

        public void add(int _id,
     Pangya_DB _pangya_db,
     Action<int, Pangya_DB, object> _callback_response = null,
     object _arg = null)
        {
            add(_id, ref _pangya_db, _callback_response, _arg);
        }


        public bool Connected()
        {
            try
            { 
                var cmd = new CmdConnection();

                add(0, cmd);  //add comand to queue
                if (cmd.getException().getCodeError() != 0)
                    throw new exception(cmd.getException().getFullMessageError(),
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.PANGYA_DB, 277, 0));
                return true;
            }
            catch (exception e)
            {
                throw;
            }
        }

    }
}

namespace snmdb
{ 
    public class NormalManagerDB : Singleton<NormalManager> { }
}