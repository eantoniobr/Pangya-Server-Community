using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_DIRECT_JOIN_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet pkt)
        {
            var targetChannel = session.GetChannel();
            try
            { 
                byte tarGetChannelId = pkt.ReadByte();      // btChannelUID
                short targetRoomId = pkt.ReadInt16();       // wRoomGUID
                string password = pkt.ReadString(7);      // Password da sala (7 chars no S4)

                var currentChannelId = targetChannel?.getId();

                //// 2. Se o canal alvo for diferente do canal atual
                //if (tarGetChannelId != currentChannelId)
                //{
                     
                //    if (targetChannel == null)
                //    {
                //        SendJoinError(session, 4); // Canal Inválido
                //        return;
                //    }

                //    // Verifica se o player pode entrar no novo canal (Level, Full, etc)
                //    bool enterCheck = targetChannel.CheckEnterChannel(session);
                //    if (enterCheck)
                //    {
                //        SendJoinError(session, 0);
                //        return;
                //    }

                //    // Sai do canal atual
                //    if (targetChannel != null)
                //    {
                //        targetChannel.LeaveChannel(session); 
                //    }

                //    // Entra no novo canal e no Lobby dele
                //    if (!targetChannel.EnterChannel(session))
                //    {
                //        SendJoinError(session, 4);
                //        return;
                //    }

                //    targetChannel.Lobby.EnterLobby(session, 0); // Entra no lobby padrão
                //}

                //// 3. Lógica de Join na Sala
                //// No S4, se o player já estiver em uma sala diferente, ele precisa sair primeiro
                //if (session.UserInfo.mi.sala_numero != -1 && session.UserInfo.mi.sala_numero != targetRoomId)
                //{
                //    // Sai da sala atual antes de migrar
                //    session.CurrentRoom?.RemovePlayer(session);
                //}

                //// Tenta entrar na sala alvo
                //if (targetChannel != null)
                //{
                //    // Chama a lógica de join (DisJoinRoom no original redireciona para a sala)
                //    targetChannel.Lobby.RequestEnterRoom(session, targetRoomId, password);
                //}
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[DirectJoin][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }

        private void SendJoinError(Player session, byte errorType)
        {
            // Pacote 0x41 (65 decimal) - Erro de Join
            var p = new Packet(0x41);
            p.WriteByte(errorType);
            session.Send(p);
        }
    }
}