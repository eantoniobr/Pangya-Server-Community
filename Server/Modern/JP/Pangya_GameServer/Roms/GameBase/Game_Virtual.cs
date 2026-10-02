using Pangya_GameServer.Models;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_GameServer.Roms.GameBase
{
    public abstract partial class Game 
    {

        // Envia os dados iniciais para quem entra depois no Game
        public virtual void SendInitialDataAfter(Player session) { }


        public virtual bool FinishGame(Player session, int option = 0) { return false; }

        public virtual void RequestInitShotSended(Player session, Packet packet)
        {

        }


        // Esse Aqui só tem no VersusBase e derivados dele
        public virtual void RequestMarkerOnCourse(Player session, Packet packet)
        { 
        }

        public virtual void RequestLoadGamePercent(Player session, Packet packet)
        { 
        }

        public virtual void RequestStartTurnTime(Player session, Packet packet)
        { 
        }

        public virtual void RequestUnOrPause(Player session, Packet packet)
        { 
        }

        // Common Command GM Change Wind Versus
        public virtual void RequestExecCCGChangeWind(Player session, Packet packet)
        { 
        }

        public virtual void RequestExecCCGChangeWeather(Player session, Packet packet)
        { 
        }

        // Continua o versus depois que o player saiu no 3 hole pra cima e se for de 18h o game
        public virtual void RequestReplyContinue()
        {
        }



        // Esse Aqui só tem no TourneyBase e derivados dele
        public virtual bool RequestUseTicketReport(Player session, Packet packet)
        {
            return false;
        }

        // Apenas no Practice que ele é implementado
        public virtual void RequestChangeWindNextHoleRepeat(Player session, Packet packet)
        {

        }

        // Exclusivo do Modo Tourney
        public virtual void RequestStartAfterEnter(Action job)
        {


        }

        public virtual void RequestEndAfterEnter()
        {
        }

        public virtual void RequestUpdateTrofel()
        {
        }

        // Excluviso do Modo Match
        public virtual void RequestTeamFinishHole(Player session, Packet packet)
        {
        }

        public virtual void RequestSendTimeGame(Player session)
        { 
        }

        public virtual void RequestUpdateEnterAfterStartedInfo(Player session, EnterAfterStartInfo easi)
        { 
        }

        // Exclusivo do Grand Zodiac Modo
        public virtual void RequestStartFirstHoleGrandZodiac(Player session, Packet packet)
        { 
        }

        public virtual void RequestReplyInitialValueGrandZodiac(Player session, Packet packet)
        { 
        }
    }
}
