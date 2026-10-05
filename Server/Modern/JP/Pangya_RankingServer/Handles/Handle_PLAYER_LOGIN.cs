using Pangya_RankingServer.Repository;
using Pangya_RankingServer.Server;
using Pangya_RankingServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_RankingServer.Handles
{
    public class Handle_PLAYER_LOGIN : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                uint uid = Packet.ReadUInt32();
                string id = Packet.ReadString();

                Player.UserInfo.m_sd.ToRead(Packet);

                Player.ResetHandShake(); // Reseta o handshake para evitar problemas de sincronização


                // 1. Validações de Segurança
                if (uid == 0 || string.IsNullOrEmpty(id))
                {
                    throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] [Login Error] Dados inválidos. UID: {uid}, ID: {id}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 1, 0x5200101));
                }

                if (RankingServer.getInstance().haveBanList(Player.GetIP(), "", false))
                {
                    throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] [Login Error] IP Banido: {Player.GetIP()}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 5, 0x5200105));
                }

                // 2. Consulta ao Banco de Dados (CmdPlayerInfo)
                var cmd_pi = new CmdPlayerInfo(uid);
                cmd_pi.exec();

                if (cmd_pi.getException().getCodeError() != 0)
                    throw cmd_pi.getException();

                // 3. Sincroniza dados do DB com a Sessão
                Player.UserInfo.Set(cmd_pi.getInfo());

                // 4. Verificação de Integridade
                if (string.CompareOrdinal(id.Trim(), Player.UserInfo.id.Trim()) != 0)
                {
                    throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] [Login Error] ID divergente! Packet: {id} vs DB: {Player.UserInfo.id}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 4, 0x5200104));
                }

                // 5. Verificação de Bloqueios
                await CheckPlayerBlock();

                // 6. Gerenciamento de Múltiplas Conexões
                var PlayerAntiga = RankingServer.getInstance().HasLoggedWithOuterSocket(Player);
                if (PlayerAntiga != null)
                {
                    _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_LOGIN] Derrubando sessão antiga do UID: {uid}", type_msg.CL_ONLY_CONSOLE));
                    RankingServer.getInstance().Disconnect(PlayerAntiga);
                }

                if (RankingServer.getInstance().m_unit_connect != null)
                {
                    RankingServer.getInstance().m_unit_connect.getInfoPlayerOnline(Player.UserInfo.server_uid, Player.UserInfo.uid);
                }
                else
                {
                    RankingServer.getInstance().Disconnect(Player);
                }
            }
            catch (exception e)
            { 

                // Log de Erro com o nome da classe
                _smp.message_pool.getInstance().push(new message($"[{nameof(Handle_PLAYER_LOGIN)}] [Error] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));

                RankingServer.getInstance().Disconnect(Player);
            }
        }

        private async Task CheckPlayerBlock()
        {
            var state = Player.UserInfo.block_flag.m_id_state;
            if (state.ull_IDState == 0) return;

            if (state.L_BLOCK_TEMPORARY && (state.block_time == -1 || state.block_time > 0))
            {
                throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] Bloqueio temporário ativo.",
                    ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 1029, 0));
            }

            if (state.L_BLOCK_FOREVER)
            {
                throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] Bloqueio permanente ativo.",
                    ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 1030, 0));
            }
        }        
    }
}