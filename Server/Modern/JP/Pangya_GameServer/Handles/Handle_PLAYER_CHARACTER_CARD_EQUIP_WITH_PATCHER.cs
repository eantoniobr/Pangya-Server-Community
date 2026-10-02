using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHARACTER_CARD_EQUIP_WITH_PATCHER : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();
            try
            {
                // 1. Validação de Maestria
                if (_session.UserInfo.block_flag.m_flag.char_mastery)
                {
                    throw new exception($"[EquipWithPatcher] Player UID={_session.UserInfo.uid} bloqueado para maestria.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 9, 0x790001));
                }

                CardEquip ce = new CardEquip().ToRead(_packet);
                List<stItem> v_item = new List<stItem>();

                // 2. Validação do Club Patcher
                var pWi = _session.Inventory.FindWarehouseItemByTypeid(CLUB_PATCHER_TYPEID);
                if (pWi == null || pWi.STDA_C_ITEM_QNTD < 1)
                {
                    throw new exception($"[EquipWithPatcher] Player UID={_session.UserInfo.uid} sem Club Patcher ou quantidade insuficiente.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 809, 0x5200810));
                }

                // Adicionar gasto do Patcher
                v_item.Add(new stItem
                {
                    type = 2,
                    id = (int)pWi.id,
                    _typeid = pWi._typeid,
                    qntd = 1,
                    STDA_C_ITEM_QNTD = -1
                });

                // 3. Validação do Card (IFF e Inventário)
                var cardIff = sIff.getInstance().findCard(ce.card_typeid);
                var pCardInfo = _session.Inventory.FindCardById(ce.card_id);

                if (cardIff == null || pCardInfo == null || pCardInfo._typeid != ce.card_typeid)
                {
                    throw new exception($"[EquipWithPatcher] Erro de validação do Card ID={ce.card_id}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 806, 0x5200807));
                }

                // 4. Validação do Character
                var pCi = _session.Inventory.FindCharacterById(ce.char_id);
                if (pCi == null || pCi._typeid != ce.char_typeid)
                {
                    throw new exception($"[EquipWithPatcher] Player UID={_session.UserInfo.uid} não possui o character ID={ce.char_id}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 800, 0x5200801));
                }

                // 5. Segurança: Personal Shop
                var r = _session.GetRoom();
                if (r != null && r.CheckPersonalShopItem(_session, ce.card_id))
                {
                    throw new exception($"[EquipWithPatcher] Card ID={ce.card_id} está no Personal Shop.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 1010, 0x5201010));
                }

                // Adicionar gasto do Card
                v_item.Add(new stItem
                {
                    type = 2,
                    id = (int)pCardInfo.id,
                    _typeid = pCardInfo._typeid,
                    qntd = 1,
                    STDA_C_ITEM_QNTD = -1
                });

                // 6. Lógica de Slots e Equipamento (Patcher permite apenas slots 4 ou 8)
                if (ce.char_card_slot != 4 && ce.char_card_slot != 8)
                {
                    throw new exception($"[EquipWithPatcher] Slot inválido para Patcher: {ce.char_card_slot}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 802, 0x5200803));
                }

                EquipCard(ce, pCi);

                // 7. Persistência e Remoção de Itens
                if (ItemManager.removeItem(v_item, _session) <= 0)
                {
                    throw new exception("[EquipWithPatcher] Falha ao remover itens do inventário.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 807, 0x5200808));
                }

                CardEquipInfoEx cei = CreateCardEquipInfo(ce, cardIff, pCi);
                _session.Inventory.CardEquipment.Add(cei);

                NormalManagerDB.getInstance().add(10, new CmdEquipCard(_session.UserInfo.uid, cei, 0), null, this);
                _session.Inventory.SyncCharacter(pCi.id, pCi);
                //_session.Inventory.ei.char_info = pCi;//evitar vazamento de memoria

                // 8. Respostas ao Cliente
                SendUpdatePacket(_session, v_item, pCi, cei);
                SendSuccessPacket(_session, ce.card_typeid);

                // 9. Conquistas
                UpdateAchievements(_session);
            }
            catch (exception e)
            {
                HandleError(_session, e);
            }
        }

        private void EquipCard(CardEquip ce, CharacterInfo pCi)
        {
            uint group = sIff.getInstance().getItemSubGroupIdentify22(ce.card_typeid);
            uint slotIdx = (ce.char_card_slot - 1) % 4;
            if (ce.char_card_slot >= 1 && ce.char_card_slot <= 4) 
            {
                if (group != 0) throw new exception("Card não é do tipo Character.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 805, 0x5200806));
                if (pCi.Card_Character[slotIdx] != 0) throw new exception("Slot já ocupado.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 811, 0x5200812));
                pCi.Card_Character[slotIdx] = ce.card_typeid;
            }
            else if (ce.char_card_slot >= 5 && ce.char_card_slot <= 8)
            {
                if (group != 1) throw new exception("Card não é do tipo Caddie.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 805, 0x5200806));
                if (pCi.Card_Caddie[slotIdx] != 0) throw new exception("Slot já ocupado.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 811, 0x5200812));
                pCi.Card_Caddie[slotIdx] = ce.card_typeid;
            }
            else if (ce.char_card_slot >= 9 && ce.char_card_slot <= 12)
            {
                throw new exception("Slot de card inválido.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 754, 0x5200755));

            }
         }

        private CardEquipInfoEx CreateCardEquipInfo(CardEquip ce, PangyaAPI.IFF.Regions.JP.Models.IFF.Card card, CharacterInfo pCi)
        {
            return new CardEquipInfoEx
            {
                index = -1,
                _typeid = ce.card_typeid,
                id = (uint)ce.card_id,
                efeito = card.Effect,
                efeito_qntd = card.EffectValue,
                slot = ce.char_card_slot,
                tipo = sIff.getInstance().getItemSubGroupIdentify22(ce.card_typeid),
                use_yn = 1,
                parts_typeid = pCi._typeid,
                parts_id = (uint)pCi.id
            };
        }

        private void SendUpdatePacket(Player session, List<stItem> usedItems, CharacterInfo pCi, CardEquipInfoEx cei)
        {
            Packet p = new Packet(0x216);
            p.WriteUInt32((uint)UtilTime.GetSystemTimeAsUnix());

            // Itens consumidos + Item Equipado (Tipo 0xCB)
            List<stItem> totalUpdates = new List<stItem>(usedItems);
            totalUpdates.Add(new stItem
            {
                type = 0xCB,
                id = (int)pCi.id,
                _typeid = pCi._typeid,
                price = cei._typeid,
                type_iff = (byte)cei.slot
            });

            p.WriteUInt32((uint)totalUpdates.Count);
            foreach (var el in totalUpdates)
            {
                p.WriteByte(el.type);
                p.WriteUInt32(el._typeid);
                p.WriteInt32(el.id);
                p.WriteUInt32(el.flag_time);
                p.WriteInt32(el.stat.qntd_ant);
                p.WriteInt32(el.stat.qntd_dep);
                p.WriteInt32((el.STDA_C_ITEM_TIME > 0) ? el.STDA_C_ITEM_TIME : el.STDA_C_ITEM_QNTD);
                p.WriteInt16(el.c);
                p.WriteZero(10);
                p.WriteUInt32(el.price);
                p.WriteByte(el.type_iff);
            }
            session.Send(p);
        }

        private void SendSuccessPacket(Player session, uint cardTypeId)
        {
            Packet p = new Packet(0x272);
            p.WriteUInt32(0);
            p.WriteUInt32(cardTypeId);
            session.Send(p);
        }

        private void UpdateAchievements(Player session)
        {
            AchievementSystem sys = new AchievementSystem();
            sys.incrementCounter(0x6C400087u);
            sys.finish_and_update(session);
        }

        private void HandleError(Player session, exception e)
        {
            _smp.message_pool.getInstance().push(new message($"[EquipWithPatcher][Error] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));
            Packet p = new Packet(0x272);
            uint errCode = (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL)
                ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                : 0x5200800;
            p.WriteUInt32(errCode);
            session.Send(p);
        }
    }
}