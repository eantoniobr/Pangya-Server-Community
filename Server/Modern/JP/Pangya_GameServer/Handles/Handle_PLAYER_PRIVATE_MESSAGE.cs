using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_PRIVATE_MESSAGE : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            try
            {  
                string targetNickname = Packet.ReadPStr();
                string messageContent = Packet.ReadPStr();

                if (string.IsNullOrWhiteSpace(targetNickname) || string.IsNullOrWhiteSpace(messageContent))
                    return; // Silencioso para evitar spam de exceção por pacotes malformados

                if (!Tools.Sanitize(targetNickname) || !Tools.Sanitize(messageContent))
                    throw new exception("Tentativa de injeção ou caracteres inválidos no PM.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1));
                 

                // 3. Busca do Destinatário
                var targetPlayer =  GameServer.getInstance().FindSessionByNickname(targetNickname);

                // Verificações de disponibilidade (Offline, Whisper Off, Away)
                if (targetPlayer == null || !targetPlayer.Connected || targetPlayer.UserInfo.WhisperState != 1)
                {
                    SendWhisperError(Player, targetNickname, 6); // 6 = Player Offline/Whisper Off
                    return;
                }
                 
                NotifyGMsOfPrivateMessage(Player, targetPlayer, messageContent);

                _smp.message_pool.getInstance().push(new message(
                    $"[PM][Log] {Player.UserInfo.nickname} -> {targetPlayer.UserInfo.nickname}: {messageContent}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE)); 

                // Resposta para quem ENVIOU (Confirmação na aba de Whisper)
                var pFrom = new Packet(0x84);
                pFrom.WriteByte(0); // Tipo 0: Enviado por mim
                pFrom.WriteString(targetPlayer.UserInfo.nickname);
                pFrom.WriteString(messageContent);
                Player.Send(pFrom);

                // Envio para quem RECEBEU
                var pTo = new Packet(0x84);
                pTo.WriteByte(1); // Tipo 1: Recebido de alguém
                pTo.WriteString(Player.UserInfo.nickname);
                pTo.WriteString(messageContent);
                targetPlayer.Send(pTo);
                 
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[PM][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                SendWhisperError(Player, "", 5); // Erro genérico
            }

        await Task.CompletedTask;
        }

        private void SendWhisperError(Player session, string nickname, byte errorType)
        {
            var p = new Packet(0x40);
            p.WriteByte(errorType);
            p.WriteString(nickname);
            Player.Send(p);
        }

        private void NotifyGMsOfPrivateMessage(Player sender, Player receiver, string msg)
        {
            var gms = GameServer.getInstance().FindAllGM();
            if (gms == null || !gms.Any()) return;

            string spyMsg = $"\\5{sender.UserInfo.nickname}>{receiver.UserInfo.nickname}: '{msg}'";

            foreach (var gm in gms)
            {
                // Verifica se o GM está com o modo espião/whisper ativo e não é um dos envolvidos
                if (gm.UserInfo.uid != sender.UserInfo.uid && gm.UserInfo.uid != receiver.UserInfo.uid)
                {
                    var p = new Packet(0x40);
                    p.WriteByte(0); // Chat Normal
                    p.WriteString("\\1[PM-Spy]");
                    p.WriteString(spyMsg);
                    gm.Send(p);
                }
            }
        }
    }
}