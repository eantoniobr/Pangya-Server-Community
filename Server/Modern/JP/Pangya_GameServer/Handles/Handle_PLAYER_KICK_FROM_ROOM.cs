using Pangya_GameServer.Manager;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_KICK_FROM_ROOM : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                // Lê o UID do Player que será chutado
                int targetUid = packet.ReadInt32();

                // 1. verifico se ele esta realmente no server....
                var _Player_server = GameServer.getInstance().FindSessionByOid(targetUid) ?? throw new exception(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Error] PLAYER[UID={targetUid}] não foi encontrado no server.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 12, 0));

                if (_Player_server.UserInfo.uid == Player.UserInfo.uid)
                {
                    // Enviamos um aviso para o chat do próprio GM em vez de dar erro fatal
                    Player.SendChatNotice("no executed, other Player");

                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Warning] GM {Player.UserInfo.nickname} tentou se auto-desconectar (Bloqueado).",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    return; // Interrompe a execução aqui
                }



                // 2. Localiza a sala atual do Master (quem enviou o pacote)
                var room = Player.GetRoom();

                if (room == null)
                {
                    throw new exception(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Error] PLAYER[UID={Player.UserInfo.uid}] tentou kikar UID={targetUid}, mas a sala {Player.UserInfo.Member.sala_numero} não existe.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0));
                }

                // 3. Validação de Master da Sala
                if (room.GetMaster() != Player.UserInfo.uid)
                {
                    throw new exception(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Error] PLAYER[UID={Player.UserInfo.uid}] tentou kikar UID={targetUid}, mas não é o Master da sala.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 11, 0));
                }

                // 4. Validação de Jogo em Andamento (Apenas GMs podem kikar durante a partida)
                if (!Player.UserInfo.UserCapabilities.game_master && room.CurrentGame != null)
                {
                    throw new exception(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Error] PLAYER[UID={Player.UserInfo.uid}] tentou kikar UID={targetUid} com jogo em andamento (Requer GM).",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 13, 0));
                }

                // 5. agora eu verifico se realmente esta em uma SALA!!!!!!!!!!!!!
                var _sessionKick = room.FindSessionByOid((uint)targetUid) ?? throw new exception(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Error] PLAYER[UID={targetUid}] não foi encontrado na sala {room.GetRoomId()}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 12, 0));


                if (PlayerKick.UserInfo.uid == Player.UserInfo.uid)
                {
                    // Enviamos um aviso para o chat do próprio GM em vez de dar erro fatal
                    Player.SendChatNotice("no executed, other Player");

                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Warning] GM {Player.UserInfo.nickname} tentou se auto-desconectar (Bloqueado).",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    return; // Interrompe a execução aqui
                }
                 
                // 6. Executa a expulsão
                // O motivo '3' é o padrão para "Kicked by Master" no protocolo Pangya MultiPlayer
                // Note que o LeaveRoom lidará com o envio dos pacotes para todos os outros Players na sala
                _sessionKick.GetChannel().LeaveRoomMultiPlayer(PlayerKick, 3);

                // Log de auditoria
                _smp.message_pool.getInstance().push(new message(
                    $"[Kick::Room] MASTER[UID={Player.UserInfo.uid}] expulsou PLAYER[UID={targetUid}] da Sala {room.GetRoomId()}.",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_KICK_FROM_ROOM][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}