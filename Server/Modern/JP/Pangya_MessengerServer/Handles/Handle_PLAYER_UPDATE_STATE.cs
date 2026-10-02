using Pangya_MessengerServer.Flags;
using Pangya_MessengerServer.Server;
using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_STATE : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet _packet)
        {
            try
            {
                var state = _packet.ReadByte();

                // Só processa se o estado realmente mudou
                if (session.UserInfo.m_state != state)
                {
                    session.UserInfo.m_state = state;

                    // Monta o pacote 0x30 com sub 0x115 (Update State)
                    using (var p = new Packet(0x30))
                    {
                        p.WriteUInt16(0x115); // Sub packet Id
                        p.WriteUInt32(session.UserInfo.uid);
                        p.WriteUInt32(session.UserInfo.m_state);
                        p.WriteByte(1); // Status OK

                        // Escreve as informações do canal/sala atual (ChannelPlayerInfo)
                        p.WriteBytes(session.UserInfo.m_cpi.ToArray());

                        // Envia para todos os amigos e membros da guilda que não estão bloqueados
                        var targets = MessengerServer.getInstance().FindAllFriend(
                            session.UserInfo.m_friend_manager.getAllFriendAndGuildMember(true)
                        );

                        if (targets != null && targets.Count > 0)
                        {
                            MessengerServer.getInstance().FriendBroadcast(targets, session, p);
                        } 
                    }
                            MessengerServer.getInstance().SendUpdatedFriendList(session); 

                    // Log de estado no console
                    LogState(session.UserInfo.uid, state);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_STATE][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }

        private void LogState(uint uid, byte state)
        {
            string statusStr = (UserFlags)state switch
            {
                UserFlags.IS_PLAYING => "IN ROOM",
                UserFlags.IS_RECONNECT => "SLEEP/RECONNECT",
                UserFlags.IS_ONLINE => "ONLINE",
                UserFlags.IS_IDLE => "BUSY/IDLE",
                _ => $"UNKNOWN ({state})"
            };

            _smp.message_pool.getInstance().push(new message(
                $"[Handle_PLAYER_STATE][Log] Player[UID={uid}] UPDATE TO {statusStr}",
                type_msg.CL_FILE_LOG_AND_CONSOLE));
        }
    }
}