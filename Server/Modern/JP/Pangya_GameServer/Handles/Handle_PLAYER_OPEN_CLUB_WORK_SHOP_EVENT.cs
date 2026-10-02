using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_OPEN_CLUB_WORK_SHOP_EVENT : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                //var events = new ClubWorkShopEvent();
                //var p = packet_func.pacote24E(events);

                //int fasesCompletas = events.totalHoles / events.holesPerPhase;
                //int progressoFaseAtual = events.totalHoles % events.holesPerPhase;

                //_session.Send(p);
            }
            catch (exception e)
            {

            }

        await Task.CompletedTask;
        }
    }
}