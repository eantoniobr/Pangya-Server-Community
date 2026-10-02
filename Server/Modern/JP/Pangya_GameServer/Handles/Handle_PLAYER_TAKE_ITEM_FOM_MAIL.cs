using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_TAKE_ITEM_FROM_MAIL : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();
            var m_ci = _session.GetChannel();
            try
            {
                int email_id = _packet.ReadInt32();

                // Level temporário para verificar subida de nível (Exp Pouch)
                ushort tmp_level = (ushort)_session.UserInfo.Member.level;

                // Não marca como lido ainda
                var ei = _session.UserInfo.MailBox.getEmailInfo(email_id, false);

                List<stItem> v_item = new List<stItem>();

                if (ei.itens != null && ei.itens.Count > 0)
                {
                    for (var i = 0; i < ei.itens.Count; ++i)
                    {
                        stItem item = new stItem();
                        ItemManager.initItemFromEmailItem(_session.UserInfo, item, ei.itens[i]);

                        if (item._typeid == 0)
                        {
                            _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TAKE_ITEM_FROM_MAIL][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou inicializar o item que pegou do mailbox[MAIL_ID=" + (email_id) + "].", type_msg.CL_FILE_LOG_AND_CONSOLE));

                            _session.Send(Handle_PACKET_RESPONSE.pacote214(3));
                            return;
                        }

                        // Verifica se já possui o item ou se pode acumular (Overlap)
                        bool canOverlap = sIff.getInstance().IsCanOverlapped(ei.itens[i]._typeid);
                        bool isCaddieItem = sIff.getInstance().getItemGroupIdentify(ei.itens[i]._typeid) == IFF_GROUP.CAD_ITEM;
                        bool ownerHasItem = _session.Inventory.ownerItem(ei.itens[i]._typeid, 1);

                        if ((canOverlap && !isCaddieItem) || !ownerHasItem)
                        {
                            if (ItemManager.isSetItem(item._typeid))
                            {
                                var v_stItem = ItemManager.GetItemOfSetItem(_session, ei.itens[i]._typeid, false, 1);

                                if (v_stItem != null && v_stItem.Count > 0)
                                {
                                    foreach (var el in v_stItem)
                                    {
                                        bool subCanOverlap = sIff.getInstance().IsCanOverlapped(el._typeid);
                                        bool subIsCaddieItem = sIff.getInstance().getItemGroupIdentify(el._typeid) == IFF_GROUP.CAD_ITEM;

                                        if ((subCanOverlap && !subIsCaddieItem) || !_session.Inventory.ownerItem(el._typeid, 1))
                                        {
                                            v_item.Add(new stItem(el));
                                        }
                                    }
                                }
                                else
                                {
                                    _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TAKE_ITEM_FROM_MAIL][Success] PLAYER [UID=" + _session.UserInfo.uid + "] tentou add set item sem item dentro, do MailBox[MAIL_ID=" + (email_id) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                                }
                            }
                            else
                            {
                                v_item.Add(new stItem(item));
                            }
                        }
                        else if (isCaddieItem)
                        {
                            throw new exception("[Handle_PLAYER_TAKE_ITEM_FROM_MAIL][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou pegar um CaddieItem[TYPEID=" + (ei.itens[i]._typeid) + "] do Mail[ID=" + (email_id) + "] de um caddie que ele nao possui",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME, 201, 5100072));
                        }
                        else
                        {
                            throw new exception("[Handle_PLAYER_TAKE_ITEM_FROM_MAIL][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou pegar um item[TYPEID=" + (ei.itens[i]._typeid) + "] do Mail[ID=" + (email_id) + "] que ele ja possui",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME, 201, 5100071));
                        }
                    }

                    // Remove itens do email no Banco de Dados
                    _session.UserInfo.MailBox.leftItensFromEmail(email_id);

                    // Adiciona itens ao Warehouse do jogador
                    var rai = ItemManager.addItem(v_item, _session, 1, 0);

                    if (rai.fails.Count > 0 && rai.type != RetAddItem.SUCCESS_PANG_AND_EXP_AND_CP_POUCH)
                    {
                        foreach (var fail in rai.fails)
                        {
                            _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TAKE_ITEM_FROM_MAIL][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou mover o item[TYPEID=" + (fail._typeid) + "] do MailBox para o MyRoom, mas falhou.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                        }

                        _session.Send(Handle_PACKET_RESPONSE.pacote214(2));
                        return;
                    }

                    // Envia atualizações para o cliente
                    _session.Send(Handle_PACKET_RESPONSE.pacote216(v_item));
                    _session.Send(Handle_PACKET_RESPONSE.pacote214());

                    // Se subiu de nível, sincroniza com o canal/lobby
                    if (tmp_level != _session.UserInfo.Member.level)
                    {
                        m_ci?.UpdatePlayerInfo(_session);

                        if (_session.UserInfo.Lobby != 255)
                        {
                            var pi = m_ci?.GetPlayerInfo(_session);
                            if (pi != null)
                            {
                                m_ci?.SendBroadcast(Handle_PACKET_RESPONSE.pacote046(new List<PlayerLobbyInfo>() { pi }, 3), 1);
                            }
                        }
                    }
                }
                else
                {
                    // Email sem itens
                    _session.Send(Handle_PACKET_RESPONSE.pacote214(1));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_TAKE_ITEM_FROM_MAIL][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                int errCode = (int)((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                    : 0x5500100);

                _session.Send(Handle_PACKET_RESPONSE.pacote214(errCode));
            }
        } 
    }
}