using Pangya_GameServer.Engine;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
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
    public class Handle_PLAYER_JOIN_ROOM : IPacketHandler<Player>
    { 
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();
            try
            {
                short sala_numero = _packet.ReadInt16();
                string senha = _packet.ReadString();

                var r = GameServer.getInstance().FindRoom(sala_numero);

                if (r == null)
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[NUMERO=" + (sala_numero) + "], mas ela nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        2, 0));
                }

                // Flag Server
                var flag = _session.UserInfo.block_flag.m_flag;

                // Player não pode criar sala, exceto Lounge, se ele não estiver bloqueado
                if (flag.all_game && (r.GetTipo() != ROOM_INFO_TYPE.LOUNGE || flag.lounge))
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar um sala[NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar em nenhuma sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 0x780001));
                }

                switch (r.GetTipo())
                {
                    case ROOM_INFO_TYPE.STROKE:
                        if (flag.stroke)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Stroke. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                2, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.MATCH:
                        if (flag.match)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Match. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                3, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.TOURNEY:
                        if (flag.tourney)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Tourney. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                4, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.TOURNEY_TEAM:
                        if (flag.team_tourney)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Team Tourney. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                5, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.GUILD_BATTLE:
                        if (flag.guild_battle)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Guild Battle. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                6, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.PANG_BATTLE:
                        if (flag.pang_battle)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Pang Battle. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                7, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.APPROCH:
                        if (flag.approach)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Approach. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                8, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.LOUNGE:
                        if (flag.lounge)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Lounge. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                9, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.GRAND_ZODIAC_INT:
                    case ROOM_INFO_TYPE.GRAND_ZODIAC_ADV:
                    case ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE:
                        if (flag.grand_zodiac)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Grand Zodiac. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                10, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.GRAND_PRIX:
                        if (flag.grand_prix)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Grand Prix. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                11, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                        if (flag.ssc)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Special Shuffle Course. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                12, 0x770001));
                        }
                        break;
                    case ROOM_INFO_TYPE.PRACTICE:
                        if (flag.single_play)
                        {
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar Practice. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                13, 0x770001));
                        }
                        break;
                }

                if (r.GetInfo().special_flag_mod.short_game && (flag.team_tourney || flag.short_game))
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas ele nao pode entrar sala Short Game. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        1, 770001));
                }

                if (r.GetTipo() == ROOM_INFO_TYPE.GRAND_PRIX)
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[TIPO=" + r.GetInfo() + ", NUMERO=" + r.GetRoomId() + "], mas nao pode entrar na sala Grand Prix com esse pacote. Hacker.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        15, 0x770001));
                }

                if (r.GameRun() && _session.UserInfo.UserCapabilities.game_master) // GM Entra na sala depois que o jogo começou
                {
                    r.SendTimeGame(_session);
                }
                else if (r.CurrentGame != null) // não é GM envia error para o player que ele nao pode entrar na sala depois de ter começado
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[NUMERO=" + (sala_numero) + "], mas a sala ja comecou o jogo. Hacker ou Bug.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        10, 0));
                }
                else
                {
                    if (!r.IsLocked() || r.IsInvited(_session) || (_session.UserInfo.UserCapabilities.game_master) || (!senha.empty() && r.CheckPass(senha)))
                    {
                        if (r.IsInvited(_session))
                        {
                            // Deleta convite

                            // Add convidado a sala
                            if (!r.IsFull() && r.GetInvited(_session) != null)
                            {
                                var ici = r.DeleteInvited(_session);

                                r.EnterToRoom(_session);

                                _session.GetChannel().DeleteInviteTimeRequest(ici);
                            }
                        }
                        else if (!r.IsFull())
                        {
                            // Verifica se o player foi convidado em outra sala
                            // e tira o convite dele
                            _session.GetChannel().DeleteInviteTimeResquestByInvited(_session);

                            r.EnterToRoom(_session);
                        }
                        else
                        {
                            throw new exception("[Handle_PLAYER_JOIN_ROOM][Warning] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[NUMERO=" + (sala_numero) + "], mas a sala esta cheia.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                3, 0));
                        }
                    }
                    else
                    {
                        throw new exception("[Handle_PLAYER_JOIN_ROOM][Warning] PLAYER[UID=" + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou entrar na sala[NUMERO=" + (sala_numero) + "], mas a senha nao é igual a da sala.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                            4, 0));
                    }

                    // Att PlayerCanalInfo
                    _session.GetChannel().UpdatePlayerInfo(_session);

                    r.SendUpdateRoom();

                    r.SendMakeRoom(_session);

                    r.SendPlayerInfo(_session, 0); //zero e a lista

                    r.SendPlayerInfo(_session, 1); //1 e o criador

                    r.SendPlayerStateLounge(_session);

                    r.SendWeatherLounge(_session);

                    _session.GetChannel().SendUpdateRoomInfo(r.GetInfo(), 3);

                    if (r.GetTipo() != ROOM_INFO_TYPE.PRACTICE && r.GetTipo() != ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE)
                    {
                        _session.GetChannel().SendUpdatePlayerInfo(_session, 3);
                    }

                    // Guild Battle precisa enviar o sendCharacter opção 0 duas vezes.
                    // Uma na sua posição normal e outra depois de atualizar o info da sala na lobby
                    if (r.GetTipo() == ROOM_INFO_TYPE.GUILD_BATTLE)
                    {
                        r.SendPlayerInfo(_session, 0);
                    }
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_JOIN_ROOM][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Resposta Error
                p.init_plain(0x49);

                p.WriteByte(1); // Error

                _session.Send(p);
            }

            await Task.CompletedTask;
        }
    }
}