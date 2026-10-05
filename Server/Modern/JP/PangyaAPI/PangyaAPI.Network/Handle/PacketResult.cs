using PangyaAPI.Network.Core;

namespace PangyaAPI.Network.Handle
{
    public class PacketResult : IPacketResult, IDisposable
    {
        private bool _disposed = false;

        public Packet _Packet { get; set; }
        public int Type => _Packet == null ? -1 : _Packet.Type;
        public byte[] Message => _Packet == null ? Array.Empty<byte>() : _Packet.Message;

        public int Size => Message.Length;

        // Retorna a quantidade de bytes que ainda NÃO foram lidos do stream
        public int UnreadBytes => _Packet == null ? 0 : (_Packet.Size - _Packet.offset);

        public int offset => _Packet?.offset ?? 0;

        /// <summary>
        /// Pulso/Avanço manual no OffSet do stream
        /// </summary>
        public void SkipBytes(int count)
        {
            if (_Packet != null && count > 0)
            {
                _Packet.ReadBytes(Math.Min(count, UnreadBytes));
            }
        }

        public virtual void Load() { }

        #region Métodos de Leitura
        public sbyte ReadSByte() => _Packet.ReadSByte();

        public sbyte[] ReadSBytes(int count)
        {
            var value = new sbyte[count];
            for (int i = 0; i < count; i++)
                value[i] = _Packet.ReadSByte();
            return value;
        }

        public byte ReadByte() => _Packet.ReadByte();
        public bool ReadUInt32(out uint value) => _Packet.ReadUInt32(out value);
        public uint ReadUInt32() => _Packet.ReadUInt32();
        public ushort ReadUInt16() => _Packet.ReadUInt16();

        public uint[] ReadUInt32(int count)
        {
            uint[] values = new uint[count];
            for (int i = 0; i < count; i++) values[i] = ReadUInt32();
            return values;
        }

        public int[] ReadInt32(int count)
        {
            int[] values = new int[count];
            for (int i = 0; i < count; i++) values[i] = ReadInt32();
            return values;
        }

        public ushort[] ReadUInt16(int count)
        {
            ushort[] values = new ushort[count];
            for (int i = 0; i < count; i++) values[i] = ReadUInt16();
            return values;
        }

        public short[] ReadInt16(int count)
        {
            short[] values = new short[count];
            for (int i = 0; i < count; i++) values[i] = ReadInt16();
            return values;
        }

        public short ReadInt16() => _Packet.ReadInt16();
        public int ReadInt32() => _Packet.ReadInt32();
        public long ReadInt64() => _Packet.ReadInt64();

        public long[] ReadInt64(int count)
        {
            long[] values = new long[count];
            for (int i = 0; i < count; i++) values[i] = ReadInt64();
            return values;
        }

        public ulong ReadUInt64() => _Packet.ReadUInt64();
        public float Readfloat() => _Packet.ReadSingle();
        public float ReadSingle() => _Packet.ReadSingle();
        public double ReadDouble() => _Packet.ReadDouble();

        public string ReadPStr()
        {
            try { return _Packet.ReadPStr(); }
            catch { throw new Exception("Fail to read string from packet"); }
        }

        public bool ReadPStr(out string value)
        {
            try { return _Packet.ReadPStr(out value); }
            catch
            {
                value = "";
                return false;
            }
        }

        public string ReadPStr(int _length) => _Packet.ReadPStr(_length);
        public byte[] ReadBytes(int _size) => _Packet.ReadBytes(_size);
        public byte[] ReadBytes() => _Packet.ReadBytes();
        public string ReadString() => ReadPStr();
        public string ReadString(int len) => _Packet.ReadPStr(len);
        #endregion

        #region Implementação IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Caso a classe Packet possua Dispose, chame-o aqui:
                    (_Packet as IDisposable)?.Dispose();
                    _Packet = null!;
                }
                _disposed = true;
            }
        }
        #endregion
    }
}