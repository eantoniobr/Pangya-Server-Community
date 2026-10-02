using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;

public class Handle_PLAYER_USE_ITEM_BUFF : IPacketHandler<Player>
{
    public async Task Handle(Player _session, Packet _packet)
    {
        Packet p = new Packet();
        try
        {
            uint item_typeid = _packet.ReadUInt32();
            if (item_typeid == 0) throw new exception("Typeid invalido", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 400, 0x5500401));

            var pWi = _session.Inventory.FindWarehouseItemByTypeid(item_typeid);
            if (pWi == null || pWi.STDA_C_ITEM_QNTD < 1) throw new exception("Sem item", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 401, 0x5500402));

            var tli = sIff.getInstance().findTimeLimitItem(item_typeid);
            if (tli == null) throw new exception("Item nao existe no IFF Buff", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 403, 0x5500404));

            stItem item_rm = new stItem { type = 2, id = (int)pWi.id, _typeid = pWi._typeid, qntd = 1, STDA_C_ITEM_QNTD = -1 };
            if (ItemManager.removeItem(item_rm, _session) <= 0) throw new exception("Erro ao deletar", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 405, 0x5500406));

            ItemBuffEx ib = _session.Inventory.FindItemBuff(item_typeid);
            if (ib != null)
            {
                uint now = (uint)UtilTime.GetLocalTimeAsUnix();
                uint end = (uint)UtilTime.SystemTimeToUnix(ib.end_date.ConvertTime());
                uint start = (now > end) ? now : end;
                ib.end_date = UtilTime.UnixToSystemTime(start + (uint)(tli.time * 60));
                ib.tempo.setTime((uint)(UtilTime.SystemTimeToUnix(ib.end_date.ConvertTime()) - UtilTime.SystemTimeToUnix(ib.use_date.ConvertTime())));
                NormalManagerDB.getInstance().add(16, new CmdUpdateItemBuff(_session.UserInfo.uid, ib), null, null);
            }
            else
            {
                ib = new ItemBuffEx { _typeid = item_typeid, tipo = tli.type, percent = tli.percent, use_yn = 1 };
                ib.use_date.CreateTime();
                ib.end_date = UtilTime.UnixToSystemTime((uint)UtilTime.SystemTimeToUnix(ib.use_date.ConvertTime()) + (uint)(tli.time * 60));
                ib.tempo.setTime((uint)(UtilTime.SystemTimeToUnix(ib.end_date.ConvertTime()) - UtilTime.SystemTimeToUnix(ib.use_date.ConvertTime())));
                CmdUseItemBuff cmd = new CmdUseItemBuff(_session.UserInfo.uid, ib, tli.time);
                NormalManagerDB.getInstance().add(15, cmd, null, null);
                if (cmd.getException().getCodeError() != 0) throw cmd.getException();
                ib = cmd.getInfo();
                _session.Inventory.ItemBuffs.Add(ib);
            }

            p.init_plain(0x181);
            p.WriteUInt32(2);
            p.WriteUInt32(1);
            p.WriteUInt32(ib._typeid);
            p.WriteBytes(ib.ToArray());
            _session.Send(p);
        }
        catch (exception e)
        {
            _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_USE_ITEM_BUFF][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            p.init_plain(0x181);
            p.WriteUInt32(0x5500400);
            _session.Send(p);
        }
    }
}