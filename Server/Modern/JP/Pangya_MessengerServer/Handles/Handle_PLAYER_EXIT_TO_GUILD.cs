using Pangya_MessengerServer.Models;
using Pangya_MessengerServer.Repository;
using Pangya_MessengerServer.Server;
using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;
using snmdb;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_EXIT_TO_GUILD : IPacketHandler<Player>//<Packet_PLAYER_INVITE_TO_ROOM_GUILD_BATTLE, MPlayer>
    {
        public const int FRIEND_PAG_LIMIT = 30;
        public async Task Handle(Player session, Packet _packet)
        {
            var p = new Packet();

            try
            {
                // O pacote costuma enviar o ClubID e o UID do membro que vai sair
                // Se um Admin tira alguém, o member_uid é diferente do session.m_pi.uid
                var club_id = _packet.ReadUInt32();
                var member_uid = _packet.ReadUInt32();

                if (club_id == 0u || member_uid == 0u)
                    throw new exception("[MessengerService::requestMemberExitedFromGuild][Error] ID de Clube ou Membro inválido.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5401, 0));

                // 1. Localiza todos os membros da guilda para o broadcast posterior
                var v_cm = MessengerServer.getInstance().FindAllGuildMember(club_id);

                // 2. Localiza o alvo (quem está saindo)
                // Pode ser a própria 'session' ou outro player online/offline
                var targetPlayer = MessengerServer.getInstance().FindPlayer(member_uid);

                if (targetPlayer != null)
                {
                    // PLAYER ONLINE: Atualiza em tempo real
                    targetPlayer.UserInfo.guild_uid = 0;
                    targetPlayer.UserInfo.m_friend_manager.init(targetPlayer.UserInfo);
                }
                else
                {
                    // PLAYER OFFLINE: Se necessário, você pode carregar do DB aqui
                    // Mas o importante é que o comando SQL de saída já tenha rodado
                    _smp.message_pool.getInstance().push(new message($"[Log] Player[{member_uid}] saiu (offline) da Guild[{club_id}].", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }

                // 3. Notificar todos os membros que restaram na guilda
                if (v_cm != null && v_cm.Count > 0)
                {
                    foreach (var member in v_cm.Values.Where(m => m != null))
                    {
                        // Re-inicializa a lista de amigos de cada membro (para remover o que saiu)
                        member.UserInfo.m_friend_manager.init(member.UserInfo);

                        // Envia a lista atualizada (Packet 0x30 -> Sub 0x102)
                        MessengerServer.getInstance().SendUpdatedFriendList(member);
                    }

                    // 4. Broadcast de saída (Packet 0x3C) 
                    p.init_plain((ushort)0x3C);
                    p.WriteUInt32(member_uid);
                    MessengerServer.getInstance().FriendBroadcast(v_cm, targetPlayer, p);
                }

                _smp.message_pool.getInstance().push(new message($"[Messenger] Sucesso: {member_uid} saiu da Guild {club_id}.", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[MessengerService::requestMemberExitedFromGuild][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}
