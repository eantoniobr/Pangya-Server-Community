using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.IFF.Lister
{
    public class IFFFile<T> where T : new()
    {
        /// <summary>
        /// List of IFF file entries
        /// </summary>
        public List<T> Entries { get; } = new List<T>();

        public IFFHeader Header = new IFFHeader();

        public IFFFile() { }

        /// <summary>
        /// Initializes a new IFFFile instance from a stream of IFF file data
        /// </summary>
        /// <param name="data">Stream containing IFF file data</param>
        public IFFFile(byte[] data)
        {
            Parse(data);
        }

        /// <summary>
        /// Parses the data from the IFF file and saves it into the Entries property
        /// 
        /// The bytes of a single entry are then marshalled into the structure provided by the
        /// generic type of the IFFFile instance
        /// </summary>
        /// <param name="stream">Stream containing IFF file data</param>
        /// <exception cref="InvalidCastException">Is thrown when the size of a single record mismatches the size of the given generic structure</exception>
        private void Parse(byte[] stream)
        {
            using (PangyaBinaryReader Reader = new PangyaBinaryReader(new MemoryStream(stream)))
            {
                if (new string(Reader.ReadChars(2)) == "PK")
                {
                    throw new NotSupportedException("The given IFF file is a ZIP file, please unpack it before attempting to parse it");
                }

                Reader.BaseStream.Seek(0, SeekOrigin.Begin);

            this.Header = (IFFHeader)Reader.Read(new IFFHeader());
            long recordLength = (Reader.GetSize() - 8L) / Header.Count;


            for (int i = 0; i < recordLength; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), System.IO.SeekOrigin.Begin);

                    byte[] recordData = Reader.ReadBytes((int)recordLength);

                    T data = new T();

                    int size = Marshal.SizeOf(data);
                    IntPtr ptr = Marshal.AllocHGlobal(size);

                    if (recordData.Length != size)
                    {
                        throw new InvalidCastException(
                            $"The record length ({recordData.Length}) mismatches the length of the passed structure ({size})");
                    }

                    Marshal.Copy(recordData, 0, ptr, size);

                    data = (T)Marshal.PtrToStructure(ptr, data.GetType());
                    Marshal.FreeHGlobal(ptr);

                    Entries.Add(data);
                }
            }
        }

        /// <summary>
        /// Save a IFFFile instance to a file
        /// </summary>
        /// <param name="filePath">File path to save the IFF file to</param>
        public void Save(string filePath)
        {
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write)))
            {
                Header.Count = (short)Entries.Count ;
                writer.WriteStruct(Header);
                foreach (var entry in Entries)
                {
                    writer.WriteStruct(entry);
                }
            }
        }
    }
}
