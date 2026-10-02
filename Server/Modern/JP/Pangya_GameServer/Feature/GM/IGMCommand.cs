using Pangya_GameServer.Session;
using PangyaAPI.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_GameServer.Feature.GM
{
    public interface IGMCommand
    {
        Task Execute(Player session, Packet packet);
    }
}
