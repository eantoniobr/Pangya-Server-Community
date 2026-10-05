using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.DataBase.Models;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_GM_CHANGE_IDENTITY : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                // 1. Leitura do Pacote
                uCapability requestedCap = new uCapability(Packet.ReadInt32());
                string nickProvided = Packet.ReadString();

                // 2. Validações de Segurança
                if (string.IsNullOrEmpty(nickProvided) || nickProvided != Player.UserInfo.nickname)
                {
                    throw new exception("Nick inválido ou não coincide com a sessão.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 12, 0x5700100));
                }

                // 3. Verificação de permissão de GM (prevenção de exploit)
                if (!Player.UserInfo.UserCapabilities.gm_normal && !Player.UserInfo.UserCapabilities.game_master)
                {
                    throw new exception("Acesso negado: Player não possui privilégios administrativos.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 13, 0x5700100));
                }

                // 4. Validação no Banco de Dados (Sincronizada)
                var dbVerify = new CmdVerifyCapability(Player.UserInfo.uid);

                NormalManagerDB.getInstance().add(0, dbVerify);

                if (!dbVerify.IsValid())
                {
                    throw new exception("Falha na validação de identidade no Banco de Dados.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 15, 0x5700100));
                }
                 
                ApplyCapabilityFlags(Player);

                // 6. Sincronização de Rede
                SyncIdentityWithServer(Player);

                // Log de Auditoria
                _smp.message_pool.getInstance().push(new message($"[Lobby::Identity][Sucess]CHANGE[NICK: {Player.UserInfo.nickname}, TYPE: {(Player.UserInfo.UserCapabilities.title_gm ? "TITLE GM" : "NORMAL")}", type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Lobby::Identity][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }

        private void ApplyCapabilityFlags(Player s)
        {
            if (s.UserInfo.UserCapabilities.gm_normal)
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
            s.Send(HandlePacket_RESPONSE.pacote09A(s.UserInfo.UserCapabilities.ulCapability));

            // Broadcast (Tipo 3: State Update)
            channel?.Lobby.SendUpdatePlayerInfo(s, 3);
            room?.SendPlayerInfo(s, 3);
        }
    }
}