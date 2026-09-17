using PangyaAPI.IFF.Definitions;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace PangyaAPI.DAT
{
    public class Language : List<DATFile>
    {
        public Encoding FileEncoding;
        public LanguageRegion Region { get; set; }

        /// <summary>
        /// ler os arquivos .dat
        /// </summary>
        private void ReadDat(Stream data)
        {
            int id = 0;
            using (PangyaBinaryReader reader = new PangyaBinaryReader(data, FileEncoding))
            {
                List<char> stringChars = new List<char>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    if (reader.PeekChar() != 0x00)
                    {
                        var ch = (reader.ReadChar());
                        stringChars.Add(ch);
                    }
                     if (reader.PeekChar() == 0x00)
                    {

                        var ch = (reader.ReadChar());
                        stringChars.Add(ch);
                    }
                   else
                    {
                        char[] chars = stringChars.ToArray();
                        byte[] bytes = FileEncoding.GetBytes(chars);
                        var sString = FileEncoding.GetString(bytes);
                        Add(new DATFile(id, sString));

                        reader.BaseStream.Seek(1L, SeekOrigin.Current);
                        id++;
                        stringChars.Clear();
                    }
                }
            }
        }

       
        /// <summary>
        /// Returns the encoding used by the DATFile instance
        /// </summary>
        public Encoding GetEncoding()
        {
            return FileEncoding;
        }

        /// <summary>
        /// Método que realiza setagens e carregamento das informações do arquivo .dat
        /// </summary>
        /// <param name="filePath"> local onde está o arquivo </param>
        public void LoadFile(string filePath, IFF_REGION region)
        {
            Tools.GetEncoding(region, ref this.FileEncoding);
            using (StreamReader stream = new StreamReader(filePath, FileEncoding))
            {
                ReadDat(stream.BaseStream);
            }

        }

        /// <summary>
        /// Método que realiza setagens e carregamento das informações do arquivo .dat
        /// </summary>
        /// <param name="filePath"> local onde está o arquivo </param>
        public void LoadFile(string filePath)
        {
            Tools.GetEncoding(filePath, ref this.FileEncoding);
            ReadDat(File.Open(filePath, FileMode.Open, FileAccess.Read));
        }

        public void Save(string filePath)
        {
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write), FileEncoding))
            {
                foreach (var entry in this)
                {
                    writer.Write(entry.Line.ToCharArray());
                    writer.Write((byte)0);
                }
            }
        }
    }
}
