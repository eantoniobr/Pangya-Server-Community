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
    public class Handle_PLAYER_PLAY_PAPEL_SHOP : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet pkt)
        {
            Packet p = new Packet();
            var sys_achieve = new AchievementSystem();

            try
            {
                // --- 1. VALIDAÇÕES ---
                if (session.UserInfo.block_flag.m_flag.papel_shop)
                    throw new exception("[Lobby::HandlePlay][Error] PLAYER [UID=" + session.UserInfo.uid + "] bloqueado.",
                  ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x790001));

                if (session.UserInfo.Member.level < 1)
                    throw new exception("[Lobby::HandlePlay][Error] Level insuficiente.",
                 ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 8, 0x5900108));

                var shopSystem = sPapelShopSystem.getInstance();
                if (!shopSystem.isLoad()) shopSystem.load();

                if (shopSystem.isLimittedPerDay() && session.UserInfo.Member.PapelShop.remain_count <= 0)
                    throw new exception("[Lobby::HandlePlay][Warning] Limite diário atingido.",
                 ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 1, 0x5900101));

                // --- 2. PAGAMENTO E SORTEIO ---
                var coupon = shopSystem.hasCoupon(session);
                if (coupon == null && session.UserInfo.Statistics.pang < shopSystem.getPriceNormal())
                    throw new exception("[Lobby::HandlePlay][Error] Sem fundos.",
                 ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 2, 0x5900102));

                var balls = shopSystem.dropBalls(session);
                if (!balls.Any()) throw new exception("[Lobby::HandlePlay][Error] Erro no sorteio.",
                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x5900103));
                // --- 3. PROCESSAMENTO DE ITENS ---
                var v_item = ProcessBallsToItems(session, balls);

                // Add ao Server e DB
                var rai = ItemManager.addItem(v_item, session, 0, 0);
                if (rai.fails.Any() && rai.type != RetAddItem.SUCCESS_PANG_AND_EXP_AND_CP_POUCH)
                    throw new exception("[Lobby::HandlePlay][Error] Erro ao adicionar itens ao DB.",
                 ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 6, 0x5900106));

                // Gerenciar Cupom ou Pang
                if (coupon != null)
                {
                    var itemRemover = new stItem { type = 2, id = coupon.id, _typeid = coupon._typeid, qntd = 1 };
                    itemRemover.STDA_C_ITEM_QNTD = (short)(itemRemover.qntd * -1);

                    if (ItemManager.removeItem(itemRemover, session) <= 0)
                        throw new exception("[Lobby::HandlePlay][Error] Erro ao deletar Cupom.",
                      ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 5, 0x5900105));

                    v_item.Add(itemRemover);
                }
                else
                {
                    session.UserInfo.consomePang(shopSystem.getPriceNormal());
                }

                // --- 4. ATUALIZAÇÕES E LOGS ---
                shopSystem.updatePlayerCount(session);
                sys_achieve.incrementCounter(0x6C40004Au); // Play Papel Shop

                foreach (var ball in balls.Where(b => b.ctx_psi.tipo == PAPEL_SHOP_TYPE.PST_RARE))
                {
                    sys_achieve.incrementCounter(0x6C400081u); // Rare Win
                    NormalManagerDB.getInstance().add(19, new CmdInsertPapelShopRareWinLog(session.UserInfo.uid, ball), null, null);
                }

                // --- 5. RESPOSTAS  ---
                SendResponsePackets(session, v_item, balls, coupon?.id?? 0);

                sys_achieve.finish_and_update(session);
            }
            catch (Exception e)
            {
                // Log igual ao seu original
                Console.WriteLine($"[Lobby::RequestPlayPapelShop][Error] {e.Message}");

                p.init_plain(0x21B);
                // Lógica de código de erro simplificada (ajuste conforme seu ExceptionError original)
                p.WriteUInt32(0x5900100);
                session.Send(p);
            }
        }

        // --- MÉTODOS AUXILIARES (Para manter o Handle limpo) ---

        private List<stItem> ProcessBallsToItems(Player session, List<ctx_papel_shop_ball> balls)
        {
            var list = new List<stItem>();
            foreach (var ball in balls)
            {
                var item = new stItem();
                var bi = new BuyItem { id = -1, _typeid = ball.ctx_psi._typeid, qntd = ball.qntd };

                ItemManager.initItemFromBuyItem(session.UserInfo, item, bi, false, 0, 0, 1);


                var existing = list.FirstOrDefault(x => x._typeid == item._typeid);
                if (existing != null)
                {
                    existing.qntd += item.qntd;
                    existing.STDA_C_ITEM_QNTD = (short)existing.qntd;
                }
                else
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private void SendResponsePackets(Player session, List<stItem> items, List<ctx_papel_shop_ball> balls, int coupon_id = 0)
        {
            // Pacote 0x216 (Update Itens)
            var p216 = new Packet(0x216);
            p216.WriteUInt32((uint)UtilTime.GetSystemTimeAsUnix());
            p216.WriteUInt32((uint)items.Count);
            foreach (var it in items) WriteStItem216(p216, it);
            session.Send(p216);

            // Pacote 0xFB (Update Count)
            var pFB = new Packet(0xFB);
            var shop = sPapelShopSystem.getInstance();
            pFB.WriteInt32(shop.isLimittedPerDay() ? session.UserInfo.Member.PapelShop.remain_count : -1);
            pFB.WriteInt32(shop.isLimittedPerDay() ? -2 : -3);
            session.Send(pFB);

            // Pacote 0x21B (Resultado Final)
            var p21B = new Packet(0x21B);
            p21B.WriteUInt32(0); // OK
            p21B.WriteInt32(coupon_id);
            p21B.WriteUInt32((uint)balls.Count);
            foreach (var b in balls)
            {
                p21B.WriteUInt32((uint)b.color);
                p21B.WriteUInt32(b.ctx_psi._typeid);
                p21B.WriteUInt32((uint)((b.item is stItem i) ? i.id : 0));
                p21B.WriteUInt32(b.qntd);
                p21B.WriteUInt32((uint)b.ctx_psi.tipo);
            }
            p21B.WriteUInt64(session.UserInfo.Statistics.pang);
            p21B.WriteUInt64(session.UserInfo.Cookie);
            session.Send(p21B);
        }

        private void WriteStItem216(Packet p, stItem it)
        {
            p.WriteByte(it.type);
            p.WriteUInt32(it._typeid);
            p.WriteInt32(it.id);
            p.WriteUInt32(it.flag_time);
            p.WriteBytes(it.stat.ToArray());
            p.WriteInt32(it.STDA_C_ITEM_TIME > 0 ? it.STDA_C_ITEM_TIME : it.STDA_C_ITEM_QNTD);
            p.WriteZero(25);
        }
    }
}