using Pangya_GameServer.Feature;
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
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_DELETE_RENTAL : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();

            try
            {
                int item_id = _packet.ReadInt32();

                if (item_id <= 0)
                {
                    throw new exception("[Lobby::RequestDeleteRental][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou deletar um Rental item[ID=" + (item_id) + "] invalid. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        400, 5200401));
                }

                var pWi = _session.Inventory.FindWarehouseItemById(item_id);

                if (pWi == null)
                {
                    throw new exception("[Lobby::RequestDeleteRental][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou deletar um Rental item[ID=" + (item_id) + "] que ele nao tem. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        401, 5200402));
                }

                if (sIff.getInstance().getItemGroupIdentify(pWi._typeid) != IFF_GROUP.PART)
                {
                    throw new exception("[Lobby::RequestDeleteRental][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou deletar um Rental Item[TYPEID=" + (pWi._typeid) + ", ID=" + (pWi.id) + "] que nao é um Part. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        402, 5200403));
                }

                var part = sIff.getInstance().findPart(pWi._typeid);

                if (part == null)
                {
                    throw new exception("[Lobby::RequestDeleteRental][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou deletar um rental Item[TYPEID=" + (pWi._typeid) + ", ID=" + (pWi.id) + "] que nao esta no IFF_STRUCT do server. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        403, 5200404));
                }

                if (part.valor_rental <= 0)
                {
                    throw new exception("[Lobby::RequestDeleteRental][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou deletar um rental Item[TYPEID=" + (pWi._typeid) + ", ID=" + (pWi.id) + "] que nao é um rental no IFF_STRUCT do server. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        404, 5200404));
                }

                var tmp_wi = pWi;

                var it = _session.Inventory.FindWarehouseItemById(pWi.id);

                if (it != null)
                {
                    _session.Inventory.WarehouseItems.Remove(it.id);
                }

                // Att no Banco de dados
                NormalManagerDB.getInstance().add(6, new CmdDeleteRental(_session.UserInfo.uid, tmp_wi.id));

                _smp.message_pool.getInstance().push(new message("[Rental::Delete][Sucess] PLAYER [UID=" + _session.UserInfo.uid + "] deletou Rental Item[TYPEID=" + (tmp_wi._typeid) + ", ID=" + (tmp_wi.id) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x190);

                p.WriteByte(0); // OK
                p.WriteUInt32(tmp_wi._typeid);
                p.WriteInt32(tmp_wi.id);

                _session.Send(p);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby::RequestDeleteRental][ErroSytem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x190);

                p.WriteByte(1); // Error

                _session.Send(p);
            }
        }
    }
}