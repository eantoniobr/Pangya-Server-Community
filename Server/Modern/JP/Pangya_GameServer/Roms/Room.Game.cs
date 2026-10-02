using Pangya_GameServer.Engine;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Roms.GameBase.Helpers;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;

using PangyaAPI.Network;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System.Numerics;

using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Roms
{
    public partial class Room
    {
        public void EnterToRoom(Player session)
        {

            if (IsFull())
            {
                throw new exception("[room::enter] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na a sala[NUMERO=" + RoomInfo.numero + "], mas a sala ja esta cheia.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2, 0));
            }

            if (session.UserInfo.Member.sala_numero != -1)
            {
                throw new exception("[room::enter] [Error] PLAYER[UID=" + session.UserInfo.uid + "] sala[NUMERO=" + RoomInfo.numero + "], ja esta em outra sala[NUMERO=" + Convert.ToString(session.UserInfo.Member.sala_numero) + "], nao pode entrar em outra. Hacker ou Bug.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    120, 0));
            }

            if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.GUILD_BATTLE
                && RoomInfo.guilds.guild_1_uid != 0
                && RoomInfo.guilds.guild_2_uid != 0
                && RoomInfo.guilds.guild_1_uid != session.UserInfo.Guild.uid
                && RoomInfo.guilds.guild_2_uid != session.UserInfo.Guild.uid)
            {
                throw new exception("[room::enter] [Error] PLAYER[UID=" + session.UserInfo.uid + "] sala[NUMERO=" + RoomInfo.numero + "], ja tem duas guild e o Player que quer entrar nao é de nenhum delas. Hacker ou Bug.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    11000, 0));
            }

            try
            {
                AddPlayer(session, false);
                 
                RoomInfo.num_player = (byte)Players.Count;

                // Update Trofel
                if (RoomInfo.trofel > 0)
                {
                    UpdateTrofel();
                }

                // Acabou de criar a sala
                if (RoomInfo.master == session.UserInfo.uid && RoomInfo.tipo != (byte)ROOM_INFO_TYPE.GRAND_PRIX)
                {
                    // Update Trofel
                    if (session.UserInfo.UserCapabilities.game_master)
                    { // GM

                        if ((RoomInfo.max_player > 30 && RoomInfo.GetTipo() == ROOM_INFO_TYPE.TOURNEY) || (RoomInfo.tipo >= (byte)ROOM_INFO_TYPE.GRAND_ZODIAC_INT && RoomInfo.tipo <= (byte)ROOM_INFO_TYPE.GRAND_ZODIAC_ADV))
                        {

                            RoomInfo.flag_gm = 1;

                            RoomInfo.state_flag = 0x100;

                            RoomInfo.trofel = TROFEL_GM_EVENT_TYPEID;

                        }
                        else if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.TOURNEY || RoomInfo.tipo >= (byte)ROOM_INFO_TYPE.GRAND_ZODIAC_INT)
                        {
                            UpdateTrofel();
                        }

                    }
                    else if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.TOURNEY || RoomInfo.tipo >= (byte)ROOM_INFO_TYPE.GRAND_ZODIAC_INT)
                    {
                        UpdateTrofel();
                    }

                }
                else if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.GRAND_PRIX)
                {
                    UpdateTrofel();
                }

                // Update Master
                // Só trocar o master da sala se não tiver nenhum jogo inicializado
                if (CurrentGame == null
                    && Players.Count > 0
                    && session.UserInfo.UserCapabilities.game_master
                    && RoomInfo.state_flag != 0x100
                    && RoomInfo.tipo != (byte)ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE
                    && RoomInfo.tipo != (byte)ROOM_INFO_TYPE.GRAND_PRIX)
                {
                    UpdateMaster(session);
                }

                // Add o Player ao jogo
                if (CurrentGame != null)
                {
                    CurrentGame.AddPlayer(session);

                    if (RoomInfo.trofel > 0)
                    {
                        UpdateTrofel();
                    }
                }

                try
                {
                    // Make Info Room Player
                    MakePlayerInfo(session);

                }
                catch (exception e)
                {
                    _smp.message_pool.getInstance().push(new message("[room::enter][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.GUILD_BATTLE)
                {
                    UpdateGuild(session);
                } 
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[room::enter][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }

        private void UpdateTrofel()
        {

            if (Players.Count() > 0 && (RoomInfo.trofel != TROFEL_GM_EVENT_TYPEID || RoomInfo.max_player <= 30) && (RoomInfo.time_30s > 0 && RoomInfo.tipo != (byte)ROOM_INFO_TYPE.GUILD_BATTLE)
                && RoomInfo.master != -2 || (RoomInfo.GetTipo() == ROOM_INFO_TYPE.GRAND_PRIX && RoomInfo.grand_prix.dados_typeid > 0))
            {

                if (CurrentGame != null)
                    CurrentGame.RequestUpdateTrofel();
                else
                {

                    uint soma = 0;

                    foreach (var el in Players)
                    {
                        if (el != null)
                            soma += (uint)((el.UserInfo.level > 60) ? 60 : (el.UserInfo.level > 0 ? el.UserInfo.level - 1 : 0));

                    }
                    var new_trofel = STDA_MAKE_TROFEL(soma, Players.Count());

                    if (new_trofel > 0 && new_trofel != RoomInfo.trofel)
                    {

                        // Check se o trofeu anterior era o GM e se o novo não é mais, aí tira a type de GM da sala
                        if (RoomInfo.trofel == TROFEL_GM_EVENT_TYPEID && new_trofel != TROFEL_GM_EVENT_TYPEID)
                            RoomInfo.flag_gm = 0;

                        if (RoomInfo.trofel > 0)
                        {

                            RoomInfo.trofel = new_trofel;

                            var p = new Packet(0x97);

                            p.WriteUInt32(RoomInfo.trofel);

                            SendBroadCast(p);

                        }
                        else
                            RoomInfo.trofel = new_trofel;
                    }
                }
            }
        }
         
        public int Leave(Player session, int option)
        { 
            lock (_cs)
            {
                try
                {
                    if (!Players.Contains(session))//evita aquele bugs de sair da sala e o player não estar na sala, ai fica tentando sair e da erro, ou seja, se não tiver na sala, nem tenta sair
                    {
                        if (PlayersInfo.ContainsKey(session))
                            PlayersInfo.Remove(session);


                        _tradeShop.DestroyShop(session);

                        session.SetRoom(null);//sai 
                                               //aqui eo contrario.
                        bool isRoomEmpty = Players.Count == 0 &&(RoomInfo.master != -2 || (IsDropRoom() && (RoomInfo.GetTipo() != ROOM_INFO_TYPE.GRAND_ZODIAC_INT || RoomInfo.GetTipo() != ROOM_INFO_TYPE.GRAND_ZODIAC_ADV)));

                        return isRoomEmpty ? 1 : 0;//deve ser o contrario, significa que vamos destruir a sala...
                    }

                    if (option != 0 && option != 1 && option != 0x800 && option != 10)
                    {
                        AddPlayerKicked(session.UserInfo.uid);
                    }

                    // Verifica se ele está em um jogo e tira ele
                    try
                    {
                        if (CurrentGame != null)
                        {
                            if (CurrentGame.DeletePlayer(session, option) && CurrentGame.FinishGame(session, 2))
                            {
                                FinishGame();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _smp.message_pool.getInstance().push(new message("[room::leave][ErrorSystem] " + e.Message, type_msg.CL_FILE_LOG_AND_CONSOLE));
                    }

                    RemovePlayer(session); 

                    if ((RoomInfo.num_player - 1) > 0 || Players.Count == 0)
                    {
                        --RoomInfo.num_player;
                    }

                    // Sai do Team se for Match
                    if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.MATCH)
                    {
                        if (Teams.Count < 2)
                        {
                            throw new Exception($"[room::leave][Error] player[UID={session.UserInfo.uid}] tentou sair da sala[NUMERO={RoomInfo.numero}], mas a sala nao tem 2 times.");
                        }

                        var pPri = GetPlayerInfo(session);
                        if (pPri == null) throw new Exception("[room::leave][Error] player info não encontrado.");

                        Teams[pPri.state_flag.team].deletePlayer(session, option);
                    }
                    else if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.GUILD_BATTLE)
                    {
                        var pPri = GetPlayerInfo(session);
                        if (pPri == null) throw new Exception("[room::leave][Error] player info não encontrado.");

                        var guild = GuildManager.findGuildByPlayer(session);
                        if (guild == null) throw new Exception("[room::leave][Error] player não está em nenhuma guild da sala.");

                        guild.deletePlayer(session);
                        Teams[pPri.state_flag.team].deletePlayer(session, option);

                        // Limpa flags
                        pPri.state_flag.team = 0;

                        if (guild.numPlayers() == 0)
                        {
                            if (guild.getTeam() == Guild.eTEAM.RED)
                            {
                                RoomInfo.guilds.guild_1_uid = 0;
                                RoomInfo.guilds.guild_1_index_mark = 0;
                                RoomInfo.guilds.guild_1_mark = ""; 
                            }
                            else
                            {
                                RoomInfo.guilds.guild_2_uid = 0;
                                RoomInfo.guilds.guild_2_index_mark = 0;
                                RoomInfo.guilds.guild_2_mark = ""; 
                            }
                            GuildManager.deleteGuild(guild);
                        }
                    }

                    // Remove do dicionário/mapa de info
                    PlayersInfo.Remove(session);

                    // Nota: DestroyShop já é chamado no bloco de saída antecipada acima.
                    // Aqui não repete para evitar dupla destruição.

                    UpdatePosition();

                    UpdateTrofel();

                    // Lógica de pacote de Kick
                    if (option == 0x800 || (option != 0 && option != 1 && option != 3))
                    {
                        int opt_kick = 0x800;
                        switch (option)
                        {
                            case 1: opt_kick = 4; break;
                            case 2: opt_kick = 2; break;
                            default: opt_kick = option; break;
                        }

                        var p = new Packet(0x7E);
                        p.WriteInt32(opt_kick);
                        session.Send(p); 
                    }

                    if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.LOUNGE)
                    {
                        session.UserInfo.PostureRoom = 0;
                        session.UserInfo.LoungeState = 0;
                    }

                    if (Players.Count > 0)
                    {
                        SendHeadRoom();
                        SendPlayerInfo(session, 2);
                    }

                    // Verificação de Master/GM para deletar a sala
                    if ((CurrentGame == null && RoomInfo.GetTipo() == ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE && session.UserInfo.uid == RoomInfo.master)
                        || (session.UserInfo.UserCapabilities.game_master && RoomInfo.master == session.UserInfo.uid && RoomInfo.GetTipo() != ROOM_INFO_TYPE.LOUNGE && RoomInfo.trofel == TROFEL_GM_EVENT_TYPEID))
                    {
                        return 0x801; // deleta todos da sala
                    }
                    else if (CurrentGame == null)
                    {
                        UpdateMaster(null);
                    }
                }
                catch (Exception e)
                {
                    _smp.message_pool.getInstance().push(new message("[room::leave][ErrorSystem] " + e.Message, type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                // Retorno final baseado na lógica original

                bool condition = Players.Count > 0 || (RoomInfo.master == -2 && (!IsDropRoom() || (RoomInfo.GetTipo() >= ROOM_INFO_TYPE.GRAND_ZODIAC_INT && RoomInfo.GetTipo() <= ROOM_INFO_TYPE.GRAND_ZODIAC_ADV)));
                return condition ? 0 : 1;
            }
        }

        public void FinishGame()
        {

            try
            {
                if (CurrentGame != null)
                {

                    var toAdd = new List<(Player player, PlayerRoomInfo info)>();
                    // Zera Player Flags
                    var player_info = PlayersInfo.ToList();
                    foreach (var el in player_info)
                    {
                        // Update Place Player
                        if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.PRACTICE || RoomInfo.GetTipo() == ROOM_INFO_TYPE.GRAND_ZODIAC_PRACTICE)
                        {
                            el.Value.place.ulPlace = 2;
                        }
                        else
                        {
                            el.Value.place.ulPlace = 0;
                        }

                        el.Value.state_flag.away = 0;

                        // Aqui só zera quem não é Master da sala, o master deixa sempre ready
                        if (RoomInfo.master == el.Key.UserInfo.uid)
                        {
                            el.Value.state_flag.ready = 1;
                        }
                        else
                        {
                            el.Value.state_flag.ready = 0;
                        }

                        // Update Player info
                        UpdatePlayerInfo(el.Key);

                        // SLast update on room
                        SendPlayerInfo(el.Key, 3);
                    }

                    // Atualiza type da sala, só não atualiza se for GM evento ou GZ Event e SSC
                    if (!(RoomInfo.trofel == TROFEL_GM_EVENT_TYPEID || RoomInfo.GetTipo() == ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE || RoomInfo.master == -2))
                        RoomInfo.state = 1; //em espera

                    // Att Exp rate, e Pang rate, que criou a sala, att ele também quando começa o jogo

                    RoomInfo.rate_exp = (uint)GameServer.getInstance().getInfo().rate.exp;
                    RoomInfo.rate_pang = (uint)GameServer.getInstance().getInfo().rate.pang;
                    RoomInfo.angel_event = GameServer.getInstance().getInfo().rate.angel_event.IsTrue();


                    // Update Course of Hole
                    if (RoomInfo.GetMap() >= 0x7F) // Random Course With Course already draw
                        RoomInfo.course = ROOM_INFO_COURSE.UNK; // Random Course standard


                    // Update Master da sala
                    UpdateMaster(null);

                    if (RoomInfo.master == -2)
                        RoomInfo.master = -1; // pode deletar a sala quando sair todos


                    if (Players.Count > 0)
                    {
                        // Atualiza info da sala para quem está na sala 
                        SendUpdateRoom();
                    }

                    // limpa lista de Player kikados
                    ClearPlayersKicked();

                    // Verifica se o Bot Tourney está ativo, kika bot e limpa a type
                    if (BotTourney)
                    {

                        var pMaster = FindMaster();

                        if (pMaster != null)
                        {

                            try
                            {
                                // Kick Bot
                                // Atualiza os Player que estão na sala que o Bot sai por que ele é só visual
                                SendPlayerInfo(pMaster, 0);

                            }
                            catch (exception e)
                            {

                                _smp.message_pool.getInstance().push(new message("[room::finish_game::KickBotTourney][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                            }
                        }

                        BotTourney = false;
                    }
                    if (CurrentGame != null)
                    {
                        CurrentGame.GameStop(); // desliga o relógio
                    }

                    // Corrigido: CurrentGame pode ter sido anulado por outra thread entre
                    CurrentGame?.Dispose();
                    CurrentGame = null;
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }
         
        public void UpdateGuild(Player session)
        {
            if (session.UserInfo.Guild.uid == -1)
                throw new Exception($"[channel::UpdateGuild] [Error] PLAYER[UID={session.UserInfo.uid}] player nao esta em uma guild.");

            PlayerRoomInfo pri = GetPlayerInfo(session);

            if (pri == null)
                throw new Exception($"[channel::UpdateGuild] [Error] PLAYER[UID={session.UserInfo.uid}] nao tem o info do player na sala[NUMERO={RoomInfo.numero}]. Hacker ou Bug.");

            Guild guild = null;

            if (RoomInfo.guilds.guild_1_uid == 0 && RoomInfo.guilds.guild_2_uid != session.UserInfo.Guild.uid)
            {
                RoomInfo.guilds.guild_1_uid = session.UserInfo.Guild.uid;
                RoomInfo.guilds.guild_1_nome = session.UserInfo.Guild.name;
                RoomInfo.guilds.guild_1_mark = session.UserInfo.Guild.mark_emblem;
                RoomInfo.guilds.guild_1_index_mark = (ushort)session.UserInfo.Guild.index_mark_emblem;

                pri.state_flag.team = 0;
                guild = GuildManager.addGuild(Guild.eTEAM.RED, RoomInfo.guilds.guild_1_uid);
            }
            else if (RoomInfo.guilds.guild_1_uid == session.UserInfo.Guild.uid)
            {
                pri.state_flag.team = 0;
                guild = GuildManager.findGuildByTeam(Guild.eTEAM.RED);
            }
            else if (RoomInfo.guilds.guild_2_uid == 0)
            {
                RoomInfo.guilds.guild_2_uid = session.UserInfo.Guild.uid;
                RoomInfo.guilds.guild_2_nome = session.UserInfo.Guild.name;
                RoomInfo.guilds.guild_2_mark = session.UserInfo.Guild.mark_emblem;
                RoomInfo.guilds.guild_2_index_mark = (ushort)session.UserInfo.Guild.index_mark_emblem;

                pri.state_flag.team = 1;
                guild = GuildManager.addGuild(Guild.eTEAM.BLUE, RoomInfo.guilds.guild_2_uid);
            }
            else
            {
                pri.state_flag.team = 1;
                guild = GuildManager.findGuildByTeam(Guild.eTEAM.BLUE);
            }

            if (guild != null)
            {
                guild.addPlayer(session);
            }
            else
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[room::updateGuild][Warning] PLAYER[UID={session.UserInfo.uid}] tentou entrar em uma guild da sala[NUMERO={RoomInfo.numero}], mas nao conseguiu criar ou achar nenhum guild na sala. Bug.",
                   type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            Teams[pri.state_flag.team].addPlayer(session);
        }

        private void InitTeams()
        {

            // Limpa teans, se tiver teans inicilizados já
            ClearTeams();

            // Init Teans
            Teams.Add(new Team(0));
            Teams.Add(new Team(1));

            PlayerRoomInfo pPri = null;

            // Add Players All Seus Respectivos teans
            foreach (var el in Players)
            {

                if ((pPri = GetPlayerInfo(el)) == null)
                {
                    throw new exception("[room::init_teans] [Error] nao encontrou o info do PLAYER[UID=" + Convert.ToString(el.UserInfo.uid) + "] na sala. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1504, 0));
                }

                Teams[pPri.state_flag.team].addPlayer(el);
            }

        }

        public int LeaveAll(int option)
        {
            // Percorre de trás para frente
            for (int i = Players.Count - 1; i >= 0; i--)
            {
                var player = Players[i];
                if (player != null)
                {
                    try
                    {
                        Leave(player, option);
                    }
                    catch (exception e)
                    {

                        _smp.message_pool.getInstance().push(new message("[room::leaveAll] [Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                    }
                }
            }
            return 0;
        }

        public InviteChannelInfo AddInvited(uint uidHasInvite, Player session)
        {

            if (IsFull())
            {
                throw new exception("[room::addInvited] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na a sala[NUMERO=" + RoomInfo.numero + "], mas a sala ja esta cheia.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2, 0));
            }

            if (FindIndexSession(uidHasInvite) == (int)~0)
            {
                throw new exception("[room::addInvited] [Error] quem convidou[UID=" + Convert.ToString(uidHasInvite) + "] o PLAYER[UID=" + session.UserInfo.uid + "] para a sala nao esta na sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2010, 0));
            }

            var s = FindSessionByUid(session.UserInfo.uid);

            if (s != null)
            {
                throw new exception("[room::addInvited] [Error] PLAYER[UID=" + Convert.ToString(uidHasInvite) + "] tentou adicionar o convidado[UID=" + session.UserInfo.uid + "] a sala, mas ele ja esta na sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2001, 0));
            }
            AddPlayer(session, true);

            ++RoomInfo.num_player;

            PlayerRoomInfoEx pri = null;

            try
            {

                // Make Info Room Player Invited
                pri = MakePlayerInvitedInfo(session);

            }
            catch (exception e)
            {

                _smp.message_pool.getInstance().push(new message("[room::addInvited][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            if (pri == null)
            {

                // Pop_back
                Players.Remove(Players.Last());



                throw new exception("[[room::addInvited] [Error] PLAYER[UID=" + Convert.ToString(uidHasInvite) + "] tentou adicionar o convidado[UID=" + session.UserInfo.uid + "] a sala, nao conseguiu criar o Player Room Info Invited do Player. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2002, 0));
            }

            // Add Invite Channel Info
            InviteChannelInfo ici = new InviteChannelInfo
            {
                room_number = RoomInfo.numero,
                invite_uid = uidHasInvite,
                invited_uid = session.UserInfo.uid,
                time = new SystemTime(DateTime.Now)
            };

            Invites.Add(ici);
            // End Add Invite Channel Info

            // Update Char Invited ON ROOM
            var p = new Packet((ushort)0x48);

            p.WriteByte(1);
            p.WriteInt16(-1);

            p.WriteBytes(pri.ToArrayEx());

            p.WriteByte(0); // Final Packet
            SendBroadCast(p);
            return ici;
        }

        public InviteChannelInfo GetInvited(Player session)
        {
            return Invites.FirstOrDefault(el =>
            {
                return (el.room_number == RoomInfo.numero && el.invited_uid == session.UserInfo.uid);
            });
        }

        public InviteChannelInfo GetInvited(uint uid)
        {
            return Invites.FirstOrDefault(el => el.room_number == RoomInfo.numero && el.invited_uid == uid); ;
        }

        public InviteChannelInfo DeleteInvited(Player session)
        {

            var it = PlayersInfo.FirstOrDefault(c => c.Key.UserInfo.uid == session.UserInfo.uid);

            if (it.Key == null && GetInvited(session) == null)
                throw new exception("[room::DeleteInvited] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou deletar convidado,"
                    + " mas nao tem o info do convidado na sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM, 2003, 0));


            int index = FindIndexSession(session);

            if (index == -1 && GetInvited(session) == null)
            {
                throw new exception("[room::DeleteInvited] [Error] session[UID=" + session.UserInfo.uid + "] nao existe no vector de sessions da sala.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    5, 0));
            }
            
            RemovePlayer(session);

            --RoomInfo.num_player;

            PlayersInfo.Remove(session);

            // Update Position all Players
            UpdatePosition();

            // Delete Invite Channel Info
            InviteChannelInfo ici = new InviteChannelInfo();


            var itt = GetInvited(session);

            if (itt != null)
            {

                ici = itt;

                Invites.Remove(itt);

            }
            else
            {
                _smp.message_pool.getInstance().push(new message("[room::DeleteInvited][Warning] PLAYER[UID=" + session.UserInfo.uid + "] nao tem um convite.", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            // End Delete Invite Channel Info

            // Resposta Delete Convidado
            var p = new Packet((ushort)0x130);

            p.WriteUInt32(session.UserInfo.uid);
            SendBroadCast(p);

            _smp.message_pool.getInstance().push(new message("[room::DeleteInvited][Info] Deleteou um convite[Convidado=" + session.UserInfo.uid + "] na Sala[NUMERO=" + RoomInfo.numero + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));


            return ici;
        }

        public InviteChannelInfo _DeleteInvited(Player session)
        {


            // Delete Invite Channel Info
            InviteChannelInfo ici = new InviteChannelInfo();


            var itt = GetInvited(session);

            if (itt != null)
            {

                ici = itt;

                Invites.Remove(itt);

            }
            else
            {
                _smp.message_pool.getInstance().push(new message("[room::DeleteInvited][Warning] PLAYER[UID=" + session.UserInfo.uid + "] nao tem um convite.", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            // End Delete Invite Channel Info

            // Resposta Delete Convidado
            var p = new Packet((ushort)0x130);

            p.WriteUInt32(session.UserInfo.uid);
            SendBroadCast(p);

            _smp.message_pool.getInstance().push(new message("[room::DeleteInvited][Info] Deleteou um convite[Convidado=" + session.UserInfo.uid + "] na Sala[NUMERO=" + RoomInfo.numero + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));


            return ici;
        }

        public InviteChannelInfo DeleteInvited(uint uid)
        {
            if (uid == 0)
            {
                throw new exception("[room::DeleteInvited] [Error] uid is invalid(zero). Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2005, 0));
            }

            var it = PlayersInfo.FirstOrDefault(el => el.Value.convidado == 1 && el.Value.uid == uid);

            // Corrigido: era PlayersInfo.Last().Key — crashes em dicionário vazio e não é
            // um sentinel válido para "não encontrado". Verificação correta é it.Key == null.
            if (it.Key == null)
            {
                throw new exception("[room::DeleteInvited] [Error] PLAYER[UID=" + Convert.ToString(uid) + "] tentou deletar convidado, mas nao tem o info do convidado na sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    2003, 0));
            }

            int index = FindIndexSession(uid);

            // Corrigido: (int)~0 == -1, comparação redundante — simplificado para -1
            if (index == -1)
            {
                throw new exception("[room::DeleteInvited] [Error] session[UID=" + Convert.ToString(uid) + "] nao existe no vector de sessions da sala.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    5, 0));
            }

            Players.RemoveAt(index);

            --RoomInfo.num_player;

            PlayersInfo.Remove(it.Key);

            // Update Position all Players
            UpdatePosition();

            // Delete Invite Channel Info
            InviteChannelInfo ici = new InviteChannelInfo();

            var itt = Invites.FirstOrDefault(el => el.room_number == RoomInfo.numero && el.invited_uid == uid);


            if (itt != null)
            {

                ici = itt;

                Invites.Remove(itt);

            }
            else
            {
                _smp.message_pool.getInstance().push(new message("[room::DeleteInvited][Warning] PLAYER[UID=" + Convert.ToString(uid) + "] nao tem um convite.", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            // End Delete Invite Channel Info

            // Resposta Delete Convidado
            var p = new Packet((ushort)0x130);

            p.WriteUInt32(uid);
            SendBroadCast(p);

            _smp.message_pool.getInstance().push(new message("[room::DeleteInvited][Info] Deleteou um convite[Convidado=" + Convert.ToString(uid) + "] na Sala[NUMERO=" + RoomInfo.numero + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

            return ici;
        }


        private void CalcRainLounge()
        {

            // Só calcRainLounge se for lounge
            if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.LOUNGE)
            {

                WeatherChatRoom = 0; // Good Weather

                short rate_rain = GameServer.getInstance().getInfo().rate.chuva;

                LotterySystem loterry = new LotterySystem();

                uint rate_good_weather = (uint)((rate_rain <= 0) ? 1000 : ((rate_rain < 1000) ? 1000 - rate_rain : 1));

                loterry.Add(rate_good_weather, 0);
                loterry.Add(rate_good_weather, 0);
                loterry.Add(rate_good_weather, 0);
                loterry.Add((uint)rate_rain, 2);

                var lc = loterry.SpinRoleta();

                if (lc != null && Convert.ToInt32(lc.Value) > 0)
                {
                    WeatherChatRoom = (byte)Convert.ToInt32(lc.Value);
                }
            }
        }

        private void ClearTeams()
        {
            if (Teams.Any())
            {
                Teams.Clear();
            }
        }

        private void MakeBotVisual(Player session)
        {
            // Add Bot
            List<PlayerRoomInfoEx> v_element = new List<PlayerRoomInfoEx>();
            PlayerRoomInfoEx pri = new PlayerRoomInfoEx();

            try
            {
                Players.ForEach(el =>
                {
                    var tmppri = GetPlayerInfo(el);
                    if (tmppri != null)
                    {
                        v_element.Add(tmppri);
                    }
                });


                if (v_element.Count == 0)
                {
                    throw new exception("[room::MakeBot] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou criar Bot na sala[NUMERO=" + RoomInfo.numero + ", MASTER=" + Convert.ToString(RoomInfo.master) + "], mas nao nenhum Player na sala. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1, 5000));
                }

                // Inicializa os dados do Bot
                pri.uid = session.UserInfo.uid;
                pri.oid = session.ConnectionID;
                pri.state_flag.ready = 1;
                pri.position = 0;
                pri.char_typeid = 0x4000000;
                pri.title = 0x39800013; // Title Helper
                pri.nickname = "\\1Bot";
                pri.sDisplayID = "@NT_" + pri.nickname; 
                // Add o Bot a sala, só no visual
                v_element.Add(pri);

                // Packet
                var p = new Packet();

                if (RoomInfo.GetTipo() != ROOM_INFO_TYPE.STROKE)
                {
                    // Option 0, passa todos que estão na sala
                    if (Handle_PACKET_RESPONSE.pacote048(p, session, v_element, 0x100))
                        SendBroadCast(p);

                    // Option 1, passa só o Player que entrou na sala, nesse caso foi o Bot
                    if (Handle_PACKET_RESPONSE.pacote048(p, session, new List<PlayerRoomInfoEx> { pri }, 0x101))
                        SendBroadCast(p);
                } 
                // Criou Bot com sucesso
                BotTourney = true;
            }
            catch (exception)
            { 
                throw;
            }
        }


        public void MakeRoomBot(Player session)
        {
            var p = new Packet();

            try
            {
                if (IsRoomGM())
                {
                    // SLast Message
                    p.init_plain(0x40); // Msg to Chat of Player

                    p.WriteByte(7); // Notice

                    p.WriteString("@NOTICE");
                    p.WriteString("[ \\2Premium ] \\c0xff00ff00\\cNot Need add bot, auto start.");
                    session.Send(p);
                    return;
                }

                else
                {
                    // Bot Ticket TypeId

                    // Premium User Não precisa de ticket não
                    if (session.UserInfo.UserCapabilities.premium_user || session.UserInfo.UserCapabilities.game_master)
                    {


                        // Add Bot Tourney Visual para a sala
                        MakeBotVisual(session);

                        // SLast Message
                        p.init_plain(0x40); // Msg to Chat of Player

                        p.WriteByte(7); // Notice

                        p.WriteString("@SuperSS");
                        p.WriteString("[ \\2Premium ] \\c0xff00ff00\\cBot was created.");
                        session.Send(p);
                    }
                    else
                    {

                        // Verifica se ele tem o ticket para criar o Bot se não manda mensagem dizenho que ele não tem ticket para criar o bot
                        var pWi = session.Inventory.FindWarehouseItemByTypeid(TICKET_BOT_TYPEID) != null ? session.Inventory.FindWarehouseItemByTypeid(TICKET_BOT_TYPEID) : session.Inventory.FindWarehouseItemByTypeid(TICKET_BOT_TYPEID2);

                        if (pWi == null)
                        {

                            // Não tem ticket bot suficiente, manda mensagem
                            // SLast Message
                            p.init_plain(0x40); // Msg to Chat of Player

                            p.WriteByte(7); // Notice

                            p.WriteString("@SuperSS");
                            p.WriteString("\\c0xffff0000\\cYou do not have enough ticket to create the Bot.");
                            session.Send(p);
                        }
                        else
                        {

                            // Add Bot Tourney Visual para a sala
                            MakeBotVisual(session);

                            // SLast Message
                            p.init_plain(0x40); // Msg to Chat of Player

                            p.WriteByte(7); // Notice

                            p.WriteString("@SuperSS");
                            p.WriteString("[ \\2Premium ] \\c0xff00ff00\\cBot was created.");
                            session.Send(p);
                        }
                    }
                }
            }
            catch (exception e)
            {

                _smp.message_pool.getInstance().push(new message("[room::MakeBot][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                // SLast Message
                p.init_plain(0x40); // Msg to Chat of Player

                p.WriteByte(7); // Notice

                p.WriteString("@SuperSS");
                p.WriteString("\\c0xffff0000\\cError creating Bot.");
                session.Send(p);
            }
        }

        public void SendHeadRoom()
        {
            SendBroadCast(Handle_PACKET_RESPONSE.pacote04A(RoomInfo, -1/*valor constante*/));
        }

        public void SendPlayerInfo(Player session, int option)
        {

            option = !(RoomInfo.GetTipo() == ROOM_INFO_TYPE.STROKE ||
                           RoomInfo.GetTipo() == ROOM_INFO_TYPE.MATCH ||
                           RoomInfo.GetTipo() == ROOM_INFO_TYPE.LOUNGE ||
                           RoomInfo.GetTipo() == ROOM_INFO_TYPE.PANG_BATTLE) ? 0x100 : 0;

            option += option;

            if (option == 0 && RoomInfo.GetTipo() == ROOM_INFO_TYPE.LOUNGE)
                option = 7;

            List<PlayerRoomInfoEx> v_element = new List<PlayerRoomInfoEx>();
            PlayerRoomInfoEx pri = null;

            try
            {

                foreach (var sess in Players)
                {
                    pri = GetPlayerInfo(sess);
                    if (pri != null)
                        v_element.Add(pri);
                }

                pri = GetPlayerInfo(session);

                if (pri == null && option != 2)
                    return;

                var p = new Packet();

                if (Handle_PACKET_RESPONSE.pacote048(p, session, (option == 1 || option == 4 || option == 0x103) ? [pri] : v_element, option))
                    SendBroadCast(p);
            }
            catch
            {
                throw;
            }
            // Exceções propagam diretamente — o catch-rethrow vazio original não adicionava valor.
        }

        public void SendPlayerStateLounge(Player session)
        { 
            if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.LOUNGE)
            {
                var it = session.UserInfo.FindStateCharacterLounger(session.Inventory.UserEquippedItem.CharacterEquiped.id);
                if (it == null)
                {
                    session.UserInfo.CharacterLoungeStates.Add(session.Inventory.UserEquippedItem.CharacterEquiped.id, new StateCharacterLounge());
                    it = new StateCharacterLounge();
                }
                 
                SendBroadCast(Handle_PACKET_RESPONSE.pacote196(session, it));
            }
        }

        public void SendWeatherLounge(Player session)
        {

            if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.LOUNGE)
            {

                // Envia o tempo(weather) do lounge só se ele for diferente de tempo bom
                if (WeatherChatRoom != 0)
                {

                    var p = new Packet((ushort)0x9E);

                    p.WriteUInt16(WeatherChatRoom);
                    p.WriteByte(0); // Flag (acho), vou colocar 0 o padrão, colocou 1 aqui só quando eu mudou com o comando GM
                    session.Send(p);
                }
            }
        }

        public void UpdateMaster(Player session)
        {
            var p = new Packet();
            try
            {
                Player master = FindSessionByUid((uint)RoomInfo.master);

                if (session != null && session.UserInfo.UserCapabilities.game_master && RoomInfo.master != -2)
                {
                    // Só troca o master se ele saiu da sala ou se ele não for GM
                    if (master == null || !(master.UserInfo.UserCapabilities.game_master/* & 4*/))
                    {
                        RoomInfo.master = (int)session.UserInfo.uid;
                        RoomInfo.state_flag = 0x100; // GM

                        if (master != null)
                        {
                            UpdatePlayerInfo(master);
                            p.init_plain(0x78);
                            p.WriteInt32(master.ConnectionID);
                            p.WriteByte((byte)~GetPlayerInfo(master).state_flag.ready);

                            SendBroadCast(p);
                        }

                        p = new Packet();
                        p.init_plain(0x7C);
                        p.WriteInt32(session.ConnectionID);
                        p.WriteInt16(0);

                        SendBroadCast(p);
                    }
                }
                else if (master == null && Players.Count > 0 && RoomInfo.master != -2)
                {
                    if (RoomInfo.GetTipo() != ROOM_INFO_TYPE.SPECIAL_SHUFFLE_COURSE && RoomInfo.GetTipo() != ROOM_INFO_TYPE.GRAND_PRIX)
                    {
                        // Find GM 
                        var i = Players.FirstOrDefault(pl => pl.UserInfo.UserCapabilities.game_master);

                        if (i != null)
                            master = i;
                        else
                            master = Players[0];

                        RoomInfo.master = (int)master.UserInfo.uid;
                        RoomInfo.state_flag = (short)(master.UserInfo.UserCapabilities.game_master ? 0x100 : 0);

                        UpdatePlayerInfo(master);

                        p = new Packet(0x7C);
                        p.WriteInt32(master.ConnectionID);
                        p.WriteInt16(0);

                        SendBroadCast(p);
                    }
                }
            }
            catch
            {
                throw;
            } 
        }


        public void SendMakeRoom(Player session)
        { 
            session.Send(Handle_PACKET_RESPONSE.pacote049(this, 0));
        }

        public void SendUpdateRoom()
        {
            SendBroadCast(Handle_PACKET_RESPONSE.pacote04A(RoomInfo, -1/*valor constante*/));
        }

        private void AddPlayerKicked(uint uid)
        {
            if (IsKickedPlayer(uid))
                _smp.message_pool.getInstance().push(new message("[room::addPlayerKicked] [Error][Warning] PLAYER[UID=" + (uid) + "] ja foi chutado da sala[NUMERO="
                    + (RoomInfo.numero) + "]", type_msg.CL_FILE_TIME_LOG_AND_CONSOLE));
            else
                PlayersKickeds[uid] = true;
        }
         
        private PlayerRoomInfoEx MakePlayerInfo(Player session)
        {
            PlayerRoomInfoEx pri = new();

            // Player Room Info Init
            pri.oid = session.ConnectionID;
            pri.nickname = session.UserInfo.nickname;
            pri.guild_name = session.UserInfo.Guild.name;
            pri.position = (byte)(GetPosition(session) + 1);
            pri.capability = session.UserInfo.UserCapabilities;
            pri.title = session.Inventory.UserEquipment.m_title;
            pri.sDisplayID = "@NT_" + session.UserInfo.nickname;
            if (session.Inventory.UserEquippedItem.CharacterEquiped != null)
                pri.char_typeid = session.Inventory.UserEquippedItem.CharacterEquiped._typeid;

            pri.skin = session.Inventory.UserEquipment.skin_typeid;

            pri.skin[4] = 0;

            if (GetMaster() == session.UserInfo.uid)
            {
                pri.state_flag.master = 1;
                pri.state_flag.ready = 1;// Sempre está pronto(ready) o master
            }
            pri.state_flag.sexo = session.UserInfo.Member.sexo;

            if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.MATCH)
            {
                if (Players.Count > 1)
                {
                    if (Teams[0].getCount() >= 2 && Teams[1].getCount() >= 2)
                    {
                        throw new exception("[room::MakePlayerInfo] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar em time para todos os times da sala estao cheios. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM, 1500, 0));
                    }
                    else if (Teams[0].getCount() >= 2)
                    {
                        pri.state_flag.team = 1;
                    }
                    else if (Teams[1].getCount() >= 2)
                    {
                        pri.state_flag.team = 0;
                    }
                    else
                    {
                        var targetSession = (Players.Count == 2) ? Players[0] : (Players.Count > 2 ? Players[1] : null);
                        var pPri = GetPlayerInfo(targetSession);

                        if (pPri == null)
                        {
                            throw new exception("[room::MakePlayerInfo] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar em um time, mas o ultimo player da sala, nao tem um info no sala. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM, 1501, 0));
                        }

                        pri.state_flag.team = (byte)~pPri.state_flag.team;
                    }
                }
                else
                {
                    pri.state_flag.team = 0;
                }

                Teams[pri.state_flag.team].addPlayer(session);
            }
            else if (RoomInfo.GetTipo() != ROOM_INFO_TYPE.GUILD_BATTLE)
            {
                pri.state_flag.team = (byte)((pri.position - 1) % 2);
            }

            if (session.UserInfo.level >= 6 && session.UserInfo.Statistics.jogado >= 50)
            {
                float rate = session.UserInfo.Statistics.getQuitRate();

                if (rate < GOOD_PLAYER_ICON)
                {
                    pri.state_flag.azinha = 1;
                }
                else if (rate >= QUITER_ICON_1 && rate < QUITER_ICON_2)
                {
                    pri.state_flag.quiter_1 = 1;
                }
                else if (rate >= QUITER_ICON_2)
                {
                    pri.state_flag.quiter_2 = 1;
                }
            }

            pri.level = session.UserInfo.Member.level;

            if (session.Inventory.UserEquippedItem.CharacterEquiped != null && session.UserInfo.Statistics.getQuitRate() < GOOD_PLAYER_ICON)
                pri.icon_angel = session.Inventory.UserEquippedItem.CharacterEquiped.AngelEquiped();
            else
                pri.icon_angel = 0;

            pri.place.ulPlace = 10;
            pri.guild_uid = session.UserInfo.Guild.uid;
            pri.guild_mark_img = session.UserInfo.Guild.mark_emblem;
            pri.guild_mark_index = session.UserInfo.Guild.index_mark_emblem;
            pri.uid = session.UserInfo.uid;
            pri.state_action.animation = session.UserInfo.LoungeState;
            pri.state_action.room_id = 0;
            pri.state_action.posture = session.UserInfo.PostureRoom; 
            pri.location.x += session.UserInfo.CurrentLocation.x;
            pri.location.z += session.UserInfo.CurrentLocation.z;
            pri.location.y += session.UserInfo.CurrentLocation.y;
            pri.shop = _tradeShop.getPersonShop(session);

            if (session.Inventory.UserEquippedItem.MascotEquiped != null)
                pri.mascot_typeid = session.Inventory.UserEquippedItem.MascotEquiped._typeid;

            pri.flag_item_boost = session.Inventory.CheckHaveItemBoost();
            pri.channeling_flag = 0;
            pri.convidado = 0;
            pri.avg_score = session.UserInfo.Statistics.getMediaScore();

            if (session.Inventory.UserEquippedItem.CharacterEquiped != null)
                pri.ci = session.Inventory.UserEquippedItem.CharacterEquiped;
            if (!PlayersInfo.TryAdd(session, pri))
            {
                if (PlayersInfo.TryGetValue(session, out var existingPri))
                {
                    if (existingPri.uid != session.UserInfo.uid)
                    {
                        try
                        {
                            var pri_ant = PlayersInfo[session];
                            PlayersInfo[session] = pri;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            _smp.message_pool.getInstance().push(new message($"[room::MakePlayerInfo] [Error][Warning] PLAYER[UID={session.UserInfo.uid}], nao conseguiu atualizar o PlayerRoomInfo da session para o novo PlayerRoomInfo do player atual da session. Bug", type_msg.CL_FILE_LOG_AND_CONSOLE));
                            throw;
                        }
                    }
                    else
                    {
                        _smp.message_pool.getInstance().push(new message($"[room::MakePlayerInfo][Info] PLAYER[UID={session.UserInfo.uid}] nao conseguiu adicionar o PlayerRoomInfo da session, por que ja tem o mesmo PlayerRoomInfo no map.", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    }
                }
                else
                {
                    _smp.message_pool.getInstance().push(new message($"[room::MakePlayerInfo] [Error] nao conseguiu inserir o pair de PlayerInfo do PLAYER[UID={session.UserInfo.uid}] no map de player info do room. Bug", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }

            return pri;
        }

        private PlayerRoomInfoEx MakePlayerInvitedInfo(Player session)
        {

            PlayerRoomInfoEx pri = new PlayerRoomInfoEx();

            // Player Room Info Init
            pri.oid = session.ConnectionID;
            pri.position = (byte)(GetPosition(session) + 1); // posição na sala 
            pri.place.ulPlace = 10; // 0x0A dec"10" session.UserInfo.place, pode ser lugar[place]

            pri.uid = session.UserInfo.uid;

            pri.convidado = 1; // Flag Convidado, [Não sei bem por que os que entra na sala normal tem valor igual aqui, já que é type de convidado waiting], Valor constante da sala para os players(ACHO)

            // Check inset pair in map of room player info
            if (PlayersInfo.ContainsKey(session))
            {
                try
                {

                    // pega o antigo PlayerRoomInfo para usar no Log
                    var pri_ant = PlayersInfo[session];

                    // Novo PlayerRoomInfo
                    PlayersInfo[session] = pri;

                }
                catch (IndexOutOfRangeException)
                {
                    _smp.message_pool.getInstance().push(new message("[room::MakePlayerInfo] [Error][Warning] PLAYER[UID=" + session.UserInfo.uid + "], nao conseguiu atualizar o PlayerRoomInfo da session para o novo PlayerRoomInfo do player atual da session. Bug", type_msg.CL_FILE_LOG_AND_CONSOLE));
                    throw;
                }
            }
            else
                PlayersInfo.Add(session, pri);

            return pri;
        }


        public void UpdatePlayerInfo(Player session)
        {
            PlayerRoomInfoEx pri = new PlayerRoomInfoEx();
            PlayerRoomInfoEx _pri = null;
            try
            {

                if ((_pri = GetPlayerInfo(session)) == null)
                    return;//antes dava exception, agora eu so retorno....

                // Copia do que esta no map
                pri = _pri;

                // Player Room Info Update
                pri.oid = session.ConnectionID;

                pri.position = (byte)(GetPosition(session) + 1); // posição na sala
                pri.capability = session.UserInfo.UserCapabilities;
                pri.title = session.Inventory.UserEquipment.m_title;

                if (session.Inventory.UserEquippedItem.CharacterEquiped != null)
                    pri.char_typeid = session.Inventory.UserEquippedItem.CharacterEquiped._typeid;


                pri.skin[4] = 0; // Aqui tem que ser zero, se for outro valor não mostra a imagem do character equipado

                if (GetMaster() == session.UserInfo.uid)
                {
                    pri.state_flag.master = 1;
                    pri.state_flag.ready = 1; // Sempre está pronto(ready) o master
                }
                else
                {

                    // Só troca o estado de pronto dele na sala, se anterior mente ele era Master da sala ou não estiver pronto
                    if (pri.state_flag.master == 1 || !(pri.state_flag.ready == 1))
                    {
                        pri.state_flag.ready = 0;
                    }

                    pri.state_flag.master = 0;
                }

                pri.state_flag.sexo = session.UserInfo.Member.sexo;

                // Update Team se for Match
                if (RoomInfo.GetTipo() == ROOM_INFO_TYPE.MATCH)
                {

                    // Verifica se o Player está em algum team para atualizar o team dele se ele não estiver em nenhum
                    var Player_team = pri.state_flag.team;
                    Player p_seg_team = null;

                    // atualizar o team do Player a type de team dele não bate com o team dele
                    if (Teams[Player_team].findPlayerByUID(pri.uid) == null && (p_seg_team = Teams[~Player_team].findPlayerByUID(pri.uid)) == null)
                    {

                        // Player não está em nenhum team
                        if (Players.Count > 1)
                        {

                            if (Teams[0].getCount() >= 2 && Teams[1].getCount() >= 2)
                            {
                                throw new exception("[room::updatePlayerInfo] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar em time para todos os times da sala estao cheios. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                                    1500, 0));
                            }
                            else if (Teams[0].getCount() >= 2)
                            {
                                pri.state_flag.team = 1; // Blue
                            }
                            else if (Teams[1].getCount() >= 2)
                            {
                                pri.state_flag.team = 0; // Red
                            }
                            else
                            {

                                var pPri = GetPlayerInfo((Players.Count == 2) ? Players.FirstOrDefault() : (Players.Count > 2 ? (Players.Skip(1).FirstOrDefault()) : null));

                                if (pPri == null)
                                {
                                    throw new exception("[room::updatePlayerInfo] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar em um time, mas o ultimo Player da sala, nao tem um info no sala. Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                                        1501, 0));
                                }

                                pri.state_flag.team = (byte)~pPri.state_flag.team;
                            }

                        }
                        else
                        {
                            pri.state_flag.team = 0;
                        }

                        Teams[pri.state_flag.team].addPlayer(session);

                    }
                    else if (p_seg_team != null)
                    {
                        // a type de team do Player está errada, ele está no outro team, ajeita
                        pri.state_flag.team = (byte)~Player_team;
                    }
                }
                else if (RoomInfo.tipo != (byte)ROOM_INFO_TYPE.GUILD_BATTLE) // O Guild Battle tem sua própria função para inicializar e atualizar o team e os dados da guild
                {
                    pri.state_flag.team = Convert.ToByte(((pri.position > 0 ? pri.position : 1) - 1) % 2);
                }

                // Só faz calculo de Quita rate depois que o Player
                // estiver no level Beginner E e jogado 50 games
                if (session.UserInfo.level >= 6 && session.UserInfo.Statistics.jogado >= 50)
                {
                    float rate = session.UserInfo.Statistics.getQuitRate();

                    if (rate < GOOD_PLAYER_ICON)
                    {
                        pri.state_flag.azinha = 1;
                    }
                    else if (rate >= QUITER_ICON_1 && rate < QUITER_ICON_2)
                    {
                        pri.state_flag.quiter_1 = 1;
                    }
                    else if (rate >= QUITER_ICON_2)
                    {
                        pri.state_flag.quiter_2 = 1;
                    }
                }

                pri.level = session.UserInfo.Member.level;

                if (session.Inventory.UserEquippedItem.CharacterEquiped != null && session.UserInfo.Statistics.getQuitRate() < GOOD_PLAYER_ICON)
                    pri.icon_angel = session.Inventory.UserEquippedItem.CharacterEquiped.AngelEquiped();
                else
                    pri.icon_angel = 0;

                pri.place.ulPlace = 10; // 0x0A dec"10" session.UserInfo.place
                pri.guild_uid = session.UserInfo.Guild.uid;

                pri.uid = session.UserInfo.uid;
                pri.state_action.animation = session.UserInfo.LoungeState;
                pri.state_action.room_id = 0; // Ví Players com valores 2 e 4 e 0
                pri.state_action.posture = session.UserInfo.PostureRoom;
                pri.location.x += session.UserInfo.CurrentLocation.x;
                pri.location.z += session.UserInfo.CurrentLocation.z;
                pri.location.y += session.UserInfo.CurrentLocation.y;

                // Personal Shop
                pri.shop = _tradeShop.getPersonShop(session);

                if (session.Inventory.UserEquippedItem.MascotEquiped != null)
                    pri.mascot_typeid = session.Inventory.UserEquippedItem.MascotEquiped._typeid;

                pri.flag_item_boost = session.Inventory.CheckHaveItemBoost();
                pri.channeling_flag = 0;

                // Só atualiza a type de convidado se for diferente de 1, por que 1 ele é convidado
                if (pri.convidado != 1)
                    pri.convidado = 0; // Flag Convidado, [Não sei bem por que os que entra na sala normal tem valor igual aqui, já que é type de convidado waiting], Valor constante da sala para os Players(ACHO)

                pri.avg_score = session.UserInfo.Statistics.getMediaScore();

                if (session.Inventory.UserEquippedItem.CharacterEquiped != null)
                    pri.ci = session.Inventory.UserEquippedItem.CharacterEquiped;

                // Salva novamente
                PlayersInfo[session] = pri;
            }
            catch
            {
                throw;
            } 
        }

        public Team GetTeamInfo(byte team)
        {
            return Teams[team];
        }

        public int TeamCount() => Teams.Count;

        public void AddPlayerTeam(Player session, byte team)
        { Teams[team].addPlayer(session); }

        public void DeletePlayerTeam(Player session, byte opt)
        { Teams[GetPlayerInfo(session).state_flag.team].deletePlayer(session, opt); }


        public void SendTimeGame(Player session)
        {
            if (!session.getState())
            {
                throw new exception("[Room::RequestSendTimeGame] [Error] player nao esta connectado", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    12, 0));
            }

            Packet p = new();

            try
            {
                if (IsKickedPlayer(session.UserInfo.uid))
                {
                    throw new exception("[Room::RequestSendTimeGame] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na sala[NUMERO=" + RoomInfo.numero + "] ja em jogo, mas o player foi chutado da sala antes de comecar o jogo.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2704, 7));
                }

                if (CurrentGame == null)
                {
                    throw new exception("[Room::RequestSendTimeGame] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou pegar o tempo do tourney que comecou na sala[NUMERO=" + RoomInfo.numero + "], mas a sala nao tem nenhum jogo inicializado. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2705, 1));
                }

                CurrentGame.RequestSendTimeGame(session);

            }
            catch (exception e)
            {

                _smp.message_pool.getInstance().push(new message("[Room::RequestSendTimeGame][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Resposta erro
                p.init_plain(0x113);

                p.WriteByte(6); // Option Error

                // Error Code
                p.WriteByte((byte)((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.ROOM) ? ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) : 1));

                session.Send(p);
            }
        }

        public bool EnterGameAfterStarted(Player session)
        {
            if (!session.getState())
            {
                throw new exception("[Room::RequestEnterGameAfterStarted] [Error] player nao esta connectado", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                    12, 0));
            }

            Packet p = new();

            bool ret = false;

            try
            {

                if (IsKickedPlayer(session.UserInfo.uid))
                {
                    throw new exception("[Room::RequestEnterGameAfterStarted][Warning] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na sala[NUMERO=" + RoomInfo.numero + "] ja em jogo, mas o player foi chutado da sala antes de comecar o jogo.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2704, 7));
                }

                if (CurrentGame == null)
                {
                    throw new exception("[Room::RequestEnterGameAfterStarted] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na sala[NUMERO=" + RoomInfo.numero + "] ja em jogo, mas a sala nao tem nenhum jogo inicializado. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2705, 1));
                }

                if (IsGamingBefore(session.UserInfo.uid))
                {
                    throw new exception("[Room::RequestEnterGameAfterStarted][Warning] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na sala[NUMERO=" + RoomInfo.numero + "] ja em jogo, mas o player ja tinha jogado nessa sala e saiu, e nao pode mais entrar.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        2703, 6));
                }

                var tempo = (RoomInfo.qntd_hole == 18) ? 10 * 60000 : 5 * 60000;

                var remain = UtilTime.GetLocalDateDiff(session.GetGameRoom().GetTimeStart());

                if (remain > 0)
                {
                    remain /= STDA_10_MICRO_PER_MILLI; // miliseconds
                }

                if (remain >= tempo)
                {
                    throw new exception("[Room::RequestEnterGameAfrerStarted][Warning] PLAYER[UID=" + session.UserInfo.uid + "] tentou entrar na sala[NUMERO=" + RoomInfo.numero + "] ja em jogo, mas o tempo de entrar no tourney acabou.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM, // Acabou o tempo de entrar na sala
                        2706, 2));
                }

                // Add Player a sala
                EnterToRoom(session);

                ret = true;

            }
            catch (exception e)
            {

                _smp.message_pool.getInstance().push(new message("[Room::RequestEnterGameAfterStarted][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Excluí player da sala se adicionou ele antes
                if (FindSessionByUid(session.UserInfo.uid) != null)
                {
                    Leave(session, 0);
                }

                // Resposta erro
                p.init_plain(0x113);

                p.WriteByte(6); // Option Error

                // Error Code
                p.WriteByte((byte)((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.ROOM) ? ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) : 1));

                session.Send(p);
            }

            return ret;
        }
          
        public bool CheckPersonalShopItem(Player session, int itemId)
        {
            return _tradeShop.isItemForSale(session, itemId);
        }
    }
}
