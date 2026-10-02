using Pangya_GameServer.Flags;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_NOTIFY_NOT_DISPLAY_PRIVATE_MESSAGE_NOW : IPacketHandler<Player>
    {

        public async Task Handle(Player session, Packet pkt)
        {
            try
            { 
                string nicknameSender = pkt.ReadPStr();

                if (string.IsNullOrWhiteSpace(nicknameSender))
                {
                    throw new exception($"[WhisperRefuse] Player[UID={session.UserInfo.uid}] enviou um nickname vazio.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 0x750050, 0));
                }

                if (!Tools.Sanitize(nicknameSender))
                {
                    throw new exception($"[WhisperRefuse] Player[UID={session.UserInfo.uid}] enviou nickname com caracteres suspeitos: {nicknameSender}",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1));
                }

                // 2. Localiza o remetente original da mensagem
                var senderSession = GameServer.getInstance().FindSessionByNickname(nicknameSender);

                if (senderSession != null && senderSession.Connected)
                {
                    // Log do evento
                    _smp.message_pool.getInstance().push(new message(
                        $"[WhisperRefuse] Player[{session.UserInfo.nickname}] recusou automaticamente o whisper de [{nicknameSender}].",
                        type_msg.CL_FILE_LOG_AND_CONSOLE)); 
                    var response = Handle_PACKET_RESPONSE.pacote040(nicknameSender, "", eChatMsg.CHAT_REFUSE_WHISPER); 
                    senderSession.Send(response);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_NOTIFY_NOT_DISPLAY_PRIVATE_MESSAGE_NOW][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}