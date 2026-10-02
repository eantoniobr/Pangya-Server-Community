using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using System.Buffers;

public class AppAuthPacketParser : IAuthPacketParser
{
    // Buffer para acumular fragmentos de pacotes
    private byte[] _buffer = new byte[ushort.MaxValue];
    private int _length = 0;

    // Constantes de Segurança
    private const int MAX_PACKET_SIZE = 8192; // O limite do buffer de rede, nada no Pangya deve passar disso
    private const int MIN_HEADER_SIZE = 5;

    public List<Packet> Parse(int _parseKey, byte[] data, int received)
    {
        var packets = new List<Packet>();

        // 1. Prevenção de Buffer Overflow interno
        if (_length + received > _buffer.Length)
        {
            _length = 0; // Limpa para evitar crash, ou você pode desconectar o client aqui.
            return packets;
        }

        Buffer.BlockCopy(data, 0, _buffer, _length, received);
        _length += received;

        int offset = 0;

        // 2. Loop enquanto houver bytes suficientes para ler ao menos o Header
        while (_length - offset >= MIN_HEADER_SIZE)
        {
            ushort payloadSize = BitConverter.ToUInt16(_buffer, offset + 1);
            int fullPacketSize = payloadSize + (_parseKey != -1 ? 4 : 3);

            // --- SANITY CHECK: Segurança contra ataques de pacotes gigantes ---
            if (fullPacketSize > MAX_PACKET_SIZE || fullPacketSize < MIN_HEADER_SIZE)
            {
                _length = 0; // Descarta tudo
                // Aqui você deve chamar o método de desconectar da sua session
                return null;
            }

            // Se o pacote ainda não chegou inteiro no stream TCP, aguardamos mais dados
            if (_length - offset < fullPacketSize)
                break;

            byte[] packetBuffer = new byte[fullPacketSize];
            Buffer.BlockCopy(_buffer, offset, packetBuffer, 0, fullPacketSize);

            var packet = DecodeBufferData(packetBuffer, _parseKey);

            if (packet != null)
            {
                packets.Add(packet);
            }
            else
            {
                // Este é o log que apareceu para você. Se o packet for 0xFFFF, o UnMakePacket falha.
                Console.WriteLine($"[AuthPacketParser] => Falha na decodificação do pacote de {_parseKey}");
            }

            offset += fullPacketSize;
        }

        // 5. Limpeza do buffer (Move os fragmentos restantes para o início)
        if (offset > 0)
        {
            int remaining = _length - offset;
            if (remaining > 0)
            {
                Buffer.BlockCopy(_buffer, offset, _buffer, 0, remaining);
            }
            _length = remaining;
        }

        return packets;
    }

    private Packet DecodeBufferData(byte[] data, int parseKey)
    {
        try
        {
            int packetHeaderLength = parseKey != -1 ? 4: 3;
            if (data.Length < MIN_HEADER_SIZE) return null;

            ushort length = BitConverter.ToUInt16(data, 1);

            if ((length + packetHeaderLength) > data.Length)
                return null;

            var packet = new Packet();
            byte[] exactPacketData = new byte[length + packetHeaderLength];
            Buffer.BlockCopy(data, 0, exactPacketData, 0, exactPacketData.Length);

            // Tenta desserializar e descriptografar
            if (!packet.UnMakePacket(exactPacketData, parseKey))
            {
                // Se o pacote for lixo (como 0xFFFF), ele cairá aqui
                return null;
            }

            return packet;
        }
        catch
        {
            return null;
        }
    }
}