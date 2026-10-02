using Pangya_AuthServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_AuthServer.Handles
{
    public class Handle_PLAYER_DISCONNECT : IAuthPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        { 
        }
    }
}
