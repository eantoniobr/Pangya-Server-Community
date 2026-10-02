using PangyaAPI.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_GameServer.Repository
{
    public abstract class DBResponse
    {
        public abstract void SQLDBResponse(int _msg_id,
            Pangya_DB _pangya_db,
            object _arg);
    }
}
