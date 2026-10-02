using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using static Pangya_GameServer.Models.DefineConstants;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_SET_ASSIST : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            if (_packet == null)
            {
                throw new exception("[Handle_PLAYER_SET_ASSIST] [Error] _packet is null", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    12, 0));
            }

            Packet p = new();

            try
            {
                if (_session.GetGameRoom() == null)
                {

                    var (rt, item) = _session.UserInfo.AssistFlag ? RemoveAssistItem(_session) : AddAssistItem(_session);
                    if (rt != RetAddItem.SUCCESS_PANG_AND_EXP_AND_CP_POUCH && item != null)
                    {
                        p.init_plain(0x216);
                        p.WriteUInt32((uint)UtilTime.GetSystemTimeAsUnix());
                        p.WriteUInt32(1);
                        p.WriteByte(item.type);
                        p.WriteUInt32(item._typeid);
                        p.WriteInt32(item.id);
                        p.WriteUInt32(item.flag_time);
                        p.WriteBytes(item.stat.ToArray());
                        p.WriteInt32(item.STDA_C_ITEM_TIME > 0 ? item.STDA_C_ITEM_TIME : item.STDA_C_ITEM_QNTD);
                        p.WriteZero(25);
                        _session.Send(p);
                    }

                    p.init_plain(0x26A);
                    p.WriteUInt32(0);
                    p.WriteUInt32(ASSIST_ITEM_TYPEID);
                    p.WriteUInt32(_session.UserInfo.uid);
                    _session.Send(p);
                }
                else
                {
                    _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_SET_ASSIST][ErrorSystem] é hacker de packet: " + _session.UserInfo.uid, type_msg.CL_FILE_LOG_AND_CONSOLE));
                    p.init_plain(0x16A);
                    p.WriteUInt32(0);
                    _session.Send(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_SET_ASSIST][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                p.init_plain(0x26A);
                p.WriteUInt32((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.ROOM) ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : 0x5200800);
                _session.Send(p);
            }
        }

        private (int rt, stItem? item) AddAssistItem(Player _session)
        {
            if (_session.Inventory.ItemExist(ASSIST_ITEM_TYPEID))
            {
                stItem item = new stItem();
                var rt = RetAddItem.INIT_VALUE;
                item.type = 2;
                item.id = -1;
                item._typeid = ASSIST_ITEM_TYPEID;
                item.qntd = 1;
                item.STDA_C_ITEM_QNTD = 1;
                if ((rt = ItemManager.addItem(item, _session, 0, 0)) < 0)
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou ativar o Assist[TYPEID=" + Convert.ToString(ASSIST_ITEM_TYPEID) + "], mas nao conseguiu adicionar o item. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1, 0x5200801));
                }

                _session.UserInfo.AssistFlag = true;
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_SET_ASSIST][Info] PLAYER[UID=" + _session.UserInfo.uid + "] Ligou o Assist Modo", type_msg.CL_FILE_LOG_AND_CONSOLE));

                CommandDB.LoadUpdateAssist(_session.UserInfo.uid, _session.UserInfo.AssistFlag);

                return (rt, item);
            }
            return (-1, null);

        }

        private (int rt, stItem? item) RemoveAssistItem(Player _session)
        {
            var pWi = _session.Inventory.FindWarehouseItemByTypeid(ASSIST_ITEM_TYPEID);

            if (pWi != null)
            {
                stItem item = new();
                var rt = RetAddItem.INIT_VALUE;
                item.type = 2;
                item._typeid = ASSIST_ITEM_TYPEID;
                item.qntd = 1;
                item.STDA_C_ITEM_QNTD = 1;
                _session.UserInfo.AssistFlag = false;
                item.id = pWi.id;
                item.qntd = (int)((pWi.STDA_C_ITEM_QNTD <= 0) ? 1 : pWi.STDA_C_ITEM_QNTD);
                item.STDA_C_ITEM_QNTD = (short)(item.qntd * -1);
                if (ItemManager.removeItem(item, _session) <= 0)
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou desativar o Assist[TYPEID=" + Convert.ToString(ASSIST_ITEM_TYPEID) + "], mas nao conseguiu remover o item. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2, 0x5200802));
                }
                CommandDB.LoadUpdateAssist(_session.UserInfo.uid, _session.UserInfo.AssistFlag);
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_SET_ASSIST][Info] PLAYER[UID=" + _session.UserInfo.uid + "] Desligou o Assist Modo", type_msg.CL_FILE_LOG_AND_CONSOLE));
                return (rt, item);
            }
            return (-1, null);
        }
    }
}