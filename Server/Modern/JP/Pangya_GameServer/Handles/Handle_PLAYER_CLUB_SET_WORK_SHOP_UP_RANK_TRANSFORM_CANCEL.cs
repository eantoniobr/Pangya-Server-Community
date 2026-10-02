using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
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
    public class Handle_PLAYER_CLUB_SET_WORK_SHOP_UP_RANK_TRANSFORM_CANCEL : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();

            try
            {
                var pClub = _session.Inventory.FindWarehouseItemById(_session.Inventory.WorkshopTransform.clubset_id);

                if (pClub == null)
                {
                    throw new exception("[Lobby::RequestClubSetWorkShopUpRankTransformCancel][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou cancelar o transformacao do ClubSet[ID=" + (_session.Inventory.WorkshopTransform.clubset_id) + "] no ClubSet[TYPEID=" + (_session.Inventory.WorkshopTransform.transform_typeid) + "] Special, mas ele nao tem o ClubSet. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        400, 0x5300401));
                }

                var clubset = sIff.getInstance().findClubSet(pClub._typeid);

                if (clubset == null)
                {
                    throw new exception("[Lobby::RequestClubSetWorkShopUpRankTransformCancel][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou cancelar o transformacao do ClubSet[ID=" + (_session.Inventory.WorkshopTransform.clubset_id) + "] no ClubSet[TYPEID=" + (_session.Inventory.WorkshopTransform.transform_typeid) + "] Special, mas o ClubSet nao existe no IFF_STRUCT do Server. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        401, 0x5300402));
                }

                if (_session.Inventory.WorkshopTransform.stat > 4)
                {
                    throw new exception("[Lobby::RequestClubSetWorkShopUpRankTransformCancel][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou cancelar o transformacao do ClubSet[ID=" + (_session.Inventory.WorkshopTransform.clubset_id) + "] no ClubSet[TYPEID=" + (_session.Inventory.WorkshopTransform.transform_typeid) + "] Special, mas o Stat[value=" + (_session.Inventory.WorkshopTransform.stat) + "] é invalido. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        402, 0x5300403));
                }

                // Log
                _smp.message_pool.getInstance().push(new message("[ClubSetWorkshop::UpRankTransformCancel][Sucess] PLAYER [UID=" + _session.UserInfo.uid + "] cancelou a transformacao do ClubSet[TYPEID=" + (pClub._typeid) + ", ID=" + (pClub.id) + "] no ClubSet[TYPEID=" + (_session.Inventory.WorkshopTransform.transform_typeid) + "] Special", type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x243);

                p.WriteUInt32(0); // OK

                p.WriteUInt32(_session.Inventory.WorkshopTransform.stat);
                p.WriteInt32(_session.Inventory.WorkshopTransform.clubset_id);

                _session.Send(p);

                // Update Achievement ON SERVER, DB and GAME
                AchievementSystem sys_achieve = new AchievementSystem();

                sys_achieve.incrementCounter(0x6C4000A3u);

                sys_achieve.finish_and_update(_session);

            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby::RequestClubSetWorkShopUpRankTransformCancel][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x243);

                p.WriteUInt32((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL) ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : 0x5300400);

                _session.Send(p);
            }

        await Task.CompletedTask;
        }
    }
}