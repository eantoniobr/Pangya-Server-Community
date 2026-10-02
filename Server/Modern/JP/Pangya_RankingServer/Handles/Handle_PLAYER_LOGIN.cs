using Pangya_RankingServer.Repository;
using Pangya_RankingServer.Server;
using Pangya_RankingServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_RankingServer.Handles
{
    public class Handle_PLAYER_LOGIN : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            try
            {
                uint uid = packet.ReadUInt32();
                string id = packet.ReadString();

                session.UserInfo.m_sd.ToRead(packet);

                session.ResetHandShake(); // Reseta o handshake para evitar problemas de sincronização


                // 1. Validações de Segurança
                if (uid == 0 || string.IsNullOrEmpty(id))
                {
                    throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] [Login Error] Dados inválidos. UID: {uid}, ID: {id}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 1, 0x5200101));
                }

                if (RankingServer.getInstance().haveBanList(session.GetIP(), "", false))
                {
                    throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] [Login Error] IP Banido: {session.GetIP()}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 5, 0x5200105));
                }

                // 2. Consulta ao Banco de Dados (CmdPlayerInfo)
                var cmd_pi = new CmdPlayerInfo(uid);
                cmd_pi.exec();

                if (cmd_pi.getException().getCodeError() != 0)
                    throw cmd_pi.getException();

                // 3. Sincroniza dados do DB com a Sessão
                session.UserInfo.Set(cmd_pi.getInfo());

                // 4. Verificação de Integridade
                if (string.CompareOrdinal(id.Trim(), session.UserInfo.id.Trim()) != 0)
                {
                    throw new exception($"[{nameof(Handle_PLAYER_LOGIN)}] [Login Error] ID divergente! Packet: {id} vs DB: {session.UserInfo.id}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.RANK_SERVER, 4, 0x5200104));
                }

                // 5. Verificação de Bloqueios
                await CheckPlayerBlock(session);

                // 6. Gerenciamento de Múltiplas Conexões
                var sessionAntiga = RankingServer.getInstance().HasLoggedWithOuterSocket(session);
                if (sessionAntiga != null)
                {
                    _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_LOGIN] Derrubando sessão antiga do UID: {uid}", type_msg.CL_ONLY_CONSOLE));
                    RankingServer.getInstance().Disconnect(sessionAntiga);
                }

                if (RankingServer.getInstance().m_unit_connect != null)
                {
                    RankingServer.getInstance().m_unit_connect.getInfoPlayerOnline(session.UserInfo.server_uid, session.UserInfo.uid);
                }
                else
                {
                    RankingServer.getInstance().Disconnect(session);
                }
            }
            catch (exception e)
            { 

                // Log de Erro com o nome da classe
                _smp.message_pool.getInstance().push(new message($"[{nameof(Handle_PLAYER_LOGIN)}] [Error] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));

                RankingServer.getInstance().Disconnect(session);
            }
        }

        private async Task CheckPlayerBlock(Player session)
        {
            var state = session.UserInfo.block_flag.m_id_state;
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