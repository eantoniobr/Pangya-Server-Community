using Pangya_LoginServer.DataBase;

using Pangya_LoginServer.PangyaEnums;
using Pangya_LoginServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Utilities.Log;
using System;

namespace Pangya_LoginServer.Handles
{
    public class Handle_PLAYER_SET_NICKNAME : IPacketHandler<Player>
    {
        /// <summary>
        /// Handler para definir o Nickname do jogador (0x06)
        /// </summary>
        public async Task Handle(Player _session, Packet _packet)
        {
            string wnick = "";

            try
            {
                wnick = _packet.ReadString();
                uint uid = _session.UserInfo.uid;

                // 1. Persistência no Banco (Async)
                // Salva o nick escolhido e marca como primeiro login realizado
                CommandDB.SaveNick(uid, wnick);
                CommandDB.AddFirstLogin(uid, 1);

                // Atualiza o nickname na sessão atual para evitar dessincronização
                _session.UserInfo.nickname = wnick;

                // 2. Fluxo de Direcionamento (Regra de Negócio Pangya)
                // Verifica se o jogador já possui o primeiro Set de Personagem (Hana/Nuri)
                var hasFirstSet = CommandDB.IsFirstSet(uid);

                if (!hasFirstSet)
                {
                    // Se não tem personagem, envia pacote 0xD9 (Seleção Inicial)
                    _session.Send(Handle_PACKET_RESPONSE.pacote001(_session, 0xD9));
                }
                else
                {
                    // Se já está tudo pronto, finaliza o processo de login com sucesso
                    // Aqui você chama seu método global de Login Success
                    await Handle_PLAYER_LOGIN.SUCCESS_LOGIN(_session);
                }
            }
            catch (Exception e)
            {
                // Em caso de erro grave, envia o pacote 0x0E com status de erro (geralmente 1 ou conforme seu Enum)
                _session.Send(Handle_PACKET_RESPONSE.pacote00E(_session, wnick, (int)NICK_CHECK.UNKNOWN_ERROR, 0));

                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_SET_NICKNAME] Erro ao definir nick '{wnick}' para UID {_session.UserInfo.uid}: {e.Message}",
                    type_msg.CL_ONLY_CONSOLE)
                );
            }
            await Task.CompletedTask;
        }
    }
}