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
    public class Handle_PLAYER_KICK_TO_GUILD : IPacketHandler<Player>
    {
        public const int FRIEND_PAG_LIMIT = 30;

        public async Task Handle(Player session, Packet _packet)
        {
            try
            {
                // No protocolo Pangya, o Messenger recebe o ID do Clube e o UID do alvo
                var club_id = _packet.ReadUInt32();
                var member_uid = _packet.ReadUInt32();

                if (club_id == 0u || member_uid == 0u)
                    throw new exception("[Handle_PLAYER_KICK_TO_GUILD][Error] ID de Clube ou Membro inválido.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5401, 0));

                // 1. Localiza os membros da guilda que estão online no Messenger
                var v_cm = MessengerServer.getInstance().FindAllGuildMember(club_id);

                // 2. Localiza o alvo (Pode ser a própria session ou outro UID)
                var targetPlayer =  MessengerServer.getInstance().FindPlayer(member_uid);
                PlayerInfo pi = null;

                if (targetPlayer != null)
                {
                    // Alvo Online: Reseta a guilda na memória
                    targetPlayer.UserInfo.guild_uid = 0;
                    targetPlayer.UserInfo.m_friend_manager.init(targetPlayer.UserInfo);
                    pi = targetPlayer.UserInfo;
                }
                else
                {
                    // Alvo Offline: Busca no DB para processar o broadcast corretamente
                    var cmd_pi = new CmdPlayerInfo(member_uid);
                    NormalManagerDB.getInstance().add(0, cmd_pi, null, null);

                    if (cmd_pi.getException().getCodeError() != 0)
                        throw cmd_pi.getException();

                    pi = new PlayerInfo();
                    pi.Set(cmd_pi.getInfo());
                }

                // 3. Notificar todos os membros remanescentes
                if (v_cm != null && v_cm.Count > 0)
                {
                    foreach (var member in v_cm.Values.Where(m => m != null))
                    {
                        // Re-inicializa o manager de cada um para atualizar a lista interna
                        member.UserInfo.m_friend_manager.init(member.UserInfo);

                        // Envia o pacote de atualização de lista (0x30 -> 0x102)
                        MessengerServer.getInstance().SendUpdatedFriendList(member);
                    }

                    // 4. Broadcast de saída/kick (0x3C)
                    using (var p = new Packet((ushort)0x3C))
                    {
                        p.WriteUInt32(pi.uid);
                        MessengerServer.getInstance().FriendBroadcast(v_cm, targetPlayer, p);
                    }
                }

                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_KICK_TO_GUILD] Player[{pi.uid}] removido da Guild[{club_id}].", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_KICK_TO_GUILD][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        } 
    }
}