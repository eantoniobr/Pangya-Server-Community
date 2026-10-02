using Pangya_MessengerServer.Models;
using Pangya_MessengerServer.Server;
using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;
using System.Data.Common;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_UPDATE_CHANNEL_INFO : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet _packet)
        {
            try
            {
                // 1. Lê e atualiza as informações de canal/sala da sessão
                session.UserInfo.m_cpi.ToRead(_packet);

                var servers = PangyaAPI.Network.Repository.DBCommand.GetGame();

                // 3. Valida se o servidor escolhido existe e está online
                var selectedServer = servers.FirstOrDefault(c => c.uid == session.UserInfo.m_cpi.server_uid);



                // Log detalhado para o console do Messenger
                LogChannelUpdate(session);

                if (selectedServer != null)//verifica se realmente existe esse servidor..
                {  
                    // 2. Prepara o pacote de broadcast (0x30 -> 0x115)
                    using (var p = new Packet(0x30))
                    {
                        p.WriteUInt16(0x115); // Sub packet Id
                        p.WriteUInt32(session.UserInfo.uid);
                        p.WriteUInt32((uint)session.UserInfo.m_state);
                        p.WriteByte(1); // Status OK
                        p.WriteBytes(session.UserInfo.m_cpi.ToArray());

                        // 3. Envia para o próprio jogador (Confirmação)
                        session.Send(p);

                        // 4. Envia para todos os amigos/guilda (Broadcast)
                        var targets = MessengerServer.getInstance().FindAllFriend(
                                session.UserInfo.m_friend_manager.getAllFriendAndGuildMember(true)
                            );

                        if (targets != null && targets.Count > 0)
                        {
                            MessengerServer.getInstance().FriendBroadcast(targets, session, p);
                        }
                    }
                }
                else
                {
                    SendErrorResponse(session);
                    MessengerServer.getInstance().Disconnect(session);
                }


            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_UPDATE_CHANNEL_INFO][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Envia pacote de erro (Byte 0) para o cliente não ficar esperando
                SendErrorResponse(session);
            }

            await Task.CompletedTask;
        }

        private async void LogChannelUpdate(Player session)
        {
            var info = session.UserInfo.m_cpi;
            var roomNum = info.room.number;

            var servers = PangyaAPI.Network.Repository.DBCommand.GetGame();

            // 3. Valida se o servidor escolhido existe e está online
            var selectedServer = servers.FirstOrDefault(c => c.uid == info.server_uid);

            if (selectedServer != null)
            {
                _smp.message_pool.getInstance().push(new message(
       $"[Handle_UPDATE_CHANNEL_INFO][Log] Player[{session.UserInfo.uid}] -> IN: {selectedServer.nome}, Room: {roomNum}, Name: {info.name}",
       type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            else
            {
                // Servidor não encontrado na lista
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_UPDATE_CHANNEL_INFO]][Error] Servidor UID {info.server_uid} não existe ou está offline.",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

            }

        }

        private void SendErrorResponse(Player session)
        {
            using (var p = new Packet((ushort)0x30))
            {
                p.WriteUInt16(0x115);
                p.WriteUInt32(session.UserInfo.uid);
                p.WriteUInt32((uint)session.UserInfo.m_state);
                p.WriteByte(0); // Error status
                session.Send(p);
            }
        }
    }
}