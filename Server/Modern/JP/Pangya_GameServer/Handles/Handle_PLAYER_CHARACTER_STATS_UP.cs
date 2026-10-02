using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
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
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHARACTER_STATS_UP : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();

            try
            {
                if (_session.UserInfo.block_flag.m_flag.char_mastery)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou upar Stats do character, mas ele nao pode. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        9, 0x790001));
                }

                uint stat = _packet.ReadUInt32();

                CharacterInfo ci = new CharacterInfo().ToRead(_packet);

                var pCi = _session.Inventory.FindCharacterById(ci.id);

                if (pCi == null || pCi._typeid != ci._typeid)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou upar stat[value=" + (stat) + "] do Character[TYPEID=" + (ci._typeid) + ", ID=" + (ci.id) + "] que ele nao possui. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        500, 0x5200501));
                }

                var character = sIff.getInstance().findCharacter(pCi._typeid);

                if (character == null)
                {
                    throw new exception("[Lobby::RequestChracterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou upar stat[value=" + (stat) + "] do Character[TYPEID=" + (pCi._typeid) + ", ID=" + (pCi.id) + "], mas ele nao existe no IFF_STRUCT do server. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        504, 0x5200505));
                }

                sbyte value = 0;

                var value_part = ci.getSlotOfStatsFromCharEquipedPartItem((byte)(stat));
                var value_auxpart = ci.getSlotOfStatsFromCharEquipedAuxPart((byte)(stat));
                var value_set_effect_table = ci.getSlotOfStatsFromSetEffectTable((byte)(stat));
                var value_card = ci.getSlotOfStatsFromCharEquipedCard((byte)(stat));

                if (value_part == -1
                    || value_card == -1
                    || value_auxpart == -1
                    || value_set_effect_table == -1)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "], stat[value=" + (stat) + "] is invalid. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        501, 0x5200502));
                }

                // Slot de Part Equiped
                value += (sbyte)value_part;

                // Slot de AuxPart Equiped
                value += (sbyte)value_auxpart;

                // Slot do Set Effect Table
                value += (sbyte)value_set_effect_table;

                // Slot de Card Equiped
                value += (sbyte)value_card;

                // Level + POWER, cada level da +1 de POWER
                if (stat == (uint)CharacterInfo.Stats.S_POWER)
                {
                    value += (sbyte)((_session.UserInfo.Member.level - 1) / 5);
                }

                var mastery = sIff.getInstance().findCharacterMastery(pCi._typeid);

                if (mastery.Count == 0)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou upar stat[value=" + (stat) + "] do Character[TYPEID=" + (pCi._typeid) + ", ID=" + (pCi.id) + "], mas nao tem o Character Mastery no IFF_STRUCT do server. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        505, 0x5200506));
                }

                if (mastery.Count < pCi.mastery)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou upar stat[value=" + (stat) + "] do Character[TYPEID=" + (pCi._typeid) + ", ID=" + (pCi.id) + "], mas o CharacterMastery[value=" + (pCi.mastery) + ", List_size=" + (mastery.Count) + "] do player e invalido. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        506, 0x5200507));
                }

                // 1. Pegue o limite base do IFF para esse personagem (Quantos slots ele PODE ter no máximo)
                var bLimiteMaximoIFF = character.PCL[stat];

                // 2. Calcule o bônus adicional vindo de Mastery
                sbyte slotsExtrasMastery = 0;
                for (var i = 0; i < pCi.mastery; ++i)
                {
                    if ((mastery[i].stats - 1) == stat)
                        slotsExtrasMastery++;
                }

                // O limite real de UPGRADE é o Base do IFF + o que ele ganhou de Mastery
                int limiteRealDeUpgrade = bLimiteMaximoIFF + slotsExtrasMastery + value;

                // 3. A validação correta: 
                if (pCi.pcl[stat] > limiteRealDeUpgrade)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] atingiu o limite de slots para o stat " + stat,
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 502, 0x5200503));
                }

                uint enchant_typeid = ((Convert.ToUInt32(sIff.getInstance().ENCHANT) << 26) | (stat << 20)) + pCi.pcl[stat];

                var enchant = sIff.getInstance().findEnchant(enchant_typeid);

                if (enchant == null)
                {
                    throw new exception("[Lobby::RequestCharacterStatsUp][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou upar stats[stats=" + (stat) + "] do Character[ID=" + (ci.id) + "], mas nao encontrou o enchant[TYPEID=" + (enchant_typeid) + "]", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        503, 0x5200504));
                }

               _session.UserInfo.consomePang((ulong)enchant.Pang);

                pCi.pcl[stat]++;

                // CmdUpdateCharacterPCL
                NormalManagerDB.getInstance().add(7, new CmdUpdateCharacterPCL(_session.UserInfo.uid, pCi), null, this);

                // Atualiza Pang(s) no Jogo
                p.init_plain(0xC8);

                p.WriteUInt64(_session.UserInfo.Statistics.pang);
                p.WriteInt64(enchant.Pang);

                _session.Send(p);

                // Atualiza Item no Jogo
                p.init_plain(0x216);

                p.WriteUInt32((uint)UtilTime.GetSystemTimeAsUnix());
                p.WriteUInt32(1); // Count

                p.WriteByte(0xC9);
                p.WriteUInt32(pCi._typeid);
                p.WriteInt32(pCi.id);
                p.WriteUInt32(0); // Flag Time
                p.WriteUInt32(0); // qntd ant
                p.WriteUInt32(0); // qntd dep
                p.WriteUInt32(0); // qntd
                p.WriteUInt16(pCi.pcl[(int)CharacterInfo.Stats.S_POWER]); // stats.PWR
                p.WriteUInt16(pCi.pcl[(int)CharacterInfo.Stats.S_CONTROL]); // stats.CTRL
                p.WriteUInt16(pCi.pcl[(int)CharacterInfo.Stats.S_ACCURACY]); // stats.ACCRY
                p.WriteUInt16(pCi.pcl[(int)CharacterInfo.Stats.S_SPIN]); // stats.SPIN
                p.WriteUInt16(pCi.pcl[(int)CharacterInfo.Stats.S_CURVE]); // stats.CURVE
                p.WriteZero(15);

                _session.Send(p);

                // Resposta de Upar Stats Character
                p.init_plain(0x26F);

                p.WriteUInt32(0); // OK

                p.WriteUInt32(stat);

                _session.Send(p);

                // Update Achievement ON SERVER, DB and GAME
                AchievementSystem sys_achieve = new AchievementSystem();

                sys_achieve.incrementCounter(0x6C400084u);

                sys_achieve.finish_and_update(_session);

                _session.Inventory.SyncCharacter(pCi.id, pCi);
                //_session.Inventory.ei.char_info = pCi;//evitar vazamento de memoria
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby::RequestCharacterStatsUp][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x26F);

                p.WriteUInt32((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL) ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : 0x5200500);

                _session.Send(p);
            }
        } 
    }
}