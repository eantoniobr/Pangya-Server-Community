using Pangya_GameServer.Flags;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Feature.GM
{
    public class WindCommand : IGMCommand
    {
        public async Task Execute(Player session, Packet pkt)
        { 
            try
            {  
                var room = session.GetGameRoom();

                // 3. Validação de Integridade
                if (room == null)
                {
                    throw new exception($"[GM::Wind] Sala {session.UserInfo.Member.sala_numero} não encontrada para o player [UID={session.UserInfo.uid}].",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0x5700100));
                }
                
                if (room.GetTipo() != Flags.ROOM_INFO_TYPE.LOUNGE || room.GetTipo() != ROOM_INFO_TYPE.PANG_BATTLE || room.GetTipo() != ROOM_INFO_TYPE.STROKE || room.GetTipo() != ROOM_INFO_TYPE.MATCH)
                {
                    throw new exception("[Room::RequestExecCCGChangeWindVersus] [Error] PLAYER[UID=" + session.UserInfo.uid + "] tentou executar o comando de troca de vento na sala[NUMERO=" + room.GetRoomId() + ", TIPO=" + Convert.ToString(room.GetTipo()) + "], mas o tipo da sala nao é Stroke ou Match modo. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.ROOM,
                        1, 0x5700100));
                }

                //somente no lounger é bloqueado...
                if (room != null && room.GameInitState > 0)
                {
                    // Delegamos a lógica de alteração do vento Versus para a instância da sala
                    room.RequestExecCCGChangeWind(session, pkt);

                    _smp.message_pool.getInstance().push(new message(
                        $"[GM::Wind][Success] {session.UserInfo.nickname} alterou o vento na Sala {room.GetRoomId()} (Canal: {session.GetChannel().getName()})",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
                else
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[GM::Wind][Warning] {session.UserInfo.nickname} tentou alterar o vento sem estar em uma sala ativa.",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[WindCommand][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}