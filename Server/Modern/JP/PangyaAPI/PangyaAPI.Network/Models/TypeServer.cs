using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Models
{
    public enum TypeServer : byte
    {
        GameServer,
        MessengerServer,
        LoginServer,
        RankServer,
        AuthServer,
    }
}
