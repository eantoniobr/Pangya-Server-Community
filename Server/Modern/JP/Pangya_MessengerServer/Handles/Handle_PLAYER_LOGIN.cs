using Pangya_MessengerServer.Repository;
using Pangya_MessengerServer.Server;
using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Network.Repository;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System.Text.RegularExpressions;
namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_LOGIN : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            try
            { 
                uint uid = packet.ReadUInt32();
                var nickname = packet.ReadString();

                session.ResetHandShake(); // Reseta o handshake para evitar problemas de sincronização


                // 1. Validações Básicas (Anti-Hacker)
                if (uid == 0)
                    throw new Exception($"[Login Error] UID inválido para o nick {nickname}.");

                if (string.IsNullOrEmpty(nickname))
                    throw new Exception($"[Login Error] Nickname vazio para o UID {uid}.");

                // 2. Busca info no Banco de Dados (Assíncrono)
                var cmd_pi = new CmdPlayerInfo(uid);

                cmd_pi.exec();

                if (cmd_pi.getException().getCodeError() != 0)
                    throw cmd_pi.getException();

                // 3. Vincula os dados ao Player
                session.UserInfo.Set(cmd_pi.getInfo());

                // 4. Verificação de Integridade (Nick DB vs Nick Packet)
                if (nickname != session.UserInfo.nickname)
                    throw new Exception("[Login Error] Nickname divergente do Database.");

                // 5. Verificação de Bloqueio (Ban)
                if (session.UserInfo.block_flag.m_id_state.ull_IDState != 0)
                {
                   await CheckPlayerBlock(session); // Podemos isolar essa lógica num método private
                }

                // 6. Gerenciamento de Conexão Duplicada
                var sessionAntiga = MessengerServer.getInstance().HasLoggedWithOuterSocket(session);
                if (sessionAntiga != null)
                    MessengerServer.getInstance().Disconnect(sessionAntiga);

                // 7. Confirmação com o Auth Server
                if (MessengerServer.getInstance().m_unit_connect != null)
                {
                    MessengerServer.getInstance().m_unit_connect.getInfoPlayerOnline(session.UserInfo.server_uid, session.UserInfo.uid);
                }
                else
                {
                    MessengerServer.getInstance().Disconnect(session);
                }

                // Se o confirm for assíncrono, use await aqui também
                session.UserInfo.m_friend_manager.init(session.UserInfo);

                // Estado 4 = Online/Lobby
                session.UserInfo.m_state = 4;
                session.Authorized = true;

                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_LOGIN] Player[UID={session.UserInfo.uid}, NICK={nickname}, NICK_DB={session.GetNickname()}] logou com sucesso!", type_msg.CL_FILE_LOG_AND_CONSOLE));
                // Resposta de Sucesso (0x2F)
                var p = new Packet(0x2F);
                 p.WriteByte(0); // OK
                p.WriteUInt32(session.UserInfo.uid);

               session.Send(p);

            }
            catch (exception e)
            {
                var p = new Packet(0x2F);
                // Envia resposta de erro para o cliente (Packet 0x2F no Pangya)
                p.init_plain(0x2F);
                p.WriteByte(1); // Flag de erro

                session.Send(p);

                MessengerServer.getInstance().Disconnect(session);

                // Log de erro centralizado
                Console.WriteLine($"[Login Error] {e.Message}");
                _smp.message_pool.getInstance().push(new message("[Handle_UPDATE_CHANNEL_INFO][Error] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            await Task.CompletedTask;
        } 

        private async Task CheckPlayerBlock(Player session)
        {
            var state = session.UserInfo.block_flag.m_id_state;

            // Se o ull_IDState for 0, não há bloqueio, então saímos cedo (Early Return)
            if (state.ull_IDState == 0) return;

            // 1. Bloqueio Temporário
            if (state.L_BLOCK_TEMPORARY && (state.block_time == -1 || state.block_time > 0))
            {
                string tempo = state.block_time == -1
                    ? "indeterminado"
                    : $"{state.block_time / 60}min {state.block_time % 60}sec";

                throw new exception(
                    $"[MessengerServer] Bloqueado por tempo [{tempo}]. Player [UID={session.UserInfo.uid}, ID={session.UserInfo.id}]",
                    ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1029, 0)
                );
            }

            // 2. Bloqueio Permanente
            if (state.L_BLOCK_FOREVER)
            {
                throw new exception(
                    $"[MessengerServer] Bloqueado permanente. Player [UID={session.UserInfo.uid}, ID={session.UserInfo.id}]",
                    ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1030, 0)
                );
            }

            // 3. Bloqueio por IP (Onde entra a integração com o banco)
            if (state.L_BLOCK_ALL_IP)
            {
                // Aqui você adiciona o IP atual do infeliz na lista de banidos
                // Como é uma operação de escrita, o ideal é que seja disparada sem travar o login
               snmdb.NormalManagerDB.getInstance().add(1, new CmdInsertBlockIp(session.GetIP(), "255.255.255.255"), null, null);

                throw new exception(
                    $"[MessengerServer] Player [UID={session.UserInfo.uid}, IP={session.GetIP()}] Block ALL IP.",
                    ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1031, 0)
                );
            }
        }
    }
}
