using System.Net.Sockets;

namespace PangyaAPI.Network.Utils
{
    public static class NetworkExtensions
    {
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch
            {
                return false;
            }
        }
    }
}
