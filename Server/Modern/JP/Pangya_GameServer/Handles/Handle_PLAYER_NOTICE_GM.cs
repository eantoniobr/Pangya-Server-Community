using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_NOTICE_GM : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {
                // 2. Verificação de Privilégio (Game Master)
                // Usamos a propriedade GameMaster que você tem no UserInfo
                if (!Player.UserInfo.UserCapabilities.game_master)
                {
                    throw new exception(
                        $"[Handle_PLAYER_NOTICE_GM][Error] PLAYER[UID={Player.UserInfo.uid}] não é GM.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 0x5700100));
                }

                // 3. Leitura da Mensagem
                string notice = Packet.ReadPStr(); // O Pangya costuma usar PStr (Prefixed String)

                if (string.IsNullOrEmpty(notice))
                {
                    throw new exception(
                        $"[Handle_PLAYER_NOTICE_GM][Error] PLAYER[UID={Player.UserInfo.uid}] enviou notice vazia.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 8, 0x5700100));
                }

                // Log do servidor
                _smp.message_pool.getInstance().push(new message(
                    $"[GM::Notice] PLAYER[UID={Player.UserInfo.uid}] enviou: {notice}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                // 4. Criação do Pacote de Broadcast (0x40 - Chat/Notice)
                using (var p = new Packet())
                {
                    p.init_plain(0x40);
                    p.WriteByte(7);
                    p.WriteString(Player.UserInfo.nickname);
                    p.WriteString(notice);
                    GameServer.getInstance().SendChannelBroadCast(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_NOTICE_GM][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Feedback de erro apenas para o GM que tentou enviar
                SendErrorNotice(Player, "Não conseguiu executar o comando.");
            }

        await Task.CompletedTask;
        }

        private void SendErrorNotice(Player session, string errorMessage)
        {
            using (var p = new Packet())
            {
                p.init_plain(0x40);
                p.WriteByte(7);
                p.WriteString(Player.UserInfo.nickname);
                p.WriteString(errorMessage);
                Player.Send(p);
            }
        }
    }
}