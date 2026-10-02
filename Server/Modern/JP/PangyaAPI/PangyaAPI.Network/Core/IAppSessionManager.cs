using System.Net.Sockets;

namespace PangyaAPI.Network.Core
{
    public interface IAppSessionManager
    {
        // Gerenciamento Básico
        IAppSession Add(IAppServer server, Socket socket);
        void Remove(IAppSession session);
        IAppSession Get(int id);

        // Status do Servidor
        int Count { get; }
        int MaxUsers { get; }
        bool IsFull();

        // Buscas por Identidade (Retornam a interface base) 
        bool HasSessionWithIP(string ip); 
    }
}