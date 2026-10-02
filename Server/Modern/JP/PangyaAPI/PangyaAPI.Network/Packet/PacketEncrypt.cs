using PangyaAPI.Network.Security;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Models;
namespace PangyaAPI.Network
{
    public partial class Packet : IDisposable
    { 
        /// <summary>
        /// Packet Client Crypt + Compress (LZO)
        /// </summary>
        public byte[] MakePacketComplete(int _parseKey)
        {
            // 1. Definições iniciais
            byte[] payload = Writer.GetBytes;
            // Se for Raw, o lowKey é 0. Se for Crypt, é um salt aleatório.
            byte lowKey = (byte)(_parseKey == -1 ? 0 : Random.Shared.Next(0, 254));

            byte[] toEncrypt;

            if (_parseKey == -1) // CASO RAW (Handshake)
            {
                toEncrypt = new byte[1 + payload.Length];
                toEncrypt[0] = 0; // Raw marker (no lugar do checkKey)
                Buffer.BlockCopy(payload, 0, toEncrypt, 1, payload.Length);
            }
            else
            {
                byte[] compressedData = Lzo.Compress(payload);

                toEncrypt = new byte[1 + compressedData.Length];
                Buffer.BlockCopy(compressedData, 0, toEncrypt, 1, compressedData.Length);

                Encryption enc = new Encryption(_parseKey, lowKey);
                enc.Encrypt(toEncrypt);
            }

            // 5. MONTAGEM DO HEADER DE REDE (Igual para todos)
            ushort finalSize = (ushort)toEncrypt.Length;
            byte[] finalPacket = new byte[3 + finalSize];

            finalPacket[0] = lowKey;
            finalPacket[1] = (byte)(finalSize & 0xFF);
            finalPacket[2] = (byte)((finalSize >> 8) & 0xFF);

            Buffer.BlockCopy(toEncrypt, 0, finalPacket, 3, toEncrypt.Length);

            return finalPacket;
        }

        /// <summary>
        /// Packet Client Crypt (no compress)
        /// </summary>
        public byte[] MakePacket(int _parseKey, int _seq = 0)
        {
            int PACKET_HEADER_SIZE = 4;
            byte low_key = (byte)Random.Shared.Next(0, 256);
             
            byte[] _Buffer = GetBytes;
             
            int size_raw =  _Buffer.Length + PACKET_HEADER_SIZE;

            if (_parseKey != -1)
                size_raw++;

            var ret_buff = new byte[size_raw];
             
            int destIndex = PACKET_HEADER_SIZE + (_parseKey != -1 ? 1 : 0);
             
            System.Buffer.BlockCopy(_Buffer, 0, ret_buff, destIndex, size_raw - 5);

            // --- Header (Manual para garantir Little Endian igual ao JS) ---
            ushort pLen = (ushort)(size_raw - PACKET_HEADER_SIZE);
            ret_buff[0] = low_key;
            ret_buff[1] = (byte)((pLen >> 0) & 0xFF);
            ret_buff[2] = (byte)((pLen >> 8) & 0xFF);
            ret_buff[3] = (byte)(_seq & 0xFF);

            if (_parseKey != -1)
            {
                var crypt = new Encryption(_parseKey, low_key);
                 
                int encryptLength = size_raw - PACKET_HEADER_SIZE;
                Span<byte> toEncryptSpan = ret_buff.AsSpan(PACKET_HEADER_SIZE, encryptLength);
                 
                byte[] dataArray = toEncryptSpan.ToArray();
                this.public_key = crypt.Encrypt(dataArray);
                 
                System.Buffer.BlockCopy(dataArray, 0, ret_buff, PACKET_HEADER_SIZE, dataArray.Length);
            }

            return ret_buff;
        }

        /// <summary>
        /// Packet Client Decrypt(no decompress)
        /// </summary>
        public bool UnMakePacket(byte[] _buff, int _parseKey)
        {
            // 1. Validação básica de integridade
            if (_buff == null || _buff.Length < 4) return false;

            try
            { 
                var reader = new PangyaBinaryReader(_buff); 
                byte lowKey = reader.ReadByte();
                short declaredLength = reader.ReadInt16();
                byte seq = reader.ReadByte();

                byte[] decryptedPayload;

                // packet raw -> packet key não presente, apenas o payload
                if (_parseKey == -1)
                {
                    // Apenas pega o restante do buffer
                    decryptedPayload = reader.GetRemainingData();
                }
                else
                {
                    // packet client real
                    var crypt = new Encryption(_parseKey, lowKey);
                    byte[] encryptedData = reader.GetRemainingData();

                    this.private_key = crypt.Decrypt(encryptedData);
                    reader = new PangyaBinaryReader(encryptedData);

                    var check_key = reader.ReadByte();
                    // Validação da Criptografia (Check de integridade)
                    if (check_key != this.private_key)
                        return false;
                     
                    decryptedPayload = reader.GetRemainingData();
                }


                _ms = new MemoryStream(decryptedPayload);
                Reader = new PangyaBinaryReader(_ms);


                this.offset = 0;
                this.Type = (ushort)Reader.ReadInt16();

                return true;
            }
            catch (Exception)
            {
                // Caso o buffer termine antes do esperado ou ocorra erro na leitura
                return false;
            }
        }

        public void PrintToConsole()
        {
            var data = Reader.GetRemainingData();
            Console.WriteLine($"[Packet 0x{Type:X2}] Size: {data.Length}");
            Console.WriteLine("Hex: " + BitConverter.ToString(data).Replace("-", " "));
        }
    }
}