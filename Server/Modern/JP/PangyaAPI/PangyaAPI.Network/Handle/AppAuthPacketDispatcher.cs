using PangyaAPI.Network.Core;
using PangyaAPI.Utilities.Log; 
namespace PangyaAPI.Network.Handle
{
    public class AppAuthPacketDispatcher<TSession, TId> : IAuthPacketDispatcher<TSession, TId>
        where TSession : IAppSession
        where TId : struct, Enum
    {
        // Dicionário usando o Enum diretamente como chave
        private readonly Dictionary<TId, IAuthPacketHandler<TSession>> _handlers = new();

        public void Register(TId id, IAuthPacketHandler<TSession> handler)
        {
            try
            {
                _handlers[id] = handler;
            }
            catch (Exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Dispatcher][Error] Falha ao registrar {id}: {e.Message}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }

        public void Dispatch(TSession session, TId id, Packet packet)
        {
            // Busca o handler usando o ID (Enum) fornecido
            if (_handlers.TryGetValue(id, out var handler))
            {
                try
                {
                    handler.Handle(session, packet);
                }
                catch (Exception ex)
                {
                    _smp.message_pool.getInstance().push(new message(
                        $"[Dispatcher][CRITICAL] Erro no Handler {id} (0x{Convert.ToInt16(id):X2}): {ex.Message}",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            else
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Dispatcher][Unknown] Pacote {id} (0x{Convert.ToInt16(id):X2}) não tratado.",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}