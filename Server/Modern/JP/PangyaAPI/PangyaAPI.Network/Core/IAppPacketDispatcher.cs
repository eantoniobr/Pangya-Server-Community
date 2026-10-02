using System;

namespace PangyaAPI.Network.Core
{
    // Adicionamos TId como um parâmetro genérico que deve ser um Enum
    public interface IAppPacketDispatcher<TSession, TId>
        where TSession : IAppSession
        where TId : struct, Enum
    {
        // O Dispatch agora usa o TId para identificar o pacote recebido
        void Dispatch(TSession session, TId id, Packet packet);

        // O Register agora aceita o seu Enum específico (PacketIDClient)
        void Register(TId id, IPacketHandler<TSession> handler);
    }


    // Adicionamos TId como um parâmetro genérico que deve ser um Enum
    public interface IAuthPacketDispatcher<TSession, TId>
        where TSession : IAppSession
        where TId : struct, Enum
    {
        // O Dispatch agora usa o TId para identificar o pacote recebido
        void Dispatch(TSession session, TId id, Packet packet);

        // O Register agora aceita o seu Enum específico (PacketIDClient)
        void Register(TId id, IAuthPacketHandler<TSession> handler);
    }
}