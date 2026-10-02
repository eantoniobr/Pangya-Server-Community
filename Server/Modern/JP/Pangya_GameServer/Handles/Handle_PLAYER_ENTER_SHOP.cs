using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ENTER_SHOP : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var m_ci = _session.GetChannel();
            try
            {
                if (_session.UserInfo.block_flag.m_flag.buy_and_gift_shop)
                {
                    throw new exception("[Lobby::RequestEnterShop][Error] PLAYER [UID=" + _session.UserInfo.uid
                            + "] tentou jogar no Papel Shop, mas ele nao pode. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x790002));
                }

                var p = new Packet(0x20E); 
                p.WriteZero(8); 
                _session.Send(p);
            }
            catch (exception e)
            {
                throw;
            }

        await Task.CompletedTask;
        }
    }
}