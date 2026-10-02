using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb; 
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_PLAY_BIG_PAPEL_SHOP : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet pkt)
        {
            var p = new Packet();
            var sys_achieve = new AchievementSystem();

            try
            {
                // --- 1. VALIDAÇÕES ORIGINAIS ---
                if (session.UserInfo.block_flag.m_flag.papel_shop)
                    throw new exception("[Lobby::HandleBigPlay][Error] PLAYER [UID=" + session.UserInfo.uid + "] tentou jogar no Papel Shop, mas ele nao pode. Hacker ou Bug",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x790001));

                if (session.UserInfo.Member.level < 1)
                    throw new exception("[Lobby::HandleBigPlay][Error] PLAYER [UID=" + session.UserInfo.uid + "] tentou jogar o Papel Shop Big, mas nao tem o level necessario.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 8, 0x5900108));

                var shopSystem = sPapelShopSystem.getInstance();
                if (!shopSystem.isLoad()) shopSystem.load();

                if (shopSystem.isLimittedPerDay() && session.UserInfo.Member.PapelShop.remain_count <= 0)
                    throw new exception("[Lobby::HandleBigPlay][Warning] PLAYER [UID=" + session.UserInfo.uid + "] atingiu o limite diario.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 1, 0x5900101));

                if (session.UserInfo.Statistics.pang < shopSystem.getPriceBig())
                    throw new exception("[Lobby::HandleBigPlay][Error] PLAYER [UID=" + session.UserInfo.uid + "] nao tem Pangs suficiente.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 2, 0x5900102));

                // --- 2. SORTEIO E PROCESSAMENTO DE ITENS ---
                var balls = shopSystem.dropBigBall(session);
                if (balls == null || !balls.Any())
                    throw new exception("[Lobby::HandleBigPlay][Error] PLAYER [UID=" + session.UserInfo.uid + "] falha ao sortear bolas Big. Bug",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x5900103));

                // Processamento dos itens sorteados
                var v_item = ProcessBigBalls(session, balls);

                // --- 3. PERSISTÊNCIA (DB E SERVER) ---
                var rai = ItemManager.addItem(v_item, session, 0, 0);
                if (rai.fails.Any() && rai.type != RetAddItem.SUCCESS_PANG_AND_EXP_AND_CP_POUCH)
                    throw new exception("[Lobby::HandleBigPlay][Error] Erro ao adicionar itens Big ao DB.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 6, 0x5900106));

                // Pagamento e Atualização de Contagem
                session.UserInfo.consomePang(shopSystem.getPriceBig());
                shopSystem.updatePlayerCount(session);

                // --- 4. LOGS DE ITENS RAROS E ACHIEVEMENTS ---
                foreach (var el in balls.Where(b => b.ctx_psi.tipo == PAPEL_SHOP_TYPE.PST_RARE))
                {
                    sys_achieve.incrementCounter(0x6C400081u); // Rare Win
                    NormalManagerDB.getInstance().add(19, new CmdInsertPapelShopRareWinLog(session.UserInfo.uid, el), null, null);
                }
                sys_achieve.incrementCounter(0x6C40004Au); // Play Papel Shop

                // --- 5. RESPOSTAS DE REDE (NETWORK) ---
                SendBigResponsePackets(session, v_item, balls);

                sys_achieve.finish_and_update(session);
            }
            catch (exception e)
            {
                // Log via message_pool original
                _smp.message_pool.getInstance().push(new message("[Lobby::RequestPlayBigPapelShop][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x26C);
                uint errorCode = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.CHANNEL)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                    : 0x5900100;

                p.WriteUInt32(errorCode);
                session.Send(p);
            }
        }

        // --- MÉTODOS AUXILIARES PARA LIMPEZA ---

        private List<stItem> ProcessBigBalls(Player session, List<ctx_papel_shop_ball> balls)
        {
            var list = new List<stItem>();
            foreach (var el in balls)
            {
                var item = new stItem();
                var bi = new BuyItem { id = -1, _typeid = el.ctx_psi._typeid, qntd = el.qntd };
                ItemManager.initItemFromBuyItem(session.UserInfo, item, bi, false, 0, 0, 1);

                if (item._typeid == 0) throw new exception("Falha ao inicializar item Big", 0x5900104);

                var existing = list.FirstOrDefault(x => x._typeid == item._typeid);
                if (existing != null)
                {
                    existing.qntd += item.qntd;
                    existing.STDA_C_ITEM_QNTD = (short)existing.qntd;
                }
                else
                {
                    list.Add(new stItem(item));
                }
                el.item = item;
            }
            return list;
        }

        private void SendBigResponsePackets(Player session, List<stItem> items, List<ctx_papel_shop_ball> balls)
        {
            var p = new Packet();

            // 0xC8 - Update Pangs
            p.init_plain(0xC8);
            p.WriteUInt64(session.UserInfo.Statistics.pang);
            p.WriteUInt64(0);
            session.Send(p);

            // 0x216 - Update Itens
            p.init_plain(0x216);
            p.WriteUInt32((uint)UtilTime.GetSystemTimeAsUnix());
            p.WriteUInt32((uint)items.Count);
            foreach (var el in items)
            {
                p.WriteByte(el.type);
                p.WriteUInt32(el._typeid);
                p.WriteInt32(el.id);
                p.WriteUInt32(el.flag_time);
                p.WriteBytes(el.stat.ToArray());
                p.WriteInt32((el.STDA_C_ITEM_TIME > 0) ? el.STDA_C_ITEM_TIME : el.STDA_C_ITEM_QNTD);
                p.WriteZero(25);
            }
            session.Send(p);

            // 0xFB - Update Count
            p.init_plain(0xFB);
            if (sPapelShopSystem.getInstance().isLimittedPerDay())
            {
                p.WriteInt32(session.UserInfo.Member.PapelShop.remain_count);
                p.WriteInt32(session.UserInfo.Member.PapelShop.current_count);
            }
            else
            {
                p.WriteInt32(-1);
                p.WriteInt32(-3);
            }
            session.Send(p);

            // 0x26C - Resposta Big
            p.init_plain(0x26C);
            p.WriteUInt32(0); // OK
            p.WriteInt32(0); // Sem cupom
            p.WriteUInt32((uint)balls.Count);
            foreach (var el in balls)
            {
                p.WriteUInt32((uint)el.color);
                p.WriteUInt32(el.ctx_psi._typeid);
                p.WriteInt32((el.item is stItem i) ? i.id : 0);
                p.WriteUInt32(el.qntd);
                p.WriteUInt32((uint)el.ctx_psi.tipo);
            }
            p.WriteUInt64(session.UserInfo.Statistics.pang);
            p.WriteUInt64(session.UserInfo.Cookie);
            session.Send(p);
        }
    }
}