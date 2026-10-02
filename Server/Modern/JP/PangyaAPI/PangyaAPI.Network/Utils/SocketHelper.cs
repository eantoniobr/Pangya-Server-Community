using System.Net.Sockets;
namespace PangyaAPI.Network.Utils
{

    public static class SocketHelper
    {
        public static void Configure(Socket socket, int sendTimeoutMs = 10000)
        {
            if (socket == null) return;

            try
            { 
                socket.NoDelay = true;

                // Timeout de envio — Timeout 3
                // Se SendAsync() travar por mais de X ms → SocketException → sessão fechada
                // Isso elimina "ghost connections" que ficam ocupando slot sem DC real
                socket.SendTimeout = sendTimeoutMs; 
                socket.ReceiveTimeout = 0; 
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                 
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                 
                socket.SendBufferSize = 65536;
                socket.ReceiveBufferSize = 65536; 
                socket.LingerState = new LingerOption(false, 0);
            }
            catch
            {
                // Ignora — socket pode ter sido fechado entre a criação e a configuração
            }
        }



        public static void SafeClose(this Socket socket)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            catch { }

            try
            {
                socket.Close();
            }
            catch { }
        }
    }
}
