using System;
using System.Threading.Tasks;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Feature.GM
{
    public class OpenWhisperCommand : IGMCommand
    {
        public async Task Execute(Player session, Packet pkt)
        {
            try
            {
                // 1. Leitura do Nickname do Alvo
                string targetNickname = pkt.ReadPStr();

                // 2. Validações de Entrada e Permissão
                if (string.IsNullOrWhiteSpace(targetNickname))
                {
                    throw new exception($"[GM::Whisper] Nickname vazio enviado por UID={session.UserInfo.uid}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 8, 0x5700108));
                }

                if (!session.UserInfo.UserCapabilities.game_master)
                {
                    throw new exception($"[GM::Whisper] Player[UID={session.UserInfo.uid}] sem privilégios de GM tentou abrir whisper.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 0x5700100));
                }

                // 3. Localização do Alvo no Singleton do Server
                var target = GameServer.getInstance().FindSessionByNickname(targetNickname);

                if (target == null)
                {
                    throw new exception($"[GM::Whisper] Alvo '{targetNickname}' não está online.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 9, 0x5700109));
                }

                // 4. Execução da Lógica de Interface (Sincronização com o Cliente)
                // Isso geralmente remove bloqueios de "DND" (Do Not Disturb) do alvo para o GM
                session.m_gi.openPlayerWhisper(target.UserInfo.uid);

                // 5. Log de Auditoria
                _smp.message_pool.getInstance().push(new message(
                    $"[GM::Whisper][Success] {session.UserInfo.nickname} abriu canal direto com {targetNickname} (UID: {target.UserInfo.uid})",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[OpenWhisperCommand][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}