using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_TICKER_QUEUE_INFO : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            try
            { 
                if (session.UserInfo.block_flag.m_flag.ticker)
                {
                    throw new exception(
                        $"[Handle_PLAYER_TICKER_QUEUE_INFO][Error] PLAYER[UID={session.UserInfo.uid}] tentou consultar fila, mas está bloqueado.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 10, 1));
                }

                // 2. Cálculo da Fila
                // Obtemos a contagem atual de mensagens esperando no TickerManager
                var count = GameServer.getInstance().SendTicker.getSize();

                // Cada ticker leva 30 segundos (30.000 ms) para rodar
                uint timeLeftMs = (uint)(count * 30000);

                // 3. Resposta ao Cliente (0xCA)
                using (var response = new Packet())
                {
                    response.init_plain(0xCA);
                    response.WriteUInt16(Convert.ToUInt16(count));      // Quantidade de pessoas na fila
                    response.WriteUInt32(timeLeftMs);         // Tempo estimado em milissegundos 
                    session.Send(response);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_TICKER_QUEUE_INFO][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Resposta de erro genérica (0x50)
                SendErrorResponse(session, e);
            }

        await Task.CompletedTask;
        }

        private void SendErrorResponse(Player session, exception e)
        {
            using (var p = new Packet())
            {
                p.init_plain(0x50);
                uint errorCode = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.GAME_SERVER)
                                 ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                                 : 1;
                p.WriteUInt32(errorCode);
                session.Send(p);
            }
        }
    }
}