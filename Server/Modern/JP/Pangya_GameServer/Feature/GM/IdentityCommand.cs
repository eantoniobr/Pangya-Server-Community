using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Threading.Tasks;
using static Pangya_GameServer.Feature.Personal.PersonalShop;
using static System.Collections.Specialized.BitVector32;

namespace Pangya_GameServer.Feature.GM
{
    public class IdentityCommand : IGMCommand
    {
        public async Task Execute(Player session, Packet pkt)
        {
            try
            {
                // 1. Leitura do Pacote
                uCapability requestedCap = new uCapability(pkt.ReadInt32());
                string nickProvided = pkt.ReadString();

                // 2. Validações de Segurança
                if (string.IsNullOrEmpty(nickProvided) || nickProvided != session.UserInfo.nickname)
                {
                    throw new exception("Nick inválido ou não coincide com a sessão.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 12, 0x5700100));
                }

                // 3. Verificação de permissão de GM (prevenção de exploit)
                if (!session.UserInfo.UserCapabilities.gm_normal && !session.UserInfo.UserCapabilities.game_master)
                {
                    throw new exception("Acesso negado: Player não possui privilégios administrativos.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 13, 0x5700100));
                }

                // 4. Validação no Banco de Dados (Sincronizada)
                var dbVerify = new CmdVerifyCapability(session.UserInfo.uid);

                NormalManagerDB.getInstance().add(0, dbVerify);

                if (!dbVerify.IsValid())
                {
                    throw new exception("Falha na validação de identidade no Banco de Dados.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 15, 0x5700100));
                }

                // 5. Aplicação da Identidade
                bool toAdmin = requestedCap.ulCapability == -1;

                ApplyCapabilityFlags(session, toAdmin);

                // 6. Sincronização de Rede
                SyncIdentityWithServer(session);

                // Log de Auditoria
                _smp.message_pool.getInstance().push(new message(
                    $"[GM::Identity] {session.UserInfo.nickname} alterou modo para: {(toAdmin ? "TITLE GM" : "NORMAL")}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[IdentityCommand][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }

        private void ApplyCapabilityFlags(Player s, bool toAdmin)
        {
            if (toAdmin)
            {
                s.UserInfo.UserCapabilities.game_master = true;
                s.UserInfo.UserCapabilities.title_gm = true;
                s.UserInfo.UserCapabilities.gm_normal = false;
            }
            else
            {
                s.UserInfo.UserCapabilities.game_master = false;
                s.UserInfo.UserCapabilities.title_gm = false;
                s.UserInfo.UserCapabilities.gm_normal = true;
            }
        }

        private void SyncIdentityWithServer(Player s)
        {
            //atualiza a capacidade nova.
            s.UserInfo.Member.capability = s.UserInfo.UserCapabilities;

            var channel = s.GetChannel();
            var room = s.GetRoom();

            // Atualiza Info no Lobby/Sala
            channel?.Lobby.UpdatePlayerInfo(s);
            room?.UpdatePlayerInfo(s);
            s.Send(Handle_PACKET_RESPONSE.pacote09A(s.UserInfo.UserCapabilities.ulCapability));

            // Broadcast (Tipo 3: State Update)
            channel?.Lobby.SendUpdatePlayerInfo(s, 3);
            room?.SendPlayerInfo(s, 3);
        }
    }
}