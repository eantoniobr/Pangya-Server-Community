using System;
using System.Threading.Tasks;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Feature.GM
{
    public class WeatherCommand : IGMCommand
    {
        public async Task Execute(Player session, Packet pkt)
        { 
            try
            {
                // 2. Localização da Sala
                // 3. Validação de Integridade da Sala
                var room = session.GetRoom() ?? throw new exception($"[GM::Weather] Sala {session.UserInfo.Member.sala_numero} não encontrada para o player [UID={session.UserInfo.uid}].",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0x5700100));

                // 4. Execução e Log
                var game = session.GetGameRoom();
                if (game == null && room != null)
                {
                    byte WeatherChatRoom = pkt.ReadByte();

                    // UPDATE ON GAME
                    Packet p = new Packet((ushort)0x9E);
                    p.WriteUInt16(WeatherChatRoom);
                    p.WriteByte(1);  
                    room.SendBroadCast(p);

                    _smp.message_pool.getInstance().push(new message(
                        $"[GM::Weather][Success] {session.UserInfo.nickname} alterou o clima na Sala {room.GetRoomId()} (Canal: {session.GetChannel()?.getName()})",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
                else if (game != null)
                {
                    game.RequestExecCCGChangeWeather(session, pkt);

                    _smp.message_pool.getInstance().push(new message(
                        $"[GM::Weather][Success] {session.UserInfo.nickname} alterou o clima na Sala {room.GetRoomId()} (Canal: {session.GetChannel()?.getName()})",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
                else
                {
                    // Caso o GM esteja no Lobby do canal e tente mudar o clima global do canal (se suportado)
                    _smp.message_pool.getInstance().push(new message(
                        $"[GM::Weather][Warning] {session.UserInfo.nickname} tentou mudar o clima, mas não está em uma sala.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[WeatherCommand][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}