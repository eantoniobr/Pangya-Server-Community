using PangyaAPI.Utilities; 
namespace PangyaAPI.Network
{
    public partial class Packet : IDisposable
    {

        // --- MÉTODOS DE ESCRITA (Delegados ao Writer) ---
        public void Write(sbyte data)
        {
            Writer.Write(data);
        }

        public void Write(bool data)
        {
            Writer.Write(data);
        }

        public void Write(byte data)
        {
            Writer.Write(data);
        }


        public void Write(short data)
        {
            Writer.Write(data);
        }

        public void Write(int data)
        {
            Writer.Write(data);
        }

        public void Write(ushort data)
        {
            Writer.Write(data);
        }

        public void Write(uint data)
        {
            Writer.Write(data);
        }

        public void Write(long data)
        {
            Writer.Write(data);
        }

        public void Write(ulong data)
        {
            Writer.Write(data);
        }

        public void Write(float data)
        {
            Writer.Write(data);
        }

        public void Write(double data)
        {
            Writer.Write(data);
        }

        public void WriteSByte(sbyte data)
        {
            Writer.WriteSByte(data);

        }

        public void WriteByte(Enum data)
        {
            Writer.WriteByte(Convert.ToByte(data));
        }

        public void WriteByte(byte data)
        {
            Writer.WriteByte(data);
        }

        public void WriteByte(int data)
        {
            Writer.WriteByte(data);
        }
        
        public void WriteInt16(int data)
        {
            Writer.Write(Convert.ToInt16(data));
        }

        public void WriteInt16(short data)
        {
            Writer.Write(data);
        }

        public void WriteInt16(Enum data)
        {
            Writer.Write(Convert.ToInt16(data));
        }

        public void WriteUInt16(Enum data)
        {
            Writer.Write(Convert.ToUInt16(data));
        }

        public void WriteInt16(short[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Writer.Write(data[i]);
        }

        public void WriteUInt16(ushort[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Writer.Write(data[i]);
        }

        public void WriteUInt32(uint[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Writer.Write(data[i]);
        }

        public void WriteInt32(int data)
        { 
            Writer.Write(data);
        }

        public void WriteUInt16(ushort data)
        {
            Writer.Write(data);
        }

        public void WriteUInt32(uint data)
        { 
            Writer.Write(data);
        }

        public void WriteInt64(long data)
        {
            Writer.Write(data);
        }

        public void WriteInt64(long[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Writer.Write(data[i]); 
        }

        public void WriteUInt64(ulong data)
        {
            Writer.Write(data);
        }

        public void WriteFloat(float data)
        {
            Writer.Write(data);
        }

        public void WriteSingle(float data)
        {
            Writer.Write(data);
        }

        public void WriteDouble(double data)
        {
            Writer.Write(data);
        }

        public void WriteBytes(byte[] _buff)
        {
            for (int i = 0; i < _buff.Length; i++)
                Writer.Write(_buff[i]);
        }

        public void WriteBytes(byte[] _buff, int size)
        {
            for (int i = 0; i < size; i++)
                Writer.Write(_buff[i]);
        }

        public void WriteSBytes(sbyte[] _buff)
        {
            for (int i = 0; i < _buff.Length; i++)
                Writer.Write(_buff[i]);
        }



        public void WriteZero(int _size)
        {
            if (_size <= 0) return;

            Writer.WriteZero(_size);
        }

        public bool WriteTime(SystemTime? date)
        {
            try
            {
                if (date == null)
                {
                    WriteZero(16);
                    return true;
                }
                Writer.WriteTime(date.ConvertTime());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WriteTime(DateTime? date)
        {
            try
            {
                if (date.HasValue == false || date?.Ticks == 0)
                {
                    WriteZero(16);
                    return true;
                }
                Writer.WriteTime(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Write Pangya Time
        /// </summary>
        /// <returns></returns>
        public bool WriteTime()
        {
            DateTime date = DateTime.Now;
            try
            {
                Writer.WriteTime(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteString(string _str)
        {
            Writer.WriteString(_str);
        }

        public void WriteString(string _str, int _size)
        {
            Writer.WriteString(_str, _size);
        }

        public string Log()
        {
            return Message.HexDump();
        }
    }
}
