using PangyaAPI.Network.Models;
using PangyaAPI.Utilities; 
using System.Threading.Tasks;

namespace PangyaAPI.Network.Core
{
    public interface IAppServer : IDisposable
    {
        Task StartAsync();
        void Stop();
        void LoadConfig();
        void CloseSession(IAppSession session); 
        bool IsRunning { get; }
        IReadOnlyCollection<IAppSession> Sessions { get; } 
        ServerInfo m_si { get; }
        int m_Bot_TTL { get; } 
        PangyaSyncTimer m_shutdown { get; }
        /// <summary>
        /// TODO:usar pra derrubar o player se em 5 minutos ele nao logar, ou nao executar nenhum pacote.
        /// </summary>
        PangyaSyncTimer m_timer_session_mgr { get; } 
        PangyaSyncTimerManager m_timer_mgr { get; } 
    }
}
