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
        // Game
        public abstract bool RequestFinishGame(Player session, Packet packet);

        // Inicializa Jogo e Finaliza Jogo
        public abstract bool InitRoomGame();

        // Trata Shot Sync Data
        public abstract void RequestTranslateSyncShotData(Player session, ShotSyncData ssd);
        public abstract void RequestReplySyncShotData(Player session);

        // Metôdos do Game.Course.Hole
        public abstract void RequestInitHole(Player session, Packet packet);
        public abstract bool RequestFinishLoadHole(Player session, Packet packet);
        public abstract void RequestFinishCharIntro(Player session, Packet packet);
        public abstract void RequestFinishHoleData(Player session, Packet packet);

        // Server enviou a resposta do InitShot para o cliente
        // Esse aqui é exclusivo do VersusBase 
        public abstract void RequestInitShot(Player session, Packet packet);
        public abstract void RequestSyncShot(Player session, Packet packet);
        public abstract void RequestInitShotArrowSeq(Player session, Packet packet);
        public abstract void RequestShotEndData(Player session, Packet packet);
        public abstract RetFinishShot RequestFinishShot(Player session, Packet packet);

        public abstract void RequestChangeMira(Player session, Packet packet);
        public abstract void RequestChangeStateBarSpace(Player session, Packet packet);
        public abstract void RequestActivePowerShot(Player session, Packet packet);
        public abstract void RequestChangeClub(Player session, Packet packet);
        public abstract void RequestUseActiveItem(Player session, Packet packet);
        public abstract void RequestChangeStateTypeing(Player session, Packet packet); // Escrevendo
        public abstract void RequestMoveBall(Player session, Packet packet);
        public abstract void RequestChangeStateChatBlock(Player session, Packet packet);
        public abstract void RequestActiveBooster(Player session, Packet packet);
        public abstract void RequestActiveReplay(Player session, Packet packet);
        public abstract void RequestActiveCutin(Player session, Packet packet);

        // Hability Item
        public abstract void RequestActiveRing(Player session, Packet packet);
        public abstract void RequestActiveRingGround(Player session, Packet packet);
        public abstract void RequestActiveRingPawsRainbowJP(Player session, Packet packet);
        public abstract void RequestActiveRingPawsRingSetJP(Player session, Packet packet);
        public abstract void RequestActiveRingPowerGagueJP(Player session, Packet packet);
        public abstract void RequestActiveRingMiracleSignJP(Player session, Packet packet);
        public abstract void RequestActiveWing(Player session, Packet packet);
        public abstract void RequestActivePaws(Player session, Packet packet);
        public abstract void RequestActiveGlove(Player session, Packet packet);
        public abstract void RequestActiveEarcuff(Player session, Packet packet); 
    }
}
