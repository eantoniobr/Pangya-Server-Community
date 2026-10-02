using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PangyaAPI.Network
{
    public partial class Packet : IDisposable
    {
        // --- MÉTODOS DE LEITURA (Delegados ao Reader) ---
        public sbyte ReadSByte()
        {
            return Reader.ReadSByte();
        }

        public sbyte[] ReadSBytes(int count)
        {
            var value = new sbyte[count];
            for (int i = 0; i < count; i++)
                value[i] = Reader.ReadSByte();

            return value;
        }

        public byte ReadByte()
        {
            return Reader.ReadByte();
        }
        public bool ReadUInt32(out uint value)
        {
            return Reader.ReadUInt32(out value);
        }

        public uint ReadUInt32()
        {
            return Reader.ReadUInt32(); 
        }

        public ushort ReadUInt16()
        {
            return Reader.ReadUInt16();

        }

        public uint[] ReadUInt32(int count)
        {
            uint[] values = new uint[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = ReadUInt32();
            }
            return values;
        }

        public int[] ReadInt32(int count)
        {
            int[] values = new int[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = ReadInt32();
            }
            return values;
        }

        public ushort[] ReadUInt16(int count)
        {
            ushort[] values = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = ReadUInt16();
            }
            return values;
        }


        public short[] ReadInt16(int count)
        {
            short[] values = new short[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = ReadInt16();
            }
            return values;
        }

        public short ReadInt16()
        {
            return Reader.ReadInt16();
        }

        public int ReadInt32()
        {
            return Reader.ReadInt32();

        }

        public long ReadInt64()
        {
            return Reader.ReadInt64();

        }

        public ulong ReadUInt64()
        {
            return Reader.ReadUInt64(); 
        }
        
        public float ReadFloat()
        {
            return Reader.ReadSingle();
        }

        public float ReadSingle()
        {
            return Reader.ReadSingle();
        }

        public double ReadDouble()
        {
            return Reader.ReadDouble();
        }

        public string ReadPStr()
        {
            try
            {
                return Reader.ReadPStr();
            }
            catch
            {
                throw new Exception("Fail to read string from packet");
            }
        }

        public bool ReadPStr(out string value)
        {

            try
            {
                return Reader.ReadPStr(out value);
            }
            catch
            {
                value = "";
                return false;
            } 
        }


        public string ReadPStr(int _length)
        {
            return Reader.ReadPStr((uint)_length);
        }

        public byte[] ReadBytes(int _size)
        {
            return Reader.ReadBytes(_size);

        }
         
        public byte[] ReadBytes()
        {

            return Reader.ReadBytes();
        }

        public string ReadString()
        {
            return ReadPStr();
        }

        public string ReadString(int len)
        {
            return Reader.ReadPStr((uint)len);
        }
    }
}
