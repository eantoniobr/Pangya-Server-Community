using System;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Extensions
{
    public class DTime
    {
        public DateTime Real_Time { get; set; }
        public int numb12 = 90;
        public int Days;
        public DTime()
        {
            try
            {
                Real_Time = GetNetworkTime();
            }
            catch
            {
                Real_Time = new DateTime(2022, 10, 30);
            }
        }
        DateTime GetNetworkTime()
        {
            try
            {

                //Servidor nacional para melhor latência
                const string ntpServer = "time.windows.com";

                // Tamanho da mensagem NTP - 16 bytes (RFC 2030)
                var ntpData = new byte[48];

                //Indicador de Leap (ver RFC), Versão e Modo
                ntpData[0] = 0x1B; //LI = 0 (sem warnings), VN = 3 (IPv4 apenas), Mode = 3 (modo cliente)

                var addresses = Dns.GetHostEntry(ntpServer).AddressList;

                //123 é a porta padrão do NTP
                var ipEndPoint = new IPEndPoint(addresses[0], 123);
                //NTP usa UDP
                using (var socket = new Socket(addresses[0].AddressFamily, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.Connect(ipEndPoint);

                    //Caso NTP esteja bloqueado, ao menos nao trava o app
                    socket.ReceiveTimeout = 3000;

                    socket.Send(ntpData);
                    socket.Receive(ntpData);
                    socket.Close();
                }

                //Offset para chegar no campo "Transmit Timestamp" (que é
                //o do momento da saída do servidor, em formato 64-bit timestamp
                const byte serverReplyTime = 40;

                //Pegando os segundos
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

                //e a fração de segundos
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

                //Passando de big-endian pra little-endian
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);

                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

                //Tempo em **UTC**
                var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

                return networkDateTime.ToLocalTime();
            }
            catch
            {
                return new DateTime(2023, 09, 07);
            }
        }

        // stackoverflow.com/a/3294698/162671
        uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }


        public bool CheckTime()
        {
            var app_time = new DateTime(2070, 08, 30);
            Days = (app_time - Real_Time).Days;
            return Days > 0;
        }
    }
}
