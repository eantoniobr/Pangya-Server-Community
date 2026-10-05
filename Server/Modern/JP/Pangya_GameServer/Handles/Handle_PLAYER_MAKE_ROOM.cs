using Pangya_GameServer.Engine;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Roms;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models.Generic;
using PangyaAPI.IFF.Regions.JP.Models.IFF;
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
    public class Handle_PLAYER_MAKE_ROOM : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            Packet p = new Packet();

           var _channel = Player.GetChannel();
            try
            {
                // 1. Validação de tamanho mínimo do pacote (Prevenção de Buffer Overflow/Crash)
                if (Packet.Size < 20)
                {
                    throw new exception($"[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= {Player.UserInfo.uid}, ID: {Player.UserInfo.id} ] Packet size ({Packet.Size}) too small. Hacker attempt.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 7, 0));
                }

                int option;
                RoomInfo ri = new RoomInfo();
                string s_tmp = "";

                option = Packet.ReadByte();

                ri.time_vs = Packet.ReadUInt32();
                ri.time_30s = Packet.ReadUInt32();
                ri.max_Player = Packet.ReadByte();
                ri.tipo = Packet.ReadByte();
                ri.qntd_hole = Packet.ReadByte();
                ri.course = (ROOM_INFO_COURSE)(Packet.ReadByte());

                // 3. Verificação de Course Válido
                if (!Enum.IsDefined(typeof(ROOM_INFO_COURSE), ri.course))
                {
                    throw new exception($"[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= {Player.UserInfo.uid}, ID: {Player.UserInfo.id} ] Course ID {(int)ri.course} inválido.",
                       ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 7, 0));
                }

                ri.modo = Packet.ReadByte();
                if (!Enum.IsDefined(typeof(ROOM_INFO_MODO), ri.modo))
                {
                    throw new exception($"[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= {Player.UserInfo.uid}, ID: {Player.UserInfo.id} ] Modo ID {(int)ri.modo} inválido.",
                       ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 7, 0));
                }

                var len = Packet.Size;

                bool practice = false; 
                ri.hole_repeat = 0;
                ri.fixed_hole = 0;
                //hole repeted = 68, chip-in = 63
                if ((len == 52) && ri.tipo == 19) //hole repeted tem natural
                {
                    Packet.ReadBytes(5);//seria esses dados abaixo...
                    ri.hole_repeat = 1;
                    ri.fixed_hole = 7;
                    practice = true;
                }
                else if (len == 47 && ri.tipo == 14) 
                    // Chip-in Practice, so pra passar true mesmo...
                {
                    practice = true;
                }

                if (!Player.UserInfo.UserCapabilities.game_master && ri.max_Player > 30)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] limite atingido, Hacker, por que o cliente nao deixa criar uma sala maior que 30, pois o cliente nao e gm/adm.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        7, 0));
                }

                ri.special_flag_mod.ulNaturalAndShortGame = Packet.ReadUInt32();

                // CHECK DE SEGURANÇA: 
                // Natural (Bit 0) + Short Game (Bit 1) = Valor máximo 3
                if (ri.special_flag_mod.ulNaturalAndShortGame > 3)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala com NaturalAndShortGame inválido.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                      7, 0));
                }
                s_tmp = Packet.ReadString();

                if (s_tmp.Length == 0)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] Nome da sala vazio, Hacker, por que o cliente nao deixa enviar esse pacote sem um nome da sala.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        7, 0));
                }

                if (s_tmp.Length > 32)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] Nome da sala muito longo, Hacker.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        7, 0));
                }

                if (practice)
                {
                    s_tmp = "Single Player Practice Mode";
                    if (ri.max_Player > 1)
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + (_channel?.getId())
                            + "] Numero de jogadores errado, Hacker, por que o cliente nao deixa enviar esse pacote assim.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 7, 7));
                    }
                }

                ri.name = s_tmp;
                s_tmp = Packet.ReadString();

                if (s_tmp.Length > 8)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tamanho da senha esta errado, Code[0].", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        7, 0));
                }

                if (practice)
                {
                    if (s_tmp.empty()) 
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + (_channel?.getId())
                            + "] senha da sala practice esta errada!.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 7, 0));
                    }

                    if (s_tmp.Length < 8)
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tamanho da senha esta errado, Code[2].", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                            7, 0));
                    }
                }

                if (!s_tmp.empty())
                {
                    ri.senha_flag = 0;
                    ri.senha = s_tmp;
                }

                ri.typeid_artefatic = Packet.ReadUInt32();

                // Check De Regras
                _channel?.CheckRoom(Player, ri);

                if (ri.special_flag_mod.short_game && ri.GetTipo() != ROOM_INFO_TYPE.TOURNEY
                    && ri.GetTipo() != ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE
                    && ri.GetTipo() != ROOM_INFO_TYPE.GRAND_PRIX)
                {
                    ri.special_flag_mod.short_game = false;
                }

                if (_channel.getProperty().natural)
                {
                    ri.special_flag_mod.natural = true;
                }

                var flag = Player.UserInfo.block_flag.m_flag;

                if (flag.all_game && (ri.GetTipo() != ROOM_INFO_TYPE.LOUNGE || flag.lounge))
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar um sala, mas ele nao pode criar nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x780001));
                }

                switch (ri.GetTipo())
                {
                    case ROOM_INFO_TYPE.STROKE:
                        if (flag.stroke)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + (_channel?.getId()) + "] tentou criar sala[TIPO=" + (ri.GetTipo()) + "], mas ele nao pode criar Stroke.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 2, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.MATCH:
                        if (flag.match)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Match.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.TOURNEY:
                        if (flag.tourney)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Tourney.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 4, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.TOURNEY_TEAM:
                        if (flag.team_tourney)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Team Tourney.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 5, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.GUILD_BATTLE:
                        if (flag.guild_battle)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Guild Battle.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 6, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.PANG_BATTLE:
                        if (flag.pang_battle)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Pang Battle.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 7, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.APPROCH:
                        if (flag.approach)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Approach.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 8, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.LOUNGE:
                        if (flag.lounge)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Lounge.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 9, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.GRAND_ZODIAC_INT:
                    case ROOM_INFO_TYPE.GRAND_ZODIAC_ADV:
                    case ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE:
                        if (flag.grand_zodiac)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Grand Zodiac.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.GRAND_PRIX:
                        if (flag.grand_prix)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Grand Prix.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 11, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                        if (flag.ssc)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Special Shuffle Course.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 12, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.PRACTICE:
                        if (flag.single_play)
                        {
                            throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas ele nao pode criar Practice.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 13, 0x770001));
                        }
                        break;
                }

                if (ri.special_flag_mod.short_game && (flag.team_tourney || flag.short_game))
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar a sala Short Game, mas ele nao pode.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 1, 770001));
                }

                if (ri.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE && ri.time_30s != (30 * 60000))
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar a sala[TIPO=" + ((ushort)ri.GetTipo()) + "], mas o tempo é diferente do esperado.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 1, 780002));
                }

                if ((ri.GetTipo() >= ROOM_INFO_TYPE.GRAND_ZODIAC_INT && ri.GetTipo() <= ROOM_INFO_TYPE.GRAND_ZODIAC_ADV) && !Player.UserInfo.UserCapabilities.game_master)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar a sala de Grand Zodiac Event sem ser GM.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 2, 760001));
                }

                if (ri.GetTipo() == ROOM_INFO_TYPE.GRAND_PRIX)
                {
                    throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar a sala Grand Prix indevidamente.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 15, 0x770001));
                }

                ri.channel_rookie = true;

                if (ri.GetTipo() == ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE)
                {
                    var pWi = Player.Inventory.FindWarehouseItemByTypeid(SPECIAL_SHUFFLE_COURSE_TICKET_TYPEID);

                    if (pWi == null)
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar a sala Special Shuffle Course, mas ele nao tem o Ticket.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 9, 0));
                    }

                    if (pWi.STDA_C_ITEM_QNTD < 1)
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] tentou criar a sala Special Shuffle Course sem tickets suficientes.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0));
                    }

                    stItem item = new stItem();
                    item.type = 2;
                    item.id = (int)pWi.id;
                    item._typeid = pWi._typeid;
                    item.qntd = 1;
                    item.STDA_C_ITEM_QNTD = (short)(item.qntd * -1);

                    if (ItemManager.removeItem(item, _session) <= 0)
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] erro ao remover Ticket SSC.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 11, 0));
                    }

                    if (ri.special_flag_mod.short_game)
                    {
                        ri.time_30s = 20 * 60000;
                    }
                }

                Room? r = null;

                try
                {
                    _channel?.DeleteInviteTimeResquestByInvited(Player);

                    r = GameServer.getInstance().MakeRoom(_channel, ri, _session);

                    if (r == null)
                    {
                        throw new exception("[Handle_PLAYER_MAKE_ROOM] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] Channel[ID=" + _channel?.getId() + "] erro na criacao da sala.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 8, 0));
                    }

                    _channel?.UpdatePlayerInfo(Player);

                    r.SendUpdateRoom();
                    r.SendMakeRoom(Player);
                    r.SendPlayerInfo(Player, 0);
                    r.SendPlayerStateLounge(Player);
                    r.SendWeatherLounge(Player);

                    _channel?.SendUpdateRoomInfo(r.GetInfo(), 1);

                    if (r.GetTipo() != ROOM_INFO_TYPE.PRACTICE && r.GetTipo() != ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE)
                    {
                        _channel?.SendUpdatePlayerInfo(Player, 3);
                    }

                    if (r.GetTipo() == ROOM_INFO_TYPE.GUILD_BATTLE)
                    {
                        r.SendPlayerInfo(Player, 0);
                    }

                    if (!r.IsWithBot() && !r.IsRoomGM() && (r.GetTipo() == ROOM_INFO_TYPE.TOURNEY || r.GetTipo() == ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE))
                    {
                        try
                        {
                            if (r.IsLocked() && r.CheckPass("bot"))
                            {
                                r.MakeRoomBot(Player);
                            }
                        }
                        catch (exception e)
                        {
                            throw e;
                        }
                    }

                    if (r != null)
                    {
                        _channel?.Lobby.AddRoom(r);
                        _channel?.Lobby.UnlockRoom(r);  
                    }
                }
                catch (exception e)
                {
                    if (r != null)
                    {
                        _channel?.Lobby.UnlockRoom(r);
                    }
                    throw e;
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_MAKE_ROOM][ErrorSystem] PLAYER[UID= " + Player.UserInfo.uid + ", ID: " + Player.UserInfo.id + " ] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x49);
                p.WriteUInt16(2); // Error
                Player.Send(p);
            }
        }
    }
}