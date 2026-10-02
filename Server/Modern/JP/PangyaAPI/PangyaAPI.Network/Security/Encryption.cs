using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Security
{
    public class Encryption
    {
        private byte privateKey;
        private byte publicKey;

        public Encryption(int parseKey, int lowKey)
        {
            int index = (parseKey << 8) | lowKey;
            this.privateKey = EncryptTableKeys.PRIVATE_KEY_TABLE[index];
            this.publicKey = EncryptTableKeys.PUBLIC_KEY_TABLE[index];
        }
          
        private byte _8bitShift(uint bits, int shift)
        {
            shift *= 8;
            return (byte)((bits >> shift) & 0xFF);
        }

        private void SimpleStreamEncrypt(byte[] buff, uint publicKey)
        {
            if (buff.Length > 0)
            {
                // Cria uma cópia do buffer original (equivalente ao Buffer.alloc + set)
                byte[] plain = new byte[buff.Length];
                Buffer.BlockCopy(buff, 0, plain, 0, buff.Length);

                int headerLimit = buff.Length >= 4 ? 4 : buff.Length;

                // Encriptação dos primeiros 4 bytes
                for (int i = 0; i < headerLimit; i++)
                {
                    buff[i] = (byte)((plain[i] ^ _8bitShift(publicKey, i)) & 0xFF);
                }

                // Encriptação encadeada
                for (int i = 4; i < buff.Length; i++)
                {
                    buff[i] = (byte)((buff[i] ^ plain[i - 4]) & 0xFF);
                }
            }
        }

        private void SimpleStreamDecrypt(byte[] buff, uint publicKey)
        {
            if (buff.Length > 0)
            {
                int headerLimit = buff.Length >= 4 ? 4 : buff.Length;

                // Decriptação dos primeiros 4 bytes
                for (int i = 0; i < headerLimit; i++)
                {
                    buff[i] = (byte)((buff[i] ^ _8bitShift(publicKey, i)) & 0xFF);
                }

                // Decriptação encadeada
                for (int i = 4; i < buff.Length; i++)
                {
                    buff[i] = (byte)((buff[i] ^ buff[i - 4]) & 0xFF);
                }
            }
        }

        public byte Encrypt(byte[] buffer)
        {
            if (buffer == null || buffer.Length <= 0)
                return 0;

            // Escreve a Private Key no primeiro byte
            buffer[0] = (byte)(this.privateKey & 0xFF);

            SimpleStreamEncrypt(buffer, this.publicKey);

            return Convert.ToByte(this.publicKey); 
        }

        public byte Decrypt(byte[] buffer)
        {
            if (buffer == null || buffer.Length <= 0)
                return 0;

            SimpleStreamDecrypt(buffer, this.publicKey);

            return Convert.ToByte(this.privateKey);
        }
    }
}
