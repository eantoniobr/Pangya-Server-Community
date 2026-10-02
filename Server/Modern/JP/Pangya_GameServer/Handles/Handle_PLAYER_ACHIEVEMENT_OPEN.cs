using System;
using System.Threading.Tasks;
using Pangya_GameServer.Manager;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ACHIEVEMENT_OPEN : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                uint uid = _packet.ReadUInt32();
                AchievementManager? mgr = GetManager(uid, _session);

                if (mgr == null)
                {
                    _session.Send(Handle_PACKET_RESPONSE.pacote22C(1)); // Falha
                    return;
                }

                mgr.sendAchievementGuiToPlayer(_session);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private AchievementManager? GetManager(uint uid, Player session)
        {
            // 1. Caso seja o próprio jogador
            if (session.UserInfo.uid == uid)
                return session.UserInfo.Achievements;

            // 2. Caso seja outro jogador online
            var targetPlayer = GameServer.getInstance().FindPlayer(uid);
            if (targetPlayer != null)
                return targetPlayer.UserInfo.Achievements;

            // 3. Caso o jogador esteja offline (Busca temporária)
            var offlineMgr = new AchievementManager();
            offlineMgr.initAchievement(uid);

            return offlineMgr;
        }
    }
}