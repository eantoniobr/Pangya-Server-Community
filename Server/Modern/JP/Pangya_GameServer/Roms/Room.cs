using Pangya_GameServer.Channels;
using Pangya_GameServer.Engine;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Roms;
using Pangya_GameServer.Roms.GameBase;
using Pangya_GameServer.Roms.GameBase.Helpers;
using Pangya_GameServer.Roms.GameModes;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.DataBase;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models.IFF;
using PangyaAPI.Network;
using PangyaAPI.Network.Models;
using PangyaAPI.Network.Repository;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using static Pangya_GameServer.Models.DefineConstants;
using static Pangya_GameServer.Models.PlayerGameInfo;

namespace Pangya_GameServer.Roms
{
    ///esqueleto. 
    public partial class Room : IDisposable
    { 
        public List<Player> Players { get; set; } = new List<Player>();
        protected Dictionary<Player, PlayerRoomInfoEx> PlayersInfo = new Dictionary<Player, PlayerRoomInfoEx>();
        protected Dictionary<uint, bool> PlayersKickeds = new Dictionary<uint, bool>();
        private readonly object _lockCs = new object();        // Bloquea a sala 
        private readonly object _cs = new object();       // Bloquea a sala   
        public TradeShopManager _tradeShop; 
        protected List<Team> Teams = new List<Team>();

        protected GuildRoomManager GuildManager = new GuildRoomManager();

        protected List<InviteChannelInfo> Invites = new List<InviteChannelInfo>();

        protected RoomInfo RoomInfo = new RoomInfo();

        protected Channel ChannelOwner; // Canal dono da sala

        protected bool BotTourney; // Bot para começa o Modo tourney só com 1 jogador
        private int m_lock_spinstate;
        protected bool Destroying; 
        public Game? CurrentGame { get; set; }
        // Room Tipo Lounge
        protected byte WeatherChatRoom;
        public RoomInfoLog RoomInfoLog;
        private bool disposedValue; 
        public Room(Channel channelOwner, RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            CurrentGame = null;
            ChannelOwner = channelOwner;
            Teams = new List<Team>();
            WeatherChatRoom = 0;
            Destroying = false;
            BotTourney = false;
            this.m_lock_spinstate = 01;
            _tradeShop = new TradeShopManager(RoomInfo);
            RoomInfoLog = new RoomInfoLog(RoomInfo);

            GenerateSecurityKey();

            // Calcula chuva(weather) se o tipo da sala for lounge
            CalcRainLounge();

            // Atualiza tipo da sala
            SetType(RoomInfo.tipo);

            // Att Exp rate, e Pang rate, que criou a sala, att ele também quando começa o jogo

            RoomInfo.rate_exp = (uint)GameServer.getInstance().getInfo().rate.exp;
            RoomInfo.rate_pang = (uint)GameServer.getInstance().getInfo().rate.pang;
            RoomInfo.angel_event = GameServer.getInstance().getInfo().rate.angel_event == 1 ? true : false;
        }


        public static void OnDatabaseResponse(int msgId, Pangya_DB pangyaDb, object arg)
        {

            if (arg == null)
            {
                _smp.message_pool.getInstance().push(new message("[room::SQLDBResponse][Warning] _arg is null com msg_id = " + Convert.ToString(msgId), type_msg.CL_FILE_LOG_AND_CONSOLE));
                return;
            }

            // Por Hora só sai, depois faço outro tipo de tratamento se precisar
            if (pangyaDb.getException().getCodeError() != 0)
            {
                _smp.message_pool.getInstance().push(new message("[room::SQLDBResponse] [Error] " + pangyaDb.getException().getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
                return;
            }
            Channel channel = null;
            Room room = null;

            if (arg is Channel ch)
                channel = ch;

            if (arg is Room r)
                room = r;

            switch (msgId)
            {
                case 7: // Update Character PCL
                    {
                        var cmd_ucp = (CmdUpdateCharacterPCL)(pangyaDb);
                        break;
                    }
                case 8: // Update ClubSet Stats
                    {
                        var cmd_ucss = (CmdUpdateClubSetStats)(pangyaDb);

                        break;
                    }
                case 9: // Update Character Mastery
                    {
                        var cmd_ucm = (CmdUpdateCharacterMastery)(pangyaDb);

                        _smp.message_pool.getInstance().push(new message("[room::SQLDBResponse][Info] Atualizou Character[TYPEID=" + Convert.ToString(cmd_ucm.getInfo()._typeid) + ", ID=" + Convert.ToString(cmd_ucm.getInfo().id) + "] Mastery[value=" + Convert.ToString(cmd_ucm.getInfo().mastery) + "] do PLAYER[UID=" + Convert.ToString(cmd_ucm.getUID()) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                        break;
                    }
                case 12: // Update ClubSet Workshop
                    {
                        var cmd_ucw = (CmdUpdateClubSetWorkshop)(pangyaDb);

                        _smp.message_pool.getInstance().push(new message("[room::SQLDBResponse][Info] PLAYER[UID=" + Convert.ToString(cmd_ucw.getUID()) + "] Atualizou ClubSet[TYPEID=" + Convert.ToString(cmd_ucw.getInfo()._typeid) + ", ID=" + Convert.ToString(cmd_ucw.getInfo().id) + "] Workshop[C0=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.c[0]) + ", C1=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.c[1]) + ", C2=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.c[2]) + ", C3=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.c[3]) + ", C4=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.c[4]) + ", Level=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.level) + ", Mastery=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.mastery) + ", Rank=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.rank) + ", Recovery=" + Convert.ToString(cmd_ucw.getInfo().clubset_workshop.recovery_pts) + "] Flag=" + Convert.ToString(cmd_ucw.getFlag()) + "", type_msg.CL_FILE_LOG_AND_CONSOLE));
                        break;
                    }
                case 26: // Update Mascot Info
                    {

                        var cmd_umi = (CmdUpdateMascotInfo)(pangyaDb);

                        _smp.message_pool.getInstance().push(new message("[room::SQLDBResponse][Info] PLAYER[UID=" + Convert.ToString(cmd_umi.getUID()) + "] Atualizar Mascot Info[TYPEID=" + Convert.ToString(cmd_umi.getInfo()._typeid) + ", ID=" + Convert.ToString(cmd_umi.getInfo().id) + ", LEVEL=" + Convert.ToString((ushort)cmd_umi.getInfo().level) + ", EXP=" + Convert.ToString(cmd_umi.getInfo().exp) + ", FLAG=" + Convert.ToString((ushort)cmd_umi.getInfo().flag) + ", TIPO=" + Convert.ToString(cmd_umi.getInfo().tipo) + ", IS_CASH=" + Convert.ToString((ushort)cmd_umi.getInfo().is_cash) + ", PRICE=" + Convert.ToString(cmd_umi.getInfo().price) + ", MESSAGE=" + cmd_umi.getInfo().message + ", END_DT=" + UtilTime.FormatDate(cmd_umi.getInfo().data.ConvertTime()) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                        break;
                    }
                case 0:
                default: // 25 é update item equipado slot
                    break;
            }
        }

        ~Room()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            { 
                if (CurrentGame != null)
                {
                    CurrentGame.GameStop();//desliga o relogio...
                    CurrentGame.Dispose(); 
                }
                CurrentGame = null;     // elimina a referência 
                ChannelOwner = null; 
                WeatherChatRoom = 0;

                PlayersInfo?.Clear();
                Players?.Clear(); 
                Invites?.Clear();

                ClearPlayersKicked();

                ClearTeams();

                BotTourney = false;

                _tradeShop?.destroy();

                // Marca destruição diretamente — chamar @lock()/@unlock() dentro do Dispose
                // é perigoso: se @lock() lançar exception (sala já destruída), disposedValue
                // nunca seria marcado como true, permitindo execuções duplas do Dispose.
                Destroying = true;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
