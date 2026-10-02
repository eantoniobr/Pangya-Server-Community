using Pangya_GameServer.Engine;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Models;
using Pangya_GameServer.Roms;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_INFO_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {

                var _channel = _session.GetChannel();

                if (_channel == null)
                    throw new exception("[Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou trocar info da sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas a sala nao esta em um canal.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                        10, 0));


                var room = _session.GetRoom();

                if (room == null) 
                    throw new exception("[Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] Channel[ID=" + +_session.GetChannel().getId() + "] tentou trocar info da sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas a sala nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                                        10, 0));


                if (room.GameRun())
                {
                    throw new exception("[Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] Channel[ID=" + +_session.GetChannel().getId() + "] tentou trocar info da sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas a sala ja foi iniciada.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                      10, 0));
                }

                if (room.GetTipo() == ROOM_INFO_TYPE.LOUNGE)
                {
                    throw new exception("[Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] Channel[ID=" + +_session.GetChannel().getId() + "] tentou trocar info da sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas a sala nao contem essa funcao.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                    10, 0));
                }
                 
                byte num_info;
                short roomId;

                if (room.GetMaster() != _session.UserInfo.uid)
                {
                    if (!_session.UserInfo.UserCapabilities.game_master)
                        throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou trocar o info da sala[NUMERO=" + room.GetRoomId() + ", MASTER=" + Convert.ToString(room.GetMaster()) + "], mas nao pode trocar o info da sala sem ser master.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        11, 0));
                }

                roomId = _packet.ReadInt16();
                num_info = _packet.ReadByte();

                if (num_info <= 0)
                {
                    throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou trocar o info da sala[NUMERO=" + room.GetRoomId() + ", MASTER=" + Convert.ToString(room.GetMaster()) + "], mas nao tem nenhum info para trocar do buffer do cliente.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        8, 0));
                }

                for (var i = 0; i < num_info; ++i)
                {
                    var type = (ROOM_INFO_CHANGE)_packet.ReadByte();

                    switch (type)
                    {
                        case ROOM_INFO_CHANGE.NAME:
                            {
                                var title = _packet.ReadString();

                                if ((room.GetTipo() == ROOM_INFO_TYPE.PRACTICE || room.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE) && title.CompareTo("Single Player Practice Mode") != 0)
                                    room.SetNome("Single Player Practice Mode");
                                else
                                    room.SetNome(title);
                            }
                            break;
                        case ROOM_INFO_CHANGE.SENHA:
                            {
                                var pwd = _packet.ReadString();

                                if (!string.IsNullOrEmpty(pwd) && pwd.Length > 8 && (room.GetTipo() == ROOM_INFO_TYPE.PRACTICE || room.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE))
                                    ThrowHackException(_session, "tamanho da str da senha na sala inválida: " + room.GetTipo());

                                room.SetSenha(pwd);
                            }
                            break;
                        case ROOM_INFO_CHANGE.TIPO:
                            {
                                var T8 = _packet.ReadByte();
                                if (Enum.IsDefined(typeof(ROOM_INFO_TYPE), T8))
                                {
                                    room.SetType(T8);
                                }
                                else
                                    ThrowHackException(_session, "falha ao setar o tipo: " + room.GetTipo());
                            }
                            break;
                        case ROOM_INFO_CHANGE.COURSE:
                            {
                                var T8 = _packet.ReadByte();
                                if (Enum.IsDefined(typeof(ROOM_INFO_COURSE), T8))
                                {
                                    room.SetCourse(T8);
                                }
                                else
                                    ThrowHackException(_session, "falha ao setar o course: " + room.GetTipo());
                            }
                            break;
                        case ROOM_INFO_CHANGE.QNTD_HOLE:
                            room.SetQntdHole(_packet.ReadByte());
                            break;
                        case ROOM_INFO_CHANGE.MODO:
                            {
                                var T8 = _packet.ReadByte();
                                if (Enum.IsDefined(typeof(ROOM_INFO_MODO), T8))
                                {
                                    room.SetModo(T8);
                                }
                                else
                                    ThrowHackException(_session, "falha ao setar o Modo: " + room.GetTipo());
                            }
                            break;
                        case ROOM_INFO_CHANGE.TEMPO_VS:
                            {
                                var timevs = (uint)_packet.ReadUInt16();
                                if (timevs > 0)
                                    room.SetStrokeTime(timevs * 1000);
                                else
                                    ThrowHackException(_session, "falha ao setar o tempo vs: " + room.GetTipo());
                            }
                            break;
                        case ROOM_INFO_CHANGE.MAX_PLAYER:
                            {
                                var T8 = _packet.ReadByte();
                                if (!(T8 <= room.Players.Count))
                                    room.SetMaxUsers(T8);
                                else
                                    ThrowHackException(_session, "falha ao setar o numero de maximo de players: " + room.GetTipo());
                            }
                            break;
                        case ROOM_INFO_CHANGE.TEMPO_30S:
                            {
                                var time30s = (uint)_packet.ReadByte();
                                if (time30s > 0)
                                    room.SetTime30S(time30s * 60000);
                                else
                                    ThrowHackException(_session, "falha ao setar o tempo minutos: " + room.GetTipo());
                            }
                            break;
                        case ROOM_INFO_CHANGE.STATE_FLAG:
                            room.SetStateAFK(_packet.ReadByte());
                            break;
                        case ROOM_INFO_CHANGE.GALLERY_LIMIT:
                            room.SetGalleryLimit(_packet.ReadByte()); 
                            break;
                        case ROOM_INFO_CHANGE.HOLE_REPEAT:
                            room.SetHoleRepeted(_packet.ReadByte());
                            break;
                        case ROOM_INFO_CHANGE.FIXED_HOLE:
                            room.SetFixedHole(_packet.ReadUInt32());
                            break;
                        case ROOM_INFO_CHANGE.ARTEFATO:
                            room.SetArtefato(_packet.ReadUInt32());
                            break;
                        case ROOM_INFO_CHANGE.NATURAL:
                            {
                                var value = _packet.ReadUInt32();
                                var natural = new SpecialModeFlag(value);

                                if (!natural.natural && GameServer.getInstance().getInfo().propriedade.natural)
                                {
                                    natural.natural = true;
                                }
                                room.SetNatural(natural.ulNaturalAndShortGame);
                                break;
                            }
                        default:
                            throw new exception("[Error] PLAYER[UID=" + _session.UserInfo.uid + "] tentou trocar info da sala[NUMERO=" + room.GetRoomId() + ", MASTER=" + Convert.ToString(room.GetMaster()) + "], mas info change é desconhecido.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                                9, 0));
                    }
                }

                HandleChangeRoom(_session, room?.GetInfo(), _channel?.getInfo());

                room.SendHeadRoom();
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_CHANGE_INFO_ROOM][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                if (ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) != STDA_ERROR_TYPE.ROOM)
                {
                    throw;
                }
            }
        }

        #region HANDLE CHANGE ROOM - Validations for each field change, based on room type and channel info. If any validation fails, a hack exception is thrown, marking the player as a cheater.
        /// <summary>
        /// so vai ser permitido, se passar pelas verificacoes.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ri"></param>
        /// <param name="_ChannelInfo"></param>
        private void HandleChangeRoom(Player session, RoomInfo ri, ChannelInfo? _ChannelInfo)
        {
            try
            {
                if (session == null || !session.getState())
                    ThrowHackException(session, "Sessão inexistente ou desconectada");

                if (_ChannelInfo == null)
                    ThrowHackException(session, "Informacões do canal inexistente");

                if (ri == null)
                    ThrowHackException(session, "Informacões da sala inexistente"); 

                ValidateRoomName(session, ri);
                ValidateRoomPass(session, ri);
                ValidateRoomCreate(session, ri);
                ValidateMaxPlayers(session, ri);
                ValidateRoomTime(session, ri, _ChannelInfo);
                ValidateHoleCount(session, ri);
                ValidateForbiddenModes(session, ri);

                switch (ri.GetTipo())
                {
                    case ROOM_INFO_TYPE.STROKE:
                        ValidateStrokeSpecific(session, ri);
                        break;
                    case ROOM_INFO_TYPE.PANG_BATTLE:
                        ValidatePangBattleSpecific(session, ri);
                        break;
                    case ROOM_INFO_TYPE.MATCH: // se MATCH corresponde ao VS/Approach no seu enum
                    case ROOM_INFO_TYPE.APPROCH:
                        ValidateVsApproach(session, ri, _ChannelInfo);
                        break;
                    case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                        ValidateShuffleSpecific(session, ri);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                session.SetReason(PangyaAPI.Network.Flags.CloseReason.Cheating);//marcar como cheat.
                throw;
            }
        }

        private void ValidateRoomTime(Player session, RoomInfo ri, ChannelInfo m_ci)
        {
            switch (ri.GetTipo())
            {
                case ROOM_INFO_TYPE.STROKE:
                    if (ri.qntd_hole == 3 || ri.qntd_hole == 6 || ri.qntd_hole == 9 || ri.qntd_hole == 18)
                    {
                        ValidateTimeVs(session, ri, 40, 60, 120, 300);
                    }
                    else
                        ThrowHackException(session, $"time_vs inválido: {ri.time_vs}");
                    break;

                case ROOM_INFO_TYPE.MATCH:
                case ROOM_INFO_TYPE.PANG_BATTLE:
                    if (ri.qntd_hole == 6 || ri.qntd_hole == 9 || ri.qntd_hole == 18)
                    {
                        ValidateTimeVs(session, ri, 30, 40, 60, 120, 300);
                    }
                    else
                        ThrowHackException(session, $"time_vs inválido: {ri.time_vs}");
                    break;
                case ROOM_INFO_TYPE.PRACTICE:
                case ROOM_INFO_TYPE.TOURNEY:
                    // Tournament: pode ter short_game / natural branches; time_30s used (ms)
                    if (ri.special_flag_mod != null)
                    {
                        if (ri.special_flag_mod.short_game)
                        {
                            if (ri.qntd_hole == 9 || ri.qntd_hole == 18)
                                ValidateTime30s(session, ri, 15, 30, 20, 25, 35);
                            else
                                ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");
                        }
                        else if (ri.special_flag_mod.natural)
                        {
                            if (ri.qntd_hole == 9)
                                ValidateTime30s(session, ri, 15, 30, 20, 25, 35);
                            else if (ri.qntd_hole == 18)
                                ValidateTime30s(session, ri, 15, 30, 20, 25, 35);
                            else
                                ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");
                        }
                    }
                    else
                    {
                        if (ri.qntd_hole == 9)
                            ValidateTime30s(session, ri, 15, 20, 25, 30);
                        else if (ri.qntd_hole == 18)
                            ValidateTime30s(session, ri, 35, 40, 45, 50, 55);
                        else
                            ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");
                    }
                    break;

                case ROOM_INFO_TYPE.GUILD_BATTLE:
                    if (ri.qntd_hole == 9)
                        ValidateTime30s(session, ri, 15, 20, 25, 30);
                    else if (ri.qntd_hole == 18)
                        ValidateTime30s(session, ri, 35, 40, 45, 50, 55);
                    else
                        ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");
                    break;
                case ROOM_INFO_TYPE.APPROCH:
                    if (ri.qntd_hole == 3 || ri.qntd_hole == 6 || ri.qntd_hole == 9)
                        ValidateTime30s(session, ri, 40);
                    else
                        ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 1000}");
                    break;

                case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                    if (ri.qntd_hole == 18)
                        ValidateTime30s(session, ri, 40);
                    else
                        ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");
                    break;

                default:
                    break;
            }
        }

        // --------- Stroke specific checks (shotTime, Modo for 18H, holes set) ----------
        private void ValidateStrokeSpecific(Player session, RoomInfo ri)
        {
            // hole count already validado em ValidateHoleCount; validar shotTime (time_vs) em segundos permitidos
            uint[] allowedShotSeconds = [40, 60, 120, 300];
            if (!allowedShotSeconds.Contains(ri.time_vs / 1000))
                ThrowHackException(session, "ShotTime inválido (Stroke)");

            // Se 18 holes então Modo deve ser 0 ou 3
            if (ri.qntd_hole == 18)
            {
                if (ri.modo != 0 && ri.modo != 3)
                    ThrowHackException(session, "Modo inválido no Stroke 18H");
            }
        }

        // --------- Pang Battle specific ----------
        private void ValidatePangBattleSpecific(Player session, RoomInfo ri)
        {
            // Modo valid
            if (ri.modo != 0 && ri.modo != 3)
                ThrowHackException(session, "Modo inválido no Pang Battle");

            // shotTime valid (seconds)
            uint[] allowedShotSeconds = [30, 40, 60, 120, 300];
            if (!allowedShotSeconds.Contains(ri.time_vs / 1000))
                ThrowHackException(session, "ShotTime inválido no Pang Battle");
        }

        // --------- VS / APPROACH (game type 4 / 5) ----------
        private void ValidateVsApproach(Player session, RoomInfo ri, ChannelInfo m_ci)
        {
            if (ri.GetTipo() == ROOM_INFO_TYPE.MATCH)
            {
                // gameTimeLimit checks (valores em milissegundos como no C++)
                if (ri.qntd_hole == 9)
                {
                    uint[] allowed = [900000, 1200000, 1500000, 1800000];
                    if (!allowed.Contains(ri.time_vs))
                        ThrowHackException(session, "gameTimeLimit inválido para 9H");
                }
                else if (ri.qntd_hole == 18)
                {
                    uint[] allowed = [1800000, 2100000, 2400000, 2700000, 3000000];
                    if (!allowed.Contains(ri.time_vs))
                        ThrowHackException(session, "gameTimeLimit inválido para 18H");

                    if (ri.modo != 0 && ri.modo != 3)//nao tenho ideia do que seja 'Modo', deve ser o 'mode/modo'
                        ThrowHackException(session, "Modo inválido em 18H");
                }
                else if (ri.qntd_hole == 6)
                {
                    uint[] allowed = [1800000, 2100000, 2400000, 2700000, 40000];
                    if (!allowed.Contains(ri.time_vs))
                        ThrowHackException(session, "gameTimeLimit inválido para 6H");

                    if (ri.modo != 0 && ri.modo != 3)//nao tenho ideia do que seja 'Modo', deve ser o 'mode/modo'
                        ThrowHackException(session, "Modo inválido em 6");
                }

                else
                    ThrowHackException(session, "HoleNum inválido para Match");

                // UserLimit válido? (4,10,20,30) — GMs podem usar 100 ou 200
                int[] allowedPlayers = [4, 10, 20, 30];
                if (!allowedPlayers.Contains(ri.max_player) && !session.UserInfo.UserCapabilities.game_master)
                    ThrowHackException(session, "UserLimit inválido no Match");
            }
            else
            {
                // gameTimeLimit checks (valores em milissegundos como no C++)
                if (ri.qntd_hole == 3 || ri.qntd_hole == 6 || ri.qntd_hole == 9)
                {
                    uint[] allowed = [40000];
                    if (!allowed.Contains(ri.time_30s))
                        ThrowHackException(session, "gameTimeLimit inválido para 9H");
                }
                else
                    ThrowHackException(session, "HoleNum inválido para Approach");

                // UserLimit válido? (4,20,30) — GMs podem usar 100 ou 200
                int[] allowedPlayers = [6, 20, 30];
                if (!allowedPlayers.Contains(ri.max_player) && !session.UserInfo.UserCapabilities.game_master)
                    ThrowHackException(session, "UserLimit inválido Approach");
            }

            // Canal normal não permite Modo aleatório (random) — apenas Modo == 3 é permitido para "random"
            if (m_ci != null && m_ci.type.all && ri.modo != 3)
                ThrowHackException(session, "Random Modo proibido no canal normal");
        }

        // --------- Shuffle (tipo 6) ----------
        private void ValidateShuffleSpecific(Player session, RoomInfo ri)
        {
            int[] allowedHoles = [18];
            if (!allowedHoles.Contains(ri.qntd_hole))
                ThrowHackException(session, "HoleNum inválido no Shuffle");

            int[] allowedPlayers = [30];
            if (!allowedPlayers.Contains(ri.max_player))
                ThrowHackException(session, "UserLimit inválido no Shuffle");

            uint[] allowedTime = [2400000 / 60000];
            if (!allowedTime.Contains(ri.time_30s / 60000))
                ThrowHackException(session, "time_30s inválido no Shuffle");

            if (ri.course != ROOM_INFO_COURSE.RANDOM)
                ThrowHackException(session, "Course/Map inválido no Shuffle");

            if (ri.modo != 0 && ri.modo != 5)
                ThrowHackException(session, "Modo inválido no Shuffle");
        }

        // --------- ValidateRoomName ----------
        private void ValidateRoomName(Player session, RoomInfo ri)
        {
            bool _check = true;
            switch (ri.GetTipo())
            {
                case ROOM_INFO_TYPE.STROKE:
                case ROOM_INFO_TYPE.MATCH:
                case ROOM_INFO_TYPE.TOURNEY:
                case ROOM_INFO_TYPE.TOURNEY_TEAM:
                case ROOM_INFO_TYPE.GUILD_BATTLE:
                case ROOM_INFO_TYPE.APPROCH:
                case ROOM_INFO_TYPE.PANG_BATTLE:
                case ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE:
                case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                case ROOM_INFO_TYPE.LOUNGE:
                    if (string.IsNullOrEmpty(ri.name))
                        _check = false;
                    break;
                case ROOM_INFO_TYPE.PRACTICE:
                    if (!string.IsNullOrEmpty(ri.name) && ri.name.CompareTo("Single Player Practice Mode") != 0)
                        _check = false;
                    break;
                default:
                    _check = false;
                    break;
            }

            if (!_check)
                ThrowHackException(session, "Nome da sala inválido: " + ri.GetTipo());
        }

        // --------- ValidateRoomPass ----------
        private void ValidateRoomPass(Player session, RoomInfo ri)
        {
            if (ri.GetTipo() == ROOM_INFO_TYPE.PRACTICE || ri.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE)
            {
                if (!string.IsNullOrEmpty(ri.senha) && ri.senha.Length < 8 && !ri.senha.Contains("MDA"))
                    ThrowHackException(session, "tamanho da str da senha na sala inválida: " + ri.GetTipo());
            }
            else
            {
                if (!string.IsNullOrEmpty(ri.senha) && ri.senha.Length > 14)
                    ThrowHackException(session, "tamanho da str da senha na sala inválida: " + ri.GetTipo());
            }
        }

        private void ValidateRoomCreate(Player session, RoomInfo ri)
        {
            bool _check;
            switch (ri.GetTipo())
            {
                case ROOM_INFO_TYPE.STROKE:
                case ROOM_INFO_TYPE.MATCH:
                case ROOM_INFO_TYPE.TOURNEY:
                case ROOM_INFO_TYPE.TOURNEY_TEAM:
                case ROOM_INFO_TYPE.GUILD_BATTLE:
                case ROOM_INFO_TYPE.APPROCH:
                case ROOM_INFO_TYPE.PANG_BATTLE:
                case ROOM_INFO_TYPE.GRAND_PRIX:
                case ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE:
                case ROOM_INFO_TYPE.PRACTICE:
                case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                case ROOM_INFO_TYPE.LOUNGE:
                    _check = true;
                    break;
                default:
                    _check = false;
                    break;
            }

            if (!_check)
                ThrowHackException(session, "Tipo de jogo inválido: " + ri.GetTipo());
        }

        private void ValidateMaxPlayers(Player session, RoomInfo ri)
        {
            int[] allowedPlayers;

            switch (ri.GetTipo())
            {
                case ROOM_INFO_TYPE.STROKE:
                    allowedPlayers = [2, 3, 4];
                    break;
                case ROOM_INFO_TYPE.MATCH:
                    allowedPlayers = [2, 4];
                    break;
                case ROOM_INFO_TYPE.TOURNEY:
                case ROOM_INFO_TYPE.TOURNEY_TEAM:
                case ROOM_INFO_TYPE.GUILD_BATTLE:
                    allowedPlayers = [10, 20, 30];
                    break;
                case ROOM_INFO_TYPE.APPROCH:
                    allowedPlayers = [6, 20, 30];
                    break;
                case ROOM_INFO_TYPE.PANG_BATTLE:
                    allowedPlayers = [2, 4];
                    break;
                case ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE:
                case ROOM_INFO_TYPE.GRAND_ZODIAC_ADV:
                case ROOM_INFO_TYPE.GRAND_ZODIAC_INT:
                case ROOM_INFO_TYPE.PRACTICE:
                    allowedPlayers = [1];
                    break;
                case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                    allowedPlayers = [30];
                    break;
                case ROOM_INFO_TYPE.LOUNGE:
                    allowedPlayers = [10, 20, 30];
                    break;
                default:
                    allowedPlayers = Array.Empty<int>();
                    break;
            }

            if (allowedPlayers.Length > 0 && Array.IndexOf(allowedPlayers, ri.max_player) == -1)
                ThrowHackException(session, "max_player inválido: " + ri.max_player);
        }

        private void ValidateHoleCount(Player session, RoomInfo ri)
        {
            int[] allowedHoles = Array.Empty<int>();
            switch (ri.GetTipo())
            {
                case ROOM_INFO_TYPE.STROKE:
                    allowedHoles = [3, 6, 9, 18];
                    break;
                case ROOM_INFO_TYPE.MATCH:
                    allowedHoles = [6, 9, 18];
                    break;
                case ROOM_INFO_TYPE.TOURNEY:
                case ROOM_INFO_TYPE.TOURNEY_TEAM:
                case ROOM_INFO_TYPE.GUILD_BATTLE:
                    allowedHoles = [9, 18];
                    break;
                case ROOM_INFO_TYPE.APPROCH:
                    allowedHoles = [3, 6, 9];
                    break;
                case ROOM_INFO_TYPE.PANG_BATTLE:
                    allowedHoles = [6, 9, 18];
                    break;
                case ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE:
                    allowedHoles = [18];
                    break;
                case ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE:
                case ROOM_INFO_TYPE.GRAND_ZODIAC_ADV:
                case ROOM_INFO_TYPE.GRAND_ZODIAC_INT:
                    allowedHoles = [1];
                    break;
                case ROOM_INFO_TYPE.PRACTICE:
                    allowedHoles = [1, 9, 18];
                    break;
                case ROOM_INFO_TYPE.LOUNGE://limite e 18, eu acho
                    allowedHoles = [1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18];
                    break;
            }

            if (allowedHoles.Length > 0 && Array.IndexOf(allowedHoles, ri.qntd_hole) == -1)
                ThrowHackException(session, "qntd_hole inválido: " + ri.qntd_hole);
        }

        private void ValidateForbiddenModes(Player session, RoomInfo ri)
        {
            if (ri.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_INT || ri.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_ADV)
            {
                ThrowHackException(session, "tentou criar modo proibido");
            }
        }

        private void ValidateTime30s(Player session, RoomInfo ri, params uint[] allowedMinutes)
        {
            if (ri.GetTipo() == ROOM_INFO_TYPE.APPROCH)//unico com time minute em segundos
            {
                if (ri.time_30s < (40 * 1000))
                    ThrowHackException(session, $"time_30s inválido para o approach: {ri.time_30s}");

                if (!allowedMinutes.Contains(ri.time_30s / 1000))
                    ThrowHackException(session, $"time_30s inválido para o approach: {ri.time_30s / 1000}");
            }
            else
            {
                if (ri.time_30s < (15 * 60000))
                    ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");

                if (!allowedMinutes.Contains(ri.time_30s / 60000))
                    ThrowHackException(session, $"time_30s inválido: {ri.time_30s / 60000}");
            }
        }

        private void ValidateTimeVs(Player session, RoomInfo ri, params uint[] allowedSeconds)
        {
            if ((ri.GetTipo() == ROOM_INFO_TYPE.STROKE || ri.GetTipo() == ROOM_INFO_TYPE.MATCH)
               && ri.time_vs < (40 * 1000))
            {
                ThrowHackException(session, $"time_vs inválido: {ri.time_vs}");
            }

            if (!allowedSeconds.Contains(ri.time_vs / 1000))
            {
                ThrowHackException(session, $"time_vs inválido: {ri.time_vs}");
            }
        }

        // --------- ThrowHackException ----------
        public void ThrowHackException(Player session, string motivo)
        {
            var ri = session.GetRoom();

            string msg = $"[Room::ThrowHackException] [Error] PLAYER [UID={session.UserInfo.uid}] " +
                         $"Channel[ID={ri.GetChannelId()}] tentou criar sala [Nome={ri.getName()}, PWD={ri.getPass()}, TIPO={ri.GetTipo()}], {motivo}. Hacker ou Bug";

            throw new exception(msg, ExceptionError.STDA_MAKE_ERROR_TYPE(
                STDA_ERROR_TYPE.ROOM, 10, 0x770001));
        }
        #endregion
    }
}