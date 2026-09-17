using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace PangyaAPI.Utilities.BinaryModels
{
    public class PangyaBinaryWriter
    {
       
        public static readonly PangyaBinaryWriter Null = new PangyaBinaryWriter();

       
        protected Stream OutStream;

        private byte[] _buffer;

        private Encoding _encoding;

        private Encoder _encoder;

        private bool _leaveOpen;

        private char[] _tmpOneCharBuffer;

        private byte[] _largeByteBuffer;

        private int _maxChars;

        private const int LargeByteBufferSize = 256;

       
        public virtual Stream BaseStream
        {
           
            get
            {
                Flush();
                return OutStream;
            }
        }
        public uint Size
        {
            get { return (uint)BaseStream.Length; }
        }
        public byte[] GetBytes => CreateBytes();

        public PangyaBinaryWriter()
        {
            OutStream = Stream.Null;
            _buffer = new byte[16];
            _encoding = Encoding.UTF8;
            _encoder = _encoding.GetEncoder();
        }

        public PangyaBinaryWriter(Encoding enc)
        {
            OutStream = Stream.Null;
            _buffer = new byte[16];
            _encoding = enc;
            _encoder = _encoding.GetEncoder();
        }
        /// <summary>
        /// create packet + id
        /// </summary>
        /// <param name="id"></param>
        public PangyaBinaryWriter(short id)
        {
            OutStream = Stream.Null;
            _buffer = new byte[16];
            _encoding = Encoding.UTF8;
            _encoder = _encoding.GetEncoder();

            Write(id);
        }

        /// <summary>
        /// create packet + id
        /// </summary>
        /// <param name="id"></param>
        public PangyaBinaryWriter(short id, Encoding enc)
        {
            OutStream = Stream.Null;
            _buffer = new byte[16];
            _encoding =enc;
            _encoder = _encoding.GetEncoder();

            Write(id);
        }


        public PangyaBinaryWriter(Stream output)
            : this(output, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true), leaveOpen: false)
        {
        }

       
        public PangyaBinaryWriter(Stream output, Encoding encoding)
            : this(output, encoding, leaveOpen: false)
        {
        }

       
        public PangyaBinaryWriter(Stream output, Encoding encoding, bool leaveOpen)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            if (!output.CanWrite)
            {
                throw new ArgumentException(("Argument_StreamNotWritable"));
            }

            OutStream = output;
            _buffer = new byte[16];
            _encoding = encoding;
            _encoder = _encoding.GetEncoder();
            _leaveOpen = leaveOpen;
        }

      
        public virtual long Seek(int offset, SeekOrigin origin)
        {
            return OutStream.Seek(offset, origin);
        }

       
        public virtual void Write(bool value)
        {
            _buffer[0] = (byte)(value ? 1u : 0u);
            OutStream.Write(_buffer, 0, 1);
        }

       
        public virtual void Write(byte value)
        {
            OutStream.WriteByte(value);
        }

      
        public virtual void Write(sbyte value)
        {
            OutStream.WriteByte((byte)value);
        }

       
        public virtual void Write(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            OutStream.Write(buffer, 0, buffer.Length);
        }

       
        public virtual void Write(byte[] buffer, int index, int count)
        {
            OutStream.Write(buffer, index, count);
        }

        public unsafe virtual void Write(char ch)
        {
            if (char.IsSurrogate(ch))
            {
                throw new ArgumentException("Arg_SurrogatesNotAllowedAsSingleChar");
            }

            int num = 0;
            fixed (byte* bytes = _buffer)
            {
                num = _encoder.GetBytes(&ch, 1, bytes, _buffer.Length, flush: true);
            }

            OutStream.Write(_buffer, 0, num);
        }

       
        public virtual void Write(char[] chars)
        {
            if (chars == null)
            {
                throw new ArgumentNullException("chars");
            }

            byte[] bytes = _encoding.GetBytes(chars, 0, chars.Length);
            OutStream.Write(bytes, 0, bytes.Length);
        }

       
        public virtual void Write(char[] chars, int index, int count)
        {
            byte[] bytes = _encoding.GetBytes(chars, index, count);
            OutStream.Write(bytes, 0, bytes.Length);
        }


       
        public unsafe virtual void Write(double value)
        {
            ulong num = *(ulong*)(&value);
            _buffer[0] = (byte)num;
            _buffer[1] = (byte)(num >> 8);
            _buffer[2] = (byte)(num >> 16);
            _buffer[3] = (byte)(num >> 24);
            _buffer[4] = (byte)(num >> 32);
            _buffer[5] = (byte)(num >> 40);
            _buffer[6] = (byte)(num >> 48);
            _buffer[7] = (byte)(num >> 56);
            OutStream.Write(_buffer, 0, 8);
        }

       
        public virtual void Write(decimal value)
        {
            //Load four 32 bit integers from the Decimal.GetBits function
            Int32[] bits = decimal.GetBits(value);
            //Create a temporary list to hold the bytes
            List<byte> bytes = new List<byte>();
            //iterate each 32 bit integer
            foreach (Int32 i in bits)
            {
                //add the bytes of the current 32bit integer
                //to the bytes list
                bytes.AddRange(BitConverter.GetBytes(i));
            }

            _buffer = bytes.ToArray();
            OutStream.Write(_buffer, 0, 16);
        }

      
        public virtual void Write(short value)
        {
            _buffer[0] = (byte)value;
            _buffer[1] = (byte)(value >> 8);
            OutStream.Write(_buffer, 0, 2);
        }


       
        public virtual void Write(ushort value)
        {
            _buffer[0] = (byte)value;
            _buffer[1] = (byte)(value >> 8);
            OutStream.Write(_buffer, 0, 2);
        }

       
        public virtual void Write(int value)
        {
            _buffer[0] = (byte)value;
            _buffer[1] = (byte)(value >> 8);
            _buffer[2] = (byte)(value >> 16);
            _buffer[3] = (byte)(value >> 24);
            OutStream.Write(_buffer, 0, 4);
        }


       
        public virtual void Write(uint value)
        {
            _buffer[0] = (byte)value;
            _buffer[1] = (byte)(value >> 8);
            _buffer[2] = (byte)(value >> 16);
            _buffer[3] = (byte)(value >> 24);
            OutStream.Write(_buffer, 0, 4);
        }

       
        public virtual void Write(long value)
        {
            _buffer[0] = (byte)value;
            _buffer[1] = (byte)(value >> 8);
            _buffer[2] = (byte)(value >> 16);
            _buffer[3] = (byte)(value >> 24);
            _buffer[4] = (byte)(value >> 32);
            _buffer[5] = (byte)(value >> 40);
            _buffer[6] = (byte)(value >> 48);
            _buffer[7] = (byte)(value >> 56);
            OutStream.Write(_buffer, 0, 8);
        }
       
        public virtual void Write(ulong value)
        {
            _buffer[0] = (byte)value;
            _buffer[1] = (byte)(value >> 8);
            _buffer[2] = (byte)(value >> 16);
            _buffer[3] = (byte)(value >> 24);
            _buffer[4] = (byte)(value >> 32);
            _buffer[5] = (byte)(value >> 40);
            _buffer[6] = (byte)(value >> 48);
            _buffer[7] = (byte)(value >> 56);
            OutStream.Write(_buffer, 0, 8);
        }


       
        public unsafe virtual void Write(float value)
        {
            uint num = *(uint*)(&value);
            _buffer[0] = (byte)num;
            _buffer[1] = (byte)(num >> 8);
            _buffer[2] = (byte)(num >> 16);
            _buffer[3] = (byte)(num >> 24);
            OutStream.Write(_buffer, 0, 4);
        }


       
        public unsafe virtual void Write(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            int byteCount = _encoding.GetByteCount(value);
            Write7BitEncodedInt(byteCount);
            if (_largeByteBuffer == null)
            {
                _largeByteBuffer = new byte[256];
                _maxChars = _largeByteBuffer.Length / _encoding.GetMaxByteCount(1);
            }

            if (byteCount <= _largeByteBuffer.Length)
            {
                _encoding.GetBytes(value, 0, value.Length, _largeByteBuffer, 0);
                OutStream.Write(_largeByteBuffer, 0, byteCount);
                return;
            }

            int num = 0;
            int num2 = value.Length;
            while (num2 > 0)
            {
                int num3 = ((num2 > _maxChars) ? _maxChars : num2);
                if (num < 0 || num3 < 0 || checked(num + num3) > value.Length)
                {
                    throw new ArgumentOutOfRangeException("charCount");
                }

                int bytes2;
                fixed (char* ptr = value)
                {
                    fixed (byte* bytes = _largeByteBuffer)
                    {
                        bytes2 = _encoder.GetBytes((char*)checked(unchecked((uint)ptr) + unchecked((uint)checked(unchecked(num) * (int)2))), num3, bytes, _largeByteBuffer.Length, num3 == num2);
                    }
                }

                OutStream.Write(_largeByteBuffer, 0, bytes2);
                num += num3;
                num2 -= num3;
            }
        }

       
        protected void Write7BitEncodedInt(int value)
        {
            uint num;
            for (num = (uint)value; num >= 128; num >>= 7)
            {
                Write((byte)(num | 0x80u));
            }

            Write((byte)num);
        }
        public bool WriteStr(string message, int length)
        {

            try
            {
                if (message == null)
                {
                    message = string.Empty;
                }

                var ret = new byte[length];
                _encoding.GetBytes(message).Take(length).ToArray().CopyTo(ret, 0);

                Write(ret);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteStr(string message)
        {
            try
            {
                WriteStr(message, message.Length);

            }
            catch
            {
                return false;
            }
            return true;

        }

        public bool WritePStr(string data)
        {
            if (data == null) data = "";
            try
            {
                var encoded = _encoding.GetBytes(data);
                var length = encoded.Length;
                if (length >= ushort.MaxValue)
                {
                    return false;
                }
                Write((short)length);
                Write(encoded);
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool WriteBytes(byte[] message, int length)
        {
            try
            {
                if (message == null)
                    message = new byte[length];

                var result = new byte[length];

                Buffer.BlockCopy(message, 0, result, 0, length);

                Write(result);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Write(byte[] message, int length)
        {
            try
            {
                if (message == null)
                    message = new byte[length];

                var result = new byte[length];

                Buffer.BlockCopy(message, 0, result, 0, message.Length);

                Write(result);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool WriteZero(int Lenght)
        {
            try
            {
                Write(new byte[Lenght]);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool WriteUInt16(ushort value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool WriteUInt16(int value)
        {
            try
            {
                Write((ushort)value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteUInt16(uint value)
        {
            try
            {
                Write((ushort)value);
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool WriteByte(byte value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteByte(int value)
        {
            try
            {
                Write(Convert.ToByte(value));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteSingle(float value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteUInt32(uint value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteInt32(int value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteUInt64(ulong value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteInt64(long value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteDouble(double value)
        {
            try
            {
                Write(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteStruct(object value)
        {
            try
            {
                int size = Marshal.SizeOf(value);
                byte[] arr = new byte[size];

                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(value, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                Marshal.FreeHGlobal(ptr);
                Write(arr);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteStruct(object value, object value_ori)
        {
            try
            {
                int size = Marshal.SizeOf(value_ori);
                byte[] arr = new byte[size];

                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(value, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                Marshal.FreeHGlobal(ptr);
                Write(arr);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool WriteHexArray(string _value)
        {
            try
            {
                _value = _value.Replace(" ", "");
                int _size = _value.Length / 2;
                byte[] _result = new byte[_size];
                for (int ii = 0; ii < _size; ii++)
                    WriteByte(Convert.ToByte(_value.Substring(ii * 2, 2), 16));
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Write Pangya Time
        /// </summary>
        /// <returns></returns>
        public bool WriteTime(DateTime? date)
        {
            try
            {
                if (date.HasValue == false || date?.Ticks == 0)
                {
                    Write(new byte[16]);
                    return true;
                }
                WriteUInt16((ushort)date?.Year);
                WriteUInt16((ushort)date?.Month);
                WriteUInt16(Convert.ToUInt16(date?.DayOfWeek));
                WriteUInt16((ushort)date?.Day);
                WriteUInt16((ushort)date?.Hour);
                WriteUInt16((ushort)date?.Minute);
                WriteUInt16((ushort)date?.Second);
                WriteUInt16((ushort)date?.Millisecond);
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
                WriteUInt16((ushort)date.Year);
                WriteUInt16((ushort)date.Month);
                WriteUInt16((ushort)date.DayOfWeek);
                WriteUInt16((ushort)date.Day);
                WriteUInt16((ushort)date.Hour);
                WriteUInt16((ushort)date.Minute);
                WriteUInt16((ushort)date.Second);
                WriteUInt16((ushort)date.Millisecond);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteObject(object _obj)
        {
            foreach (var property in _obj.GetType().GetProperties())
            {
                Type type = property.PropertyType;

                TypeCode typeCode = Type.GetTypeCode(type);
                var obj = property.GetValue(_obj);
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
                            Write((bool)obj);
                        }
                        break;
                    case TypeCode.Char:
                        {
                            Write((char)obj);
                        }
                        break;
                    case TypeCode.SByte:
                        {
                            Write((sbyte)obj);
                        }
                        break;

                    case TypeCode.Byte:
                        {
                            Write((byte)obj);
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            Write((short)obj);
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            WriteUInt16((UInt16)obj);
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            WriteInt32((int)obj);
                        }
                        break;
                    case TypeCode.UInt32:
                        WriteUInt32((UInt32)obj);
                        break;
                    case TypeCode.Int64:
                        {
                            WriteInt64((long)obj);
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            WriteUInt64((ulong)obj);
                        }
                        break;
                    case TypeCode.Single:
                        {
                            WriteSingle((Single)obj);
                        }
                        break;
                    case TypeCode.Double:
                        {
                            WriteDouble((Double)obj);
                        }
                        break;
                    case TypeCode.Decimal:
                        {
                            Write((decimal)obj);
                        }
                        break;
                    case TypeCode.DateTime:
                        {
                            WriteTime((DateTime)obj);
                        }
                        break;
                    case TypeCode.String:
                        {
                            WritePStr((string)obj);
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
        public void SaveWrite(string name)
        {
            File.WriteAllBytes(name, GetBytes);
        }
        public virtual void Close()
        {
            Dispose(disposing: true);
            this.OutStream = new MemoryStream();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_leaveOpen)
                {
                    OutStream.Flush();
                }
                else
                {
                    OutStream.Close();
                }
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
        }


        public virtual void Flush()
        {
            OutStream.Flush();
        }

        /// <summary>
        /// GetBytes Written in Binary
        /// </summary>
        /// <returns>Array Of Bytes</returns>
        byte[] CreateBytes()
        {
            if (OutStream is MemoryStream stream)
                return stream.ToArray();


            using (var memoryStream = new MemoryStream())
            {
                memoryStream.GetBuffer();
                OutStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
