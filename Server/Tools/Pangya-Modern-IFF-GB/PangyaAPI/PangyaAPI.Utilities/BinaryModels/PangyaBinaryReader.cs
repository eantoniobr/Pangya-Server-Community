using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PangyaAPI.Utilities.BinaryModels
{
    public class PangyaBinaryReader
    {
        private const int MaxCharBytesSize = 128;

        private Stream m_stream;

        private byte[] m_buffer;

        private Encoding m_decoder;

        private byte[] m_charBytes;

        private char[] m_singleChar;

        private char[] m_charBuffer;

        private int m_maxCharsSize;

        private bool m_2BytesPerChar;

        private bool m_isMemoryStream;

        private bool m_leaveOpen;


        public virtual Stream BaseStream
        {
    
            get
            {
                return m_stream;
            }
        }


        public PangyaBinaryReader(Stream input)
            : this(input, new UTF8Encoding(), leaveOpen: false)
        {
        }


        public PangyaBinaryReader(Stream input, Encoding encoding)
            : this(input, encoding, leaveOpen: false)
        {
        }


        public PangyaBinaryReader(Stream input, Encoding encoding, bool leaveOpen)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            if (!input.CanRead)
            {
                throw new ArgumentException(("Argument_StreamNotReadable"));
            }

            m_stream = input;
            m_decoder = encoding;
            m_maxCharsSize = encoding.GetMaxCharCount(128);
            int num = encoding.GetMaxByteCount(1);
            if (num < 16)
            {
                num = 16;
            }

            m_buffer = new byte[num];
            m_2BytesPerChar = encoding is UnicodeEncoding;
            m_isMemoryStream = m_stream.GetType() == typeof(MemoryStream);
            m_leaveOpen = leaveOpen;
        }

      
        public virtual int Read()
        {
            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            return InternalReadOneChar();
        }


        public virtual bool ReadBoolean()
        {
            FillBuffer(1);
            return m_buffer[0] != 0;
        }


        public virtual byte ReadByte()
        {
            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            int num = m_stream.ReadByte();
            if (num == -1)
            {
                throw new Exception("leitura quebrada, valor estar -1");
            }

            return (byte)num;
        }



        public virtual sbyte ReadSByte()
        {
            FillBuffer(1);
            return (sbyte)m_buffer[0];
        }


        public virtual char ReadChar()
        {
            int num = Read();
            if (num == -1)
            {
                throw new Exception("leitura quebrada, valor estar -1");
            }

            return (char)num;
        }


        public virtual short ReadInt16()
        {
            FillBuffer(2);
            return (short)(m_buffer[0] | (m_buffer[1] << 8));
        }



        public virtual ushort ReadUInt16()
        {
            FillBuffer(2);
            return (ushort)(m_buffer[0] | (m_buffer[1] << 8));
        }


        public virtual int ReadInt32()
        {
            if (m_isMemoryStream)
            {
                if (m_stream == null)
                {
                   throw new Exception("m_stream = null !");
                }

                MemoryStream memoryStream = m_stream as MemoryStream;
                return memoryStream.Read(new byte[4],0, 4);
            }

            FillBuffer(4);
            return m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24);
        }



        public virtual uint ReadUInt32()
        {
            FillBuffer(4);
            return (uint)(m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24));
        }


        public virtual long ReadInt64()
        {
            FillBuffer(8);
            uint num = (uint)(m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24));
            uint num2 = (uint)(m_buffer[4] | (m_buffer[5] << 8) | (m_buffer[6] << 16) | (m_buffer[7] << 24));
            return (long)(((ulong)num2 << 32) | num);
        }



        public virtual ulong ReadUInt64()
        {
            FillBuffer(8);
            uint num = (uint)(m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24));
            uint num2 = (uint)(m_buffer[4] | (m_buffer[5] << 8) | (m_buffer[6] << 16) | (m_buffer[7] << 24));
            return ((ulong)num2 << 32) | num;
        }



        public unsafe virtual float ReadSingle()
        {
            FillBuffer(4);
            uint num = (uint)(m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24));
            return *(float*)(&num);
        }



        public unsafe virtual double ReadDouble()
        {
            FillBuffer(8);
            uint num = (uint)(m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24));
            uint num2 = (uint)(m_buffer[4] | (m_buffer[5] << 8) | (m_buffer[6] << 16) | (m_buffer[7] << 24));
            ulong num3 = ((ulong)num2 << 32) | num;
            return *(double*)(&num3);
        }


        public virtual decimal ReadDecimal()
        {
            FillBuffer(16);
            try
            {
                return Convert.ToDecimal(m_buffer);
            }
            catch (ArgumentException innerException)
            {
                throw new IOException(("Arg_DecBitCtor"), innerException);
            }
        }


        public virtual string ReadString()
        {
            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            int num = 0;
            int num2 = Read7BitEncodedInt();
            if (num2 < 0)
            {
                throw new IOException(($"IO.IO_InvalidStringLen_Len: {num2}"));
            }

            if (num2 == 0)
            {
                return string.Empty;
            }

            if (m_charBytes == null)
            {
                m_charBytes = new byte[128];
            }

            if (m_charBuffer == null)
            {
                m_charBuffer = new char[m_maxCharsSize];
            }

            StringBuilder stringBuilder = null;
            do
            {
                int count = ((num2 - num > 128) ? 128 : (num2 - num));
                int num3 = m_stream.Read(m_charBytes, 0, count);
                if (num3 == 0)
                {
                    throw new Exception("leitura quebrada, valor estar -1");
                }

                int chars = m_decoder.GetChars(m_charBytes, 0, num3, m_charBuffer, 0);
                if (num == 0 && num3 == num2)
                {
                    return new string(m_charBuffer, 0, chars);
                }

                if (stringBuilder == null)
                {
                    stringBuilder = new StringBuilder(360);
                }

                stringBuilder.Append(m_charBuffer, 0, chars);
                num += num3;
            }
            while (num < num2);
            return stringBuilder.ToString();
        }



        public virtual int Read(char[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer", ("ArgumentNull_Buffer"));
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }

            if (buffer.Length - index < count)
            {
                throw new ArgumentException(("Argument_InvalidOffLen"));
            }

            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            return InternalReadChars(buffer, index, count);
        }


        private unsafe int InternalReadChars(char[] buffer, int index, int count)
        {
            int num = 0;
            int num2 = count;
            if (m_charBytes == null)
            {
                m_charBytes = new byte[128];
            }

            while (num2 > 0)
            {
                int num3 = 0;
                num = num2;
                var decoderNLS = m_decoder;
                if (decoderNLS != null && num > 1)
                {
                    num--;
                }

                if (m_2BytesPerChar)
                {
                    num <<= 1;
                }

                if (num > 128)
                {
                    num = 128;
                }

                int num4 = 0;
                byte[] array = null;
                if (m_isMemoryStream)
                {
                    MemoryStream memoryStream = m_stream as MemoryStream;
                    num4 = (int)memoryStream.Position;
                    num = memoryStream.Read(new byte[4],0,num);
                    array = memoryStream.GetBuffer();
                }
                else
                {
                    num = m_stream.Read(m_charBytes, 0, num);
                    array = m_charBytes;
                }

                if (num == 0)
                {
                    return count - num2;
                }

                checked
                {
                    if (num4 < 0 || num < 0 || num4 + num > array.Length)
                    {
                        throw new ArgumentOutOfRangeException("byteCount");
                    }

                    if (index < 0 || num2 < 0 || index + num2 > buffer.Length)
                    {
                        throw new ArgumentOutOfRangeException("charsRemaining");
                    }
                }

                fixed (byte* ptr = array)
                {
                    fixed (char* ptr2 = buffer)
                    {
                        num3 = m_decoder.GetChars((byte*)checked(unchecked((uint)ptr) + unchecked((uint)num4)), num, (char*)checked(unchecked((uint)ptr2) + unchecked((uint)checked(unchecked((int)index) * (int)2))), num2);
                    }
                }

                num2 -= num3;
                index += num3;
            }

            return count - num2;
        }

        private int InternalReadOneChar()
        {
            int num = 0;
            int num2 = 0;
            long num3 = (num3 = 0L);
            if (m_stream.CanSeek)
            {
                num3 = m_stream.Position;
            }

            if (m_charBytes == null)
            {
                m_charBytes = new byte[128];
            }

            if (m_singleChar == null)
            {
                m_singleChar = new char[1];
            }

            while (num == 0)
            {
                num2 = ((!m_2BytesPerChar) ? 1 : 2);
                int num4 = m_stream.ReadByte();
                m_charBytes[0] = (byte)num4;
                if (num4 == -1)
                {
                    num2 = 0;
                }

                if (num2 == 2)
                {
                    num4 = m_stream.ReadByte();
                    m_charBytes[1] = (byte)num4;
                    if (num4 == -1)
                    {
                        num2 = 1;
                    }
                }

                if (num2 == 0)
                {
                    return -1;
                }

                try
                {
                    num = m_decoder.GetChars(m_charBytes, 0, num2, m_singleChar, 0);
                }
                catch
                {
                    if (m_stream.CanSeek)
                    {
                        m_stream.Seek(num3 - m_stream.Position, SeekOrigin.Current);
                    }

                    throw;
                }
            }

            if (num == 0)
            {
                return -1;
            }

            return m_singleChar[0];
        }



        public virtual char[] ReadChars(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }

            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            if (count == 0)
            {
                return new char[0];
            }

            char[] array = new char[count];
            int num = InternalReadChars(array, 0, count);
            if (num != count)
            {
                char[] array2 = new char[num];
                Buffer.BlockCopy(array, 0, array2, 0, 2 * num);
                array = array2;
            }

            return array;
        }


        public virtual int Read(byte[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer", ("ArgumentNull_Buffer"));
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }

            if (buffer.Length - index < count)
            {
                throw new ArgumentException(("Argument_InvalidOffLen"));
            }

            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            return m_stream.Read(buffer, index, count);
        }


        public virtual byte[] ReadBytes(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }

            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            if (count == 0)
            {
                return new byte[0];
            }

            byte[] array = new byte[count];
            int num = 0;
            do
            {
                int num2 = m_stream.Read(array, num, count);
                if (num2 == 0)
                {
                    break;
                }

                num += num2;
                count -= num2;
            }
            while (count > 0);
            if (num != array.Length)
            {
                byte[] array2 = new byte[num];
                Buffer.BlockCopy(array, 0, array2, 0, num);
                array = array2;
            }

            return array;
        }


        protected virtual void FillBuffer(int numBytes)
        {
            if (m_buffer != null && (numBytes < 0 || numBytes > m_buffer.Length))
            {
                throw new ArgumentOutOfRangeException("numBytes", ("ArgumentOutOfRange_PangyaBinaryReaderFillBuffer"));
            }

            int num = 0;
            int num2 = 0;
            if (m_stream == null)
            {
               throw new Exception("m_stream = null !");
            }

            if (numBytes == 1)
            {
                num2 = m_stream.ReadByte();
                if (num2 == -1)
                {
                    throw new Exception("leitura quebrada, valor estar -1");
                }

                m_buffer[0] = (byte)num2;
                return;
            }

            do
            {
                num2 = m_stream.Read(m_buffer, num, numBytes - num);
                if (num2 == 0)
                {
                    throw new Exception("leitura quebrada, valor estar -1");
                }

                num += num2;
            }
            while (num < numBytes);
        }


        protected internal int Read7BitEncodedInt()
        {
            int num = 0;
            int num2 = 0;
            byte b;
            do
            {
                if (num2 == 35)
                {
                    throw new FormatException(("Format_Bad7BitInt32"));
                }

                b = ReadByte();
                num |= (b & 0x7F) << num2;
                num2 += 7;
            }
            while ((b & 0x80u) != 0);
            return num;
        }

        public void Skip(int count)
        {
            Seek(count, 1);
        }

        public void Seek(long offset, int origin)
        {
            BaseStream.Seek(offset, (SeekOrigin)origin);
        }
        public void Seek(uint offset, int origin)
        {
            BaseStream.Seek(offset, (SeekOrigin)origin);
        }

        public void Seek(int offset, int origin)
        {
            BaseStream.Seek(offset, (SeekOrigin)origin);
        }
        public uint Size =>  (uint)BaseStream.Length;

        private string decodingGetString(byte[] bytes, int index, int count)
        {
            return new string(m_decoder.GetChars(bytes, index, count));
        }
        public byte[] GetRemainingData(int Count)
        {
            int previousOffset;
            previousOffset = (int)BaseStream.Position;
            var array = ReadBytes(Count);
            BaseStream.Position = previousOffset;
            return array;
        }
        public byte[] GetRemainingData()
        {
            int previousOffset;
            previousOffset = (int)BaseStream.Position;
            var array = ReadBytes((int)Size);
            BaseStream.Position = previousOffset;
            return array;
        }

        public bool ReadPStr(out string value, uint Count)
        {
            try
            {
                var data = new byte[Count];
                //ler os dados
                BaseStream.Read(data, 0, (int)Count);

                value = m_decoder.GetString(data);
            }
            catch
            {
                value = null;
                return false;
            }
            return true;
        }

        public bool ReadPStr(out string[] value, uint Length, uint Count)
        {
            try
            {
                value = new string[Count / Length];
                for (int i = 0; i < Count / Length; i++)
                {
                    value[i] = ReadPStr(Length);
                }
            }
            catch
            {
                value = null;
                return false;
            }
            return true;
        }
        public bool ReadPStr(out string value)
        {
            try
            {
                var size = ReadUInt16();
                value = m_decoder.GetString(ReadBytes(size));
            }
            catch
            {
                value = null;
                return false;
            }
            return true;
        }

        public string ReadPStr()
        {
            try
            {
                var size = ReadUInt16();

                return m_decoder.GetString(ReadBytes(size));
            }
            catch
            {
                return "";
            }
        }
        public string ReadPStr(uint Count)
        {
            try
            {
                var data = new byte[Count];
                //ler os dados
                BaseStream.Read(data, 0, (int)Count);

                return m_decoder.GetString(data).Replace("\0", "");
            }
            catch
            {
                return "";
            }
        }

        public short[] ReadShorts(uint Count)
        {
            try
            {
                var data = new short[Count];
                for (int i = 0; i < Count; i++)
                {
                    data[i] = ReadInt16();
                }
                return data;
            }
            catch
            {
                return new short[0];
            }
        }

        public uint GetPosition()
        {
            return (uint)BaseStream.Position;
        }

        public bool ReadDouble(out Double value)
        {
            try
            {
                value = ReadDouble();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadByte(out byte value)
        {
            try
            {
                value = ReadByte();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }
        public bool ReadInt16(out short value)
        {
            try
            {
                value = ReadInt16();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadBytes(out byte[] value, int size)
        {
            try
            {
#pragma warning disable CS0652 // Comparação com constante integral é inútil; a constante está fora do intervalo do tipo "int"
                if (uint.MaxValue < size)
                {
                    value = new byte[0];
                    return false;
                }
#pragma warning restore CS0652 // Comparação com constante integral é inútil; a constante está fora do intervalo do tipo "int"
                value = ReadBytes(size);
            }
            catch
            {
                value = new byte[0];
                return false;
            }
            return true;
        }

        public bool ReadBytes(out byte[] value)
        {
            try
            {
                int size = ReadInt16();

                if (ushort.MaxValue < size)
                {
                    value = new byte[0];
                    return false;
                }
                value = ReadBytes(size);
            }
            catch
            {
                value = new byte[0];
                return false;
            }
            return true;
        }
        public bool ReadUInt16(out ushort value)
        {
            try
            {
                value = ReadUInt16();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadUInt32(out uint value)
        {
            try
            {
                value = ReadUInt32();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadInt32(out int value)
        {
            try
            {
                value = ReadInt32();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadUInt64(out ulong value)
        {
            try
            {
                value = ReadUInt64();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadInt64(out long value)
        {
            try
            {
                value = ReadInt64();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public bool ReadSingle(out float value)
        {
            try
            {
                value = ReadSingle();
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public DateTime ReadDateTime()
        {
            try
            {
                var result = (_SYSTEMTIME)Read(new _SYSTEMTIME());
                return result.ConvertIFFToDateTime();
            }
            catch
            {
                var result = new _SYSTEMTIME();
                return result.ConvertIFFToDateTime();
            }
        }

        public IEnumerable<uint> Read(uint count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return ReadUInt32();
            }
        }
        //não testado
        public bool Read(out object value, int Count)
        {
            try
            {
                var obj = new object();
                byte[] recordData = ReadBytes(Count);

                IntPtr ptr = Marshal.AllocHGlobal(Count);

                Marshal.Copy(recordData, 0, ptr, Count);

                value = Marshal.PtrToStructure(ptr, obj.GetType());
                Marshal.FreeHGlobal(ptr);
            }
            catch
            {
                value = 0;
                return false;
            }
            return true;
        }

        public T ReadStruct<T>()
        {
            var byteLength = Marshal.SizeOf(typeof(T));
            var bytes = ReadBytes(byteLength);
            var pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var stt = (T)Marshal.PtrToStructure(
                pinned.AddrOfPinnedObject(),
                typeof(T));
            pinned.Free();
            return stt;
        }
        public T Read<T>() where T : struct
        {
            T local;
            int count = (typeof(T) == typeof(bool)) ? 1 : Marshal.SizeOf(typeof(T));
            GCHandle handle = GCHandle.Alloc(this.ReadBytes(count), GCHandleType.Pinned);
            try
            {
                local = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
            return local;
        }

        public object Read(object value)
        {
            var Count = Marshal.SizeOf(value);

            byte[] recordData = ReadBytes(Count);

            if (recordData.Length != Count)
            {
                throw new Exception(
                    $"The record length ({recordData.Length}) mismatches the length of the passed structure ({Count})");
            }

            IntPtr ptr = Marshal.AllocHGlobal(Count);

            Marshal.Copy(recordData, 0, ptr, Count);

            value = Marshal.PtrToStructure(ptr, value.GetType());
            Marshal.FreeHGlobal(ptr);
            return value;
        }

        public object Read(object value, object value_ori)
        {
            var Count = Marshal.SizeOf(value_ori);

            byte[] recordData = ReadBytes(Count);

            if (recordData.Length != Count)
            {
                throw new Exception(
                    $"The record length ({recordData.Length}) mismatches the length of the passed structure ({Count})");
            }

            IntPtr ptr = Marshal.AllocHGlobal(Count);

            Marshal.Copy(recordData, 0, ptr, Count);

            value = Marshal.PtrToStructure(ptr, value.GetType());
            Marshal.FreeHGlobal(ptr);
            return value;
        }

        public object Read(object value, int Count)
        {
            byte[] recordData = ReadBytes(Count);

            IntPtr ptr = Marshal.AllocHGlobal(Count);

            Marshal.Copy(recordData, 0, ptr, Count);

            value = Marshal.PtrToStructure(ptr, value.GetType());
            Marshal.FreeHGlobal(ptr);
            return value;
        }
        public Object ReadObject(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                Type type = property.PropertyType;

                TypeCode typeCode = Type.GetTypeCode(type);
                switch (typeCode)
                {
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Object:
                        {
                            if (type.Name == "Byte[]")
                            {
                                //  property.SetValue(obj, ReadBytes(obj));
                            }
                        }
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.Boolean:
                        {
                            property.SetValue(obj, ReadBoolean());
                        }
                        break;
                    case TypeCode.Char:
                        {
                            property.SetValue(obj, ReadChar());
                        }
                        break;
                    case TypeCode.SByte:
                        {
                            property.SetValue(obj, ReadSByte());
                        }
                        break;
                    case TypeCode.Byte:
                        {
                            property.SetValue(obj, ReadByte());
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            property.SetValue(obj, ReadInt16());
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            property.SetValue(obj, ReadUInt16());
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            property.SetValue(obj, ReadInt32());
                        }
                        break;
                    case TypeCode.UInt32:
                        property.SetValue(obj, ReadUInt32());
                        break;
                    case TypeCode.Int64:
                        {
                            property.SetValue(obj, ReadInt64());
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            property.SetValue(obj, ReadUInt64());
                        }
                        break;
                    case TypeCode.Single:
                        {
                            property.SetValue(obj, ReadSingle());
                        }
                        break;
                    case TypeCode.Double:
                        {
                            property.SetValue(obj, ReadDouble());
                        }
                        break;
                    case TypeCode.Decimal:
                        {
                            property.SetValue(obj, ReadDecimal());
                        }
                        break;
                    case TypeCode.DateTime:
                        {
                            property.SetValue(obj, ReadDateTime());
                        }
                        break;
                    case TypeCode.String:
                        {
                            property.SetValue(obj, ReadPStr());
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Object Type Name: " + typeCode);
                        }
                        break;
                }
            }
            return obj;
        }
        public void ReadObject(out object obj)
        {
            obj = new object();
            foreach (var property in obj.GetType().GetProperties())
            {
                Type type = property.PropertyType;

                TypeCode typeCode = Type.GetTypeCode(type);
                switch (typeCode)
                {
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Object:
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.Boolean:
                        {
                            property.SetValue(obj, ReadBoolean());
                        }
                        break;
                    case TypeCode.Char:
                        {
                            property.SetValue(obj, ReadChar());
                        }
                        break;
                    case TypeCode.SByte:
                        {
                            property.SetValue(obj, ReadSByte());
                        }
                        break;

                    case TypeCode.Byte:
                        {
                            property.SetValue(obj, ReadByte());
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            property.SetValue(obj, ReadInt16());
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            property.SetValue(obj, ReadUInt16());
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            property.SetValue(obj, ReadInt32());
                        }
                        break;
                    case TypeCode.UInt32:
                        property.SetValue(obj, ReadUInt32());
                        break;
                    case TypeCode.Int64:
                        {
                            property.SetValue(obj, ReadInt64());
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            property.SetValue(obj, ReadUInt64());
                        }
                        break;
                    case TypeCode.Single:
                        {
                            property.SetValue(obj, ReadSingle());
                        }
                        break;
                    case TypeCode.Double:
                        {
                            property.SetValue(obj, ReadDouble());
                        }
                        break;
                    case TypeCode.Decimal:
                        {
                            property.SetValue(obj, ReadDecimal());
                        }
                        break;
                    case TypeCode.DateTime:
                        {
                            property.SetValue(obj, ReadDateTime());
                        }
                        break;
                    case TypeCode.String:
                        {
                            property.SetValue(obj, ReadPStr());
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Object Type Name: " + typeCode);
                        }
                        break;
                }
            }
            // return obj;
        }

        public void Close()
        {
            Dispose(disposing: true);
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stream stream = m_stream;
                m_stream = null;
                if (stream != null && !m_leaveOpen)
                {
                    stream.Close();
                }
            }

            m_stream = null;
            m_buffer = null;
            m_decoder = null;
            m_charBytes = null;
            m_singleChar = null;
            m_charBuffer = null;
        }


        public void Dispose()
        {
            Dispose(disposing: true);
        }


        public virtual int PeekChar()
        {
            if (m_stream == null)
            {
                throw new Exception("Peek Char null !");
            }

            if (!m_stream.CanSeek)
            {
                return -1;
            }

            long position = m_stream.Position;
            int result = Read();
            m_stream.Position = position;
            return result;
        }

    }
}
